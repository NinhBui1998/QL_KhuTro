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
    public partial class frm_vipham : DevExpress.XtraEditors.XtraForm
    {
        DAL_ViPham dal_vipham = new DAL_ViPham();
        BLL_ViPham bll_vipham = new BLL_ViPham();
        BLL_NoiQuy bll_noiquy = new BLL_NoiQuy();
        BLL_KhachThue bll_khachthue = new BLL_KhachThue();
        BLL_Phong bll_phong = new BLL_Phong();
        public frm_vipham()
        {
            InitializeComponent();
        }
        string Manv;

        public string MaNV { get => Manv; set => Manv = value; }

        private void frm_vipham_Load(object sender, EventArgs e)
        {
            cbb_manoiquy.DataSource = bll_noiquy.loadBang_NoiQuy();
            //cbb_manoiquy.ValueMember = "NOIDUNG";
            cbb_manoiquy.DisplayMember = "MANOIQUY";
            grv_vipham.DataSource = bll_vipham.LoadViPham();
            grv_khachthue.DataSource = bll_khachthue.loadBangKT();
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";
            txt_manv.Text = MaNV;

            btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_huy.Enabled = btn_luu.Enabled = false;
            btn_them.Enabled = true;
            txt_solan.Enabled = txt_ghichu.Enabled = false;
            txt_ngayvipham.Text = DateTime.Now.ToShortDateString();

        }
        
       

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = bll_khachthue.loadBangKT();
            grv_vipham.DataSource = bll_vipham.LoadViPham();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = bll_khachthue.loadBangKTtheoma(cbo_phong.SelectedValue.ToString());

        }

        private void grv_khachthue_Click(object sender, EventArgs e)
        {
            int position = gridView_kt.FocusedRowHandle;
            try
            {
                string MAKT = gridView_kt.GetRowCellValue(position, "MAKT").ToString();
               
                grv_vipham.DataSource = bll_vipham.Loadviphamtheoma(MAKT);
            }
            catch
            {
                return;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_solan.Enabled = txt_ghichu.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_huy.Enabled = btn_luu.Enabled = true;
        }

        private void grv_vipham_Click(object sender, EventArgs e)
        {
            int position = gridView_ViPham.FocusedRowHandle;
            try
            {
                txt_solan.Text = gridView_ViPham.GetRowCellValue(position, "Solan").ToString();
               // txt_ghichu.Text = gridView_ViPham.GetRowCellValue(position, "Ghichu").ToString();
                cbb_manoiquy.Text = gridView_ViPham.GetRowCellValue(position, "Manoiquy").ToString();
                txt_noidung.Text = gridView_ViPham.GetRowCellValue(position, "Noidung").ToString();

                btn_sua.Enabled = true;
                btn_xoa.Enabled = true;
                btn_them.Enabled = true;

            }
            catch { }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_solan.Clear();
            txt_ghichu.Clear();
            btn_them.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            btn_luu.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            VIPHAM vp = new VIPHAM();
            int position = gridView_kt.FocusedRowHandle;
            vp.MANOIQUY = gridView_ViPham.GetRowCellValue(position, "Manoiquy").ToString();
            vp.MAKT = gridView_ViPham.GetRowCellValue(position, "Makt").ToString();

            if (bll_vipham.xoa_vipham(vp.MANOIQUY,vp.MAKT) == true)
            {
                MessageBox.Show("Xóa thành công");
                grv_vipham.DataSource = bll_vipham.Loadviphamtheoma(vp.MAKT);
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            txt_solan.Enabled = txt_ghichu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int position = gridView_kt.FocusedRowHandle;
         
            string MAKT = gridView_kt.GetRowCellValue(position, "MAKT").ToString();
          
            VIPHAM vp = new VIPHAM();
            vp.MANOIQUY = cbb_manoiquy.Text;
            vp.MAKT = MAKT;
            vp.NGAYVIPHAM = Convert.ToDateTime(txt_ngayvipham.Text);
            vp.SOLAN =Convert.ToInt32( txt_solan.Text);
            vp.GHICHU = txt_ghichu.Text;
            vp.MANV = txt_manv.Text;
            if(txt_solan.Text==string.Empty)
            {
                MessageBox.Show("Không được để trống");
            }    
            if(btn_them.Enabled==true && btn_sua.Enabled==false)
            {
                if(bll_vipham.them_vipham(vp)==true)
                {
                    MessageBox.Show("Thêm thành công");
                    grv_vipham.DataSource = bll_vipham.Loadviphamtheoma(MAKT);
                }    
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }    
            }
            if (btn_them.Enabled == false && btn_sua.Enabled == true)
            {

                    vp.MANOIQUY = gridView_ViPham.GetRowCellValue(position, "Manoiquy").ToString();
                    vp.MAKT= gridView_ViPham.GetRowCellValue(position, "Makt").ToString();

                if (bll_vipham.sua_vipham(vp) == true)
                {
                    MessageBox.Show("sửa thành công");
                    grv_vipham.DataSource = bll_vipham.Loadviphamtheoma(MAKT);
                }
                else
                {
                    MessageBox.Show("sửa thất bại");
                }
            }
          
          
        }

        private void cbb_manoiquy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbb_manoiquy_Click(object sender, EventArgs e)
        {
            NOIQUY nq = new NOIQUY();
            nq = dal_vipham.loadnoiquy(cbb_manoiquy.Text);
            txt_noidung.Text = nq.NOIDUNG;
            txt_hinhphat.Text = String.Format("{0:#,##0.##}",Convert.ToDecimal( nq.HINHPHAT)); ;
        }
    }
}