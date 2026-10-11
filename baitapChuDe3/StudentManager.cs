using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace baitapChuDe3
{
    /// <summary>
    /// Lớp quản lý danh sách sinh viên: thêm, sửa, xóa, tìm kiếm, lưu trữ
    /// </summary>
    public class StudentManager
    {
        public List<Student> Students { get; private set; }
        public IStudentStorage Storage { get; set; }
        public string FilePath { get; set; }

        public StudentManager(IStudentStorage storage, string filePath)
        {
            Storage = storage ?? throw new ArgumentNullException(nameof(storage));
            FilePath = filePath;
            Students = new List<Student>();
            Load();
        }

        /// <summary>
        /// Tải danh sách sinh viên từ tập tin hiện tại
        /// </summary>
        public void Load()
        {
            if (File.Exists(FilePath))
            {
                Students = Storage.Read(FilePath) ?? new List<Student>();
            }
            else
            {
                Students = new List<Student>();
            }
        }

        /// <summary>
        /// Lưu danh sách sinh viên xuống tập tin
        /// </summary>
        public void Save()
        {
            Storage.Write(FilePath, Students);
        }

        /// <summary>
        /// Thêm sinh viên mới (kiểm tra không trùng MSSV)
        /// </summary>
        public void Add(Student sv)
        {
            if (sv == null) throw new ArgumentNullException(nameof(sv));

            if (Students.Any(s => s.MSSV.Equals(sv.MSSV, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Sinh viên có MSSV {sv.MSSV} đã tồn tại trong danh sách!");
            }

            Students.Add(sv);
            Save();
        }

        /// <summary>
        /// Cập nhật thông tin sinh viên theo MSSV
        /// </summary>
        public void Update(Student sv)
        {
            if (sv == null) throw new ArgumentNullException(nameof(sv));

            var existing = Students.FirstOrDefault(s => s.MSSV.Equals(sv.MSSV, StringComparison.OrdinalIgnoreCase));
            if (existing == null)
            {
                throw new InvalidOperationException($"Không tìm thấy sinh viên có MSSV {sv.MSSV} để cập nhật!");
            }

            existing.HoVaTenLot = sv.HoVaTenLot;
            existing.Ten = sv.Ten;
            existing.GioiTinh = sv.GioiTinh;
            existing.NgaySinh = sv.NgaySinh;
            existing.Lop = sv.Lop;
            existing.SoCMND = sv.SoCMND;
            existing.SoDienThoai = sv.SoDienThoai;
            existing.DiaChiLienLac = sv.DiaChiLienLac;
            existing.MonHocDangKy = sv.MonHocDangKy ?? new List<string>();

            Save();
        }

        /// <summary>
        /// Xóa 1 sinh viên theo MSSV
        /// </summary>
        public bool Delete(string mssv)
        {
            var sv = Students.FirstOrDefault(s => s.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                Students.Remove(sv);
                Save();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Xóa nhiều sinh viên theo danh sách MSSV
        /// </summary>
        public int DeleteMany(IEnumerable<string> mssvList)
        {
            if (mssvList == null) return 0;
            var set = new HashSet<string>(mssvList, StringComparer.OrdinalIgnoreCase);
            int removedCount = Students.RemoveAll(s => set.Contains(s.MSSV));
            if (removedCount > 0)
            {
                Save();
            }
            return removedCount;
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo một hoặc nhiều điều kiện kết hợp (MSSV, Tên, Lớp)
        /// </summary>
        public List<Student> Search(string mssv, string ten, string lop)
        {
            IEnumerable<Student> query = Students;

            if (!string.IsNullOrWhiteSpace(mssv))
            {
                string cleanMssv = mssv.Trim();
                query = query.Where(s => s.MSSV != null && s.MSSV.IndexOf(cleanMssv, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.IsNullOrWhiteSpace(ten))
            {
                string cleanTen = ten.Trim();
                // Tìm kiếm theo tên hoặc cả họ tên
                query = query.Where(s =>
                    (s.Ten != null && s.Ten.IndexOf(cleanTen, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (s.HoVaTenDayDu != null && s.HoVaTenDayDu.IndexOf(cleanTen, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }

            if (!string.IsNullOrWhiteSpace(lop))
            {
                string cleanLop = lop.Trim();
                query = query.Where(s => s.Lop != null && s.Lop.IndexOf(cleanLop, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            return query.ToList();
        }

        /// <summary>
        /// Suy ra năm nhập học từ tên lớp
        /// Ví dụ: 
        /// - CTK44: Khóa 44 -> 1976 + 44 = 2020 -> năm 2020
        /// - 20DTHA1 hoặc K20 -> năm 2020
        /// </summary>
        public static int? GetAdmissionYearFromClass(string lop)
        {
            if (string.IsNullOrWhiteSpace(lop)) return null;

            // Kiểm tra dạng CTKxx hoặc Kxx (ví dụ CTK42, CTK43, CTK44, CTK45...)
            var matchK = Regex.Match(lop, @"(?:CTK|K)(\d{2})", RegexOptions.IgnoreCase);
            if (matchK.Success && int.TryParse(matchK.Groups[1].Value, out int khoa))
            {
                // Quy chuẩn khóa trường Đại học Đà Lạt: Khóa 44 nhập học năm 2020 (1976 + 44)
                if (khoa >= 30 && khoa <= 70)
                {
                    return 1976 + khoa;
                }
                // Nếu K20, K21, K22 (năm 20xx)
                if (khoa >= 10 && khoa <= 29)
                {
                    return 2000 + khoa;
                }
            }

            // Kiểm tra dạng 2 số năm ở đầu lớp, ví dụ 20DTHA1, 21DTH01
            var matchYear = Regex.Match(lop, @"^(\d{2})");
            if (matchYear.Success && int.TryParse(matchYear.Groups[1].Value, out int yearPrefix))
            {
                return 2000 + yearPrefix;
            }

            return null;
        }

        /// <summary>
        /// Kiểm tra quy tắc định dạng MSSV:
        /// 1. Đúng 7 chữ số: AABBCCC
        /// 2. AA là 2 số cuối năm nhập học suy ra từ Lớp
        /// 3. BB phải là 10
        /// 4. CCC là 3 chữ số bất kỳ
        /// </summary>
        public static bool ValidateMSSV(string mssv, string lop, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(mssv))
            {
                errorMessage = "MSSV không được để trống!";
                return false;
            }

            mssv = mssv.Trim();

            if (mssv.Length != 7 || !Regex.IsMatch(mssv, @"^\d{7}$"))
            {
                errorMessage = "MSSV phải gồm đúng 7 chữ số (dạng AABBCCC)!";
                return false;
            }

            string aa = mssv.Substring(0, 2);
            string bb = mssv.Substring(2, 2);
            // string ccc = mssv.Substring(4, 3);

            // Kiểm tra BB = 10
            if (bb != "10")
            {
                errorMessage = $"Hai chữ số giữa của MSSV (BB) phải là 10! (Hiện tại: {bb})";
                return false;
            }

            // Kiểm tra AA theo năm nhập học từ lớp
            int? admissionYear = GetAdmissionYearFromClass(lop);
            if (admissionYear.HasValue)
            {
                string expectedAA = (admissionYear.Value % 100).ToString("D2");
                if (aa != expectedAA)
                {
                    errorMessage = $"Lớp {lop} có năm nhập học là {admissionYear.Value}. Hai chữ số đầu của MSSV (AA) phải là '{expectedAA}', nhưng bạn đang nhập '{aa}'!";
                    return false;
                }
            }

            return true;
        }
    }
}
