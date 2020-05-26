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
    public partial class frm_noiquy : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_NoiQuy noiquy = new BLL_NoiQuy();
        public frm_noiquy()
        {
            InitializeComponent();
        }

        private void frm_noiquy_Load(object sender, EventArgs e)
        {
            grv_noiquy.DataSource = noiquy.loadBang_NoiQuy();
            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled = txt_manoiquy.Enabled
                = txt_noidung.Enabled = txt_hinhphat.Enabled = false;
            btn_them.Enabled = true;
        }

        private void gridView_noiquy_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NOIQUY nq = new NOIQUY();
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_noiquy.FocusedRowHandle;
            try
            {
                nq.NOIDUNG = gridView_noiquy.GetRowCellValue(position, "NOIDUNG").ToString();
                nq.MANOIQUY = gridView_noiquy.GetRowCellValue(position, "MANOIQUY").ToString();
                nq.HINHPHAT= gridView_noiquy.GetRowCellValue(position, "HINHPHAT").ToString();
              
                txt_manoiquy.Text = nq.MANOIQUY.ToString();
                txt_hinhphat.Text = nq.HINHPHAT.ToString();
                txt_noidung.Text = nq.NOIDUNG.ToString();
            }
            catch { }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_manoiquy.Clear();
            txt_hinhphat.Clear();
            txt_noidung.Clear();
          
            txt_hinhphat.Enabled = txt_noidung.Enabled = true;
            txt_manoiquy.Enabled = false;
            //sinh mã
            string pos = gridView_noiquy.GetRowCellValue(gridView_noiquy.RowCount - 1, "MANOIQUY").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_manoiquy.Text = "NQ00" + k;
            }
            else if (k > 10 && k < 100)
            {
                txt_manoiquy.Text = "NQ0" + k;
            }

            btn_luu.Enabled = btn_huy.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Bạn có muốn xóa không!", "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                int position = gridView_noiquy.FocusedRowHandle;
                string m = gridView_noiquy.GetRowCellValue(position, "MANOIQUY").ToString();
                if (m == string.Empty)
                {
                    MessageBox.Show("Mã nội quy không được để trống");
                    return;
                }
                if (noiquy.ktx_nq(m) == true)
                {
                    MessageBox.Show("Nội quy hiện đang áp dụng không thể xóa");
                    return;
                }
                if (noiquy.xoa_NoiQuy(m) == true)
                {
                    grv_noiquy.DataSource = noiquy.loadBang_NoiQuy();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else
            {
                MessageBox.Show("Lỗi !!!");
            }
            frm_noiquy_Load(sender,e);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_manoiquy.Enabled = false;
            btn_luu.Enabled = true;
            btn_xoa.Enabled = btn_them.Enabled = false;
            txt_hinhphat.Enabled = txt_noidung.Enabled = true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            NOIQUY nq = new NOIQUY();
            if (btn_them.Enabled == true)
            {
                nq.MANOIQUY = txt_manoiquy.Text;
                nq.NOIDUNG= txt_noidung.Text;          
                nq.HINHPHAT = txt_hinhphat.Text;
                if (txt_manoiquy.Text == string.Empty && txt_noidung.Text == string.Empty
                    && txt_hinhphat.Text == string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }
                //kiểm tra khóa chính
                if (noiquy.ktkc_NoiQuy(nq.MANOIQUY) == true)
                {
                    MessageBox.Show("TRùng khóa chính");
                    return;
                }
                if (noiquy.them_NoiQuy(nq) == true)
                {

                    grv_noiquy.DataSource = noiquy.loadBang_NoiQuy();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                frm_noiquy_Load(sender,e);
            }
            if (btn_sua.Enabled == true)
            {
                try
                {
                    if (txt_hinhphat.Text == string.Empty)
                    {
                        MessageBox.Show("Hình phạt không được để trống");
                        return;
                    }
                    if (txt_noidung.Text == string.Empty)
                    {
                        MessageBox.Show("Nội dung không được để trống");
                        return;
                    }

                    nq.MANOIQUY = txt_manoiquy.Text;
                    nq.NOIDUNG = txt_noidung.Text;
                    nq.HINHPHAT = txt_hinhphat.Text;

                    if (noiquy.sua_NoiQuy(nq) == true)
                    {
                        grv_noiquy.DataSource = noiquy.loadBang_NoiQuy();
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
            }
            frm_noiquy_Load(sender,e);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_manoiquy.Clear();
            txt_hinhphat.Clear();
            txt_noidung.Clear();
            frm_noiquy_Load(sender,e);
           
        }
    }
}