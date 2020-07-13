using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_dialog : Form
    {
        public frm_dialog()
        {
            InitializeComponent();
        }
        string TENPHONG;
        public string TenPhong
        {
            get { return TENPHONG; }
            set { TENPHONG = value; }
        }

        string MAnv;
        public string MaNhanVien
        {
            get { return MAnv; }
            set { MAnv = value; }
        }
        private void frm_dialog_Load(object sender, EventArgs e)
        {

        }

        private void btn_datphong_Click(object sender, EventArgs e)
        {
            frm_datphong frm = new frm_datphong();
            frm.TenPhong = TENPHONG;
            frm.MaNhanVien = MAnv;
            Visible = false;
            frm.ShowDialog();
        }

        private void frm_dialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_test frm = new frm_test();
            frm.MaNhanVien = MAnv;
            Visible = false;
            frm.ShowDialog();
        }

        private void btn_traphong_Click(object sender, EventArgs e)
        {
            frm_traphong frm = new frm_traphong();
            frm.TenPhong = TENPHONG;
            frm.MaNhanVien = MAnv;
            Visible = false;
            frm.ShowDialog();
        }
    }
}
