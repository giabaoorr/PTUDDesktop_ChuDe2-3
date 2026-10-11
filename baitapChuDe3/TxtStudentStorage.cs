using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace baitapChuDe3
{
    /// <summary>
    /// Lớp đọc/ghi danh sách sinh viên từ tập tin văn bản thuần (.txt)
    /// Cấu trúc mỗi dòng: MSSV|HoVaTenLot|Ten|GioiTinh|NgaySinh|Lop|SoCMND|SoDienThoai|DiaChiLienLac|Mon1,Mon2,...
    /// </summary>
    public class TxtStudentStorage : IStudentStorage
    {
        private const char FieldDelimiter = '|';
        private const char SubjectDelimiter = ',';

        public List<Student> Read(string filePath)
        {
            var list = new List<Student>();
            if (!File.Exists(filePath))
            {
                return list;
            }

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                string[] parts = line.Split(FieldDelimiter);
                if (parts.Length >= 9)
                {
                    try
                    {
                        var sv = new Student
                        {
                            MSSV = parts[0].Trim(),
                            HoVaTenLot = parts[1].Trim(),
                            Ten = parts[2].Trim(),
                            GioiTinh = parts[3].Trim().Equals("Nam", StringComparison.OrdinalIgnoreCase) ||
                                       parts[3].Trim().Equals("True", StringComparison.OrdinalIgnoreCase) ||
                                       parts[3].Trim() == "1",
                            NgaySinh = DateTime.TryParseExact(parts[4].Trim(),
                                           new[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" },
                                           CultureInfo.InvariantCulture, DateTimeStyles.None, out var ns)
                                       ? ns : DateTime.Now,
                            Lop = parts[5].Trim(),
                            SoCMND = parts[6].Trim(),
                            SoDienThoai = parts[7].Trim(),
                            DiaChiLienLac = parts[8].Trim()
                        };

                        if (parts.Length > 9 && !string.IsNullOrWhiteSpace(parts[9]))
                        {
                            sv.MonHocDangKy = parts[9].Split(SubjectDelimiter)
                                                      .Select(s => s.Trim())
                                                      .Where(s => !string.IsNullOrEmpty(s))
                                                      .ToList();
                        }

                        list.Add(sv);
                    }
                    catch
                    {
                        // Bỏ qua dòng bị lỗi định dạng
                    }
                }
            }

            return list;
        }

        public void Write(string filePath, List<Student> students)
        {
            var lines = new List<string>();
            foreach (var sv in students)
            {
                string monHoc = sv.MonHocDangKy != null && sv.MonHocDangKy.Count > 0
                    ? string.Join(SubjectDelimiter.ToString(), sv.MonHocDangKy)
                    : string.Empty;

                string line = string.Join(FieldDelimiter.ToString(),
                    sv.MSSV,
                    sv.HoVaTenLot,
                    sv.Ten,
                    sv.GioiTinh ? "Nam" : "Nữ",
                    sv.NgaySinh.ToString("dd/MM/yyyy"),
                    sv.Lop,
                    sv.SoCMND,
                    sv.SoDienThoai,
                    sv.DiaChiLienLac,
                    monHoc
                );
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }
    }
}
