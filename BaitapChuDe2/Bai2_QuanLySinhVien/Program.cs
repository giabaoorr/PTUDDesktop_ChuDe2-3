using System;
using System.Windows.Forms;

namespace BaitapChuDe2.Bai2_QuanLySinhVien
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSinhVien());
        }
    }
}
