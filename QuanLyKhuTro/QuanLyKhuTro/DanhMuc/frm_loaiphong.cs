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
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if(btn_them.Enabled==true)
            {
                loaip.MALOAI = txt_maloai.Text;
                loaip.TENLOAI = txt_tenloai.Text;
                loaip.GIA = Convert.ToDouble(txt_gia.Text);
                if (txt_maloai.Text == string.Empty && txt_tenloai.Text == string.Empty && txt_gia.Text==string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }
                //kiểm tra khóa chính
                if (blp.ktkc_LoaiPhong(loaip.MALOAI) == true)
                {
                    MessageBox.Show("TRùng khóa chính");
                    return;
                }
                if (blp.ThemLoaiPhong(loaip) == true)
                {


                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                frm_loaiphong_Load(sender,e);
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
                    loaip.MALOAI = txt_maloai.Text;
                    loaip.TENLOAI = txt_tenloai.Text;
                    loaip.GIA = Convert.ToDouble(txt_gia.Text);
                    if (blp.sua_LoaiPhong(loaip) == true)
                    {
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
            }
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

        private void gridView_LoaiPhong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_LoaiPhong.FocusedRowHandle;
            try
            {
                txt_tenloai.Text = gridView_LoaiPhong.GetRowCellValue(position, "TENLOAI").ToString();
                txt_maloai.Text = gridView_LoaiPhong.GetRowCellValue(position, "MALOAI").ToString();
                txt_gia.Text = gridView_LoaiPhong.GetRowCellValue(position, "GIA").ToString();
            }
            catch { }
        }

        private void txt_gia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}