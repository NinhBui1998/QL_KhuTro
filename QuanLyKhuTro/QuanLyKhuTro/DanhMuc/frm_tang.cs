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

namespace QuanLyKhuTro
{
    public partial class frm_tang : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_Tang tang = new BLL_Tang();
        public frm_tang()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_tang_Load(object sender, EventArgs e)
        {
            grv_Tang.DataSource = tang.loadBangTang();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            TANG tg = new TANG();
            tg.MATANG = txt_matang.Text;
            tg.TENTANG = txt_tentang.Text;
            //kiểm tra khóa chính
            if (tang.ktkc_Tang(tg.MATANG) == true)
            {
                MessageBox.Show("TRùng khóa chính");
                return;
            }
            if (tang.themTang(tg) == true)
            {

                grv_Tang.DataSource = tang.loadBangTang();
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int position = gridView1.FocusedRowHandle;
            string m = gridView1.GetRowCellValue(position, "MATANG").ToString();
            if (m == string.Empty)
            {
                MessageBox.Show("mã hóa đơn không được để trống");
                return;
            }
            //if (ta.ktxoa_HD(m) == true)
            //{
            //    MessageBox.Show("Mã hóa đơn hiện đang sử dụng không thể xóa");
            //    return;
            //}
            if (tang.xoa_Tang(m) == true)
            {
                grv_Tang.DataSource = tang.loadBangTang();
                MessageBox.Show("Thành công");
               

            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}