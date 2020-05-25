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
    public partial class frm_thietbi : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_ThietBi thietbi = new BLL_ThietBi();
        public frm_thietbi()
        {
            InitializeComponent();
        }
        private void gridView_ThietBi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            THIETBI tb = new THIETBI();
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_ThietBi.FocusedRowHandle;
            try
            {
                tb.TENTB = gridView_ThietBi.GetRowCellValue(position, "TENTB").ToString();
                tb.MATHIETBI = gridView_ThietBi.GetRowCellValue(position, "MATHIETBI").ToString();
                tb.GIATB = double.Parse(gridView_ThietBi.GetRowCellValue(position, "GIATB").ToString());
                tb.SOLUONG_PHANBO = Int32.Parse(gridView_ThietBi.GetRowCellValue(position,"SOLUONG_PHANBO").ToString());
                tb.SOLUONG_HUHONG = Int32.Parse(gridView_ThietBi.GetRowCellValue(position, "SOLUONG_HUHONG").ToString());
                tb.SOLUONG_TONKHO = Int32.Parse(gridView_ThietBi.GetRowCellValue(position, "SOLUONG_TONKHO").ToString());
           
          
                txt_maloai.Text = tb.MATHIETBI.ToString();
                txt_tenloai.Text = tb.TENTB.ToString();
                txt_gia.Text = tb.GIATB.ToString();
                txt_slphanbo.Text = tb.SOLUONG_PHANBO.ToString();
                txt_slhuhong.Text = tb.SOLUONG_HUHONG.ToString();
                txt_sltonkho.Text = tb.SOLUONG_TONKHO.ToString();
            }
            catch { }
        }
        private void frm_thietbi_Load(object sender, EventArgs e)
        {
            txt_maloai.Enabled = false;
            grv_thietbi.DataSource = thietbi.loadBang_TB();
            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled = txt_maloai.Enabled
                = txt_tenloai.Enabled = txt_gia.Enabled = txt_slphanbo.Enabled
                = txt_slhuhong.Enabled= txt_sltonkho.Enabled= false;
            btn_them.Enabled = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_maloai.Clear();
            txt_tenloai.Clear();
            txt_gia.Clear();
            txt_slphanbo.Clear();
            txt_slhuhong.Clear();
            txt_sltonkho.Clear();

            txt_tenloai.Enabled = txt_gia.Enabled = txt_slphanbo.Enabled 
                =txt_slhuhong.Enabled=txt_sltonkho.Enabled= true;
            txt_maloai.Enabled = false;
            //sinh mã
            string pos = gridView_ThietBi.GetRowCellValue(gridView_ThietBi.RowCount - 1, "MATHIETBI").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_maloai.Text = "TB00" + k;
            }
            else if (k > 10 && k < 100)
            {
                txt_maloai.Text = "TB0" + k;
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
                int position = gridView_ThietBi.FocusedRowHandle;
                string m = gridView_ThietBi.GetRowCellValue(position, "MATHIETBI").ToString();
                if (m == string.Empty)
                {
                    MessageBox.Show("Mã dịch vụ không được để trống");
                    return;
                }
                if (thietbi.ktx_tb(m) == true)
                {
                    MessageBox.Show("THiết bị hiện đang sử dụng không thể xóa");
                    return;
                }
                if (thietbi.xoa_ThietBi(m) == true)
                {
                    grv_thietbi.DataSource = thietbi.loadBang_TB();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else
            {

            }

            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled = txt_maloai.Enabled
                 = txt_tenloai.Enabled = txt_gia.Enabled = txt_slphanbo.Enabled 
                 = txt_slhuhong.Enabled=txt_sltonkho.Enabled=false;
            btn_them.Enabled = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_maloai.Enabled = false;
            btn_luu.Enabled= true;
            btn_xoa.Enabled = btn_them.Enabled = false;
            txt_tenloai.Enabled = txt_gia.Enabled = txt_slphanbo.Enabled
                 = txt_slhuhong.Enabled = txt_sltonkho.Enabled = true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            THIETBI tb = new THIETBI();
            if (btn_them.Enabled == true)
            {
                tb.MATHIETBI = txt_maloai.Text;
                tb.TENTB = txt_tenloai.Text;
                tb.GIATB= Convert.ToDouble(txt_gia.Text);
                tb.SOLUONG_PHANBO =Convert.ToInt32(txt_slphanbo.Text);
                tb.SOLUONG_HUHONG = Convert.ToInt32(txt_slhuhong.Text);
                tb.SOLUONG_TONKHO = Convert.ToInt32(txt_sltonkho.Text);

                if (txt_maloai.Text == string.Empty && txt_tenloai.Text == string.Empty
                    && txt_gia.Text == string.Empty && txt_slphanbo.Text == string.Empty
                    && txt_slhuhong.Text == string.Empty && txt_sltonkho.Text == string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }
                //kiểm tra khóa chính
                if (thietbi.ktkc_ThietBi(tb.MATHIETBI) == true)
                {
                    MessageBox.Show("TRùng khóa chính");
                    return;
                }
                if (thietbi.them_ThietBi(tb) == true)
                {

                    grv_thietbi.DataSource = thietbi.loadBang_TB();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                btn_sua.Enabled = btn_luu.Enabled = btn_them.Enabled = false;
            }
            if (btn_sua.Enabled == true)
            {
                try
                {
                    if (txt_tenloai.Text == string.Empty)
                    {
                        MessageBox.Show("Tên thiết bị không được để trống");
                        return;
                    }
                    if (txt_gia.Text == string.Empty)
                    {
                        MessageBox.Show("Giá thiết bị không được để trống");
                        return;
                    }
                    if (txt_slphanbo.Text == string.Empty)
                    {
                        MessageBox.Show("Số lượng phân bổ không được để trống");
                        return;
                    }
                    if (txt_slhuhong.Text == string.Empty)
                    {
                        MessageBox.Show("Số lượng hư hỏng không được để trống");
                        return;
                    }
                    if (txt_sltonkho.Text == string.Empty)
                    {
                        MessageBox.Show("Số lượng tồn kho không được để trống");
                        return;
                    }

                    tb.MATHIETBI= txt_maloai.Text;
                    tb.TENTB = txt_tenloai.Text;
                    tb.GIATB = Convert.ToDouble(txt_gia.Text);
                    tb.SOLUONG_PHANBO =Convert.ToInt32(txt_slphanbo.Text);
                    tb.SOLUONG_HUHONG = Convert.ToInt32(txt_slhuhong.Text);
                    tb.SOLUONG_TONKHO = Convert.ToInt32(txt_sltonkho.Text);

                    if (thietbi.sua_ThietBi(tb) == true)
                    {
                        grv_thietbi.DataSource = thietbi.loadBang_TB();
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
            }
            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled =
                txt_maloai.Enabled = txt_tenloai.Enabled = txt_gia.Enabled =
                txt_slphanbo.Enabled = txt_slhuhong.Enabled = txt_sltonkho.Enabled = false;

            btn_them.Enabled = true;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_maloai.Clear();
            txt_tenloai.Clear();
            txt_gia.Clear();
            txt_slphanbo.Clear();
            txt_slhuhong.Clear();
            txt_sltonkho.Clear();
            btn_them.Enabled = true;
            btn_sua.Enabled = btn_luu.Enabled = btn_xoa.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled =
                txt_maloai.Enabled = txt_tenloai.Enabled = txt_gia.Enabled = txt_slphanbo.Enabled
                 = txt_slhuhong.Enabled = txt_sltonkho.Enabled = false;
            btn_them.Enabled = true;
        }
    }
}