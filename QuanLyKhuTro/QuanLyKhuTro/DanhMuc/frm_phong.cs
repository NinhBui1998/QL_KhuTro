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
using System.Data.SqlClient;

namespace QuanLyKhuTro.DanhMuc
{
    public partial class frm_phong : DevExpress.XtraEditors.XtraForm
    {
        BLL_Phong phong = new BLL_Phong();
        BLL_LoaiPhong loaip = new BLL_LoaiPhong();
        BLL_Tang tang = new BLL_Tang();
        public frm_phong()
        {
            InitializeComponent();
        }

        private void frm_phong_Load(object sender, EventArgs e)
        {          
            //load dữ liêu combobox tầng
            cbb_tang.DataSource = tang.loadBangTang();
            cbb_tang.DisplayMember = "TENTANG";
            cbb_tang.ValueMember = "MATANG";

            //load dữ liêu combobox loai phòng
            cbb_loaiphong.DataSource = loaip.loadBangLoaiPhong();
            cbb_loaiphong.DisplayMember = "TENLOAI";
            cbb_loaiphong.ValueMember = "MALOAI";

            grv_phong.DataSource = phong.loadBang_Phong();
            cbb_loaiphong.Enabled = cbb_tang.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled = txt_maphong.Enabled
                = txt_tenphong.Enabled = ckb_tinhtrang.Enabled = txt_slhientai.Enabled =
                txt_sltoida.Enabled = false;
            btn_them.Enabled = true;
        }

        private void gridView_Phong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            PHONG p = new PHONG();
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_Phong.FocusedRowHandle;
            try
            {
                p.TENPHONG = gridView_Phong.GetRowCellValue(position, "TENPHONG").ToString();
                p.MAPHONG = gridView_Phong.GetRowCellValue(position, "MAPHONG").ToString();
                p.MALOAI = gridView_Phong.GetRowCellValue(position, "MALOAI").ToString();
                p.MATANG = gridView_Phong.GetRowCellValue(position, "MATANG").ToString();
                p.SOLUONG_HT = Convert.ToInt32(gridView_Phong.GetRowCellValue(position, "SOLUONG_HT").ToString());
                p.SOLUONG_TD = Convert.ToInt32(gridView_Phong.GetRowCellValue(position, "SOLUONG_TD").ToString());
                p.TINHTRANG = Convert.ToBoolean(gridView_Phong.GetRowCellValue(position, "TINHTRANG").ToString());


                txt_maphong.Text = p.MAPHONG.ToString();
                txt_tenphong.Text = p.TENPHONG.ToString();
                txt_slhientai.Text = p.SOLUONG_HT.ToString();
                txt_sltoida.Text = p.SOLUONG_TD.ToString();
                cbb_loaiphong.Text = p.MALOAI.ToString();
                cbb_tang.Text = p.MATANG.ToString();
                ckb_tinhtrang.Checked = p.TINHTRANG.Value;
                if(ckb_tinhtrang.Checked==true)
                {
                    ckb_tinhtrang.Text = "Đã thuê";
                }    
                else
                {
                    ckb_tinhtrang.Text = "Chưa thuê";
                }    
                
            }
            catch { }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {        
            txt_tenphong.Clear();
            txt_slhientai.Clear();
            txt_sltoida.Clear();

            txt_tenphong.Enabled = txt_slhientai.Enabled = txt_sltoida.Enabled = true;
            cbb_loaiphong.Enabled = cbb_tang.Enabled = ckb_tinhtrang.Enabled = true;
            txt_maphong.Enabled = false;
            //sinh mã
            string pos = gridView_Phong.GetRowCellValue(gridView_Phong.RowCount - 1, "MAPHONG").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_maphong.Text = "P00" + k;
            }
            else if (k > 10 && k < 100)
            {
                txt_maphong.Text = "P0" + k;
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
                int position = gridView_Phong.FocusedRowHandle;
                string m = gridView_Phong.GetRowCellValue(position, "MAPHONG").ToString();
                if (m == string.Empty)
                {
                    MessageBox.Show("Mã phòng không được để trống");
                    return;
                }
                if (phong.ktx_p(m) == true)
                {
                    MessageBox.Show("Phòng hiện đang sử dụng không thể xóa");
                    return;
                }
                if (phong.xoa_Phong(m) == true)
                {
                    grv_phong.DataSource = phong.loadBang_Phong();
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
            frm_phong_Load(sender, e);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_maphong.Enabled = false;
            btn_luu.Enabled = true;
            btn_xoa.Enabled = btn_them.Enabled = false;
            txt_tenphong.Enabled = txt_slhientai.Enabled = txt_sltoida.Enabled = true;
            cbb_loaiphong.Enabled = cbb_tang.Enabled = ckb_tinhtrang.Enabled = true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            PHONG nq = new PHONG();
            nq.MAPHONG = txt_maphong.Text;
            nq.TENPHONG = txt_tenphong.Text;
            nq.TINHTRANG = ckb_tinhtrang.Checked;
            nq.SOLUONG_TD = Convert.ToInt32(txt_sltoida.Text);
            nq.SOLUONG_HT= Convert.ToInt32(txt_slhientai.Text);
            nq.MALOAI = cbb_loaiphong.SelectedValue.ToString();
            nq.MATANG = cbb_tang.SelectedValue.ToString();
            nq.TRANGTHAIPHONG = cbo_ttphong.Text;
            if (btn_them.Enabled == true && btn_sua.Enabled == false)
            {               
                if (txt_maphong.Text == string.Empty && txt_slhientai.Text == string.Empty && txt_sltoida.Text==string.Empty 
                    && txt_tenphong.Text == string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }
                //kiểm tra khóa chính
                if (phong.ktkc_Phong(nq.MAPHONG) == true)
                {
                    MessageBox.Show("TRùng khóa chính");
                    return;
                }
                if (phong.them_Phong(nq) == true)
                {

                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else if (btn_sua.Enabled == true && btn_them.Enabled == false)
            {
                try
                {
                    if (txt_maphong.Text == string.Empty && txt_slhientai.Text == string.Empty && txt_sltoida.Text == string.Empty
                    && txt_tenphong.Text == string.Empty)
                    {
                        MessageBox.Show(" không được để trống");
                        return;
                    }
                    if (phong.sua_Phong(nq) == true)
                    {
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
            frm_phong_Load(sender,e);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_maphong.Clear();
            txt_tenphong.Clear();
            txt_slhientai.Clear();
            txt_sltoida.Clear();
            frm_phong_Load(sender, e);
        }

        private void ckb_tinhtrang_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_tinhtrang.Checked == true)
            {
                ckb_tinhtrang.Text = "Đã thuê";
            }
            else
            {
                ckb_tinhtrang.Text = "Chưa thuê";
            }
        }
    }
}