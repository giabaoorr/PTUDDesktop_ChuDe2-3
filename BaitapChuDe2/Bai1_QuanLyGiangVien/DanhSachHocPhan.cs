using System;
using System.Collections.Generic;

namespace BaitapChuDe2.Bai1_QuanLyGiangVien
{
    public class DanhSachHocPhan
    {
        private List<HocPhan> dsHocPhan;

        public DanhSachHocPhan()
        {
            dsHocPhan = new List<HocPhan>();
        }

        public HocPhan this[int index]
        {
            get
            {
                if (index >= 0 && index < dsHocPhan.Count)
                    return dsHocPhan[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < dsHocPhan.Count)
                    dsHocPhan[index] = value;
            }
        }

        public int Count => dsHocPhan.Count;

        public List<HocPhan> DanhSach => dsHocPhan;

        public void Them(HocPhan hp)
        {
            if (hp != null && !dsHocPhan.Contains(hp))
            {
                dsHocPhan.Add(hp);
            }
        }

        public void Xoa(HocPhan hp)
        {
            if (hp != null)
            {
                dsHocPhan.Remove(hp);
            }
        }

        public override string ToString()
        {
            var dsTen = new List<string>();
            foreach (var hp in dsHocPhan)
            {
                dsTen.Add(hp.TenHP);
            }
            return string.Join(",", dsTen) + (dsTen.Count > 0 ? ";" : "");
        }
    }
}
