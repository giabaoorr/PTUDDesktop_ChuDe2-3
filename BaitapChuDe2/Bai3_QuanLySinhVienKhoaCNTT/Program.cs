using System;
using System.Windows.Forms;

namespace BaitapChuDe2.Bai3_QuanLySinhVienKhoaCNTT
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmQLSinhVienKhoaCNTT());
        }
    }
}
