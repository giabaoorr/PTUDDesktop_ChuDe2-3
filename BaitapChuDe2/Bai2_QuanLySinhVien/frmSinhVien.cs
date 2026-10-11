using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BaitapChuDe2.Bai2_QuanLySinhVien
{
    public partial class frmSinhVien : Form
    {
        private QuanLySinhVien qlsv;
        private string filePath = "DanhSachSV.txt";

        public frmSinhVien()
        {
            InitializeComponent();
            qlsv = new QuanLySinhVien();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0;

            // Nếu file chưa có thì tạo file mẫu
            if (!File.Exists(filePath))
            {
                TaoDuLieuMau();
            }

            qlsv.DocTuFile(filePath);
            LoadListView(qlsv.DanhSach);
        }

        private void TaoDuLieuMau()
        {
            var sv1 = new SinhVien("SV.00001", "Nguyễn Văn An", new DateTime(2001, 5, 20), "Đà Lạt", "CTK31", true, new List<string> { "Mạng truyền thông", "Công nghệ phần mềm" }, "SV.00001.jpg");
            var sv2 = new SinhVien("SV.00002", "Trần Thị Bình", new DateTime(2001, 8, 15), "Đức Trọng", "CTK32", false, new List<string> { "Khoa học máy tính", "Trí tuệ nhân tạo" }, "SV.00002.jpg");
            var sv3 = new SinhVien("SV.00003", "Lê Hoàng Cường", new DateTime(2002, 1, 10), "Bảo Lộc", "CTK33", true, new List<string> { "Hệ thống thông tin" }, "SV.00003.jpg");
            var sv4 = new SinhVien("SV.00004", "Phạm Ngọc Dung", new DateTime(2002, 11, 25), "Nha Trang", "CTK34", false, new List<string> { "Tin học ứng dụng" }, "SV.00004.jpg");
            var sv5 = new SinhVien("SV.00005", "Võ Minh Đức", new DateTime(2001, 3, 30), "Đơn Dương", "CTK31", true, new List<string> { "Mạng truyền thông" }, "SV.00005.jpg");

            qlsv.Them(sv1);
            qlsv.Them(sv2);
            qlsv.Them(sv3);
            qlsv.Them(sv4);
            qlsv.Them(sv5);
            qlsv.GhiRaFile(filePath);
        }

        public void LoadListView(List<SinhVien> ds)
        {
            lvSinhVien.Items.Clear();
            if (ds != null)
            {
                foreach (var sv in ds)
                {
                    Them1SinhVienLenListView(sv);
                }
                tssTongSinhVien.Text = $"Tổng Sinh Viên: {ds.Count}";
            }
            else
            {
                tssTongSinhVien.Text = "Tổng Sinh Viên: 0";
            }
        }

        public void Them1SinhVienLenListView(SinhVien sv)
        {
            var item = new ListViewItem(sv.MaSo);
            item.SubItems.Add(sv.HoTen);
            item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sv.DiaChi);
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.PhaiStr);
            item.SubItems.Add(sv.ChuyenNganhStr);
            item.SubItems.Add(sv.Hinh ?? "");
            item.Tag = sv;

            lvSinhVien.Items.Add(item);
        }

        public SinhVien GetSinhVien()
        {
            string maSo = mtxtMaSo.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = txtDiaChi.Text.Trim();
            string lop = cboLop.Text;
            bool phai = rdNam.Checked;
            string hinh = txtHinh.Text.Trim();

            var dsCN = new List<string>();
            foreach (var item in clbChuyenNganh.CheckedItems)
            {
                dsCN.Add(item.ToString());
            }

            return new SinhVien(maSo, hoTen, ngaySinh, diaChi, lop, phai, dsCN, hinh);
        }

        public void ThietLapThongTin(SinhVien sv)
        {
            if (sv == null) return;

            mtxtMaSo.Text = sv.MaSo;
            txtHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;
            txtDiaChi.Text = sv.DiaChi;
            cboLop.Text = sv.Lop;
            if (sv.Phai) rdNam.Checked = true;
            else rdNu.Checked = true;

            txtHinh.Text = sv.Hinh ?? "";
            if (!string.IsNullOrEmpty(sv.Hinh) && File.Exists(sv.Hinh))
            {
                try { pbHinh.Image = Image.FromFile(sv.Hinh); } catch { pbHinh.Image = null; }
            }
            else
            {
                pbHinh.Image = null;
            }

            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
            {
                string cn = clbChuyenNganh.Items[i].ToString();
                bool isChecked = sv.ChuyenNganh != null && sv.ChuyenNganh.Contains(cn);
                clbChuyenNganh.SetItemChecked(i, isChecked);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                var item = lvSinhVien.SelectedItems[0];
                var sv = item.Tag as SinhVien;
                ThietLapThongTin(sv);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogHinh.ShowDialog() == DialogResult.OK)
            {
                txtHinh.Text = OpenFileDialogHinh.FileName;
                try
                {
                    pbHinh.Image = Image.FromFile(OpenFileDialogHinh.FileName);
                }
                catch
                {
                    pbHinh.Image = null;
                }
            }
        }

        private void mnuOpenFile_Click(object sender, EventArgs e)
        {
            btnBrowse_Click(sender, e);
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            mtxtMaSo.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            rdNam.Checked = true;
            txtHinh.Clear();
            pbHinh.Image = null;

            for (int i = 0; i < clbChuyenNganh.Items.Count; i++)
            {
                clbChuyenNganh.SetItemChecked(i, false);
            }

            LoadListView(qlsv.DanhSach);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var sv = GetSinhVien();
            if (string.IsNullOrWhiteSpace(sv.MaSo) || sv.MaSo == "SV.")
            {
                MessageBox.Show("Vui lòng nhập Mã số sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtMaSo.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(sv.HoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            bool ketQua = qlsv.Them(sv);
            if (!ketQua)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            qlsv.GhiRaFile(filePath);
            LoadListView(qlsv.DanhSach);
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var dsMaXoa = new List<string>();
            foreach (ListViewItem item in lvSinhVien.CheckedItems)
            {
                dsMaXoa.Add(item.SubItems[0].Text);
            }

            if (dsMaXoa.Count == 0)
            {
                MessageBox.Show("Vui lòng đánh dấu chọn ít nhất một sinh viên trên danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa {dsMaXoa.Count} sinh viên đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (var ma in dsMaXoa)
                {
                    qlsv.Xoa(ma, QuanLySinhVien.SoSanhTheoMa);
                }
                qlsv.GhiRaFile(filePath);
                LoadListView(qlsv.DanhSach);
                btnMacDinh_Click(sender, e);
                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var svMoi = GetSinhVien();
            if (string.IsNullOrWhiteSpace(svMoi.MaSo))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ketQua = qlsv.Sua(svMoi, svMoi.MaSo, QuanLySinhVien.SoSanhTheoMa);
            if (!ketQua)
            {
                MessageBox.Show("Không tìm thấy sinh viên có mã này để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            qlsv.GhiRaFile(filePath);
            LoadListView(qlsv.DanhSach);
            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                lvSinhVien.Font = fontDialog1.Font;
            }
        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lvSinhVien.ForeColor = colorDialog1.Color;
            }
        }

        private void mnuSapXep_Click(object sender, EventArgs e)
        {
            using (var frm = new frmTuyChon(isTimKiem: false))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    switch (frm.Kieu)
                    {
                        case TuyChon.MaSV:
                            qlsv.SapXep(QuanLySinhVien.SoSanhTheoMa);
                            break;
                        case TuyChon.HoTen:
                            qlsv.SapXep(QuanLySinhVien.SoSanhTheoHoTen);
                            break;
                        case TuyChon.NgaySinh:
                            qlsv.SapXep(QuanLySinhVien.SoSanhTheoNgaySinh);
                            break;
                    }
                    LoadListView(qlsv.DanhSach);
                }
            }
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmTuyChon(isTimKiem: true))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    List<SinhVien> ketQua = new List<SinhVien>();
                    string tuKhoa = frm.ChuoiTim;

                    switch (frm.Kieu)
                    {
                        case TuyChon.MaSV:
                            ketQua = qlsv.DanhSach.Where(s => s.MaSo.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                            break;
                        case TuyChon.HoTen:
                            ketQua = qlsv.DanhSach.Where(s => s.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                            break;
                        case TuyChon.NgaySinh:
                            ketQua = qlsv.DanhSach.Where(s => s.NgaySinh.ToString("dd/MM/yyyy").IndexOf(tuKhoa) >= 0).ToList();
                            break;
                    }

                    LoadListView(ketQua);
                    MessageBox.Show($"Số sinh viên tìm thấy:{ketQua.Count}", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
