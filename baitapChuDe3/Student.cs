using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace baitapChuDe3
{
    /// <summary>
    /// Lớp biểu diễn thông tin sinh viên
    /// </summary>
    [Serializable]
    public class Student
    {
        public string MSSV { get; set; }
        public string HoVaTenLot { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; } // true: Nam, false: Nữ
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SoCMND { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChiLienLac { get; set; }

        [XmlArray("MonHocDangKy")]
        [XmlArrayItem("MonHoc")]
        public List<string> MonHocDangKy { get; set; }

        // Constructor mặc định (cần cho XML và JSON serializer)
        public Student()
        {
            MonHocDangKy = new List<string>();
        }

        // Constructor đầy đủ tham số
        public Student(string mssv, string hoVaTenLot, string ten, bool gioiTinh,
                       DateTime ngaySinh, string lop, string soCMND, string soDienThoai,
                       string diaChiLienLac, List<string> monHocDangKy)
        {
            MSSV = mssv;
            HoVaTenLot = hoVaTenLot;
            Ten = ten;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            Lop = lop;
            SoCMND = soCMND;
            SoDienThoai = soDienThoai;
            DiaChiLienLac = diaChiLienLac;
            MonHocDangKy = monHocDangKy ?? new List<string>();
        }

        public string HoVaTenDayDu => $"{HoVaTenLot} {Ten}".Trim();

        public string GioiTinhStr => GioiTinh ? "Nam" : "Nữ";

        public override string ToString()
        {
            return $"{MSSV} - {HoVaTenDayDu} ({Lop})";
        }
    }
}
