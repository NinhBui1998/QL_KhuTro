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
using DAL;
using BLL;
using BLL.ThongKe;
using QuanLyKhuTro.user_thongke;
using QuanLyKhuTro.user_thongkePhong;

namespace QuanLyKhuTro.ThongKe
{
    public partial class frm_tkphong : DevExpress.XtraEditors.XtraForm
    {
        BLL_ThongKePhong bll_tkphong = new BLL_ThongKePhong();
        public frm_tkphong()
        {
            InitializeComponent();
        }

        private void frm_tkphong_Load(object sender, EventArgs e)
        {
           

        }

        private void btn_phongdc_Click(object sender, EventArgs e)
        {
            frm_dsphongdcoc vp = new frm_dsphongdcoc();
            vp.TopLevel = false;
            pnl_tkp.Controls.Clear();
            pnl_tkp.Controls.Add(vp);
            vp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            vp.Dock = DockStyle.Fill;
            vp.Show();
        }

        private void btn_xemphongtrong_Click(object sender, EventArgs e)
        {
            frm_tongphong vp = new frm_tongphong();
            vp.TopLevel = false;
            pnl_tkp.Controls.Clear();
            pnl_tkp.Controls.Add(vp);
            vp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            vp.Dock = DockStyle.Fill;
            vp.Show();
        }

        private void btn_xemphongtrong_Click_1(object sender, EventArgs e)
        {
            frm_phongtrong vp = new frm_phongtrong();
            vp.TopLevel = false;
            pnl_tkp.Controls.Clear();
            pnl_tkp.Controls.Add(vp);
            vp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            vp.Dock = DockStyle.Fill;
            vp.Show();
        }

        private void btn_xemphongxokhachthue_Click(object sender, EventArgs e)
        {
            frm_dsphongcokhach vp = new frm_dsphongcokhach();
            vp.TopLevel = false;
            pnl_tkp.Controls.Clear();
            pnl_tkp.Controls.Add(vp);
            vp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            vp.Dock = DockStyle.Fill;
            vp.Show();
        }

        private void btn_xemphongst_Click(object sender, EventArgs e)
        {

        }
    }
}