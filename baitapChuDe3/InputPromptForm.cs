using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitapChuDe3
{
    /// <summary>
    /// Hộp thoại đơn giản để người dùng nhập chuỗi (như tên môn học mới)
    /// </summary>
    public class InputPromptForm : Form
    {
        private TextBox txtInput;
        private Button btnOk;
        private Button btnCancel;
        private Label lblMessage;

        public string InputText => txtInput.Text.Trim();

        public InputPromptForm(string title, string prompt, string defaultValue = "")
        {
            this.Text = title;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(380, 130);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);

            lblMessage = new Label
            {
                Text = prompt,
                Location = new Point(16, 16),
                AutoSize = true
            };

            txtInput = new TextBox
            {
                Text = defaultValue,
                Location = new Point(18, 42),
                Size = new Size(344, 25)
            };

            btnOk = new Button
            {
                Text = "Đồng ý",
                DialogResult = DialogResult.OK,
                Location = new Point(190, 80),
                Size = new Size(80, 30),
                UseVisualStyleBackColor = true
            };

            btnCancel = new Button
            {
                Text = "Hủy",
                DialogResult = DialogResult.Cancel,
                Location = new Point(282, 80),
                Size = new Size(80, 30),
                UseVisualStyleBackColor = true
            };

            this.Controls.Add(lblMessage);
            this.Controls.Add(txtInput);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        public static string Show(IWin32Window owner, string title, string prompt, string defaultValue = "")
        {
            using (var form = new InputPromptForm(title, prompt, defaultValue))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    return form.InputText;
                }
            }
            return null;
        }
    }
}
