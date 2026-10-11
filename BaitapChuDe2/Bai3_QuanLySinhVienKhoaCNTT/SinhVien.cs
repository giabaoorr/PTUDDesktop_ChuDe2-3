using System;

namespace BaitapChuDe2.Bai3_QuanLySinhVienKhoaCNTT
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public bool Phai { get; set; } // true: Nam, false: Nữ
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SoDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Hinh { get; set; }

        public SinhVien() { }

        public SinhVien(string mssv, string hoTen, bool phai, DateTime ngaySinh,
                        string lop, string soDT, string email, string diaChi, string hinh)
        {
            MSSV = mssv;
            HoTen = hoTen;
            Phai = phai;
            NgaySinh = ngaySinh;
            Lop = lop;
            SoDT = soDT;
            Email = email;
            DiaChi = diaChi;
            Hinh = hinh;
        }

        public string PhaiStr => Phai ? "Nam" : "Nữ";

        public override string ToString()
        {
            return $"{MSSV} - {HoTen}";
        }
    }
}
