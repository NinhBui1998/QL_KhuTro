using QuanLyKhuTro.DanhMuc;
using QuanLyKhuTro.HeThong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhuTro
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_main());
            //Application.Run(new frm_dangnhap());
            //Application.Run(new frm_dangnhap());
        }
    }
}
