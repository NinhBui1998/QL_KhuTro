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
using DAL.NghiepVu;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_vipham : DevExpress.XtraEditors.XtraUserControl
    {
        DAL_ViPham dal_vipham = new DAL_ViPham();
        BLL_ViPham vipham = new BLL_ViPham();
        BLL_NoiQuy noiquy = new BLL_NoiQuy();     
        public frm_vipham()
        {
            InitializeComponent();
        }
      
        private void frm_vipham_Load(object sender, EventArgs e)
        {
            cbb_manoiquy.DataSource = noiquy.loadBang_NoiQuy();
            cbb_manoiquy.ValueMember = "MANOIQUY";
            // cbb_manoiquy.DisplayMember = "NOIDUNG";
            grv_vipham.DataSource = vipham.LoadViPham();
        }
        
        private void cbb_manoiquy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbb_manoiquy_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbb_manoiquy_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            
        }
    }
}