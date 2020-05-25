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

        private void btn_huy_Click(object sender, EventArgs e)
        {
            frm_loaiphong_Load(sender,e);
        }

        private void btn_xoa_Click(object sender, EventArgs e)
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
        }
    }
}