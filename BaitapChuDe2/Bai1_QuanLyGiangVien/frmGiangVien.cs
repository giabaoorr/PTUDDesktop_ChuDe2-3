using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace BaitapChuDe2.Bai1_QuanLyGiangVien
{
    public partial class frmGiangVien : Form
    {
        private QuanLyGiangVien qlgv;

        public frmGiangVien()
        {
            InitializeComponent();
            qlgv = new QuanLyGiangVien();
        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            if (cboMaSo.Items.Count > 0)
                cboMaSo.SelectedIndex = 0;

            NapDanhSachHocPhan();

            // Thêm dữ liệu mẫu ban đầu để dễ dàng kiểm thử tìm kiếm
            ThemGiangVienMau();
        }

        private void NapDanhSachHocPhan()
        {
            lbDanhSachHP.Items.Clear();
            lbDanhSachHP.Items.Add(new HocPhan("HP01", "Tin học cơ sở", 2));
            lbDanhSachHP.Items.Add(new HocPhan("HP02", "Cơ sở dữ liệu", 3));
            lbDanhSachHP.Items.Add(new HocPhan("HP03", "Hệ điều hành", 3));
            lbDanhSachHP.Items.Add(new HocPhan("HP04", "Mạng máy tính", 3));
            lbDanhSachHP.Items.Add(new HocPhan("HP05", "Lập trình mạng", 3));
            lbDanhSachHP.Items.Add(new HocPhan("HP06", "Phân tích TKHĐT", 3));
            lbDanhSachHP.Items.Add(new HocPhan("HP07", "Lập trình cấu trúc C/C++", 3));
            lbDanhSachHP.Items.Add(new HocPhan("HP08", "Đồ án cơ sở", 2));
        }

        private void ThemGiangVienMau()
        {
            var dsHP = new DanhSachHocPhan();
            dsHP.Them(new HocPhan("HP06", "Phân tích TKHĐT", 3));
            dsHP.Them(new HocPhan("HP07", "Lập trình cấu trúc C/C++", 3));

            var gvMau = new GiangVien(
                "002",
                "Nguyen Thi C",
                false,
                DateTime.Parse("9/23/1999 4:59:39 PM"),
                "(0633).333.333",
                "cc@yahoo.com",
                new List<string> { "Tiếng Anh" },
                dsHP
            );
            qlgv.Them(gvMau);
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            var dsChon = new List<object>();
            foreach (var item in lbDanhSachHP.SelectedItems)
            {
                dsChon.Add(item);
            }

            foreach (var item in dsChon)
            {
                lbHocPhanDay.Items.Add(item);
                lbDanhSachHP.Items.Remove(item);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var dsChon = new List<object>();
            foreach (var item in lbHocPhanDay.SelectedItems)
            {
                dsChon.Add(item);
            }

            foreach (var item in dsChon)
            {
                lbDanhSachHP.Items.Add(item);
                lbHocPhanDay.Items.Remove(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cboMaSo.Items.Count > 0) cboMaSo.SelectedIndex = 0;
            txtHoTen.Clear();
            rdNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            mtxtSoDT.Clear();
            txtMail.Clear();

            for (int i = 0; i < chklbNgoaiNgu.Items.Count; i++)
            {
                chklbNgoaiNgu.SetItemChecked(i, false);
            }

            // Chuyển toàn bộ môn học trở về danh sách nguồn
            NapDanhSachHocPhan();
            lbHocPhanDay.Items.Clear();
        }

        private GiangVien LayThongTinGiangVienTuForm()
        {
            string maSo = cboMaSo.Text;
            string hoTen = txtHoTen.Text.Trim();
            bool gioiTinh = rdNam.Checked;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string soDT = mtxtSoDT.Text;
            string mail = txtMail.Text.Trim();

            var dsNN = new List<string>();
            foreach (var item in chklbNgoaiNgu.CheckedItems)
            {
                dsNN.Add(item.ToString());
            }

            var dsHP = new DanhSachHocPhan();
            foreach (HocPhan hp in lbHocPhanDay.Items)
            {
                dsHP.Them(hp);
            }

            return new GiangVien(maSo, hoTen, gioiTinh, ngaySinh, soDT, mail, dsNN, dsHP);
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            var gv = LayThongTinGiangVienTuForm();
            var frmTB = new frmTBGiangVien();
            frmTB.SetText(gv.LayChuoiThongTin());
            frmTB.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var gv = LayThongTinGiangVienTuForm();

            if (string.IsNullOrWhiteSpace(gv.HoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            bool ketQua = qlgv.Them(gv);
            if (!ketQua)
            {
                MessageBox.Show("Mã giảng viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Thêm giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (var frmTim = new frmTimGiangVien(qlgv))
            {
                frmTim.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://cntt.dlu.edu.vn/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở liên kết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
