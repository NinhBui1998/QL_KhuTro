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
using BLL.NghiepVu;
using DAL.DuLieu;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_tienphong : DevExpress.XtraEditors.XtraForm
    {
        WordExport we = new WordExport();
        BLL_Phong bll_phong = new BLL_Phong();
        DAL_NhanVien dal_nv = new DAL_NhanVien();
        BLL_Tang bll_tang = new BLL_Tang();
        DAL_Phong dal_phong = new DAL_Phong();
        DAL_LoaiPhong dal_lp = new DAL_LoaiPhong();
        BLL_SinhMa bll_sm = new BLL_SinhMa();
        BLL_TraPhong traphong = new BLL_TraPhong();
        BLL_DichVu bll_dichvu = new BLL_DichVu();
        BLL_HoaDon bll_hoadon = new BLL_HoaDon();
        BLL_ChiSoDienNuoc bll_csdn = new BLL_ChiSoDienNuoc();
        DAL_KhachThue dal_khachthue = new DAL_KhachThue();
    
        BLL_TienPhongHangThang bLL_TienPhongHangThang = new BLL_TienPhongHangThang();
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
            DateTime d = DateTime.Now;
            txt_nam.Text = d.Year.ToString();
            cbo_tang.DataSource = bll_tang.loadBangTang();
            cbo_tang.DisplayMember = "TENTANG";
            cbo_tang.ValueMember = "MATANG";
            cbo_maphong.DataSource = bll_phong.loadBang_Phong();
            cbo_maphong.DisplayMember = "TENPHONG";
            cbo_maphong.ValueMember = "MAPHONG";

            txt_mahd.Text = bll_sm.SinhMaHoaDon();
            txt_manv.Text = MaNV;
            txt_ngaylaphd.Text= DateTime.Now.ToShortDateString();

            string[] s = { "01", "02", "03", "04",  "05", "06", "07", "08", "09", "10", "11", "12" };
            cbo_thang.DataSource = s;
        }

      

        private void cbo_tang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_maphong.DataSource = bll_phong.loadBang_Phongtheoma(cbo_tang.SelectedValue.ToString());
            cbo_maphong.DisplayMember = "TENPHONG";
            cbo_maphong.ValueMember = "MAPHONG";

        }

        private void cbo_maphong_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public bool kttinhtienthaothang(string pmap, DateTime thangnam)
        {
            var kq = (from h in data.HOADONs
                      where h.MAPHONG == pmap && h.THANGNAM == thangnam
                      select h).Count();
            if(kq>0)
            {
                return true;
            }
            else
            {
                return false;
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
        public double tinhtiendien()
        {

            double dientuyen1 = bll_dichvu.laygiadien("BAC001");
            double dientuyen2 = bll_dichvu.laygiadien("BAC002");
            double dientuyen3 = bll_dichvu.laygiadien("BAC003");
            double dientuyen4 = bll_dichvu.laygiadien("BAC004");
            double dientuyen5 = bll_dichvu.laygiadien("BAC005");
            double dientuyen6 = bll_dichvu.laygiadien("BAC006");
            double TienDien = 0;
            int sodien = Convert.ToInt32(txt_sodien.Text);
            if (sodien >= 0 && sodien <= 50)
            {
                TienDien += sodien * dientuyen1;
            }
            else if (sodien > 50 && sodien <= 100)
            {
                TienDien += (sodien - (sodien - 50)) * dientuyen1 + (sodien - 50) * dientuyen2;
            }
            else if (sodien > 100 && sodien <= 200)
            {
                TienDien += 50 * dientuyen1 + 50 * dientuyen2 + (sodien - 100) * dientuyen3;

            }
            else if (sodien > 200 && sodien <= 300)
            {
                TienDien += 50 * dientuyen1 + 50 * dientuyen2 + 100 * dientuyen3 + (sodien - 200) * dientuyen4;
            }
            else if (sodien > 300 && sodien <= 400)
            {
                TienDien += 50 * dientuyen1 + 50 * dientuyen2 + 100 * dientuyen3 + 100 * dientuyen4 + (sodien - 300) * dientuyen5;
            }
            else
            {
                TienDien += 50 * dientuyen1 + 50 * dientuyen2 + 100 * dientuyen3 + 100 * dientuyen4 + 100 * dientuyen5 + (sodien - 400) * dientuyen6;

            }
            return TienDien;

        }
        public double tiennuoc()
        {
            string tiennuoc = bll_dichvu.loaddv("DV001");
            double TienNuoc = Convert.ToInt32(txt_sonuoc.Text) * Convert.ToDouble(tiennuoc);
            return TienNuoc;
        }
        public double tienrac()
        {
            string tienrac = bll_dichvu.loaddv("DV003");
            double rac = Convert.ToDouble(tienrac);
            return rac;
        }
        public double tienwifi()
        {
            string tienwifi = bll_dichvu.loaddv("DV002");
            double wifi = Convert.ToDouble(tienwifi);
            return wifi;
        }

        public Double TinhTienPhong()
        {
            double tienphong =Convert.ToDouble( txt_tienphong.Text);
            double Tong;
            if (ckb_wifi.Checked == true && ckb_rac.Checked == false)
            {
                Tong = (tinhtiendien() + tiennuoc() + tienwifi()+tienphong);
            }
            else if (ckb_wifi.Checked == false && ckb_rac.Checked == true)
            {
                Tong = (tinhtiendien() + tiennuoc() + tienrac()+tienphong);
            }
            else if (ckb_wifi.Checked == false && ckb_rac.Checked == false)
            {
                Tong = (tinhtiendien() + tiennuoc()+tienphong);
            }
            else
            {
                Tong = (tinhtiendien() + tiennuoc() + tienrac() + tienwifi()+tienphong);
            }
            return Tong;
        }
        private void txt_sodien_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                txt_tiendien.Text = String.Format("{0:#,##0.##}", tinhtiendien().ToString());
            }
            catch
            {
                return;
            }
        }

        private void txt_sonuoc_TextChanged(object sender, EventArgs e)
        {
            try {
               
                txt_tiennuoc.Text = String.Format("{0:#,##0.##}", tiennuoc().ToString());
            }
            catch
            {
                return;
            }
            
            
        }

     
        private void btn_tinhtienphong_Click(object sender, EventArgs e)
        {
            txt_tongtien.Text= String.Format("{0:#,##0.##}", TinhTienPhong()); 
            
            //thêm hóa đơn
            HOADON hd = new HOADON();
            hd.MAHOADON = txt_mahd.Text;
            hd.TIENDIEN = Convert.ToDecimal(tinhtiendien());
            hd.TIENNUOC = Convert.ToDecimal(tiennuoc());
            hd.WIFI = Convert.ToDecimal(tienwifi());
            hd.RAC = Convert.ToDecimal(tienrac());
            hd.NGAYLAP = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            hd.TONGTIEN = Convert.ToDecimal(TinhTienPhong());
            hd.MANV = txt_manv.Text;
            hd.MAPHONG = cbo_maphong.SelectedValue.ToString();
            hd.THANGNAM =Convert.ToDateTime("05"+"/"+ cbo_thang.Text + "/" + txt_nam.Text);
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
            //frm_tienphong_Load(sender,e);
            grv_hoadon.DataSource = bLL_TienPhongHangThang.LoadDataHoaDontheomaphong(cbo_maphong.SelectedValue.ToString());

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
                    txt_tiendien.Text = String.Format("{0:#,##0.##} ", tinhtiendien());
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
                    
                    txt_tiennuoc.Text = String.Format("{0:#,##0.##} ", tiennuoc());
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
            int position = gridView_hoadon.FocusedRowHandle;
            hd.MAHOADON = gridView_hoadon.GetRowCellValue(position, "MaHD").ToString();
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
            grv_hoadon.DataSource = bLL_TienPhongHangThang.LoadDataHoaDontheomaphong(cbo_maphong.SelectedValue.ToString());

        }

        private void btn_xuathd_Click(object sender, EventArgs e)
        {
            int position = gridView_hoadon.FocusedRowHandle;
            string mahd = gridView_hoadon.GetRowCellValue(position, "MaHD").ToString();
            NHANVIEN nv = new NHANVIEN();
            string manv = txt_manv.Text;
            nv = dal_nv.loadTenNV(txt_manv.Text);
            // data 
            string ngaylap = DateTime.Now.ToShortDateString();
            string tennv = nv.TENNV;
            string tenphong = gridView_hoadon.GetRowCellValue(position, "TenPhong").ToString();
            string tentang = gridView_hoadon.GetRowCellValue(position, "TenTang").ToString();
            string tienphong =txt_tienphong.Text;
            string CSDDau = txt_sodiendau.Text;
            string CSDCuoi = txt_sodiencuoi.Text;
            int sodien = Convert.ToInt32(gridView_hoadon.GetRowCellValue(position, "SoDien").ToString());
            string DonGiaDien;
            if (sodien >= 0 && sodien <= 50)
            {
                DonGiaDien = (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.laygiadien("BAC001"))).ToString());
            }
            else if (sodien > 50 && sodien <= 100)
            {
                DonGiaDien = (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.laygiadien("BAC001"))).ToString()) + "-" + (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.laygiadien("BAC002"))).ToString());
            }
            else if (sodien > 100 && sodien <= 200)
            {
                DonGiaDien = (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.laygiadien("BAC001"))).ToString()) + "-" + (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.laygiadien("BAC002"))).ToString()) + "-" + (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.laygiadien("BAC003"))).ToString());
            }
            else if (sodien > 200 && sodien <= 300)
            {
                DonGiaDien = bll_dichvu.laygiadien("BAC004").ToString();
            }
            else if (sodien > 300 && sodien <= 400)
            {
                DonGiaDien = bll_dichvu.laygiadien("BAC005").ToString();
            }
            else
            {
                DonGiaDien = bll_dichvu.laygiadien("BAC006").ToString();
            }
            string TienDien = txt_tiendien.Text;
            string CSNDau = txt_sonuocdau.Text;
            string CSNCuoi = txt_sonuoccuoi.Text;
            string DonGiaNuoc = (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.loaddv("DV001"))).ToString());
            string TienNuoc = txt_tiennuoc.Text;
            string DonGiaWifi = (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.loaddv("DV002"))).ToString());
            string DonGiaRac = (String.Format("{0:#,##0.##}", Convert.ToDouble(bll_dichvu.loaddv("DV003"))).ToString()); ;
            string TongTien = txt_tongtien.Text;
            we.PhieuThuTienTro(ngaylap,tenphong,tentang, tienphong, CSDDau, CSDCuoi,
                DonGiaDien, TienDien, CSNDau, CSNCuoi, DonGiaNuoc, TienNuoc, DonGiaWifi,
                DonGiaRac, TongTien,mahd, manv, tennv);
        }

        private void ckb_Tinhtrang_Click(object sender, EventArgs e)
        {
            if(ckb_Tinhtrang.Checked==true)
            {
                ckb_Tinhtrang.Text = "Đã nạp";
            }   
            else
            {
                ckb_Tinhtrang.Text = "Chưa nạp";
            }    
        }

        private void cbo_thang_Click(object sender, EventArgs e)
        {
            try { 
           
                txt_sodiencuoi.Clear();
                txt_sonuoccuoi.Clear();
                txt_mahd.Text = bll_sm.SinhMaHoaDon();
            }
            catch
            {
                return;
            }
        }
        DAL_Tang dal_tang = new DAL_Tang();
        private void cbo_maphong_Click(object sender, EventArgs e)
        {
            PHONG p = new PHONG();
            TANG t = new TANG();
            LOAIPHONG lp = new LOAIPHONG();
            p = dal_phong.loadTenPhong(cbo_maphong.SelectedValue.ToString());
            lp = dal_lp.loadTenLoaiPhong(p.MALOAI);
            t = dal_tang.loadTenTang(p.MATANG);
            //txt_tenphong.Text = p.TENPHONG.ToString();
            cbo_tang.Text = string.Empty;
            cbo_tang.Text = t.TENTANG;
            txt_loaiphong.Text = lp.TENLOAI;
            txt_ma.Text = p.MAPHONG;
            txt_tienphong.Text = String.Format("{0:#,##0.##}", Convert.ToDouble(lp.GIA.ToString()));
            String kq = traphong.laySoDien(cbo_maphong.SelectedValue.ToString());
            if (kq == "")
            {
                txt_sodiendau.Text = "0";
            }
            else
            {
                txt_sodiendau.Text = kq;
            }

            String sn = traphong.laySoNuoc(cbo_maphong.SelectedValue.ToString());
            if (sn == "")
            {
                txt_sonuocdau.Text = "0";
            }
            else
            {
                txt_sonuocdau.Text = sn;
            }
            txt_mahd.Text = bll_sm.SinhMaHoaDon();
            txt_sodiencuoi.Clear();
            txt_sonuoccuoi.Clear();
            txt_sonuoc.Clear();
            txt_sodien.Clear();
            txt_tongtien.Clear();
            txt_tiendien.Clear();
            txt_tiennuoc.Clear();
            DateTime thang = Convert.ToDateTime("05" + "/" + cbo_thang.Text + "/" + txt_nam.Text);
            if (kttinhtienthaothang(cbo_maphong.SelectedValue.ToString(), thang) == true)
            {
                btn_tinhtienphong.Enabled = false;
            }
            else
            { btn_tinhtienphong.Enabled = true; }

            grv_hoadon.DataSource = bLL_TienPhongHangThang.LoadDataHoaDontheomaphong(cbo_maphong.SelectedValue.ToString());
        }
    }
}