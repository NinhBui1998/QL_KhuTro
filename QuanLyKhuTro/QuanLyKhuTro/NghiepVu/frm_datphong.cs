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
using System.IO;
using System.Globalization;
using DAL.DuLieu;
using QuanLyKhuTro.DanhMuc;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_datphong : DevExpress.XtraEditors.XtraForm
    {
        WordExport we = new WordExport();
        DAL_Phong dal_phong = new DAL_Phong();
        DAL_Tang dal_tang = new DAL_Tang();
        DAL_LoaiPhong dal_lp = new DAL_LoaiPhong();
        BLL_KhachThue khachthue = new BLL_KhachThue();
        BLL_LoaiPhong loaip = new BLL_LoaiPhong();
        BLL_Tang tang = new BLL_Tang();
        BLL_Phong phong = new BLL_Phong();
        BLL_HopDong hopdong = new BLL_HopDong();
        BLL_DatPhong datphong = new BLL_DatPhong();
     
        BLL_SinhMa bll_sinhma = new BLL_SinhMa();
        DAL_NhanVien dal_nv = new DAL_NhanVien();
        DAL_KhachThue dal_kt = new DAL_KhachThue();

        string Ten;
        public string TenPhong
        {
            get { return Ten; }
            set { Ten = value; }
        }

        string MaNV;
        public string MaNhanVien
        {
            get { return MaNV; }
            set { MaNV = value; }
        }
        public frm_datphong()
        {
            InitializeComponent();
        }
        public frm_datphong(frm_test us)
        {
            InitializeComponent();
        }
        public delegate void updatedelegate(object sender, UpdateEventArgs args);
        public event updatedelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string data
            {
                get;
                set;
            }
        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void frm_datphong_Load(object sender, EventArgs e)
        {
            PHONG p = new PHONG();
            txt_phong.Text = Ten;

            grv_datphong.DataSource = datphong.LoadDatPhongTheoMa(Ten);
            txt_manv.Text = MaNV;
            txt_ngaylaphd.Text = DateTime.Now.ToShortDateString();
            txt_makt.Text = bll_sinhma.SinhMa_KhachThue();
            txt_mahd.Text = bll_sinhma.SinhMa_HopDong();

            //cbb_tang.Enabled = cbb_loaiphong.Enabled = cbb_phong.Enabled = false;
            //btn_sua.Enabled = false;
            //txt_makt.Enabled = txt_tenkt.Enabled = rdb_nam.Enabled = rdb_nu.Enabled = txt_sdt.Enabled
            //    = txt_quequan.Enabled = txt_cmnd.Enabled = txt_ngaysinh.Enabled = pic_anh.Enabled = false;
            //txt_mahd.Enabled = txt_tiencoc.Enabled = txt_thoihan.Enabled = txt_manv.Enabled = txt_ngaylaphd.Enabled = false;

            //string pos = gridView_datphong.GetRowCellValue(gridView_datphong.RowCount - 1, "Makt").ToString();
            //pos = pos.Substring(2);
            //int k = (int.Parse(pos) + 1);
            //if (k < 10)
            //{
            //    txt_makt.Text = "KT00" + k;
            //}
            //else if (k >= 10 && k < 100)
            //{
            //    txt_makt.Text = "KT0" + k;
            //}
            ////sinh mã hợp đồng
            //string pos1 = gridView_datphong.GetRowCellValue(gridView_datphong.RowCount - 1, "Mahd").ToString();
            //pos1 = pos1.Substring(2);
            //int k1 = (int.Parse(pos1) + 1);
            //if (k1 < 10)
            //{
            //    txt_mahd.Text = "HD00" + k1;
            //}
            //else if (k1 >= 10 && k1 < 100)
            //{
            //    txt_mahd.Text = "HD0" + k1;
            //}



        }

        private void gridView_datphong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //KHACHTHUE kt = new KHACHTHUE();
            //HOPDONG hd = new HOPDONG();

            //DatPhong dp = new DatPhong();
            ////btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            ////btn_them.Enabled = false;
            //int position = gridView_datphong.FocusedRowHandle;
            //try
            //{
            //    dp.Mahd = gridView_datphong.GetRowCellValue(position, "MAHD").ToString();
            //    dp.Makt = gridView_datphong.GetRowCellValue(position, "Makt").ToString();

            //    txt_mahd.Text = dp.Mahd.ToString();
            //    txt_makt.Text = dp.Makt.ToString();
            //}
            //catch { }
        }

        private void btn_taohd_Click(object sender, EventArgs e)
        {
            KHACHTHUE kt = new KHACHTHUE();
            HOPDONG hd = new HOPDONG();
         
            //thêm hợp đồng

            hd.MAHD = txt_mahd.Text;
            hd.TIENCOC = decimal.Parse(txt_tiencoc.Text);
            hd.NGAYLAPHD = Convert.ToDateTime(txt_ngaylaphd.Text);
            //hd.MAPHONG = datphong.laymaphong(Ten);
            hd.MANV = txt_manv.Text;
            hd.MAKT = txt_makt.Text;
            hd.NGAYTRA = Convert.ToDateTime(txt_ngaykt.Text);


            //Thêm khách thuê vào hợp đồng
            kt.MAKT = txt_makt.Text;
            kt.TENKT = txt_tenkt.Text;
            kt.SDT = txt_sdt.Text;
            kt.MAPHONG = datphong.laymaphong(Ten);
            kt.TRUONGPHONG = true;
            if (pic_anh.Image != null)
            {
                byte[] b = convertImage(pic_anh.Image);
                kt.ANH = b;
            }
            else
            {
                kt.ANH = null;
            }
            if (rdb_nam.Checked == true)
            {
                kt.GIOITINH = rdb_nam.Text;
            }
            else
            {
                kt.GIOITINH = rdb_nu.Text;
            }
            kt.SOCMND = txt_cmnd.Text;
            kt.NGAYSINH = Convert.ToDateTime(txt_ngaysinh.Text);
            kt.QUEQUAN = txt_quequan.Text;
          
            

            if (txt_makt.Text == string.Empty && txt_mahd.Text == string.Empty
                    && txt_manv.Text == string.Empty && txt_tenkt.Text == string.Empty)
            {
                MessageBox.Show("không được để trống");
                return;
            }

            //kiểm tra khóa chính
            if (khachthue.ktkc_khachthue(kt.MAKT) == true)
            {
                MessageBox.Show("Trùng khóa chính khách thuê");
                return;
            }
            if (hopdong.ktkc_HopDong(txt_mahd.Text) == true)
            {
                MessageBox.Show("Trùng khóa chính hợp đồng");
                return;
            }
            //thêm

            if (khachthue.ThemKT(kt) == true && hopdong.them_HopDong(hd) == true)
            {
                grv_datphong.DataSource = datphong.LoadDatPhongTheoMa(Ten);

            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            //sửa số lượng hiện tại trong phòng
            PHONG ph = new PHONG();
            ph.MAPHONG = datphong.laymaphong(Ten);
            ph.TINHTRANG = true;
            ph.SOLUONG_HT = datphong.demsohd(ph.MAPHONG);
            if (phong.sua_slhientai(ph) == true)
            {

                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            frm_datphong_Load(sender, e);
            txt_soluonght.Text = (datphong.demsohd(datphong.laymaphong(Ten))).ToString();
        }

        private void cbb_phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    PHONG p = new PHONG();
            //    cbb_phong.Text = string.Empty;
            //p = dal_phong.loadTenPhong(cbb_phong.SelectedValue.ToString());
            //    txt_soluongtd.Text = p.SOLUONG_TD.ToString();
            //    txt_soluonght.Text = p.SOLUONG_HT.ToString();
            //}
            //catch { MessageBox.Show("Lỗi hệ thống"); }
          
            //txt_soluonght.Text = datphong.layslht(cbb_phong.SelectedValue.ToString());

            //PHONG p = new PHONG();
            //p = dal_phong.loadTenPhong(cbb_phong.SelectedValue.ToString());
            //txt_soluongtd.Text = p.SOLUONG_TD.ToString();
        }

        private void txt_phong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PHONG p = new PHONG();
                LOAIPHONG lp = new LOAIPHONG();
                TANG t = new TANG();
                p = dal_phong.loadTenPhong(datphong.laymaphong(Ten));
                lp = dal_lp.loadTenLoaiPhong(p.MALOAI);
                t = dal_tang.loadTenTang(p.MATANG);
                txt_soluongtd.Text = p.SOLUONG_TD.ToString();
                txt_soluonght.Text = p.SOLUONG_HT.ToString();
                txt_loaiphong.Text = lp.TENLOAI;
                txt_matang.Text = t.TENTANG;
                txt_gia.Text = String.Format("{0:#,##0.##}", lp.GIA);
            }
            catch { MessageBox.Show("Lỗi hệ thống"); }

        }

        private void pic_anh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "All Text File (.jpg)|.jpg";
            open.FilterIndex = 1;
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {

                pic_anh.ImageLocation = open.FileName;
                pic_anh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
           
        }
         private byte[] convertImage(Image img)//chuyen image sang byte
         {
         
                MemoryStream m = new MemoryStream();
                img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
                return m.ToArray();
            
           
         }
            private Image bytetoimage(byte[] b)//chuyen byte sang image
            {
                MemoryStream m = new MemoryStream(b);
                return Image.FromStream(m);
            }

        public void frm_datphong_Leave(object sender, EventArgs e)
        {
            txt_soluonght.Refresh();
        }

        private void grv_datphong_Click(object sender, EventArgs e)
        {
          try
            { 
            HOPDONG hd = new HOPDONG();
           
            //btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            //btn_them.Enabled = false;
            int position = gridView_datphong.FocusedRowHandle;
            try
            {
                txt_mahd.Text = gridView_datphong.GetRowCellValue(position, "Mahd").ToString();
                txt_ngaykt.Text= gridView_datphong.GetRowCellValue(position, "NgayTra").ToString();
                hd.TIENCOC= Convert.ToDecimal(gridView_datphong.GetRowCellValue(position, "Tiencoc").ToString());
                txt_tiencoc.Text = String.Format("{0:#,##0.##}", hd.TIENCOC);


            }
            catch { }
            }
            catch
            {
                return;
            }
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_datphong.DataSource = datphong.LoadDatPhong();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            HOPDONG hd = new HOPDONG();
            hd.MAHD = txt_mahd.Text;
           
            hd.TIENCOC = Convert.ToDecimal(txt_tiencoc.Text);
            if (hopdong.sua_HopDong(hd) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            grv_datphong.DataSource = datphong.LoadDatPhongTheoMa(Ten);
            txt_mahd.Text = bll_sinhma.SinhMa_HopDong();
            txt_ngaykt.Clear();txt_tiencoc.Clear();
          
        }

        private void frm_datphong_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_test frm = new frm_test();
            frm.MaNhanVien = MaNV;
            Visible = false;
            frm.ShowDialog();
        }

        private void txt_tiencoc_TextChanged(object sender, EventArgs e)
        {
            try {
                //địng dạng tiền tệ
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txt_tiencoc.Text, System.Globalization.NumberStyles.AllowThousands);
                txt_tiencoc.Text = String.Format(culture, "{0:N0}", value);
                //texbox1.Text = String.Format(culture, "{0:N0}", value);
                txt_tiencoc.Select(txt_tiencoc.Text.Length, 0);
            }
            catch
            {
                return;
            }
           
           
        }

        private void btn_in_Click(object sender, EventArgs e)
        {
            int position = gridView_datphong.FocusedRowHandle;
            string mahd = gridView_datphong.GetRowCellValue(position, "Mahd").ToString();
            string tenphong = gridView_datphong.GetRowCellValue(position, "TenPhong").ToString();

            string tiencoc = String.Format("{0:#,##0.##}", Convert.ToDecimal(gridView_datphong.GetRowCellValue(position, "Tiencoc").ToString()));

            string ngay = DateTime.Now.Day.ToString();
            string thang = DateTime.Now.Month.ToString();
            string nam = DateTime.Now.Year.ToString();


            NHANVIEN nv = new NHANVIEN();
            nv = dal_nv.loadTenNV(txt_manv.Text);
            string tennv = nv.TENNV;
            string ngaysinhnvtam = nv.NGAYSINH.ToString();
            string ngaysinhnv = ngaysinhnvtam.Substring(0, 11);
            string cmndnv = nv.CMND_NV;
            string quequannv = nv.DIACHI;
            string sdtnv = nv.SODT_CT;

            KHACHTHUE kt = new KHACHTHUE();
            kt = dal_kt.loadTenKT(datphong.laymakt(mahd));
            string tenkt = kt.TENKT;
            string ngaysinhkttam = kt.NGAYSINH.ToString();
            string ngaysinhkt = ngaysinhkttam.Substring(0, 11);
            string cmndkt = kt.SOCMND;
            string quequankt = kt.QUEQUAN;
            string sdtkt = kt.SDT;

            PHONG p = new PHONG();
            LOAIPHONG lp = new LOAIPHONG();
            TANG t = new TANG();
            p = dal_phong.loadTenPhong(datphong.laymaphong(tenphong));
            lp = dal_lp.loadTenLoaiPhong(p.MALOAI);
            t = dal_tang.loadTenTang(p.MATANG);
            string loaiphong = lp.TENLOAI;
            string tang = t.TENTANG;
            string gia = String.Format("{0:#,##0.##}", lp.GIA);
            we.ThongTinHopDong(mahd, ngay, thang, nam, tennv,ngaysinhnv,cmndnv,
                quequannv,sdtnv,tenkt,ngaysinhkt,cmndkt,quequankt,sdtkt,
                tenphong,loaiphong,tang,gia,tiencoc,"22","02","2021");
        }

        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {
            //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            //String value = (txt_sdt.Text, System.Globalization.NumberStyles.AllowThousands).ToString();
            //txt_sdt.Text = string.Format("{0:(###) ###-###}", value);
            //texbox1.Text = String.Format(culture, "{0:N0}", value);
            //txt_sdt.Select(txt_tiencoc.Text.Length, 0);
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_khachthue frm = new frm_khachthue();
            frm.TenPhong = datphong.laymaphong(Ten);
            frm.ShowDialog(); 
        }

        private void txt_sdt_Leave(object sender, EventArgs e)
        {
            if (khachthue.kt_SoDT(txt_sdt.Text) == true)
            {
                MessageBox.Show("Trùng số điện thoại");
                return;
            }
            else
            {
                return;
            }
        }

        private void txt_cmnd_Leave(object sender, EventArgs e)
        {
            if (khachthue.kt_Socm(txt_cmnd.Text) == true)
            {
                MessageBox.Show("Trùng số chứng minh");
                return;
            }
            else
            {
                return;
            }
        }
    }
}