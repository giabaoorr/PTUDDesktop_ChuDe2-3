using System;
using System.Windows.Forms;

namespace BaitapChuDe2.Bai1_QuanLyGiangVien
{
    public partial class frmTimGiangVien : Form
    {
        private QuanLyGiangVien qlgv;

        public frmTimGiangVien(QuanLyGiangVien ql)
        {
            InitializeComponent();
            this.qlgv = ql;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string giaTri = txtGiaTri.Text.Trim();
            if (string.IsNullOrEmpty(giaTri))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GiangVien gv = null;
            if (rdMaGV.Checked)
            {
                gv = qlgv.Tim(giaTri, (a, b) => ((GiangVien)a).MaSo.CompareTo((string)b));
            }
            else if (rdHoTen.Checked)
            {
                gv = qlgv.Tim(giaTri, (a, b) => ((GiangVien)a).HoTen.IndexOf((string)b, StringComparison.OrdinalIgnoreCase) >= 0 ? 0 : 1);
            }
            else if (rdSoDT.Checked)
            {
                gv = qlgv.Tim(giaTri, (a, b) => ((GiangVien)a).SoDT.Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "")
                                                  .IndexOf(((string)b).Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", ""), StringComparison.OrdinalIgnoreCase) >= 0 ? 0 : 1);
            }

            if (gv != null)
            {
                var frmTB = new frmTBGiangVien();
                frmTB.SetText(gv.LayChuoiThongTin());
                frmTB.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
