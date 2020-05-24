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

namespace QuanLyKhuTro
{
    public partial class frm_tang : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_Tang tang = new BLL_Tang();
        public frm_tang()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_tang_Load(object sender, EventArgs e)
        {
            grv_Tang.DataSource = tang.loadBangTang();
          
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {

            TANG tg = new TANG();
            if (btn_them.Enabled==true)
           {   
                tg.MATANG = txt_matang.Text;
                tg.TENTANG = txt_tentang.Text;
                if(txt_matang.Text==null && txt_tentang.Text== string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }   
                //kiểm tra khóa chính
                if (tang.ktkc_Tang(tg.MATANG) == true)
                {
                    MessageBox.Show("TRùng khóa chính");
                    return;
                }
                if (tang.themTang(tg) == true)
                {

                    grv_Tang.DataSource = tang.loadBangTang();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                btn_sua.Enabled = btn_luu.Enabled = btn_them.Enabled = false;
            }
           if(btn_sua.Enabled==true)
            {
                try
                {
                    if(txt_tentang.Text== string.Empty)
                    {
                        MessageBox.Show("Tên tầng không được để trống");
                        return;
                    }    
                    tg.MATANG = txt_matang.Text;
                    tg.TENTANG = txt_tentang.Text;
                 

               
                    if (tang.sua_Tang(tg) == true)
                    {
                        grv_Tang.DataSource = tang.loadBangTang();
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
            }    
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int position = gridView1.FocusedRowHandle;
            string m = gridView1.GetRowCellValue(position, "MATANG").ToString();
            if (m == string.Empty)
            {
                MessageBox.Show("mã hóa đơn không được để trống");
                return;
            }
            if (tang.ktx_tang(m) == true)
            {
                MessageBox.Show("Tầng hiện đang sử dụng không thể xóa");
                return;
            }
            if (tang.xoa_Tang(m) == true)
            {
                grv_Tang.DataSource = tang.loadBangTang();
                MessageBox.Show("Thành công");
               

            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }
      
        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_matang.Clear();
            txt_tentang.Clear();
            txt_matang.Enabled = txt_tentang.Enabled = true;
            //sinh mã
            string pos = gridView1.GetRowCellValue(gridView1.RowCount - 1, "MATANG").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_matang.Text = "T00" + k;
            }
            else if (k > 10 && k < 100)
            {
                txt_matang.Text = "T0" + k;
            }

            btn_luu.Enabled=btn_huy.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            
        }

       

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_matang.Clear();
            txt_tentang.Clear();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TANG t = new TANG();
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            int position = gridView1.FocusedRowHandle;
            try
            {
                t.MATANG = gridView1.GetRowCellValue(position, "MATANG").ToString();
                t.TENTANG = gridView1.GetRowCellValue(position, "TENTANG").ToString();
               

                txt_matang.Text = t.MATANG.ToString();
                txt_tentang.Text = t.TENTANG.ToString();
            
            }
            catch { }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = true;
            btn_xoa.Enabled = btn_them.Enabled = false;
            txt_tentang.Enabled = true;
        }
    }
}