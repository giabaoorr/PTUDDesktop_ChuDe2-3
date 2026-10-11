using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BaitapChuDe2.Bai2_QuanLySinhVien
{
    public delegate int SoSanh(object a, object b);

    public class QuanLySinhVien
    {
        public List<SinhVien> DanhSach;

        public SinhVien this[int index]
        {
            get
            {
                if (index >= 0 && index < DanhSach.Count)
                    return DanhSach[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < DanhSach.Count)
                    DanhSach[index] = value;
            }
        }

        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }

        public bool Them(SinhVien sv)
        {
            if (sv == null) return false;
            if (DanhSach.Any(s => s.MaSo.Equals(sv.MaSo, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            DanhSach.Add(sv);
            return true;
        }

        public SinhVien TimKiem(object obj, SoSanh ss)
        {
            if (obj == null || ss == null) return null;
            return DanhSach.FirstOrDefault(sv => ss(sv, obj) == 0);
        }

        public List<SinhVien> TimKiemTatCa(object obj, SoSanh ss)
        {
            var ketQua = new List<SinhVien>();
            if (obj == null || ss == null) return ketQua;

            foreach (var sv in DanhSach)
            {
                if (ss(sv, obj) == 0)
                {
                    ketQua.Add(sv);
                }
            }
            return ketQua;
        }

        public bool Sua(SinhVien svMoi, object obj, SoSanh ss)
        {
            if (svMoi == null || obj == null || ss == null) return false;
            for (int i = 0; i < DanhSach.Count; i++)
            {
                if (ss(DanhSach[i], obj) == 0)
                {
                    DanhSach[i] = svMoi;
                    return true;
                }
            }
            return false;
        }

        public bool Xoa(object obj, SoSanh ss)
        {
            if (obj == null || ss == null) return false;
            for (int i = 0; i < DanhSach.Count; i++)
            {
                if (ss(DanhSach[i], obj) == 0)
                {
                    DanhSach.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void SapXep(SoSanh ss)
        {
            if (ss == null) return;
            DanhSach.Sort((a, b) => ss(a, b));
        }

        public void DocTuFile(string fileName)
        {
            DanhSach.Clear();
            if (!File.Exists(fileName)) return;

            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('*');
                if (parts.Length >= 8)
                {
                    var sv = new SinhVien
                    {
                        MaSo = parts[0].Trim(),
                        HoTen = parts[1].Trim(),
                        NgaySinh = DateTime.TryParseExact(parts[2].Trim(), new[] { "dd/MM/yyyy", "d/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out var ns) ? ns : DateTime.Now,
                        DiaChi = parts[3].Trim(),
                        Lop = parts[4].Trim(),
                        Phai = parts[5].Trim() == "1" || parts[5].Trim().Equals("Nam", StringComparison.OrdinalIgnoreCase),
                        ChuyenNganh = parts[6].Split(',').Select(cn => cn.Trim()).Where(cn => !string.IsNullOrEmpty(cn)).ToList(),
                        Hinh = parts[7].Trim()
                    };
                    DanhSach.Add(sv);
                }
            }
        }

        public void GhiRaFile(string fileName)
        {
            var lines = new List<string>();
            foreach (var sv in DanhSach)
            {
                string cn = string.Join(",", sv.ChuyenNganh);
                string phai = sv.Phai ? "1" : "0";
                string line = $"{sv.MaSo}*{sv.HoTen}*{sv.NgaySinh:dd/MM/yyyy}*{sv.DiaChi}*{sv.Lop}*{phai}*{cn}*{sv.Hinh}";
                lines.Add(line);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        public static int SoSanhTheoMa(object a, object b)
        {
            string maA = a is SinhVien sv ? sv.MaSo : a.ToString();
            string maB = b is SinhVien svB ? svB.MaSo : b.ToString();
            return string.Compare(maA, maB, StringComparison.OrdinalIgnoreCase);
        }

        public static int SoSanhTheoHoTen(object a, object b)
        {
            string tenA = a is SinhVien sv ? sv.HoTen : a.ToString();
            string tenB = b is SinhVien svB ? svB.HoTen : b.ToString();
            return string.Compare(tenA, tenB, StringComparison.OrdinalIgnoreCase);
        }

        public static int SoSanhTheoNgaySinh(object a, object b)
        {
            DateTime nsA = a is SinhVien sv ? sv.NgaySinh : (DateTime.TryParse(a.ToString(), out var dtA) ? dtA : DateTime.MinValue);
            DateTime nsB = b is SinhVien svB ? svB.NgaySinh : (DateTime.TryParse(b.ToString(), out var dtB) ? dtB : DateTime.MinValue);
            return DateTime.Compare(nsA, nsB);
        }
    }
}
