using System;
using System.Windows.Forms;

namespace BaitapChuDe2.Bai1_QuanLyGiangVien
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmGiangVien());
        }
    }
}
