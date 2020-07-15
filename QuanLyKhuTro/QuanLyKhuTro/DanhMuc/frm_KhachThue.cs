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
using DevExpress.Utils.Extensions;
using DevExpress.Data.WcfLinq.Helpers;
using QuanLyKhuTro.NghiepVu;

namespace QuanLyKhuTro.DanhMuc
{
    public partial class frm_khachthue : DevExpress.XtraEditors.XtraForm
    {
        BLL_Phong bll_phong = new BLL_Phong();
        BLL_KhachThue khachthue = new BLL_KhachThue();
        //QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        BLL_SinhMa bll_sinhma = new BLL_SinhMa();
        BLL_DatPhong bll_datphong = new BLL_DatPhong();
        public frm_khachthue()
        {
            InitializeComponent();
        }
        string Ten;
        public string TenPhong
        {
            get { return Ten; }
            set { Ten = value; }
        }
        private void frm_khachthue_Load(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = khachthue.loadBangKT();
            txt_tenphong.Text = Ten;
            if(Ten!=null)
            {    
                grv_khachthue.DataSource = khachthue.loadBangKTtheoma(Ten);
            }
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";

            
            btn_sua.Enabled = btn_xoa.Enabled=btn_huy.Enabled=btn_luu.Enabled = false;
            txt_makt.Enabled = txt_tenkt.Enabled = txt_sdt.Enabled
                = txt_quequan.Enabled = txt_ngaysinh.Enabled = false;
            txt_cmnd.Enabled = rdb_nam.Enabled = rdb_nu.Enabled =  false;
            txt_makt.Text = bll_sinhma.SinhMa_KhachThue();
           

            ckb_tinhtrang.Checked = true;
            rdb_nam.Checked = true;
            ckb_tinhtrang.Text = "đang ở";
             btn_them.Enabled = true;
            if(khachthue.ktTRuongPhong(txt_tenphong.Text)==true)
            {
                ckb_truongphong.Checked = false;
                ckb_truongphong.Enabled = false;
            }
            else
            {
                ckb_truongphong.Checked = true;
                ckb_truongphong.Enabled = true;
            }
            btn_them.Enabled = true;
        }
        

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            txt_makt.Enabled = false;
            btn_luu.Enabled =btn_huy.Enabled= true;
            btn_xoa.Enabled = false;
            txt_tenkt.Enabled = txt_sdt.Enabled = txt_quequan.Enabled = true;
            txt_ngaysinh.Enabled = txt_cmnd.Enabled = rdb_nam.Enabled = rdb_nu.Enabled = true;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {

            byte[] b = convertImage(pic_anhkt.Image);

            KHACHTHUE kt = new KHACHTHUE();
            kt.MAKT = txt_makt.Text;
            kt.TENKT = txt_tenkt.Text;
            kt.SDT = txt_sdt.Text;
            kt.ANH = b;
            kt.TINHTRANGTAMTRU = "chưa đăng ký";
           
           
            if (rdb_nam.Checked == true)
            {
                kt.GIOITINH = rdb_nam.Text;
            }
            else
                kt.GIOITINH = rdb_nu.Text;
            kt.SOCMND = txt_cmnd.Text;
            kt.NGAYSINH = Convert.ToDateTime(txt_ngaysinh.Text);
            kt.QUEQUAN = txt_quequan.Text;
           
           
            if (ckb_truongphong.Checked==true)
            {
                kt.TRUONGPHONG = true;
            }    
            else
            {
                kt.TRUONGPHONG = false;
            }
            kt.MAPHONG = txt_tenphong.Text;
            kt.MK = "abc";
            kt.TINHTRANG = true;
            if (btn_sua.Enabled == false && btn_them.Enabled == true)
            {
                try
                {
                    if (txt_makt.Text == string.Empty && txt_sdt.Text == string.Empty && txt_cmnd.Text == string.Empty
                     && txt_quequan.Text == string.Empty)
                    {
                        MessageBox.Show(" không được để trống");
                        return;
                    }  
                    if(khachthue.ktkc_khachthue(txt_makt.Text)==true)
                    {
                        MessageBox.Show("Trùng khóa chính");
                        return;
                    }    
                    if(khachthue.ThemKT(kt)==true)
                    {
                        PHONG ph = new PHONG();
                        ph.MAPHONG =txt_tenphong.Text;
                      
                        ph.SOLUONG_HT = datphong.demsohd(ph.MAPHONG);
                        if (phong.sua_sl(ph) == true)
                        {

                            MessageBox.Show("Thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thất bại");
                        }
                       
                    }
                    if (khachthue.ktTRuongPhong(txt_tenphong.Text) == true)
                    {
                        ckb_truongphong.Enabled = false;
                    }
                    else
                    {
                        ckb_truongphong.Enabled = true;
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Thất bại");
                }
            }    
            if (btn_sua.Enabled == true && btn_them.Enabled == false)
            {
                try
                {
                    if (txt_makt.Text == string.Empty && txt_sdt.Text == string.Empty && txt_cmnd.Text == string.Empty
                    && txt_quequan.Text == string.Empty)
                    {
                        MessageBox.Show(" không được để trống");
                        return;
                    }
                    if (khachthue.sua_khachthue(kt) == true)
                    {
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
            }
            txt_makt.Enabled = txt_tenkt.Enabled = txt_sdt.Enabled
                 = txt_quequan.Enabled = txt_ngaysinh.Enabled = false;
            txt_cmnd.Enabled = rdb_nam.Enabled = rdb_nu.Enabled = false;

            txt_makt.Text = bll_sinhma.SinhMa_KhachThue();
            grv_khachthue.DataSource = khachthue.loadBangKTtheoma(txt_tenphong.Text);
            btn_huy.Enabled = btn_luu.Enabled = btn_xoa.Enabled = btn_sua.Enabled = false;
            ckb_truongphong.Checked = false;

        }
        BLL_DatPhong datphong = new BLL_DatPhong();
        BLL_Phong phong = new BLL_Phong();
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Bạn có muốn xóa không!", "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                int position = gridView_khachthue.FocusedRowHandle;
                string m = gridView_khachthue.GetRowCellValue(position, "MAKT").ToString();
                string ma = gridView_khachthue.GetRowCellValue(position, "MAPHONG").ToString();

                if (m == string.Empty)
                {
                    MessageBox.Show("Mã phòng không được để trống");
                    return;
                }
                if (khachthue.ktx_khachthue(m) == true)
                {
                    MessageBox.Show("Phòng hiện đang sử dụng không thể xóa");
                    return;
                }
                if (khachthue.xoa_KhachThue(m) == true)
                {
                    grv_khachthue.DataSource = khachthue.loadBangKT();
                    //sửa số lượng hiện tại trong phòng
                    PHONG ph = new PHONG();
                    ph.MAPHONG = ma;
                    ph.SOLUONG_HT = datphong.demsohd(ph.MAPHONG);
                    if (phong.sua_sl(ph) == true)
                    {

                        MessageBox.Show("Thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thất bại");
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
            frm_khachthue_Load(sender, e);
        }

        private void btn_chonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "All Text File (.jpg)|.jpg";
            open.FilterIndex = 1;
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
               
                pic_anhkt.ImageLocation = open.FileName;
                pic_anhkt.SizeMode = PictureBoxSizeMode.StretchImage;
                
            }
        }
        private byte[] convertImage(Image img)//chuyen image sang byte
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        //chuyển kểu ảnh
        //private byte[] chuyenKieuAnh()
        //{
        //    FileStream fs = new FileStream(textBox1.Text,FileMode.Open, FileAccess.Read);
        //    byte[] picByte = new byte[fs.Length];
        //    fs.Read(picByte, 0, System.Convert.ToInt32(fs.Length));
        //    fs.Close();
        //    return picByte;
        //}
        private Image bytetoimage(byte[] b)//chuyen byte sang image
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
           
            if(khachthue.ktSOLUONGHT(txt_tenphong.Text)==true)
            {
                MessageBox.Show("Đã đủ số lượng người ở");
                return;
            } 
            else
            {
                btn_sua.Enabled = btn_xoa.Enabled = true;
                txt_makt.Enabled = false;
                    txt_tenkt.Enabled = txt_sdt.Enabled
                    = txt_quequan.Enabled = txt_ngaysinh.Enabled = true;
                txt_cmnd.Enabled = rdb_nam.Enabled = rdb_nu.Enabled = true;
                btn_luu.Enabled = btn_huy.Enabled = true;
                btn_xoa.Enabled = btn_sua.Enabled = false;
                xoatext();
                txt_makt.Text = bll_sinhma.SinhMa_KhachThue();
            }    

        }
        public void xoatext()
        {
            txt_tenkt.Clear(); txt_sdt.Clear();
            txt_quequan.Clear(); txt_ngaysinh.Clear();
            txt_cmnd.Clear(); 
        }

        private void grv_khachthue_Click(object sender, EventArgs e)
        {
            KHACHTHUE kt = new KHACHTHUE();
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = false;
            btn_huy.Enabled = true;

            int position = gridView_khachthue.FocusedRowHandle;
            try
            {
                kt.MAPHONG = gridView_khachthue.GetRowCellValue(position, "MAPHONG").ToString();
                kt.TENKT = gridView_khachthue.GetRowCellValue(position, "TENKT").ToString();
                kt.MAKT = gridView_khachthue.GetRowCellValue(position, "MAKT").ToString();
                kt.NGAYSINH = Convert.ToDateTime(gridView_khachthue.GetRowCellValue(position, "NGAYSINH").ToString());
                kt.GIOITINH = gridView_khachthue.GetRowCellValue(position, "GIOITINH").ToString();
                kt.QUEQUAN = gridView_khachthue.GetRowCellValue(position, "QUEQUAN").ToString();
                kt.SOCMND = gridView_khachthue.GetRowCellValue(position, "SOCMND").ToString();
                kt.SDT = gridView_khachthue.GetRowCellValue(position, "SDT").ToString();

                txt_makt.Text = kt.MAKT.ToString();
                txt_tenkt.Text = kt.TENKT.ToString();
                txt_sdt.Text = kt.SDT.ToString();
                txt_cmnd.Text = kt.SOCMND.ToString();
                txt_ngaysinh.Text = kt.NGAYSINH.ToString();
                txt_quequan.Text = kt.QUEQUAN.ToString();
                txt_tenphong.Text = kt.MAPHONG;
                if (kt.GIOITINH == "Nam")
                {
                    rdb_nam.Checked = true;
                }
                if (kt.GIOITINH == "Nữ")
                {
                    rdb_nu.Checked = true;
                }


                //var q3 = data.KHACHTHUEs.Where(c => c.MAKT == kt.MAKT).Select(c => c.ANH).FirstOrDefault();

                //byte[] b = q3.ToArray();
                //if(kt.ANH!=null)
                //{
                try
                {
                    byte[] b = (byte[])khachthue.layanh(kt.MAKT);
                    pic_anhkt.Image = bytetoimage(b);
                    pic_anhkt.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    return;
                }

                // }
                //else
                //{
                //    MessageBox.Show("Không có ảnh");
                //}

            }
            catch { }
            int sltd = Convert.ToInt32(bll_datphong.laysoLuongtd(cbo_phong.SelectedValue.ToString()));
            if (bll_datphong.demsohd(cbo_phong.SelectedValue.ToString()) <= sltd)
            {
                btn_them.Enabled = false;
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = khachthue.loadBangKTtheoma(cbo_phong.SelectedValue.ToString());
            int sltd = Convert.ToInt32(bll_datphong.laysoLuongtd(cbo_phong.SelectedValue.ToString()));
            //if (bll_datphong.demsohd(cbo_phong.SelectedValue.ToString()) <= sltd)
            //{
            //    btn_them.Enabled = false;
            //}
            txt_tenphong.Text = cbo_phong.SelectedValue.ToString();
            if (khachthue.ktTRuongPhong(txt_tenphong.Text) == true)
            {
                ckb_truongphong.Checked = false;
                ckb_truongphong.Enabled = false;
            }
            else
            {
                ckb_truongphong.Checked = false;
                ckb_truongphong.Enabled = true;
            }
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = khachthue.loadBangKT();
        }

        private void txt_cmnd_Leave(object sender, EventArgs e)
        {
            if(khachthue.kt_Socm(txt_cmnd.Text)==true)
            {
                MessageBox.Show("Trùng số chứng minh");
                return;
            }
            else
            {
                return;
            }    
        }

        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {
            
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

        private void txt_sdt_Validating(object sender, CancelEventArgs e)
        {
            if (khachthue.kt_SoDT(txt_sdt.Text) == true)
            {
                errorProvider1.SetError(txt_sdt, "trùng số điện thoại");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_sdt, null);
            }
        }

        private void txt_cmnd_Validating(object sender, CancelEventArgs e)
        {
            if (khachthue.kt_Socm(txt_cmnd.Text) == true)
            {
                errorProvider1.SetError(txt_cmnd, "trùng số chứng minh");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_cmnd, null);
            }
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            frm_khachthue_Load(sender, e);
        }

        private void frm_khachthue_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void cbo_phong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}