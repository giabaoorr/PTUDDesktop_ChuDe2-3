using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace baitapChuDe3
{
    public partial class Form1 : Form
    {
        private StudentManager studentManager;
        private string currentTxtPath = "students.txt";
        private string currentXmlPath = "students.xml";
        private string currentJsonPath = "students.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoDanhSachLop();
            KhoiTaoDanhSachMonHoc();
            KhoiTaoQuanLySinhVien();
            HienThiDanhSachSinhVien(studentManager.Students);
        }

        #region Khởi tạo dữ liệu ban đầu

        private void KhoiTaoDanhSachLop()
        {
            cboLop.Items.Clear();
            cboLop.Items.AddRange(new object[] {
                "CTK42", // Khóa 42: năm nhập học 2018 (AA = 18)
                "CTK43", // Khóa 43: năm nhập học 2019 (AA = 19)
                "CTK44", // Khóa 44: năm nhập học 2020 (AA = 20)
                "CTK45", // Khóa 45: năm nhập học 2021 (AA = 21)
                "CTK46", // Khóa 46: năm nhập học 2022 (AA = 22)
                "CTK47"  // Khóa 47: năm nhập học 2023 (AA = 23)
            });
            cboLop.SelectedIndex = 2; // Mặc định CTK44 (2020)
        }

        private void KhoiTaoDanhSachMonHoc()
        {
            clbMonHoc.Items.Clear();
            // 8 môn học ban đầu theo đề bài yêu cầu:
            // Cột trái:
            clbMonHoc.Items.Add("Mạng máy tính");
            clbMonHoc.Items.Add("Hệ điều hành");
            clbMonHoc.Items.Add("Lập trình CSDL");
            clbMonHoc.Items.Add("Lập trình mạng");
            // Cột phải:
            clbMonHoc.Items.Add("Đồ án cơ sở");
            clbMonHoc.Items.Add("Phương pháp NCKH");
            clbMonHoc.Items.Add("Lập trình trên thiết bị di động");
            clbMonHoc.Items.Add("An toàn và bảo mật hệ thống");
        }

        private void KhoiTaoQuanLySinhVien()
        {
            // Mặc định sử dụng TxtStudentStorage và tập tin students.txt
            var txtStorage = new TxtStudentStorage();
            studentManager = new StudentManager(txtStorage, currentTxtPath);

            // Nếu tập tin chưa có sinh viên nào, khởi tạo dữ liệu mẫu và đồng bộ cả 3 định dạng
            if (studentManager.Students.Count == 0 && !File.Exists(currentTxtPath))
            {
                TaoDuLieuMau();
            }
        }

        private void TaoDuLieuMau()
        {
            var mauList = new List<Student>
            {
                new Student("2010001", "Nguyễn Văn", "An", true, new DateTime(2002, 3, 15),
                    "CTK44", "251234567", "0912345678", "1 Phù Đổng Thiên Vương, Đà Lạt",
                    new List<string> { "Mạng máy tính", "Lập trình CSDL", "Đồ án cơ sở" }),

                new Student("2010002", "Trần Thị", "Bình", false, new DateTime(2002, 8, 20),
                    "CTK44", "251234568", "0987654321", "29 Yersin, Đà Lạt",
                    new List<string> { "Hệ điều hành", "Phương pháp NCKH", "Lập trình trên thiết bị di động" }),

                new Student("2110015", "Lê Hoàng", "Cường", true, new DateTime(2003, 11, 2),
                    "CTK45", "251234569", "0905123456", "10 Đinh Tiên Hoàng, Đà Lạt",
                    new List<string> { "Lập trình mạng", "An toàn và bảo mật hệ thống" }),

                new Student("1910088", "Phạm Ngọc", "Dung", false, new DateTime(2001, 5, 12),
                    "CTK43", "251234570", "0934567890", "12 Bùi Thị Xuân, Đà Lạt",
                    new List<string> { "Mạng máy tính", "Hệ điều hành", "Đồ án cơ sở" })
            };

            studentManager.Students.AddRange(mauList);
            studentManager.Save();

            // Đồng bộ sang cả file XML và JSON mẫu
            try
            {
                new XmlStudentStorage().Write(currentXmlPath, mauList);
                new JsonStudentStorage().Write(currentJsonPath, mauList);
            }
            catch
            {
                // Bỏ qua nếu lỗi đồng bộ ban đầu
            }
        }

        #endregion

        #region Hiển thị danh sách lên ListView

        private void HienThiDanhSachSinhVien(List<Student> danhSach)
        {
            lvSinhVien.Items.Clear();
            if (danhSach == null) return;

            foreach (var sv in danhSach)
            {
                var item = new ListViewItem(sv.MSSV);
                item.SubItems.Add(sv.HoVaTenLot ?? "");
                item.SubItems.Add(sv.Ten ?? "");
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop ?? "");
                item.SubItems.Add(sv.SoCMND ?? "");
                item.SubItems.Add(sv.SoDienThoai ?? "");
                item.SubItems.Add(sv.DiaChiLienLac ?? "");
                item.Tag = sv;

                lvSinhVien.Items.Add(item);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                var item = lvSinhVien.SelectedItems[0];
                var sv = item.Tag as Student;
                if (sv != null)
                {
                    DienThongTinLenForm(sv);
                }
            }
        }

        private void DienThongTinLenForm(Student sv)
        {
            mtxtMSSV.Text = sv.MSSV;
            txtHoTenLot.Text = sv.HoVaTenLot;
            txtTen.Text = sv.Ten;

            if (sv.GioiTinh)
                rbNam.Checked = true;
            else
                rbNu.Checked = true;

            dtpNgaySinh.Value = sv.NgaySinh;
            cboLop.Text = sv.Lop;
            mtxtCMND.Text = sv.SoCMND;
            mtxtSDT.Text = sv.SoDienThoai;
            txtDiaChi.Text = sv.DiaChiLienLac;

            // Đặt trạng thái check cho các môn học
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                string mon = clbMonHoc.Items[i].ToString();
                bool isChecked = sv.MonHocDangKy != null && sv.MonHocDangKy.Contains(mon);
                clbMonHoc.SetItemChecked(i, isChecked);
            }
        }

        private void XoaTrangForm()
        {
            mtxtMSSV.Clear();
            txtHoTenLot.Clear();
            txtTen.Clear();
            rbNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            mtxtCMND.Clear();
            mtxtSDT.Clear();
            txtDiaChi.Clear();

            for (int i = 0; i < clbMonHoc.Items.Count; i++)
            {
                clbMonHoc.SetItemChecked(i, false);
            }
        }

        #endregion

        #region Kiểm tra dữ liệu nhập (Validation)

        /// <summary>
        /// Lấy giá trị chuỗi thuần từ MaskedTextBox (chỉ lấy số)
        /// </summary>
        private string LayChuoiSoThuan(MaskedTextBox mtxt)
        {
            string s = mtxt.Text;
            return Regex.Replace(s, @"\D", "");
        }

        private bool KiemTraThongTin(out Student sv, bool laThemMoi)
        {
            sv = null;

            string mssv = LayChuoiSoThuan(mtxtMSSV);
            string hoLot = txtHoTenLot.Text.Trim();
            string ten = txtTen.Text.Trim();
            bool gioiTinh = rbNam.Checked;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string lop = cboLop.Text.Trim();
            string cmnd = LayChuoiSoThuan(mtxtCMND);
            string sdt = LayChuoiSoThuan(mtxtSDT);
            string diaChi = txtDiaChi.Text.Trim();

            // 1. Kiểm tra để trống các trường cơ bản
            if (string.IsNullOrWhiteSpace(mssv))
            {
                MessageBox.Show("Vui lòng nhập MSSV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtMSSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(hoLot))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên lót!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenLot.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(lop))
            {
                MessageBox.Show("Vui lòng chọn Lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmnd))
            {
                MessageBox.Show("Vui lòng nhập Số CMND!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtCMND.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtSDT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(diaChi))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ liên lạc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            // 2. Kiểm tra độ dài CMND (đúng 9 chữ số)
            if (cmnd.Length != 9)
            {
                MessageBox.Show($"Số CMND phải có đủ 9 chữ số! Hiện tại: {cmnd.Length} chữ số.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtCMND.Focus();
                return false;
            }

            // 3. Kiểm tra độ dài Số ĐT (đúng 10 chữ số)
            if (sdt.Length != 10)
            {
                MessageBox.Show($"Số điện thoại phải có đủ 10 chữ số! Hiện tại: {sdt.Length} chữ số.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtSDT.Focus();
                return false;
            }

            // 4. Kiểm tra quy tắc MSSV (Phần 4.1: đúng 7 chữ số, AABBCCC, BB=10, AA khớp năm nhập học từ lớp)
            if (!StudentManager.ValidateMSSV(mssv, lop, out string mssvError))
            {
                MessageBox.Show(mssvError, "Quy tắc MSSV không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtMSSV.Focus();
                return false;
            }

            // 5. Kiểm tra môn học đăng ký (ít nhất 1 môn)
            var dsMonHoc = new List<string>();
            foreach (var item in clbMonHoc.CheckedItems)
            {
                dsMonHoc.Add(item.ToString());
            }

            if (dsMonHoc.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một môn học đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clbMonHoc.Focus();
                return false;
            }

            // 6. Kiểm tra trùng MSSV nếu là thêm mới
            if (laThemMoi && studentManager.Students.Any(s => s.MSSV.Equals(mssv, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Sinh viên có MSSV {mssv} đã tồn tại trong danh sách!\nNếu muốn sửa thông tin, vui lòng nhấn nút 'Cập nhật'.",
                                "Trùng MSSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtMSSV.Focus();
                return false;
            }

            sv = new Student(mssv, hoLot, ten, gioiTinh, ngaySinh, lop, cmnd, sdt, diaChi, dsMonHoc);
            return true;
        }

        #endregion

        #region Các nút chức năng chính (Thêm mới, Cập nhật, Thoát, Tìm kiếm)

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin(out Student sv, laThemMoi: true))
            {
                return;
            }

            try
            {
                studentManager.Add(sv);
                HienThiDanhSachSinhVien(studentManager.Students);
                MessageBox.Show($"Thêm mới sinh viên '{sv.HoVaTenDayDu}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin(out Student sv, laThemMoi: false))
            {
                return;
            }

            try
            {
                studentManager.Update(sv);
                HienThiDanhSachSinhVien(studentManager.Students);
                MessageBox.Show($"Cập nhật thông tin sinh viên '{sv.HoVaTenDayDu}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dr = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các lớp hiện có để đưa vào combobox tìm kiếm
            var dsLop = studentManager.Students.Select(s => s.Lop).Distinct();
            using (var formTk = new FormTimKiem(dsLop))
            {
                if (formTk.ShowDialog(this) == DialogResult.OK)
                {
                    if (formTk.IsCleared)
                    {
                        HienThiDanhSachSinhVien(studentManager.Students);
                    }
                    else
                    {
                        var ketQua = studentManager.Search(formTk.SearchMSSV, formTk.SearchTen, formTk.SearchLop);
                        HienThiDanhSachSinhVien(ketQua);
                        MessageBox.Show($"Tìm thấy {ketQua.Count} sinh viên phù hợp!", "Kết quả tìm kiếm",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion

        #region ContextMenu Môn học (Thêm môn, Xóa môn)

        private void mnuThemMonHoc_Click(object sender, EventArgs e)
        {
            string monMoi = InputPromptForm.Show(this, "Thêm môn học", "Nhập tên môn học mới:");
            if (!string.IsNullOrWhiteSpace(monMoi))
            {
                monMoi = monMoi.Trim();
                foreach (var item in clbMonHoc.Items)
                {
                    if (item.ToString().Equals(monMoi, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Môn học này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                clbMonHoc.Items.Add(monMoi, true);
                MessageBox.Show($"Đã thêm môn học '{monMoi}'!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuXoaMonHoc_Click(object sender, EventArgs e)
        {
            if (clbMonHoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhấp chọn môn học cần xóa trong danh sách trước khi nhấp chuột phải!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string monChon = clbMonHoc.SelectedItem.ToString();
            var dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa môn học '{monChon}' khỏi danh sách?",
                                     "Xác nhận xóa môn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                clbMonHoc.Items.Remove(clbMonHoc.SelectedItem);
            }
        }

        #endregion

        #region ContextMenu Danh sách sinh viên (Xóa sinh viên, Đổi định dạng)

        private void mnuXoaSinhVien_Click(object sender, EventArgs e)
        {
            var dsMssvXoa = new List<string>();

            // 1. Lấy từ các dòng có đánh dấu checkbox
            if (lvSinhVien.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in lvSinhVien.CheckedItems)
                {
                    dsMssvXoa.Add(item.SubItems[0].Text);
                }
            }
            // 2. Nếu không có dòng nào được check, lấy dòng đang được click chọn
            else if (lvSinhVien.SelectedItems.Count > 0)
            {
                dsMssvXoa.Add(lvSinhVien.SelectedItems[0].SubItems[0].Text);
            }

            if (dsMssvXoa.Count == 0)
            {
                MessageBox.Show("Vui lòng tích vào checkbox hoặc chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa {dsMssvXoa.Count} sinh viên đã chọn không?",
                                     "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int count = studentManager.DeleteMany(dsMssvXoa);
                HienThiDanhSachSinhVien(studentManager.Students);
                XoaTrangForm();
                MessageBox.Show($"Đã xóa thành công {count} sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuTaiLaiDanhSach_Click(object sender, EventArgs e)
        {
            HienThiDanhSachSinhVien(studentManager.Students);
        }

        private void mnuDinhDangTxt_Click(object sender, EventArgs e)
        {
            DoiDinhDangLuuTru(new TxtStudentStorage(), currentTxtPath, mnuDinhDangTxt);
        }

        private void mnuDinhDangXml_Click(object sender, EventArgs e)
        {
            DoiDinhDangLuuTru(new XmlStudentStorage(), currentXmlPath, mnuDinhDangXml);
        }

        private void mnuDinhDangJson_Click(object sender, EventArgs e)
        {
            DoiDinhDangLuuTru(new JsonStudentStorage(), currentJsonPath, mnuDinhDangJson);
        }

        private void DoiDinhDangLuuTru(IStudentStorage storageMoi, string pathMoi, ToolStripMenuItem mnuChon)
        {
            try
            {
                // Lưu danh sách hiện tại theo định dạng mới
                storageMoi.Write(pathMoi, studentManager.Students);

                studentManager.Storage = storageMoi;
                studentManager.FilePath = pathMoi;

                mnuDinhDangTxt.Checked = (mnuChon == mnuDinhDangTxt);
                mnuDinhDangXml.Checked = (mnuChon == mnuDinhDangXml);
                mnuDinhDangJson.Checked = (mnuChon == mnuDinhDangJson);

                MessageBox.Show($"Đã chuyển định dạng lưu trữ sang: {Path.GetFileName(pathMoi)} và lưu thành công!",
                                "Đổi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển định dạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
