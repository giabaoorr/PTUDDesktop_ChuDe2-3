namespace baitapChuDe3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.mtxtMSSV = new System.Windows.Forms.MaskedTextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.rbNam = new System.Windows.Forms.RadioButton();
            this.rbNu = new System.Windows.Forms.RadioButton();
            this.lblHoTenLot = new System.Windows.Forms.Label();
            this.txtHoTenLot = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.mtxtCMND = new System.Windows.Forms.MaskedTextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.mtxtSDT = new System.Windows.Forms.MaskedTextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.clbMonHoc = new System.Windows.Forms.CheckedListBox();
            this.contextMenuMonHoc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuThemMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXoaMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbDanhSach = new System.Windows.Forms.GroupBox();
            this.lvSinhVien = new System.Windows.Forms.ListView();
            this.colMSSV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHoTenLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgaySinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCMND = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuSinhVien = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuXoaSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSep = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDinhDang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDinhDangTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDinhDangXml = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDinhDangJson = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaiLaiDanhSach = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuMonHoc.SuspendLayout();
            this.gbDanhSach.SuspendLayout();
            this.contextMenuSinhVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Location = new System.Drawing.Point(30, 28);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(49, 17);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV :";
            // 
            // mtxtMSSV
            // 
            this.mtxtMSSV.Location = new System.Drawing.Point(135, 25);
            this.mtxtMSSV.Mask = "0000000";
            this.mtxtMSSV.Name = "mtxtMSSV";
            this.mtxtMSSV.Size = new System.Drawing.Size(185, 24);
            this.mtxtMSSV.TabIndex = 1;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(345, 28);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(63, 17);
            this.lblGioiTinh.TabIndex = 2;
            this.lblGioiTinh.Text = "Giới tính :";
            // 
            // rbNam
            // 
            this.rbNam.AutoSize = true;
            this.rbNam.Checked = true;
            this.rbNam.Location = new System.Drawing.Point(425, 26);
            this.rbNam.Name = "rbNam";
            this.rbNam.Size = new System.Drawing.Size(54, 21);
            this.rbNam.TabIndex = 3;
            this.rbNam.TabStop = true;
            this.rbNam.Text = "Nam";
            this.rbNam.UseVisualStyleBackColor = true;
            // 
            // rbNu
            // 
            this.rbNu.AutoSize = true;
            this.rbNu.Location = new System.Drawing.Point(505, 26);
            this.rbNu.Name = "rbNu";
            this.rbNu.Size = new System.Drawing.Size(44, 21);
            this.rbNu.TabIndex = 4;
            this.rbNu.Text = "Nữ";
            this.rbNu.UseVisualStyleBackColor = true;
            // 
            // lblHoTenLot
            // 
            this.lblHoTenLot.AutoSize = true;
            this.lblHoTenLot.Location = new System.Drawing.Point(30, 63);
            this.lblHoTenLot.Name = "lblHoTenLot";
            this.lblHoTenLot.Size = new System.Drawing.Size(90, 17);
            this.lblHoTenLot.TabIndex = 5;
            this.lblHoTenLot.Text = "Họ và tên lót :";
            // 
            // txtHoTenLot
            // 
            this.txtHoTenLot.Location = new System.Drawing.Point(135, 60);
            this.txtHoTenLot.Name = "txtHoTenLot";
            this.txtHoTenLot.Size = new System.Drawing.Size(185, 24);
            this.txtHoTenLot.TabIndex = 6;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(345, 63);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(35, 17);
            this.lblTen.TabIndex = 7;
            this.lblTen.Text = "Tên :";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(425, 60);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(195, 24);
            this.txtTen.TabIndex = 8;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 98);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(73, 17);
            this.lblNgaySinh.TabIndex = 9;
            this.lblNgaySinh.Text = "Ngày sinh :";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(135, 95);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(185, 24);
            this.dtpNgaySinh.TabIndex = 10;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(345, 98);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(37, 17);
            this.lblLop.TabIndex = 11;
            this.lblLop.Text = "Lớp :";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(425, 95);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(195, 25);
            this.cboLop.TabIndex = 12;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Location = new System.Drawing.Point(30, 133);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(73, 17);
            this.lblCMND.TabIndex = 13;
            this.lblCMND.Text = "Số CMND :";
            // 
            // mtxtCMND
            // 
            this.mtxtCMND.Location = new System.Drawing.Point(135, 130);
            this.mtxtCMND.Mask = "000000000";
            this.mtxtCMND.Name = "mtxtCMND";
            this.mtxtCMND.Size = new System.Drawing.Size(185, 24);
            this.mtxtCMND.TabIndex = 14;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(345, 133);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(50, 17);
            this.lblSDT.TabIndex = 15;
            this.lblSDT.Text = "Số ĐT :";
            // 
            // mtxtSDT
            // 
            this.mtxtSDT.Location = new System.Drawing.Point(425, 130);
            this.mtxtSDT.Mask = "0000.000.000";
            this.mtxtSDT.Name = "mtxtSDT";
            this.mtxtSDT.Size = new System.Drawing.Size(195, 24);
            this.mtxtSDT.TabIndex = 16;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(30, 168);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(98, 17);
            this.lblDiaChi.TabIndex = 17;
            this.lblDiaChi.Text = "Địa chỉ liên lạc :";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(135, 165);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(485, 24);
            this.txtDiaChi.TabIndex = 18;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(30, 203);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(117, 17);
            this.lblMonHoc.TabIndex = 19;
            this.lblMonHoc.Text = "Môn học đăng ký :";
            // 
            // clbMonHoc
            // 
            this.clbMonHoc.CheckOnClick = true;
            this.clbMonHoc.ColumnWidth = 240;
            this.clbMonHoc.ContextMenuStrip = this.contextMenuMonHoc;
            this.clbMonHoc.FormattingEnabled = true;
            this.clbMonHoc.Location = new System.Drawing.Point(135, 200);
            this.clbMonHoc.MultiColumn = true;
            this.clbMonHoc.Name = "clbMonHoc";
            this.clbMonHoc.Size = new System.Drawing.Size(485, 80);
            this.clbMonHoc.TabIndex = 20;
            // 
            // contextMenuMonHoc
            // 
            this.contextMenuMonHoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThemMonHoc,
            this.mnuXoaMonHoc});
            this.contextMenuMonHoc.Name = "contextMenuMonHoc";
            this.contextMenuMonHoc.Size = new System.Drawing.Size(192, 48);
            // 
            // mnuThemMonHoc
            // 
            this.mnuThemMonHoc.Name = "mnuThemMonHoc";
            this.mnuThemMonHoc.Size = new System.Drawing.Size(191, 22);
            this.mnuThemMonHoc.Text = "Thêm môn học...";
            this.mnuThemMonHoc.Click += new System.EventHandler(this.mnuThemMonHoc_Click);
            // 
            // mnuXoaMonHoc
            // 
            this.mnuXoaMonHoc.Name = "mnuXoaMonHoc";
            this.mnuXoaMonHoc.Size = new System.Drawing.Size(191, 22);
            this.mnuXoaMonHoc.Text = "Xóa môn học đã chọn";
            this.mnuXoaMonHoc.Click += new System.EventHandler(this.mnuXoaMonHoc_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(235, 298);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 30);
            this.btnTimKiem.TabIndex = 21;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(335, 298);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(85, 30);
            this.btnThemMoi.TabIndex = 22;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(435, 298);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(85, 30);
            this.btnCapNhat.TabIndex = 23;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(535, 298);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(85, 30);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // gbDanhSach
            // 
            this.gbDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDanhSach.Controls.Add(this.lvSinhVien);
            this.gbDanhSach.Location = new System.Drawing.Point(15, 338);
            this.gbDanhSach.Name = "gbDanhSach";
            this.gbDanhSach.Size = new System.Drawing.Size(625, 220);
            this.gbDanhSach.TabIndex = 25;
            this.gbDanhSach.TabStop = false;
            this.gbDanhSach.Text = "Danh sách sinh viên";
            // 
            // lvSinhVien
            // 
            this.lvSinhVien.CheckBoxes = true;
            this.lvSinhVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMSSV,
            this.colHoTenLot,
            this.colTen,
            this.colNgaySinh,
            this.colLop,
            this.colCMND,
            this.colSDT,
            this.colDiaChi});
            this.lvSinhVien.ContextMenuStrip = this.contextMenuSinhVien;
            this.lvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSinhVien.FullRowSelect = true;
            this.lvSinhVien.GridLines = true;
            this.lvSinhVien.HideSelection = false;
            this.lvSinhVien.Location = new System.Drawing.Point(3, 20);
            this.lvSinhVien.Name = "lvSinhVien";
            this.lvSinhVien.Size = new System.Drawing.Size(619, 197);
            this.lvSinhVien.TabIndex = 0;
            this.lvSinhVien.UseCompatibleStateImageBehavior = false;
            this.lvSinhVien.View = System.Windows.Forms.View.Details;
            this.lvSinhVien.SelectedIndexChanged += new System.EventHandler(this.lvSinhVien_SelectedIndexChanged);
            // 
            // colMSSV
            // 
            this.colMSSV.Text = "MSSV";
            this.colMSSV.Width = 75;
            // 
            // colHoTenLot
            // 
            this.colHoTenLot.Text = "Họ và tên lót";
            this.colHoTenLot.Width = 125;
            // 
            // colTen
            // 
            this.colTen.Text = "Tên";
            this.colTen.Width = 65;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Text = "Ngày sinh";
            this.colNgaySinh.Width = 85;
            // 
            // colLop
            // 
            this.colLop.Text = "Lớp";
            this.colLop.Width = 65;
            // 
            // colCMND
            // 
            this.colCMND.Text = "Số CMND";
            this.colCMND.Width = 85;
            // 
            // colSDT
            // 
            this.colSDT.Text = "Số điện thoại";
            this.colSDT.Width = 95;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Text = "Địa chỉ liên lạc";
            this.colDiaChi.Width = 160;
            // 
            // contextMenuSinhVien
            // 
            this.contextMenuSinhVien.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuXoaSinhVien,
            this.toolStripMenuItemSep,
            this.mnuDinhDang,
            this.mnuTaiLaiDanhSach});
            this.contextMenuSinhVien.Name = "contextMenuSinhVien";
            this.contextMenuSinhVien.Size = new System.Drawing.Size(191, 76);
            // 
            // mnuXoaSinhVien
            // 
            this.mnuXoaSinhVien.Name = "mnuXoaSinhVien";
            this.mnuXoaSinhVien.Size = new System.Drawing.Size(190, 22);
            this.mnuXoaSinhVien.Text = "Xóa sinh viên đã chọn";
            this.mnuXoaSinhVien.Click += new System.EventHandler(this.mnuXoaSinhVien_Click);
            // 
            // toolStripMenuItemSep
            // 
            this.toolStripMenuItemSep.Name = "toolStripMenuItemSep";
            this.toolStripMenuItemSep.Size = new System.Drawing.Size(187, 6);
            // 
            // mnuDinhDang
            // 
            this.mnuDinhDang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDinhDangTxt,
            this.mnuDinhDangXml,
            this.mnuDinhDangJson});
            this.mnuDinhDang.Name = "mnuDinhDang";
            this.mnuDinhDang.Size = new System.Drawing.Size(190, 22);
            this.mnuDinhDang.Text = "Định dạng lưu trữ";
            // 
            // mnuDinhDangTxt
            // 
            this.mnuDinhDangTxt.Checked = true;
            this.mnuDinhDangTxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuDinhDangTxt.Name = "mnuDinhDangTxt";
            this.mnuDinhDangTxt.Size = new System.Drawing.Size(143, 22);
            this.mnuDinhDangTxt.Text = "Text (*.txt)";
            this.mnuDinhDangTxt.Click += new System.EventHandler(this.mnuDinhDangTxt_Click);
            // 
            // mnuDinhDangXml
            // 
            this.mnuDinhDangXml.Name = "mnuDinhDangXml";
            this.mnuDinhDangXml.Size = new System.Drawing.Size(143, 22);
            this.mnuDinhDangXml.Text = "XML (*.xml)";
            this.mnuDinhDangXml.Click += new System.EventHandler(this.mnuDinhDangXml_Click);
            // 
            // mnuDinhDangJson
            // 
            this.mnuDinhDangJson.Name = "mnuDinhDangJson";
            this.mnuDinhDangJson.Size = new System.Drawing.Size(143, 22);
            this.mnuDinhDangJson.Text = "JSON (*.json)";
            this.mnuDinhDangJson.Click += new System.EventHandler(this.mnuDinhDangJson_Click);
            // 
            // mnuTaiLaiDanhSach
            // 
            this.mnuTaiLaiDanhSach.Name = "mnuTaiLaiDanhSach";
            this.mnuTaiLaiDanhSach.Size = new System.Drawing.Size(190, 22);
            this.mnuTaiLaiDanhSach.Text = "Hiển thị lại toàn bộ";
            this.mnuTaiLaiDanhSach.Click += new System.EventHandler(this.mnuTaiLaiDanhSach_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 571);
            this.Controls.Add(this.gbDanhSach);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.clbMonHoc);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.mtxtSDT);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.mtxtCMND);
            this.Controls.Add(this.lblCMND);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtHoTenLot);
            this.Controls.Add(this.lblHoTenLot);
            this.Controls.Add(this.rbNu);
            this.Controls.Add(this.rbNam);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.mtxtMSSV);
            this.Controls.Add(this.lblMSSV);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin sinh viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuMonHoc.ResumeLayout(false);
            this.gbDanhSach.ResumeLayout(false);
            this.contextMenuSinhVien.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.MaskedTextBox mtxtMSSV;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.RadioButton rbNam;
        private System.Windows.Forms.RadioButton rbNu;
        private System.Windows.Forms.Label lblHoTenLot;
        private System.Windows.Forms.TextBox txtHoTenLot;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.MaskedTextBox mtxtCMND;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.MaskedTextBox mtxtSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.CheckedListBox clbMonHoc;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox gbDanhSach;
        private System.Windows.Forms.ListView lvSinhVien;
        private System.Windows.Forms.ColumnHeader colMSSV;
        private System.Windows.Forms.ColumnHeader colHoTenLot;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colNgaySinh;
        private System.Windows.Forms.ColumnHeader colLop;
        private System.Windows.Forms.ColumnHeader colCMND;
        private System.Windows.Forms.ColumnHeader colSDT;
        private System.Windows.Forms.ColumnHeader colDiaChi;
        private System.Windows.Forms.ContextMenuStrip contextMenuMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuThemMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuXoaMonHoc;
        private System.Windows.Forms.ContextMenuStrip contextMenuSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuXoaSinhVien;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSep;
        private System.Windows.Forms.ToolStripMenuItem mnuDinhDang;
        private System.Windows.Forms.ToolStripMenuItem mnuDinhDangTxt;
        private System.Windows.Forms.ToolStripMenuItem mnuDinhDangXml;
        private System.Windows.Forms.ToolStripMenuItem mnuDinhDangJson;
        private System.Windows.Forms.ToolStripMenuItem mnuTaiLaiDanhSach;
    }
}
