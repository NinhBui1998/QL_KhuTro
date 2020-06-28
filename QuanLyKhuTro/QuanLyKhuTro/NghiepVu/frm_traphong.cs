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
using DAL.Model;
using DevExpress.Utils.Extensions;
using BLL.NghiepVu;
using DAL.DuLieu;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_traphong : DevExpress.XtraEditors.XtraForm
    {
        WordExport we = new WordExport();
        BLL_SinhMa bll_sinhma = new BLL_SinhMa();
        DAL_Phong dal_phong = new DAL_Phong();
      
        DAL_LoaiPhong dal_lp = new DAL_LoaiPhong();
        DAL_Tang dal_tang = new DAL_Tang();
        DAL_LoaiPhong dal_loaiphong = new DAL_LoaiPhong();
        DAL_KhachThue dal_khachthue = new DAL_KhachThue();
        DAL_Phong ph = new DAL_Phong();

        BLL_Phong phong = new BLL_Phong();
        BLL_TraPhong traphong = new BLL_TraPhong();
      
        BLL_HopDong hopdong = new BLL_HopDong();
        BLL_KhachThue khachthue = new BLL_KhachThue();
        BLL_DatPhong datphong = new BLL_DatPhong();
        BLL_DichVu bll_dichvu = new BLL_DichVu();
        BLL_HoaDon bll_hoadon = new BLL_HoaDon();
        BLL_ChiSoDienNuoc bll_csdn = new BLL_ChiSoDienNuoc();

        string Ten;
        public string TenPhong
        {
            get { return Ten; }
            set { Ten = value; }
        }
        string MAnv;
        public string MaNhanVien
        {
            get { return MAnv; }
            set { MAnv = value; }
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
           
            
            txt_ngaytra.Text = DateTime.Now.ToShortDateString();
            txt_manv.Text = MAnv;
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
                txt_sonuocdau.Text = sn;
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


                txt_mahd.Text = tp.Mahd.ToString();
                // txt_maphong.Text = p.MAPHONG.ToString();
                txt_makt.Text = tp.Makt.ToString();
                txt_tenkt.Text = tp.Tenkt.ToString();
                txt_ngaylap.Text = tp.Ngaylap.ToString();
             //   txt_ngaytra.Text = tp.Ngaytra.ToString();
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
            string tiennuoc = bll_dichvu.loaddv("DV002");
            string tienrac = bll_dichvu.loaddv("DV004");
            string tiendien = bll_dichvu.loaddv("DV001");
            string tienwifi = bll_dichvu.loaddv("DV003");
            
            double TienNuoc = Convert.ToInt32(txt_sonuoc.Text) * Convert.ToDouble(tiennuoc);
            double TienDien = Convert.ToInt32(txt_sodien.Text) * Convert.ToDouble(tiendien);
            double wifi = Convert.ToDouble(tienwifi);
            double rac = Convert.ToDouble(tienrac);
            // String tienphong = laytienphong(txt_maphong.Text);
            double Tong;
            if (ckb_wifi.Checked == true && ckb_rac.Checked == false)
            {
                Tong = (TienDien + TienNuoc + wifi);
            }
            else if (ckb_wifi.Checked == false && ckb_rac.Checked == true)
            {
                Tong = (TienDien + TienNuoc + rac);
            }
            else if (ckb_wifi.Checked == false && ckb_rac.Checked == false)
            {
                Tong = (TienDien + TienNuoc);
            }
            else
            {
                Tong = (TienDien + TienNuoc + wifi + rac);
            }
            return Tong;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String MaHD = bll_sinhma.SinhMaHoaDon().ToString();
                txt_tongtien.Text = String.Format("{0:#,##0.##}", TinhTienPhong());
          
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
                hd.MAHOADON = MaHD;
                hd.TIENDIEN =Convert.ToDecimal(tiendien);
                hd.TIENNUOC= Convert.ToDecimal(TienNuoc);
                hd.WIFI = Convert.ToDecimal(wifi);
                hd.RAC= Convert.ToDecimal(rac);
                hd.NGAYLAP = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                hd.TONGTIEN = Convert.ToDecimal(TinhTienPhong());
                hd.MANV = txt_manv.Text;
                hd.MAPHONG = txt_maphong.Text;
                hd.TINHTRANG = false;
                //thêm chỉ số điện nước

                CHISO_DIENNUOC csdn = new CHISO_DIENNUOC();
                csdn.MAHOADON = MaHD;
                csdn.SODIENCU = Convert.ToInt32( txt_sodiendau.Text);
                csdn.SODIENMOI = Convert.ToInt32(txt_sodiencuoi.Text);
                csdn.SONUOCCU = Convert.ToInt32(txt_sonuocdau.Text);
                csdn.SONUOCMOI = Convert.ToInt32(txt_sonuoccuoi.Text);
                csdn.SODIEN = Convert.ToInt32(txt_sodien.Text);
                csdn.SONUOC = Convert.ToInt32(txt_sonuoc.Text);

                if (lb_manv.Text == string.Empty && txt_mahd.Text == string.Empty
                      && txt_tiendien.Text == string.Empty && txt_tiennuoc.Text == string.Empty
                      && txt_tongtien.Text==string.Empty && txt_maphong.Text==string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }

                ////kiểm tra khóa chính
                if ((bll_hoadon.ktkc_HoaDon(hd.MAHOADON)== true))
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

                if (bll_hoadon.Them_HoaDon(hd) == true && bll_csdn.Them_ChiSonc(csdn) == true )
                {
                    grv_traphong.DataSource = datphong.LoadDatPhong();
                    MessageBox.Show("Thành công");

                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                frm_traphong_Load(sender,e);
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void frm_traphong_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_test frm = new frm_test();
            frm.MaNhanVien = MAnv;
            Visible = false;
            frm.ShowDialog();
        }

      
        private void txt_tiendien_TextChanged(object sender, EventArgs e)
        {
            ////địng dạng tiền tệ
            //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            //decimal value = decimal.Parse(txt_tiendien.Text, System.Globalization.NumberStyles.AllowThousands);
            //txt_tiendien.Text = String.Format(culture, "{0:N0}", value);
            ////texbox1.Text = String.Format(culture, "{0:N0}", value);
            //txt_tiendien.Select(txt_tiendien.Text.Length, 0);

        }

        private void txt_tiennuoc_TextChanged(object sender, EventArgs e)
        {
            //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            //decimal value = decimal.Parse(txt_tiennuoc.Text, System.Globalization.NumberStyles.AllowThousands);
            //txt_tiennuoc.Text = String.Format(culture, "{0:N0}", value);
            ////texbox1.Text = String.Format(culture, "{0:N0}", value);
            //txt_tiennuoc.Select(txt_tiendien.Text.Length, 0);
        }

        private void txt_sodiencuoi_Leave(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(txt_sodiencuoi.Text);
                int b = Convert.ToInt32(txt_sodiendau.Text);
                if (a >= b)
                {
                    int sd = Convert.ToInt32(txt_sodiencuoi.Text) - Convert.ToInt32(txt_sodiendau.Text);
                    txt_sodien.Text = sd.ToString();

                    string tiendien = bll_dichvu.loaddv("DV001");

                    double TienDien = Convert.ToInt32(txt_sodien.Text) * Convert.ToDouble(tiendien);
                    txt_tiendien.Text = String.Format("{0:#,##0.##}", TienDien);
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
                if (a >= b)
                {
                    int sd = Convert.ToInt32(txt_sonuoccuoi.Text) - Convert.ToInt32(txt_sonuocdau.Text);
                    txt_sonuoc.Text = sd.ToString();
                    string tiennuoc = bll_dichvu.loaddv("DV002");
                    double TienNuoc = Convert.ToInt32(txt_sonuoc.Text) * Convert.ToDouble(tiennuoc);
                    txt_tiennuoc.Text = String.Format("{0:#,##0.##}", TienNuoc);
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
        private void btn_in_Click(object sender, EventArgs e)
        {
            int position = gridView_traphong.FocusedRowHandle;
            string mahd = gridView_traphong.GetRowCellValue(position, "Mahd").ToString();
            string maphong = gridView_traphong.GetRowCellValue(position, "Maphong").ToString();

            KHACHTHUE kt = new KHACHTHUE();
        //    kt = dal_khachthue.loadTenKT(hopdong_khachthue.laymakt(mahd));


            PHONG p = new PHONG();
            p = dal_phong.loadTenPhong(maphong);

            // data 
            string ngaytra = DateTime.Now.ToShortDateString();
            string tenphong = p.TENPHONG;
            string tenkt = kt.TENKT;
            string tracoc = "Chưa";
            string CSDDau = txt_sodiendau.Text;
            string CSDCuoi = txt_sodiencuoi.Text;
            string DonGiaDien = "3,000";
            string TienDien = txt_tiendien.Text;
            string CSNDau = txt_sonuocdau.Text;
            string CSNCuoi = txt_sonuoccuoi.Text;
            string DonGiaNuoc = "6,000";
            string TienNuoc = txt_tiennuoc.Text;
            string DonGiaWifi = "60,000";
            string DonGiaRac = "20,000";
            string TongTien = txt_tongtien.Text;
            we.ThongTinTraPhong(ngaytra, tenphong, tenkt, tracoc, CSDDau, CSDCuoi,
                DonGiaDien, TienDien, CSNDau, CSNCuoi, DonGiaNuoc, TienNuoc, DonGiaWifi,
                DonGiaRac, TongTien);
        }

        private void ckb_tracoc_CheckedChanged(object sender, EventArgs e)
        {
            if(ckb_tracoc.Checked==true)
            {
                ckb_tracoc.Text = "Đã trả cọc";
            }
            else
            {
                ckb_tracoc.Text = "Chưa trả cọc";
            }    
        }
    }
}