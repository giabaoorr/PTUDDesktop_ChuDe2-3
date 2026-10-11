using System;
using System.Windows.Forms;
using BaitapChuDe2.Bai1_QuanLyGiangVien;
using BaitapChuDe2.Bai2_QuanLySinhVien;
using BaitapChuDe2.Bai3_QuanLySinhVienKhoaCNTT;

namespace BaitapChuDe2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            using (var frm = new frmGiangVien())
            {
                frm.ShowDialog();
            }
        }

        private void btnBai2_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSinhVien())
            {
                frm.ShowDialog();
            }
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            using (var frm = new frmQLSinhVienKhoaCNTT())
            {
                frm.ShowDialog();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
