using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BaitapChuDe2.Bai3_QuanLySinhVienKhoaCNTT
{
    public partial class frmQLSinhVienKhoaCNTT : Form
    {
        private ArrayList dsSinhVien;
        private string filePath = "DSNV.txt";
        private bool isModified = false;

        public frmQLSinhVienKhoaCNTT()
        {
            InitializeComponent();
            dsSinhVien = new ArrayList();
        }

        private void frmQLSinhVienKhoaCNTT_Load(object sender, EventArgs e)
        {
            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0;

            if (!File.Exists(filePath))
            {
                TaoDuLieuMau();
            }

            DocFileDSNV();
            HienThiLenListView();
            isModified = false;
        }

        private void TaoDuLieuMau()
        {
            var sv1 = new SinhVien("2010001", "Nguyễn Văn An", true, new DateTime(2002, 3, 15), "CTK44", "0912.345.678", "an@gmail.com", "1 Phù Đổng Thiên Vương, Đà Lạt", "");
            var sv2 = new SinhVien("2010002", "Trần Thị Bình", false, new DateTime(2002, 8, 20), "CTK44", "0987.654.321", "binh@gmail.com", "29 Yersin, Đà Lạt", "");
            var sv3 = new SinhVien("2110015", "Lê Hoàng Cường", true, new DateTime(2003, 11, 2), "CTK45", "0905.123.456", "cuong@gmail.com", "10 Đinh Tiên Hoàng, Đà Lạt", "");
            var sv4 = new SinhVien("1910088", "Phạm Ngọc Dung", false, new DateTime(2001, 5, 12), "CTK43", "0934.567.890", "dung@gmail.com", "12 Bùi Thị Xuân, Đà Lạt", "");

            dsSinhVien.Add(sv1);
            dsSinhVien.Add(sv2);
            dsSinhVien.Add(sv3);
            dsSinhVien.Add(sv4);
            GhiFileDSNV();
        }

        private void DocFileDSNV()
        {
            dsSinhVien.Clear();
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('*');
                if (parts.Length >= 9)
                {
                    var sv = new SinhVien
                    {
                        MSSV = parts[0].Trim(),
                        HoTen = parts[1].Trim(),
                        Phai = parts[2].Trim() == "1" || parts[2].Trim().Equals("Nam", StringComparison.OrdinalIgnoreCase),
                        NgaySinh = DateTime.TryParseExact(parts[3].Trim(), new[] { "dd/MM/yyyy", "d/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out var ns) ? ns : DateTime.Now,
                        Lop = parts[4].Trim(),
                        SoDT = parts[5].Trim(),
                        Email = parts[6].Trim(),
                        DiaChi = parts[7].Trim(),
                        Hinh = parts[8].Trim()
                    };
                    dsSinhVien.Add(sv);
                }
            }
        }

        private void GhiFileDSNV()
        {
            var lines = new ArrayList();
            foreach (SinhVien sv in dsSinhVien)
            {
                string phai = sv.Phai ? "1" : "0";
                string line = $"{sv.MSSV}*{sv.HoTen}*{phai}*{sv.NgaySinh:dd/MM/yyyy}*{sv.Lop}*{sv.SoDT}*{sv.Email}*{sv.DiaChi}*{sv.Hinh}";
                lines.Add(line);
            }
            File.WriteAllLines(filePath, (string[])lines.ToArray(typeof(string)), Encoding.UTF8);
            isModified = false;
        }

        private void HienThiLenListView()
        {
            lvSinhVien.Items.Clear();
            foreach (SinhVien sv in dsSinhVien)
            {
                var item = new ListViewItem(sv.MSSV);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.PhaiStr);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SoDT);
                item.SubItems.Add(sv.Email);
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Hinh ?? "");
                item.Tag = sv;

                lvSinhVien.Items.Add(item);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                var item = lvSinhVien.SelectedItems[0];
                var sv = item.Tag as SinhVien;
                if (sv != null)
                {
                    mtxtMSSV.Text = sv.MSSV;
                    txtHoTen.Text = sv.HoTen;
                    dtpNgaySinh.Value = sv.NgaySinh;
                    if (sv.Phai) rdNam.Checked = true;
                    else rdNu.Checked = true;
                    txtEmail.Text = sv.Email;
                    cboLop.Text = sv.Lop;
                    txtDiaChi.Text = sv.DiaChi;
                    mtxtSoDT.Text = sv.SoDT;
                    txtHinh.Text = sv.Hinh ?? "";

                    if (!string.IsNullOrEmpty(sv.Hinh) && File.Exists(sv.Hinh))
                    {
                        try { pbHinh.Image = Image.FromFile(sv.Hinh); } catch { pbHinh.Image = null; }
                    }
                    else
                    {
                        pbHinh.Image = null;
                    }
                }
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtHinh.Text = openFileDialog1.FileName;
                try
                {
                    pbHinh.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch
                {
                    pbHinh.Image = null;
                }
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            mtxtMSSV.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            rdNam.Checked = true;
            txtEmail.Clear();
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            txtDiaChi.Clear();
            mtxtSoDT.Clear();
            txtHinh.Clear();
            pbHinh.Image = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mssv = Regex.Replace(mtxtMSSV.Text, @"\D", "");
            string hoTen = txtHoTen.Text.Trim();
            bool phai = rdNam.Checked;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string lop = cboLop.Text.Trim();
            string email = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string soDT = mtxtSoDT.Text.Trim();
            string soDTThuan = Regex.Replace(soDT, @"\D", "");
            string hinh = txtHinh.Text.Trim();

            // Kiểm tra các ràng buộc:
            // a) MSSV gồm 7 ký tự số
            if (mssv.Length != 7)
            {
                MessageBox.Show($"Mã sinh viên phải gồm đúng 7 ký tự số! (Hiện tại: {mssv.Length} số)",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtMSSV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // d) Số điện thoại 10 chữ số
            if (soDTThuan.Length != 10)
            {
                MessageBox.Show($"Số điện thoại phải có đủ 10 chữ số! (Hiện tại: {soDTThuan.Length} số)",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtSoDT.Focus();
                return;
            }

            // Tìm sinh viên theo MSSV trong ArrayList
            SinhVien svTonTai = null;
            foreach (SinhVien s in dsSinhVien)
            {
                if (s.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase))
                {
                    svTonTai = s;
                    break;
                }
            }

            if (svTonTai != null)
            {
                // Cập nhật thông tin
                svTonTai.HoTen = hoTen;
                svTonTai.Phai = phai;
                svTonTai.NgaySinh = ngaySinh;
                svTonTai.Lop = lop;
                svTonTai.SoDT = soDT;
                svTonTai.Email = email;
                svTonTai.DiaChi = diaChi;
                svTonTai.Hinh = hinh;
                MessageBox.Show($"Cập nhật sinh viên '{hoTen}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Thêm mới vào ArrayList
                var svMoi = new SinhVien(mssv, hoTen, phai, ngaySinh, lop, soDT, email, diaChi, hinh);
                dsSinhVien.Add(svMoi);
                MessageBox.Show($"Thêm mới sinh viên '{hoTen}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            isModified = true;
            HienThiLenListView();
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sinh viên cần xóa trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa {lvSinhVien.SelectedItems.Count} sinh viên đã chọn?",
                                     "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                var dsXoa = new ArrayList();
                foreach (ListViewItem item in lvSinhVien.SelectedItems)
                {
                    dsXoa.Add(item.Tag);
                }

                foreach (SinhVien sv in dsXoa)
                {
                    dsSinhVien.Remove(sv);
                }

                isModified = true;
                HienThiLenListView();
                btnMacDinh_Click(sender, e);
                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuTaiLai_Click(object sender, EventArgs e)
        {
            DocFileDSNV();
            HienThiLenListView();
            btnMacDinh_Click(sender, e);
            isModified = false;
            MessageBox.Show("Đã tải lại danh sách sinh viên từ tập tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQLSinhVienKhoaCNTT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModified)
            {
                var dr = MessageBox.Show("Danh sách sinh viên đã có sự thay đổi. Bạn có muốn lưu lại vào tập tin không?",
                                         "Xác nhận lưu thay đổi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    GhiFileDSNV();
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
