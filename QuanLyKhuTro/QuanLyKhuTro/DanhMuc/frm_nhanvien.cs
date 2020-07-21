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
    public partial class frm_nhanvien : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_NhanVien bnv = new BLL_NhanVien();
        NHANVIEN nv;
        QUANLYND qlnd;
        BLL_Quanlynguoidung bqlnd = new BLL_Quanlynguoidung();
        public frm_nhanvien()
        {
            InitializeComponent();
        }
        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            
            btn_huy.Enabled = btn_luu.Enabled = true;
            rdb_nam.Enabled = rdb_nu.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_diachi.Enabled  = txt_sdt.Enabled = txt_tennv.Enabled = txt_scm.Enabled = true;
            txt_sdt.Clear();txt_scm.Clear();txt_tennv.Clear();txt_diachi.Clear();
            //sinh mã tự dộng
            string pos = gridView_NhanVien.GetRowCellValue(gridView_NhanVien.RowCount - 1, "MANV").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_manv.Text = "NV00" + k;
            }
            else if (k > 10 && k < 100)
            {
                txt_manv.Text = "NV0" + k;
            }
        }

        private void frm_nhanvien_Load(object sender, EventArgs e)
        {
            grv_nhanvien.DataSource = bnv.loadBangNV();
            rdb_nam.Checked = true;
            rdb_nam.Enabled = rdb_nu.Enabled = false;
            txt_diachi.Enabled = txt_manv.Enabled  = txt_scm.Enabled=
            txt_sdt.Enabled = txt_tennv.Enabled = btn_huy.Enabled=btn_luu.Enabled=btn_sua.Enabled=btn_xoa.Enabled= false;
            btn_them.Enabled = true;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            frm_nhanvien_Load(sender,e);
        }

        private void gridView_NhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            

            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_NhanVien.FocusedRowHandle;
            try
             {
                txt_manv.Text = gridView_NhanVien.GetRowCellValue(position, "MANV").ToString();
                txt_tennv.Text = gridView_NhanVien.GetRowCellValue(position, "TENNV").ToString();
                txt_scm.Text = gridView_NhanVien.GetRowCellValue(position, "CMND_NV").ToString();
                txt_diachi.Text = gridView_NhanVien.GetRowCellValue(position, "DIACHI").ToString();
                txt_sdt.Text = gridView_NhanVien.GetRowCellValue(position, "SODT_CT").ToString();
                string gt = gridView_NhanVien.GetRowCellValue(position, "GIOITINH").ToString();
                if(gt=="Nam")
                {
                    rdb_nam.Checked = true;

                }
                else
                {
                    rdb_nu.Checked = true;
                }
            }
            catch { }
            
          
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            
            btn_luu.Enabled = true;
            btn_xoa.Enabled = btn_them.Enabled = false;
            txt_diachi.Enabled = txt_sdt.Enabled = txt_tennv.Enabled = txt_scm.Enabled = true;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            nv = new NHANVIEN();
            DialogResult res;
            res = MessageBox.Show("Bạn có muốn xóa không!", "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                int position = gridView_NhanVien.FocusedRowHandle;
                string m = gridView_NhanVien.GetRowCellValue(position, "MANV").ToString();
                if (m == string.Empty)
                {
                    MessageBox.Show("mã nhân viên không được để trống");
                    return;
                }
                if (bnv.ktx_nhanvien(m) == true)
                {
                    MessageBox.Show("không thể xóa nhân viên");
                    return;
                }
                if (bnv.xoa_Nhanvien(m) == true)
                {
                    grv_nhanvien.DataSource = bnv.loadBangNV();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else { }

            frm_nhanvien_Load(sender, e);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            nv = new NHANVIEN();
            qlnd = new QUANLYND();
            nv.MANV = txt_manv.Text;
            nv.TENNV = txt_tennv.Text;
            nv.CMND_NV = txt_scm.Text;
            nv.SODT_CT = txt_sdt.Text;
            nv.DIACHI = txt_diachi.Text;

            qlnd.TENDN = txt_manv.Text;
            qlnd.MK = "123456789";
            qlnd.HOATDONG = false;
            if(rdb_nam.Checked==true)
            {
                nv.GIOITINH = "Nam";
            }    
            else
            {
                nv.GIOITINH = "Nữ";
            }
            if (btn_them.Enabled==true && btn_sua.Enabled==false)
            {
                
                if (txt_manv.Text == string.Empty && txt_tennv.Text == string.Empty
                    && txt_scm.Text == string.Empty && txt_sdt.Text==string.Empty && txt_diachi.Text==string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }
                //kiểm tra khóa chính
                if (bnv.ktkc_nhanvien(nv.MANV) == true)
                {
                    MessageBox.Show("TRùng khóa chính");
                    return;
                }
                if (bnv.ThemNV(nv) == true && bqlnd.them_nguoidung(qlnd)==true )
                {
                    MessageBox.Show("Thành công");

                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                frm_nhanvien_Load(sender, e);

            }    
            else if(btn_them.Enabled == false && btn_sua.Enabled == true)
            {
                try
                {
                    if (txt_tennv.Text == string.Empty
                    && txt_scm.Text == string.Empty && txt_sdt.Text == string.Empty && txt_diachi.Text == string.Empty)
                    {
                        MessageBox.Show(" không được để trống");
                        return;
                    }
          
                    if (bnv.sua_nhanvien(nv) == true)
                    {
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
                frm_nhanvien_Load(sender, e);
            }   
            else
            {
                MessageBox.Show("Lỗi");
            }    
        }
    }
}