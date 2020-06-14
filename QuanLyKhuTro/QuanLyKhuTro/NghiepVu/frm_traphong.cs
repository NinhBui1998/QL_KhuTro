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
using DAL.Model;
using DevExpress.Utils.Extensions;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_traphong : DevExpress.XtraEditors.XtraForm
    {
        BLL_SinhMa bll_sinhma = new BLL_SinhMa();
        DAL_Phong dal_phong = new DAL_Phong();
      
        DAL_LoaiPhong dal_lp = new DAL_LoaiPhong();
        DAL_Tang dal_tang = new DAL_Tang();
        DAL_LoaiPhong dal_loaiphong = new DAL_LoaiPhong();
        DAL_KhachThue dal_khachthue = new DAL_KhachThue();
        DAL_Phong ph = new DAL_Phong();

        BLL_Phong phong = new BLL_Phong();
        BLL_TraPhong traphong = new BLL_TraPhong();
        BLL_HopDong_KhachThue hopdong_khachthue = new BLL_HopDong_KhachThue();
        BLL_HopDong hopdong = new BLL_HopDong();
        BLL_KhachThue khachthue = new BLL_KhachThue();
        BLL_DatPhong datphong = new BLL_DatPhong();

        string Ten;
        public string TenPhong
        {
            get { return Ten; }
            set { Ten = value; }
        }
        public frm_traphong()
        {
            InitializeComponent();
        }

        private void frm_traphong_Load(object sender, EventArgs e)
        { 
            txt_tenphong.Text = Ten;
            grv_traphong.DataSource = traphong.LoadTraPhongtheoten(Ten);
            txt_maphong.Text = datphong.laymaphong(txt_tenphong.Text);
            String MaHD = bll_sinhma.SinhMaHoaDon().ToString();
            txt_ngaytra.Text = DateTime.Now.ToShortDateString();
          
            txt_mahd.Enabled = false;
            txt_ngaylap.Enabled = false;
            String kq = traphong.laySoDien(txt_maphong.Text);
            if(kq == "")
            {
                txt_sodiendau.Text ="0" ;
            }  
            else
            {
                txt_sodiendau.Text = kq;
            }

            String sn = traphong.laySoNuoc(txt_maphong.Text);
            if (sn == "")
            {
                txt_sonuocdau.Text = "0";
            }
            else
            {
                txt_sonuocdau.Text = kq;
            }
        }

        private void gridView_traphong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void txt_maphong_TextChanged(object sender, EventArgs e)
        {
 
            try
            {
                PHONG p = new PHONG();
                LOAIPHONG lp = new LOAIPHONG();
                TANG t = new TANG();
                
                p = dal_phong.loadTenPhong(txt_maphong.Text);
                lp = dal_lp.loadTenLoaiPhong(p.MALOAI);
                t = dal_tang.loadTenTang(p.MATANG);
                txt_sltoida.Text = p.SOLUONG_TD.ToString();
                txt_slhientai.Text = p.SOLUONG_HT.ToString();
                txt_loaiphong.Text = lp.TENLOAI;
                txt_tang.Text = t.TENTANG;
            }
            catch { MessageBox.Show("Lỗi hệ thống"); }
        }

        private void txt_makt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                KHACHTHUE kt = new KHACHTHUE();
                kt = dal_khachthue.loadTenKhachThue(txt_makt.Text);
                txt_cmnd.Text = kt.SOCMND;
                txt_sdt.Text = kt.SDT;
            }
            catch { MessageBox.Show("Lỗi hệ thống"); }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Xác nhận trả phòng!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                try
                {


                    int position = gridView_traphong.FocusedRowHandle;
                    string m = gridView_traphong.GetRowCellValue(position, "Makt").ToString();
                    string n = gridView_traphong.GetRowCellValue(position, "Mahd").ToString();

                    if (hopdong_khachthue.xoa_HopDong_KhachThue(n, m) == true)
                    {
                        if (hopdong.xoa_HopDong(n) == true)
                        {
                            if (khachthue.xoa_KhachThue(m) == true)
                            {

                                grv_traphong.DataSource = traphong.LoadTraPhong();
                            }

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


                    PHONG p = new PHONG();
                    p.MAPHONG = txt_maphong.Text;
                    p.TINHTRANG = false;
                    p.SOLUONG_HT = datphong.demsohd(p.MAPHONG);

                    if (phong.sua_slhientai(p) == true)
                    {

                        MessageBox.Show(" thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sữa slht thất bại");
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi !!!");
                }

                frm_traphong_Load(sender, e);
                txt_slhientai.Text = (datphong.demsohd(datphong.laymaphong(Ten))).ToString();
            }
            else
            {
                return;
            }    
        }

        private void ckb_wifi_CheckedChanged(object sender, EventArgs e)
        {
            if(ckb_wifi.Checked==true)
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

        private void grv_traphong_Click(object sender, EventArgs e)
        {
            HOPDONG hd = new HOPDONG();
            HOPDONG_KT hd_kt = new HOPDONG_KT();
            TraPhong tp = new TraPhong();
            PHONG p = new PHONG();
            int position = gridView_traphong.FocusedRowHandle;
            try
            {

                tp.Mahd = gridView_traphong.GetRowCellValue(position, "Mahd").ToString();
                //  p.MAPHONG = gridView_traphong.GetRowCellValue(position, "Maphong").ToString();
                tp.Makt = gridView_traphong.GetRowCellValue(position, "Makt").ToString();
                tp.Tenkt = gridView_traphong.GetRowCellValue(position, "Tenkt").ToString();
                tp.Ngaylap = Convert.ToDateTime(gridView_traphong.GetRowCellValue(position, "Ngaylap").ToString());
              //  tp.Ngaytra = Convert.ToDateTime(gridView_traphong.GetRowCellValue(position, "Ngaytra").ToString());
                hd_kt.TRACOC = Convert.ToBoolean(gridView_traphong.GetRowCellValue(position, "Tracoc").ToString());


                txt_mahd.Text = tp.Mahd.ToString();
                // txt_maphong.Text = p.MAPHONG.ToString();
                txt_makt.Text = tp.Makt.ToString();
                txt_tenkt.Text = tp.Tenkt.ToString();
                txt_ngaylap.Text = tp.Ngaylap.ToString();
             //   txt_ngaytra.Text = tp.Ngaytra.ToString();
                ckb_tracoc.Checked = hd_kt.TRACOC.Value;
                if (ckb_tracoc.Checked == true)
                {
                    ckb_tracoc.Text = "Rồi";
                }
                else
                {
                    ckb_tracoc.Text = "Chưa";
                }

            }
            catch { }
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_traphong.DataSource = traphong.LoadTraPhong();
        }

        private void txt_sodiencuoi_TextChanged(object sender, EventArgs e)
        {
            int sd =Convert.ToInt32(txt_sodiencuoi.Text) - Convert.ToInt32(txt_sodiendau.Text);
            txt_sodien.Text =sd.ToString();
        }

        private void txt_sonuoccuoi_TextChanged(object sender, EventArgs e)
        {
            int sd = Convert.ToInt32(txt_sonuoccuoi.Text) - Convert.ToInt32(txt_sonuocdau.Text);
            txt_sonuoc.Text = sd.ToString();
        }
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public string laytienphong(string pma)
        {
            var k = (from p in data.PHONGs
                     from lp in data.LOAIPHONGs
                     where p.MALOAI == lp.MALOAI && p.MAPHONG == pma
                     select lp.GIA).FirstOrDefault();
            return k.ToString();
        }
        public Double TinhTienPhong()
        {
            double TienNuoc = Convert.ToInt32(txt_sonuoc.Text) * Convert.ToInt32(6000);
            double TienDien= Convert.ToInt32(txt_sonuoc.Text) * Convert.ToInt32(3000);
            double wifi = 60000;
            double rac = 20000;
           // String tienphong = laytienphong(txt_maphong.Text);
            double Tong = (TienDien + TienNuoc + wifi + rac);
            return Tong;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
                txt_tongtien.Text = TinhTienPhong().ToString();
            
           
        }
    }
}