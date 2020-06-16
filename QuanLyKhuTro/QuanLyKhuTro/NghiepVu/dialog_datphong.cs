using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class dialog_datphong : DevExpress.XtraEditors.XtraForm
    {
        public dialog_datphong()
        {
            InitializeComponent();
        }
        string TENPHONG;
        public string TenPhong
        {
            get { return TENPHONG; }
            set { TENPHONG = value; }
        }
        private void btn_datphong_Click(object sender, EventArgs e)
        {
            frm_datphong frm = new frm_datphong();
            frm.TenPhong = TENPHONG;
            frm.Show();
            Visible = false;
           // this.Close();
        }

        private void btn_traphong_Click(object sender, EventArgs e)
        {
            frm_traphong frm = new frm_traphong();
            frm.TenPhong = TENPHONG;
            frm.Show();
            Visible = false;
        }

        private void dialog_datphong_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_test frm = new frm_test();
            frm.Show();

        }
    }
}