﻿using System;
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
using BLL.NghiepVu;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_tienphong : DevExpress.XtraEditors.XtraForm
    {
        BLL_Phong bll_phong = new BLL_Phong();
        BLL_Tang bll_tang = new BLL_Tang();
        DAL_Phong dal_phong = new DAL_Phong();
        DAL_LoaiPhong dal_lp = new DAL_LoaiPhong();
        BLL_SinhMa bll_sm = new BLL_SinhMa();
        BLL_TraPhong traphong = new BLL_TraPhong();
        BLL_DichVu bll_dichvu = new BLL_DichVu();
        BLL_HoaDon bll_hoadon = new BLL_HoaDon();
        BLL_ChiSoDienNuoc bll_csdn = new BLL_ChiSoDienNuoc();
        public frm_tienphong()
        {
            InitializeComponent();
        }
        string MaNV;
        public string MaNhanVien
        {
            get { return MaNV; }
            set { MaNV = value; }
        }
        private void frm_tienphong_Load(object sender, EventArgs e)
        {

            cbo_tang.DataSource = bll_tang.loadBangTang();
            cbo_tang.DisplayMember = "TENTANG";
            cbo_tang.ValueMember = "MATANG";

            txt_mahd.Text = bll_sm.SinhMaHoaDon();
            txt_manv.Text = MaNV;
            txt_ngaylaphd.Text= DateTime.Now.ToShortDateString();

            grv_hoadon.DataSource = bll_hoadon.LoadDataHoaDon();
        }

      

        private void cbo_tang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_maphong.DataSource = bll_phong.loadBang_Phongtheoma(cbo_tang.SelectedValue.ToString());
            cbo_maphong.DisplayMember = "MAPHONG";

        }

        private void cbo_maphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            PHONG p = new PHONG();
            LOAIPHONG lp = new LOAIPHONG();
            p = dal_phong.loadTenPhong(cbo_maphong.Text);
            lp = dal_lp.loadTenLoaiPhong(p.MALOAI);
            txt_tenphong.Text = p.TENPHONG.ToString();
            txt_loaiphong.Text = lp.TENLOAI;
            txt_tienphong.Text =lp.GIA.ToString();
            String kq = traphong.laySoDien(cbo_maphong.Text);
            if (kq == "")
            {
                txt_sodiendau.Text = "0";
            }
            else
            {
                txt_sodiendau.Text = kq;
            }

            String sn = traphong.laySoNuoc(cbo_maphong.Text);
            if (sn == "")
            {
                txt_sonuocdau.Text = "0";
            }
            else
            {
                txt_sonuocdau.Text = sn;
            }
        }

        private void ckb_wifi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_wifi.Checked == true)
            {
                ckb_wifi.Text = "có";
            }
            else
            {
                ckb_wifi.Text = "Không";
            }
        }

        private void ckb_rac_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_rac.Checked == true)
            {
                ckb_rac.Text = "có";
            }
            else
            {
                ckb_rac.Text = "Không";
            }
        }

        private void txt_sodiencuoi_TextChanged(object sender, EventArgs e)
        {

          
        }

        private void txt_sonuoccuoi_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void txt_sodien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tiendien = bll_dichvu.loaddv("DV001");
                double TienDien = Convert.ToInt32(txt_sodien.Text) * Convert.ToDouble(tiendien);
                txt_tiendien.Text = TienDien.ToString();
            }
            catch
            {

            }
        }

        private void txt_sonuoc_TextChanged(object sender, EventArgs e)
        {
            string tiennuoc = bll_dichvu.loaddv("DV002");
            double TienNuoc = Convert.ToInt32(txt_sonuoc.Text) * Convert.ToDouble(tiennuoc);
            txt_tiennuoc.Text = TienNuoc.ToString();
        }

     
        private void btn_tinhtienphong_Click(object sender, EventArgs e)
        {
            txt_tongtien.Text=TinhTienPhong().ToString();
            //lấy tiền điện nước
            string tienwifi = bll_dichvu.loaddv("DV003");
            string tienrac = bll_dichvu.loaddv("DV004");
            string tiendien = bll_dichvu.loaddv("DV001");
            string tiennuoc = bll_dichvu.loaddv("DV002");

            double TienNuoc = Convert.ToInt32(txt_sonuoc.Text) * Convert.ToDouble(tiennuoc);
            double TienDien = Convert.ToInt32(txt_sodien.Text) * Convert.ToDouble(tiendien);
            double wifi = Convert.ToDouble(tienwifi);
            double rac = Convert.ToDouble(tienrac);
            //thêm hóa đơn
            HOADON hd = new HOADON();
            hd.MAHOADON = txt_mahd.Text;
            hd.TIENDIEN = Convert.ToDecimal(tiendien);
            hd.TIENNUOC = Convert.ToDecimal(TienNuoc);
            hd.WIFI = Convert.ToDecimal(wifi);
            hd.RAC = Convert.ToDecimal(rac);
            hd.NGAYLAP = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            hd.TONGTIEN = Convert.ToDecimal(TinhTienPhong());
            hd.MANV = txt_manv.Text;
            hd.MAPHONG = cbo_maphong.Text;
            if(ckb_Tinhtrang.Checked==true)
            {
                ckb_Tinhtrang.Text ="Đã đóng";
                hd.TINHTRANG = true; }
            else
            {
                ckb_Tinhtrang.Text = "Chưa đóng";
                hd.TINHTRANG = false;
            }    
           
            //thêm chỉ số điện nước

            CHISO_DIENNUOC csdn = new CHISO_DIENNUOC();
            csdn.MAHOADON = txt_mahd.Text;
            csdn.SODIENCU = Convert.ToInt32(txt_sodiendau.Text);
            csdn.SODIENMOI = Convert.ToInt32(txt_sodiencuoi.Text);
            csdn.SONUOCCU = Convert.ToInt32(txt_sonuocdau.Text);
            csdn.SONUOCMOI = Convert.ToInt32(txt_sonuoccuoi.Text);
            csdn.SODIEN = Convert.ToInt32(txt_sodien.Text);
            csdn.SONUOC = Convert.ToInt32(txt_sonuoc.Text);

            if (txt_mahd.Text == string.Empty 
                  && txt_sodien.Text == string.Empty && txt_sonuoc.Text == string.Empty
                  && txt_sonuoccuoi.Text == string.Empty && txt_sodiencuoi.Text == string.Empty)
            {
                MessageBox.Show("không được để trống");
                return;
            }

            ////kiểm tra khóa chính
            if ((bll_hoadon.ktkc_HoaDon(hd.MAHOADON) == true))
            {
                MessageBox.Show("Trùng khóa chính Hóa đơn");
                return;
            }
            if (bll_csdn.ktkc_ChiSodn(hd.MAHOADON) == true)
            {
                MessageBox.Show("Trùng khóa chính chỉ số điện nước");
                return;
            }
            ////thêm

            if (bll_hoadon.Them_HoaDon(hd) == true && bll_csdn.Them_ChiSonc(csdn) == true)
            {
               
                MessageBox.Show("Thành công");

            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            frm_tienphong_Load(sender,e);
        }
        public Double TinhTienPhong()
        {
            string tiennuoc = bll_dichvu.loaddv("DV002");
            string tiendien = bll_dichvu.loaddv("DV001");
            string tienwifi = bll_dichvu.loaddv("DV003");
            string tienrac = bll_dichvu.loaddv("DV004");
            double TienNuoc = Convert.ToInt32(txt_sonuoc.Text) * Convert.ToDouble(tiennuoc);
            double TienDien = Convert.ToInt32(txt_sodien.Text) * Convert.ToDouble(tiendien);
            double wifi = Convert.ToDouble(tienwifi);
            double rac = Convert.ToDouble(tienrac);
            double TienPhong = Convert.ToDouble(txt_tienphong.Text);
            // String tienphong = laytienphong(txt_maphong.Text);
            double Tong;
            if (ckb_wifi.Checked == true && ckb_rac.Checked == false)
            {
                Tong = (TienDien + TienNuoc + wifi +TienPhong);
            }
            else if (ckb_wifi.Checked == false && ckb_rac.Checked == true)
            {
                Tong = (TienDien + TienNuoc + rac + TienPhong);
            }
            else if (ckb_wifi.Checked == false && ckb_rac.Checked == false)
            {
                Tong = (TienDien + TienNuoc + TienPhong);
            }
            else
            {
                Tong = (TienDien + TienNuoc + wifi + rac + TienPhong);
            }
            return Tong;
        }

        private void txt_sodiencuoi_Leave(object sender, EventArgs e)
        {

            try
            {
                int a = Convert.ToInt32(txt_sodiencuoi.Text);
                int b = Convert.ToInt32(txt_sodiendau.Text);
                if (a > b)
                {
                    int sd = Convert.ToInt32(txt_sodiencuoi.Text) - Convert.ToInt32(txt_sodiendau.Text);
                    txt_sodien.Text = sd.ToString();

                    string tiendien = bll_dichvu.loaddv("DV001");
                    double TienDien = Convert.ToInt32(txt_sodien.Text) * Convert.ToDouble(tiendien);
                    txt_tiendien.Text = String.Format("{0:#,##0.##} VNĐ", TienDien);
                }
                else
                {
                    MessageBox.Show("Lỗi! Số điện đầu phải nhỏ hơn số điện cuối");
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void txt_sonuoccuoi_Leave(object sender, EventArgs e)
        {
            
            try
            {
                int a = Convert.ToInt32(txt_sonuoccuoi.Text);
                int b = Convert.ToInt32(txt_sonuocdau.Text);
                if (a > b)
                {
                    int sd = Convert.ToInt32(txt_sonuoccuoi.Text) - Convert.ToInt32(txt_sonuocdau.Text);
                    txt_sonuoc.Text = sd.ToString();
                    string tiennuoc = bll_dichvu.loaddv("DV002");
                    double TienNuoc = Convert.ToInt32(txt_sonuoc.Text) * Convert.ToDouble(tiennuoc);
                    txt_tiennuoc.Text = String.Format("{0:#,##0.##} VNĐ", TienNuoc);
                }
                else
                {
                    MessageBox.Show("Lỗi! Số nước đầu phải nhỏ hơn số nước cuối");
                    return;
                }
            }
            catch
            {
                return;
            }
        
         }

        private void btn_suahd_Click(object sender, EventArgs e)
        {
            HOADON hd = new HOADON();
            int position = gridView1.FocusedRowHandle;
            hd.MAHOADON = gridView1.GetRowCellValue(position, "MaHD").ToString();
            if(ckb_Tinhtrang.Checked==true)
            {
                hd.TINHTRANG = true;
            }  
            else
            {
                hd.TINHTRANG = false;
            }   
           
        
            if(bll_hoadon.sua_HoaDon(hd)==true)
            {
                MessageBox.Show("Thành công");
            }    
            else
            {
                MessageBox.Show("Thất bại");
            }
            frm_tienphong_Load(sender,e);
        }
    }
}