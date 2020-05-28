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
namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_datphong : DevExpress.XtraEditors.XtraForm
    {
        BLL_KhachThue khachthue = new BLL_KhachThue();
        BLL_LoaiPhong loaip = new BLL_LoaiPhong();
        BLL_Tang tang = new BLL_Tang();
        BLL_Phong phong = new BLL_Phong();
        public frm_datphong()
        {
            InitializeComponent();
        }

        private void frm_datphong_Load(object sender, EventArgs e)
        {
            //load dữ liêu combobox tầng
            cbb_tang.DataSource = tang.loadBangTang();
            cbb_tang.DisplayMember = "TENTANG";
            cbb_tang.ValueMember = "MATANG";

            //load dữ liêu combobox loai phòng
            cbb_loaiphong.DataSource = loaip.loadBangLoaiPhong();
            cbb_loaiphong.DisplayMember = "TENLOAI";
            cbb_loaiphong.ValueMember = "MALOAI";

            //load dữ liệu combobox phòng

            cbb_phong.DataSource = phong.loadBang_Phong();
            cbb_phong.DisplayMember = "TENPHONG";
            cbb_phong.ValueMember = "MAPHONG";
        }

    }
}