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
        public frm_loaiphong()
        {
            InitializeComponent();
        }

        private void frm_loaiphong_Load(object sender, EventArgs e)
        {
            grv_loaiPhong.DataSource = blp.loadBangLoaiPhong();
            txt_maloai.Enabled = txt_tenloai.Enabled = txt_gia.Enabled = false;
            btn_huy.Enabled = btn_luu.Enabled = btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_them.Enabled = true;
            
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_maloai.Enabled = false;
            btn_luu.Enabled = true;
            btn_xoa.Enabled = btn_them.Enabled = false;
            txt_tenloai.Enabled = txt_gia.Enabled = true;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            frm_loaiphong_Load(sender,e);
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
             DialogResult res;
            res = MessageBox.Show("Bạn có muốn xóa không!", "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                int position = gridView_LoaiPhong.FocusedRowHandle;
                string m = gridView_LoaiPhong.GetRowCellValue(position, "MALOAI").ToString();
                if (m == string.Empty)
                {
                    MessageBox.Show("mã loại không được để trống");
                    return;
                }
                if (blp.ktx_loaiPhong(m) == true)
                {
                    MessageBox.Show("Phòng hiện đang sử dụng không thể xóa");
                    return;
                }
                if (blp.xoa_LoaiPhong(m) == true)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else { }


            frm_loaiphong_Load(sender,e);
        } 
        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_gia.Enabled = txt_tenloai.Enabled = btn_huy.Enabled = btn_luu.Enabled = true;
            txt_gia.Clear(); txt_maloai.Clear(); txt_tenloai.Clear();
            //sinh mã 
            string pos = gridView_LoaiPhong.GetRowCellValue(gridView_LoaiPhong.RowCount - 1, "MALOAI").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_maloai.Text = "L00" + k;
            }
            else if (k > 10 && k < 100)
            {
                txt_maloai.Text = "L0" + k;
            }

            btn_luu.Enabled = btn_huy.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            LOAIPHONG lp = new LOAIPHONG();
            if (btn_them.Enabled == true)
            {
                lp.MALOAI = txt_maloai.Text;
                lp.TENLOAI = txt_tenloai.Text;
                lp.GIA = decimal.Parse(txt_gia.Text);
                if (txt_maloai.Text == string.Empty && txt_tenloai.Text == string.Empty && txt_gia.Text == string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }
                //kiểm tra khóa chính
                if (blp.ktkc_LoaiPhong(lp.MALOAI) == true)
                {
                    MessageBox.Show("Trùng khóa chính");
                    return;
                }
                if (blp.ThemLoaiPhong(lp) == true)
                {
                    grv_loaiPhong.DataSource = blp.loadBangLoaiPhong();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                frm_loaiphong_Load(sender, e);
            }
            if (btn_sua.Enabled == true && btn_them.Enabled == false)
            {
                try
                {
                    if (txt_tenloai.Text == string.Empty || txt_gia.Text == string.Empty)
                    {
                        MessageBox.Show(" không được để trống");
                        return;
                    }
                    lp.MALOAI = txt_maloai.Text;
                    lp.TENLOAI = txt_tenloai.Text;
                    lp.GIA = decimal.Parse(txt_gia.Text);
                    if (blp.sua_LoaiPhong(lp) == true)
                    {
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
            }
            frm_loaiphong_Load(sender, e);
        }

        private void gridView_LoaiPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LOAIPHONG lp = new LOAIPHONG();
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_LoaiPhong.FocusedRowHandle;
            try
            {
               lp.TENLOAI= gridView_LoaiPhong.GetRowCellValue(position, "TENLOAI").ToString();
               lp.MALOAI = gridView_LoaiPhong.GetRowCellValue(position, "MALOAI").ToString();
               lp.GIA= decimal.Parse(gridView_LoaiPhong.GetRowCellValue(position, "GIA").ToString());

                txt_tenloai.Text = lp.TENLOAI.ToString();
                txt_maloai.Text = lp.MALOAI.ToString();
                txt_gia.Text = String.Format("{0:#,##0.##} VNĐ", lp.GIA);
            }
            catch { }
        }

        private void txt_gia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_gia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //địng dạng tiền tệ
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txt_gia.Text, System.Globalization.NumberStyles.AllowThousands);
                txt_gia.Text = String.Format(culture, "{0:N0}", value);
                //texbox1.Text = String.Format(culture, "{0:N0}", value);
                txt_gia.Select(txt_gia.Text.Length, 0);
            }
            catch
            {
                return;
            }
        }
    }
}