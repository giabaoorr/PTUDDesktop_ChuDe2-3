using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace baitapChuDe3
{
    public partial class FormTimKiem : Form
    {
        public string SearchMSSV => txtMSSV.Text.Trim();
        public string SearchTen => txtTen.Text.Trim();
        public string SearchLop => cboLop.Text.Trim();

        public bool IsCleared { get; private set; }

        public FormTimKiem(IEnumerable<string> danhSachLop)
        {
            InitializeComponent();

            cboLop.Items.Add(""); // Lựa chọn tất cả lớp
            if (danhSachLop != null)
            {
                foreach (var lop in danhSachLop)
                {
                    if (!string.IsNullOrWhiteSpace(lop) && !cboLop.Items.Contains(lop))
                    {
                        cboLop.Items.Add(lop);
                    }
                }
            }
            cboLop.SelectedIndex = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchMSSV) &&
                string.IsNullOrWhiteSpace(SearchTen) &&
                string.IsNullOrWhiteSpace(SearchLop))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một điều kiện tìm kiếm (MSSV, Tên hoặc Lớp)!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IsCleared = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnXoaBoLoc_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtTen.Clear();
            cboLop.SelectedIndex = 0;
            IsCleared = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
