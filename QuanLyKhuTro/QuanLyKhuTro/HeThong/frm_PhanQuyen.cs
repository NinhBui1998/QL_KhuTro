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

namespace QuanLyKhuTro.HeThong
{
    public partial class frm_phanquyen : DevExpress.XtraEditors.XtraUserControl  
    {
        BLL_Quanlynguoidung bqlnd = new BLL_Quanlynguoidung();
        BLL_NguoiDung_NhomNguoiDung bnd_nnd = new BLL_NguoiDung_NhomNguoiDung();
        BLL_NhomNguoiDung bnhomnd = new BLL_NhomNguoiDung();

        QUANLYND qlnd ;
        QLND_NHOMND qlndnnd;
        public frm_phanquyen()
        {
            InitializeComponent();
        }

        private void frm_PhanQuyen_Load(object sender, EventArgs e)
        {
            cbo_quanlynhomnd.DataSource = bnhomnd.loadBang_TB();
            cbo_quanlynhomnd.DisplayMember = "TENNHOMND";
            cbo_quanlynhomnd.ValueMember = "MANHOM";
            //
            grv_qlnd.DataSource = bqlnd.loadnd();
            grv_qlnd_nnd.DataSource = bnd_nnd.loadBang_QLND_NHOMND();

        }

        private void gridView_qlnguoidung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            qlnd = new QUANLYND();
            int position = gridView_qlnguoidung.FocusedRowHandle;
           qlnd.HOATDONG = Convert.ToBoolean(gridView_qlnguoidung.GetRowCellValue(position, "HOATDONG").ToString());
            ckb_hoatdong.Checked = qlnd.HOATDONG.Value;
            if (ckb_hoatdong.Checked==true)
            {
                ckb_hoatdong.Text = "Đang hoạt động";
            }    
            else
            {
                ckb_hoatdong.Text = "Không hoạt động";
            }    
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Bạn có muốn xóa không!", "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                int position = gridView_qlnguoidung.FocusedRowHandle;
                string m = gridView_qlnguoidung.GetRowCellValue(position, "TENDN").ToString();
                if (m == string.Empty)
                {
                    MessageBox.Show("Mã phòng không được để trống");
                    return;
                }

                if (bqlnd.xoand(m) == true)
                {
                    grv_qlnd.DataSource = bqlnd.loadnd();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            int position = gridView_qlnguoidung.FocusedRowHandle;
            qlnd.TENDN= gridView_qlnguoidung.GetRowCellValue(position, "TENDN").ToString();
            qlnd.HOATDONG = ckb_hoatdong.Checked;
            if (bqlnd.sua_ND(qlnd) == true)
            {
                grv_qlnd.DataSource = bqlnd.loadnd();
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }    
        }

        private void btn_them_Click(object sender, EventArgs e)
        
        {
            try
            {

            
            int position = gridView_qlnguoidung.FocusedRowHandle;
            qlndnnd.TENDN = gridView_qlnguoidung.GetRowCellValue(position, "TENDN").ToString();
            qlndnnd.MANHOM = cbo_quanlynhomnd.SelectedValue.ToString();
            qlndnnd.GHICHU = null;
            if(bnd_nnd.ktkc_QLND_NHOMND(qlndnnd.MANHOM,qlndnnd.TENDN) ==true)
            {
                MessageBox.Show("trùng khóa chính");
                return;
            }    
            if(bnd_nnd.them_QLND_NHOMND(qlndnnd)==true)
            {
                //grv_qlnd_nnd.DataSource = bnd_nnd.loadBang_QLND_NHOMND();
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            }
            catch
            {
                MessageBox.Show("lỗi hệ thống");
            }
            frm_PhanQuyen_Load(sender,e);
            //cbo_quanlynhomnd.DataSource = bnhomnd.loadBang_TB();
            //cbo_quanlynhomnd.DisplayMember = "TENNHOMND";
            //cbo_quanlynhomnd.ValueMember = "MANHOM";
            ////
            //grv_qlnd.DataSource = bqlnd.loadnd();
            //grv_qlnd_nnd.DataSource = bnd_nnd.loadBang_QLND_NHOMND();
        }

        private void btn_xoa_nd_Click(object sender, EventArgs e)
        {
            int position = gridView_qlnd_nhomnd.FocusedRowHandle;
            string m = gridView_qlnd_nhomnd.GetRowCellValue(position, "TENDN").ToString();
            string n= gridView_qlnd_nhomnd.GetRowCellValue(position, "MANHOM").ToString();
            if (m == string.Empty && n==string.Empty)
            {
                MessageBox.Show("Mã và tên đăng nhập không được để trống");
                return;
            }

            if (bnd_nnd.xoa_QLND_NHOMND(n,m) == true)
            {
                //grv_qlnd_nnd.DataSource = bnd_nnd.loadBang_QLND_NHOMND();
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            frm_PhanQuyen_Load(sender,e);
        }
    }
}