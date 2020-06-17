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
                txt_sonuocdau.Text = kq;
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

            int sd = Convert.ToInt32(txt_sodiencuoi.Text) - Convert.ToInt32(txt_sodiendau.Text);
            txt_sodien.Text = sd.ToString();
        }

        private void txt_sonuoccuoi_TextChanged(object sender, EventArgs e)
        {
            int sd = Convert.ToInt32(txt_sonuoccuoi.Text) - Convert.ToInt32(txt_sonuocdau.Text);
            txt_sonuoc.Text = sd.ToString();
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

        }
        public Double TinhTienPhong()
        {
            string tiennuoc = bll_dichvu.loaddv("DV002");
            string tiendien = bll_dichvu.loaddv("DV001");
            string tienwifi = bll_dichvu.loaddv("DV003");
            string tienrac = bll_dichvu.loaddv("DV004");
            double TienNuoc = Convert.ToDouble(txt_tiennuoc.Text);
            double TienDien = Convert.ToDouble(txt_tiendien.Text);
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
    }
}