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

namespace QuanLyKhuTro.HeThong
{
    public partial class frm_dangnhap : DevExpress.XtraEditors.XtraForm
    {
        public frm_dangnhap()
        {
            InitializeComponent();
        }
        cauhinh kt = new cauhinh();
        private void Processlogin()
        {
            LoginResult result;
            result = kt.Check_User(txt_taikhoan.Text, txt_matkhau.Text);
            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                return;
            }
            else if (result == LoginResult.Disable)
            {
                MessageBox.Show("Tài khoản đã bị khóa");
                return;
            }
            else
            {
                // đúng tài khoản và mật khẩu
                frm_main main = new frm_main();
                main.Tendn = txt_taikhoan.Text;
                main.MatKhau = txt_matkhau.Text;
                main.ShowDialog();
            }
        }


        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_taikhoan.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống");
                txt_taikhoan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_matkhau.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống");
                txt_matkhau.Focus();
                return;
            }
            int kq = kt.Check_Config();
            if (kq == 0)
            {
                Processlogin();
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");
                ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");
                ProcessConfig();
            }

        }
        private void ProcessConfig()
        {
            frm_cauhinh frm_cauhinh = new frm_cauhinh();

            frm_cauhinh.Show();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_matkhau.Clear();
            txt_taikhoan.Clear();
        }

       
    }
}