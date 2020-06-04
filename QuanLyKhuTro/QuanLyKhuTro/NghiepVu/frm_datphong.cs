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
        BLL_HopDong_KhachThue hopdong_khachthue = new BLL_HopDong_KhachThue();
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

            //load dl
            grv_datphong.DataSource = datphong.LoadDatPhong();

            cbb_tang.Enabled = cbb_loaiphong.Enabled = cbb_phong.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled = false;
            txt_makt.Enabled = txt_tenkt.Enabled = rdb_nam.Enabled = rdb_nu.Enabled = txt_sdt.Enabled
                = txt_quequan.Enabled = txt_cmnd.Enabled = txt_ngaysinh.Enabled = pic_anh.Enabled = false;
            txt_mahd.Enabled = txt_tiencoc.Enabled = txt_thoihan.Enabled = txt_manv.Enabled = txt_ngaylaphd.Enabled = false;
            //foreach (Control ctrl in grb_thongtinkhachthue.Controls)
            //{
            //    if (ctrl.Enabled == true && ctrl.GetType() == typeof(TextBox))
            //    {
            //        ctrl.Enabled = false;
            //    }
            //}

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
            KHACHTHUE kt = new KHACHTHUE();
            HOPDONG hd = new HOPDONG();
            HOPDONG_KT hd_kt = new HOPDONG_KT();
            //if (btn_them.Enabled == true)
            //{
            hd.MAHD = txt_mahd.Text;
            hd.TIENCOC = Convert.ToDouble(txt_tiencoc.Text);        
            hd.NGAYLAPHD = Convert.ToDateTime(txt_ngaylaphd.Text);
            hd.THOIHAN = txt_thoihan.Text;
            hd.MAPHONG = cbb_phong.SelectedValue.ToString();
            hd.MANV = txt_manv.Text;


                    
            //Thêm khách thuê vào hợp đồng
            kt.MAKT = txt_makt.Text;
            kt.TENKT = txt_tenkt.Text;
            kt.SDT = txt_sdt.Text;
            if (rdb_nam.Checked == true)
            {
                kt.GIOITINH = rdb_nam.Text;
            }
            else
            {
                kt.GIOITINH = rdb_nu.Text;
            }
            //kt.ANH = b;
            kt.SOCMND = txt_cmnd.Text;
            kt.NGAYSINH = Convert.ToDateTime(txt_ngaysinh.Text);
            kt.QUEQUAN = txt_quequan.Text;
            //Thêm hợp đồng_khách thuê
            hd_kt.MAHD = txt_mahd.Text;
            hd_kt.MAKT = txt_makt.Text;
            hd_kt.TRACOC = false;
            hd_kt.NGAYTRA =null;

            if (txt_makt.Text == string.Empty && txt_mahd.Text == string.Empty
                    && txt_manv.Text == string.Empty && txt_tenkt.Text == string.Empty)
            {
                MessageBox.Show("không được để trống");
                return;
            }
            //kiểm tra khóa chính
            //if (khachthue.ktkc_khachthue(kt.MAKT) == true)
            //{
            //    MessageBox.Show("Trùng khóa chính");
            //    return;
            //}
            if (khachthue.ThemKT(kt) == true && hopdong.them_HopDong(hd) == true && hopdong_khachthue.them_HopDong_KhachThue(hd_kt)==true)
            {
                grv_datphong.DataSource = datphong.LoadDatPhong();
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            frm_datphong_Load(sender, e);
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

        private void btn_them_Click(object sender, EventArgs e)
        {
            cbb_tang.Enabled = cbb_loaiphong.Enabled = cbb_phong.Enabled = true;
            txt_makt.Enabled = txt_tenkt.Enabled = rdb_nam.Enabled = rdb_nu.Enabled = txt_sdt.Enabled
                = txt_quequan.Enabled = txt_cmnd.Enabled = txt_ngaysinh.Enabled = pic_anh.Enabled = true;
            txt_mahd.Enabled = txt_tiencoc.Enabled = txt_thoihan.Enabled = txt_manv.Enabled = txt_ngaylaphd.Enabled = true;
            //sinh mã khách thuê
            string pos = gridView_datphong.GetRowCellValue(gridView_datphong.RowCount - 1, "Makt").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_makt.Text = "KT00" + k;
            }
            else if (k > 10 && k < 100)
            {
                txt_makt.Text = "KT0" + k;
            }
            //sinh mã hợp đồng
            string pos1 = gridView_datphong.GetRowCellValue(gridView_datphong.RowCount - 1, "Mahd").ToString();
            pos1 = pos1.Substring(2);
            int k1 = (int.Parse(pos1) + 1);
            if (k1 < 10)
            {
                txt_mahd.Text = "HD00" + k1;
            }
            else if (k1 > 10 && k1 < 100)
            {
                txt_mahd.Text = "HD0" + k1;
            }
            btn_luu.Enabled = btn_huy.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
        }
    }
}