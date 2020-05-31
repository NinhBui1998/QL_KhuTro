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

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_datphong : DevExpress.XtraEditors.XtraForm
    {
        BLL_KhachThue khachthue = new BLL_KhachThue();
        BLL_LoaiPhong loaip = new BLL_LoaiPhong();
        BLL_Tang tang = new BLL_Tang();
        BLL_Phong phong = new BLL_Phong();
        BLL_HopDong hopdong = new BLL_HopDong();
        BLL_DatPhong datphong = new BLL_DatPhong();
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

            ////load dữ liệu combobox phòng
            //cbb_phong.DataSource = phong.loadBang_Phong();
            //cbb_phong.DisplayMember = "TENPHONG";
            //cbb_phong.ValueMember = "MAPHONG";

            //load dl
            grv_datphong.DataSource = datphong.LoadDatPhong();

        }

        private void gridView_datphong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            HOPDONG hd = new HOPDONG();
            HOPDONG_KT hd_kt = new HOPDONG_KT();
            //btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            //btn_them.Enabled = false;
            int position = gridView_datphong.FocusedRowHandle;
            try
            {
                //hd.MAHD = gridView_datphong.GetRowCellValue(position, "MAHD").ToString();
                //hd.MANV= gridView_datphong.GetRowCellValue(position, "MANV").ToString();
                ////hd_kt.MAKT = gridView_datphong.GetRowCellValue(position, "MAKT").ToString();
                //hd.NGAYLAPHD =Convert.ToDateTime(gridView_datphong.GetRowCellValue(position,"NGAYLAPHD").ToString());
                //hd.TIENCOC = Convert.ToDouble(gridView_datphong.GetRowCellValue(position,"TIENCOC").ToString());
                ////hd_kt.TENKT = gridView_datphong.GetRowCellValue(position,"TENKT").ToString();


                //txt_mahd.Text = hd.MAHD.ToString();
                //txt_manv.Text = hd.MANV.ToString();
                ////txt_makt.Text = hd_kt.MAKT.ToString();
                //txt_ngaylaphd.Text = hd.NGAYLAPHD.ToString();
                //txt_tiencoc.Text = hd.TIENCOC.ToString();
                ////txt_tenkt.Text = hd_kt.TENKT.ToString();
            }
            catch { }
        }

        private void btn_taohd_Click(object sender, EventArgs e)
        {

        }

        private void cbb_phong_SelectedValueChanged(object sender, EventArgs e)
        {
            //load dữ liệu combobox phòng
            cbb_phong.Text = string.Empty;
            cbb_phong.DataSource = phong.loadBang_Phong();
            cbb_phong.DisplayMember = "TENPHONG";
            cbb_phong.ValueMember = "MAPHONG";
            cbb_phong.DataSource = datphong.laytenphong(cbb_tang.SelectedValue.ToString(), cbb_loaiphong.SelectedValue.ToString()).ToList();
        }

        private void cbb_tang_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}