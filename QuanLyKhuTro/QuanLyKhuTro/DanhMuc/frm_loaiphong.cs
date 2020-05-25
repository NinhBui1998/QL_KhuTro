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
using BLL;
using DAL;

namespace QuanLyKhuTro.DanhMuc
{
    public partial class frm_loaiphong : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_LoaiPhong blp = new BLL_LoaiPhong();
        LOAIPHONG loaip = new LOAIPHONG();
        public frm_loaiphong()
        {
            InitializeComponent();
        }

        private void frm_loaiphong_Load(object sender, EventArgs e)
        {
            txt_maloai.Enabled = txt_tenloai.Enabled = txt_gia.Enabled = false;
            btn_huy.Enabled = btn_luu.Enabled = btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_them.Enabled = true;
            grv_loaiPhong.DataSource = blp.loadBangLoaiPhong();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_maloai.Clear();
            txt_gia.Clear();
            txt_tenloai.Clear();
            frm_loaiphong_Load(sender,e);
        }
    }
}