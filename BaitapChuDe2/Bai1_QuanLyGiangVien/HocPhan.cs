using System;

namespace BaitapChuDe2.Bai1_QuanLyGiangVien
{
    public class HocPhan
    {
        public string ID { get; set; }
        public string TenHP { get; set; }
        public int SoTC { get; set; }

        public HocPhan() { }

        public HocPhan(string id, string tenHP, int soTC)
        {
            ID = id;
            TenHP = tenHP;
            SoTC = soTC;
        }

        public override string ToString()
        {
            return TenHP;
        }
    }
}
