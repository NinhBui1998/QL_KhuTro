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

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_datphong : DevExpress.XtraEditors.XtraForm
    {
        DAL_Phong dal_phong = new DAL_Phong();
        DAL_Tang dal_tang = new DAL_Tang();
        DAL_LoaiPhong dal_lp = new DAL_LoaiPhong();
        BLL_KhachThue khachthue = new BLL_KhachThue();
        BLL_LoaiPhong loaip = new BLL_LoaiPhong();
        BLL_Tang tang = new BLL_Tang();
        BLL_Phong phong = new BLL_Phong();
        BLL_HopDong hopdong = new BLL_HopDong();
        BLL_DatPhong datphong = new BLL_DatPhong();
        BLL_HopDong_KhachThue hopdong_khachthue = new BLL_HopDong_KhachThue();


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
            ////load dữ liêu combobox tầng
            //cbb_tang.DataSource = tang.loadBangTang();
            //cbb_tang.DisplayMember = "TENTANG";
            //cbb_tang.ValueMember = "MATANG";

            ////load dữ liêu combobox loai phòng
            //cbb_loaiphong.DataSource = loaip.loadBangLoaiPhong();
            //cbb_loaiphong.DisplayMember = "TENLOAI";
            //cbb_loaiphong.ValueMember = "MALOAI";

            //load dl
            
            grv_datphong.DataSource = datphong.LoadDatPhong();
            txt_manv.Text = MaNV;
            txt_ngaylaphd.Text= DateTime.Now.ToShortDateString();
            //cbb_tang.Enabled = cbb_loaiphong.Enabled = cbb_phong.Enabled = false;
            //btn_sua.Enabled = false;
            //txt_makt.Enabled = txt_tenkt.Enabled = rdb_nam.Enabled = rdb_nu.Enabled = txt_sdt.Enabled
            //    = txt_quequan.Enabled = txt_cmnd.Enabled = txt_ngaysinh.Enabled = pic_anh.Enabled = false;
            //txt_mahd.Enabled = txt_tiencoc.Enabled = txt_thoihan.Enabled = txt_manv.Enabled = txt_ngaylaphd.Enabled = false;

            string pos = gridView_datphong.GetRowCellValue(gridView_datphong.RowCount - 1, "Makt").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_makt.Text = "KT00" + k;
            }
            else if (k >= 10 && k < 100)
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
            else if (k1 >= 10 && k1 < 100)
            {
                txt_mahd.Text = "HD0" + k1;
            }
            
            txt_phong.Text = Ten;

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
            }
            catch { }
        }

        private void btn_taohd_Click(object sender, EventArgs e)
        {
            try
            { 
                byte[] b = convertImage(pic_anh.Image);
                KHACHTHUE kt = new KHACHTHUE();
                HOPDONG hd = new HOPDONG();
                HOPDONG_KT hd_kt = new HOPDONG_KT();

                hd.MAHD = txt_mahd.Text;
                hd.TIENCOC = decimal.Parse(txt_tiencoc.Text);
                hd.NGAYLAPHD = Convert.ToDateTime(txt_ngaylaphd.Text);
                hd.THOIHAN = txt_thoihan.Text;
                hd.MAPHONG =datphong.laymaphong(Ten);
                hd.MANV = txt_manv.Text;
           



            //Thêm khách thuê vào hợp đồng
            kt.MAKT = txt_makt.Text;
            kt.TENKT = txt_tenkt.Text;
            kt.SDT = txt_sdt.Text;
            kt.ANH = b;
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
            hd_kt.NGAYTRA = null;

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

            if (khachthue.ThemKT(kt) == true && hopdong.them_HopDong(hd) == true &&
                hopdong_khachthue.them_HopDong_KhachThue(hd_kt) == true )
            {
                grv_datphong.DataSource = datphong.LoadDatPhong();
               
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            //sửa số lượng hiện tại trong phòng
            PHONG ph = new PHONG();
            ph.MAPHONG = datphong.laymaphong(Ten);
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
            txt_soluonght.Text=( datphong.demsohd(datphong.laymaphong(Ten))).ToString();
            }
            catch
            {
                MessageBox.Show("chưa có ảnh khách thuê");
            }
            insert();
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
    }
}