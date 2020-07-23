using QuanLyKhuTro.DanhMuc;
using QuanLyKhuTro.HeThong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhuTro
{
   public static class Program
    {
        public static frm_dangnhap frm_dn;
        public static frm_main frm_nain;
        public static frm_test frm_dsp;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_main());
            Application.Run(frm_dn= new frm_dangnhap());
         
            //Application.Run(new frm_thietbiphong());
        }
    }
}
