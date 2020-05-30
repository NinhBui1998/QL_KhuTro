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
using DAL;
using BLL;

namespace QuanLyKhuTro
{
    public partial class frm_doimatkhau : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_Quanlynguoidung qlnd = new BLL_Quanlynguoidung();
        public frm_doimatkhau()
        {
            InitializeComponent();
        }
        String TenDN;
        public string Tendn
        {
            get { return TenDN; }
            set { TenDN = value; }
        }
        string MK;
        public string MatKhau
        {
            get { return MK; }
            set { MK = value; }
        }
        private void txt_matkhaumoi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_matkhaumoi.Text))
            {
                e.Cancel = true;
                txt_matkhaumoi.Focus();
                errorProvider1.SetError(txt_matkhaumoi, "Không được để trống");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_matkhaumoi, null);
            }
        }

        private void txt_xacnhanmk_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_xacnhanmk.Text))
            {
                e.Cancel = true;
                txt_xacnhanmk.Focus();
                errorProvider1.SetError(txt_xacnhanmk, "Không được để trống");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_xacnhanmk, null);
            }
            if (txt_xacnhanmk.Text != txt_xacnhanmk.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txt_xacnhanmk, "Mật khẩu và mật khẩu xác nhận không giống nhau");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_xacnhanmk, null);
            }
        }

        private void frm_doimatkhau_Load(object sender, EventArgs e)
        {
            txtmanv.Text = Tendn;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_matkhaumoi.Clear();
            txt_xacnhanmk.Clear();
        }

        private void txtmkc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtmkc.Text))
            {
                e.Cancel = true;
                txtmkc.Focus();
                errorProvider1.SetError(txtmkc, "Không được để trống");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtmkc, null);
            }
           
            if(txtmkc.Text!=MatKhau)
            {
                e.Cancel = true;
                txtmkc.Focus();
                errorProvider1.SetError(txtmkc, "Sai mật khẩu");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtmkc, null);
            }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (txt_xacnhanmk.Text == txt_matkhaumoi.Text)
            {


                QUANLYND nd = new QUANLYND();
                nd.TENDN = txtmanv.Text;
                nd.MK = txt_xacnhanmk.Text;
                nd.HOATDONG = true;
                if (qlnd.sua_ND(nd) == true)
                {
                    MessageBox.Show("Thành công");
                }
                txt_xacnhanmk.Clear();
                txtmkc.Clear();
                txt_matkhaumoi.Clear();
            }
            else
            {
                MessageBox.Show("Mật khẩu và mật khẩu xác nhận không giống nhau");
            }    
        }
    }
}