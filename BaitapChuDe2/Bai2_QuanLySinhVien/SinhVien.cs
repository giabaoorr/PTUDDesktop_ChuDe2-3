using System;
using System.Collections.Generic;

namespace BaitapChuDe2.Bai2_QuanLySinhVien
{
    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Lop { get; set; }
        public bool Phai { get; set; } // true: Nam, false: Nữ
        public List<string> ChuyenNganh { get; set; }
        public string Hinh { get; set; }

        public SinhVien()
        {
            ChuyenNganh = new List<string>();
        }

        public SinhVien(string maSo, string hoTen, DateTime ngaySinh, string diaChi,
                        string lop, bool phai, List<string> chuyenNganh, string hinh)
        {
            MaSo = maSo;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            Lop = lop;
            Phai = phai;
            ChuyenNganh = chuyenNganh ?? new List<string>();
            Hinh = hinh;
        }

        public string ChuyenNganhStr => string.Join(",", ChuyenNganh);
        public string PhaiStr => Phai ? "Nam" : "Nữ";
    }
}
