using System;
using System.Collections.Generic;

namespace BaitapChuDe2.Bai1_QuanLyGiangVien
{
    public class GiangVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; } // true: Nam, false: Nữ
        public DateTime NgaySinh { get; set; }
        public string SoDT { get; set; }
        public string Mail { get; set; }
        public List<string> NgoaiNgu { get; set; }
        public DanhSachHocPhan DanhSachHP { get; set; }

        public GiangVien()
        {
            NgoaiNgu = new List<string>();
            DanhSachHP = new DanhSachHocPhan();
        }

        public GiangVien(string maSo, string hoTen, bool gioiTinh, DateTime ngaySinh,
                         string soDT, string mail, List<string> ngoaiNgu, DanhSachHocPhan dsHocPhan)
        {
            MaSo = maSo;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SoDT = soDT;
            Mail = mail;
            NgoaiNgu = ngoaiNgu ?? new List<string>();
            DanhSachHP = dsHocPhan ?? new DanhSachHocPhan();
        }

        public string LayChuoiThongTin()
        {
            string nn = string.Join(";", NgoaiNgu) + (NgoaiNgu.Count > 0 ? ";" : "");
            string dsMon = DanhSachHP.ToString();

            return $"Mã số:{MaSo}\r\n" +
                   $"Họ tên:{HoTen}\r\n" +
                   $"Ngày Sinh:{NgaySinh}\r\n" +
                   $"Giới tính:{(GioiTinh ? "Nam" : "Nữ")}\r\n" +
                   $"Số ĐT:{SoDT}\r\n" +
                   $"Mail:{Mail}\r\n\r\n" +
                   $"Ngoại ngữ:{nn}\r\n" +
                   $"Danh sách môn dạy:{dsMon}";
        }

        public override string ToString()
        {
            return $"{MaSo} - {HoTen}";
        }
    }
}
