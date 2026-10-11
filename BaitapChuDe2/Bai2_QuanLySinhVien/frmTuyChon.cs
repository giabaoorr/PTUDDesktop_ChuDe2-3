using System;
using System.Windows.Forms;

namespace BaitapChuDe2.Bai2_QuanLySinhVien
{
    public enum TuyChon
    {
        MaSV,
        HoTen,
        NgaySinh
    }

    public partial class frmTuyChon : Form
    {
        public string ChuoiTim { get; set; }
        public TuyChon Kieu { get; set; }
        public bool IsCheDoTim { get; set; }

        public frmTuyChon(bool isTimKiem = true)
        {
            InitializeComponent();
            IsCheDoTim = isTimKiem;
            Kieu = TuyChon.MaSV;
        }

        private void frmTuyChon_Load(object sender, EventArgs e)
        {
            rdMaSV.Checked = true;

            if (IsCheDoTim)
            {
                lblNhapThongTin.Enabled = true;
                txtThongTin.Enabled = true;
                btnTim.Enabled = true;
                btnSapXep.Enabled = false;
                this.AcceptButton = btnTim;
            }
            else
            {
                lblNhapThongTin.Enabled = false;
                txtThongTin.Enabled = false;
                btnTim.Enabled = false;
                btnSapXep.Enabled = true;
                this.AcceptButton = btnSapXep;
            }
        }

        private void rdTuyChon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMaSV.Checked) Kieu = TuyChon.MaSV;
            else if (rdHoTen.Checked) Kieu = TuyChon.HoTen;
            else if (rdNgaySinh.Checked) Kieu = TuyChon.NgaySinh;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string thongTin = txtThongTin.Text.Trim();
            if (string.IsNullOrEmpty(thongTin))
            {
                MessageBox.Show("Hãy nhập thông tin tìm!", "Lỗi nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThongTin.Focus();
                return;
            }

            ChuoiTim = thongTin;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
