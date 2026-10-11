using System.Windows.Forms;

namespace BaitapChuDe2.Bai1_QuanLyGiangVien
{
    public partial class frmTBGiangVien : Form
    {
        public frmTBGiangVien()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.lblThongBao.Text = text;
        }
    }
}
