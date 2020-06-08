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

        private void btn_datphong_Click(object sender, EventArgs e)
        {
            frm_datphong frm = new frm_datphong();
            frm.ShowDialog();
        }

        private void btn_traphong_Click(object sender, EventArgs e)
        {
            frm_traphong frm = new frm_traphong();
            frm.ShowDialog();
        }
    }
}