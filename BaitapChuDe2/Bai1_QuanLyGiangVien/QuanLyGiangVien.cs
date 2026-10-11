using System;
using System.Collections.Generic;

namespace BaitapChuDe2.Bai1_QuanLyGiangVien
{
    public enum KieuTim
    {
        TheoMa,
        TheoHoTen,
        TheoSDT
    }

    public delegate int SoSanh(object a, object b);

    public class QuanLyGiangVien
    {
        public List<GiangVien> dsGiangVien;

        public GiangVien this[int index]
        {
            get
            {
                if (index >= 0 && index < dsGiangVien.Count)
                    return dsGiangVien[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < dsGiangVien.Count)
                    dsGiangVien[index] = value;
            }
        }

        public QuanLyGiangVien()
        {
            dsGiangVien = new List<GiangVien>();
        }

        public void SapXep(SoSanh ss)
        {
            if (ss == null) return;
            dsGiangVien.Sort((a, b) => ss(a, b));
        }

        public bool Them(GiangVien gv)
        {
            if (gv == null) return false;

            // Kiểm tra mã giảng viên đã tồn tại chưa
            foreach (var item in dsGiangVien)
            {
                if (item.MaSo.Equals(gv.MaSo, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            dsGiangVien.Add(gv);
            return true;
        }

        public GiangVien Tim(object temp, SoSanh ss)
        {
            if (temp == null || ss == null) return null;

            foreach (var gv in dsGiangVien)
            {
                if (ss(gv, temp) == 0)
                {
                    return gv;
                }
            }
            return null;
        }

        public GiangVien Xoa(object temp, SoSanh ss)
        {
            var gv = Tim(temp, ss);
            if (gv != null)
            {
                dsGiangVien.Remove(gv);
            }
            return gv;
        }
    }
}
