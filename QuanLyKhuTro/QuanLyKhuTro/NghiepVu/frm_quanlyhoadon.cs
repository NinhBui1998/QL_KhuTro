using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using BLL.NghiepVu;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_quanlyhoadon : UserControl
    {
        BLL_TienPhongHangThang bll_tienPhong = new BLL_TienPhongHangThang();
        BLL_Phong bll_phong = new BLL_Phong();
        public frm_quanlyhoadon()
        {
            InitializeComponent();
        }

        private void frm_quanlyhoadon_Load(object sender, EventArgs e)
        {
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";
            grv_hoadon.DataSource = bll_tienPhong.LoadDataHoaDon();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_hoadon.DataSource = bll_tienPhong.LoadDataHoaDontheomaphong(cbo_phong.SelectedValue.ToString());
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_hoadon.DataSource = bll_tienPhong.LoadDataHoaDon();
        }
    }
}
