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

namespace QuanLyKhuTro.DanhMuc
{
    public partial class frm_thietbiphong : Form
    {
        BLL_ThietBi bll_thietbi = new BLL_ThietBi();
        BLL_Phong bll_phong = new BLL_Phong();
        public frm_thietbiphong()
        {
            InitializeComponent();
        }

        private void frm_thietbiphong_Load(object sender, EventArgs e)
        {
            
            cbo_matb.DataSource = bll_thietbi.loadBang_TB();
            //cbo_matb.DisplayMember = "MATB";
            cbo_matb.ValueMember = "MATHIETBI";

            cbo_tenphong.DataSource = bll_phong.loadBang_Phong();
            cbo_tenphong.DisplayMember = "TENPHONG";
            cbo_tenphong.ValueMember = "MAPHONG";
            grv_thietbiphong.DataSource = bll_thietbi.loadBang_TBPhong();

            btn_them.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = btn_xoa.Enabled = btn_luu.Enabled = false;
            txt_tentb.Enabled = false;
            txt_tinhtrangtb.Enabled = false;

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_tinhtrangtb.Clear();
            frm_thietbiphong_Load(sender,e);
        }

        private void grv_thietbiphong_Click(object sender, EventArgs e)
        {
          
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView1.FocusedRowHandle;
            try
            {
                cbo_matb.Text = gridView1.GetRowCellValue(position, "MATHIETBI").ToString();
               cbo_tenphong.Text = gridView1.GetRowCellValue(position, "MAPHONG").ToString();
                txt_tinhtrangtb.Text = gridView1.GetRowCellValue(position, "TRANGTHAI").ToString();
                txt_tentb.Text = bll_thietbi.laytenthietbi(gridView1.GetRowCellValue(position, "MATHIETBI").ToString());

            }
            catch { }
        }

        private void cbo_matb_Click(object sender, EventArgs e)
        {

            txt_tentb.Text = bll_thietbi.laytenthietbi(cbo_matb.Text);
        }

      

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = btn_huy.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_tinhtrangtb.Enabled = true;
            txt_tinhtrangtb.Clear();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if(txt_tinhtrangtb.Text==string.Empty)
            {
                MessageBox.Show("Nhập trạng thái thiết bị");
                return;
            }
            THIETBI_PHONG tbp = new THIETBI_PHONG();
            tbp.MATHIETBI = cbo_matb.Text;
           
            tbp.TRANGTHAI = txt_tinhtrangtb.Text;
            if (btn_sua.Enabled == false && btn_them.Enabled == true)
            {
                tbp.MAPHONG = cbo_tenphong.SelectedValue.ToString();
                if (bll_thietbi.ktkc_ThietBiphong(tbp.MATHIETBI, tbp.MAPHONG) == true)
                {
                    MessageBox.Show("trùng khóa chính");
                    return;
                }
                if (bll_thietbi.them_ThietBiphong(tbp) == true)
                {
                    MessageBox.Show("Thành công");
                    //grv_thietbiphong.DataSource = bll_thietbi.loadBang_TBPhong();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            if (btn_sua.Enabled == true && btn_them.Enabled == false)
            {
                tbp.MAPHONG = cbo_tenphong.Text;
                if (bll_thietbi.sua_ThietBiphong(tbp) == true)
                {
                    MessageBox.Show("Thành công");
                    //grv_thietbiphong.DataSource = bll_thietbi.loadBang_TBPhong();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
                    frm_thietbiphong_Load(sender,e);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            btn_luu.Enabled = btn_huy.Enabled = txt_tinhtrangtb.Enabled= true;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Bạn có muốn xóa không!", "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                if (bll_thietbi.xoa_ThietBiphong(cbo_matb.Text, cbo_tenphong.Text) == true)
                {
                    MessageBox.Show("Thành công");
                    //grv_thietbiphong.DataSource = bll_thietbi.loadBang_TBPhong();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            frm_thietbiphong_Load(sender, e);
        }

    }
}
