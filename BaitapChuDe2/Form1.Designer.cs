namespace BaitapChuDe2
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnBai1 = new System.Windows.Forms.Button();
            this.btnBai2 = new System.Windows.Forms.Button();
            this.btnBai3 = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(85, 25);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(374, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÀI TẬP CHỦ ĐỀ 2 - WINDOWS FORMS";
            // 
            // btnBai1
            // 
            this.btnBai1.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBai1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBai1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBai1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBai1.Location = new System.Drawing.Point(50, 100);
            this.btnBai1.Name = "btnBai1";
            this.btnBai1.Size = new System.Drawing.Size(440, 50);
            this.btnBai1.TabIndex = 1;
            this.btnBai1.Text = "Bài 1: Quản lý giảng viên (frmGiangVien)";
            this.btnBai1.UseVisualStyleBackColor = false;
            this.btnBai1.Click += new System.EventHandler(this.btnBai1_Click);
            // 
            // btnBai2
            // 
            this.btnBai2.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBai2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBai2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBai2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBai2.Location = new System.Drawing.Point(50, 165);
            this.btnBai2.Name = "btnBai2";
            this.btnBai2.Size = new System.Drawing.Size(440, 50);
            this.btnBai2.TabIndex = 2;
            this.btnBai2.Text = "Bài 2: Quản lý sinh viên đơn giản (Demo Sinh viên)";
            this.btnBai2.UseVisualStyleBackColor = false;
            this.btnBai2.Click += new System.EventHandler(this.btnBai2_Click);
            // 
            // btnBai3
            // 
            this.btnBai3.BackColor = System.Drawing.Color.AliceBlue;
            this.btnBai3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBai3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBai3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBai3.Location = new System.Drawing.Point(50, 230);
            this.btnBai3.Name = "btnBai3";
            this.btnBai3.Size = new System.Drawing.Size(440, 50);
            this.btnBai3.TabIndex = 3;
            this.btnBai3.Text = "Bài 3: Quản lý sinh viên khoa CNTT";
            this.btnBai3.UseVisualStyleBackColor = false;
            this.btnBai3.Click += new System.EventHandler(this.btnBai3_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(215, 305);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 35);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.Color.Gray;
            this.lblMoTa.Location = new System.Drawing.Point(120, 65);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(301, 15);
            this.lblMoTa.TabIndex = 5;
            this.lblMoTa.Text = "Chọn bài tập cần chạy để mở form tương ứng độc lập:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 360);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnBai3);
            this.Controls.Add(this.btnBai2);
            this.Controls.Add(this.btnBai1);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Bài tập Chủ đề 2";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnBai1;
        private System.Windows.Forms.Button btnBai2;
        private System.Windows.Forms.Button btnBai3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblMoTa;
    }
}
