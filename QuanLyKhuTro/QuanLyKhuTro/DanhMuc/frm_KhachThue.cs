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
            txt_tenphong.Text = Ten; 
            
            
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";

            
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_makt.Enabled = txt_tenkt.Enabled = txt_sdt.Enabled
                = txt_quequan.Enabled = txt_ngaysinh.Enabled = false;
            txt_cmnd.Enabled = rdb_nam.Enabled = rdb_nu.Enabled =  false;
            txt_makt.Text = bll_sinhma.SinhMa_KhachThue();
            btn_them.Enabled = true;
            int sltd =Convert.ToInt32( bll_datphong.laysoLuongtd(cbo_phong.SelectedValue.ToString()));
            if (bll_datphong.demsohd(cbo_phong.SelectedValue.ToString())<=sltd)
            {
                btn_them.Enabled = false;
            }
            grv_khachthue.DataSource = khachthue.loadBangKT();

        }

        private void gridView_khachthue_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            

        }
        

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            txt_makt.Enabled = false;
            btn_luu.Enabled = true;
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
            if (rdb_nam.Checked == true)
            {
                kt.GIOITINH = rdb_nam.Text;
            }
            else
                kt.GIOITINH = rdb_nu.Text;
            kt.SOCMND = txt_cmnd.Text;
            kt.NGAYSINH = Convert.ToDateTime(txt_ngaysinh.Text);
            kt.QUEQUAN = txt_quequan.Text;
            if(ckb_truongphong.Checked==true)
            {
                kt.TRUONGPHONG = true;
            }    
            else
            {
                kt.TRUONGPHONG = false;
            }
            kt.MAPHONG = cbo_phong.SelectedValue.ToString();
            if(btn_sua.Enabled == false && btn_them.Enabled == true)
            {
                try
                {
                    if (txt_makt.Text == string.Empty && txt_sdt.Text == string.Empty && txt_cmnd.Text == string.Empty
                     && txt_quequan.Text == string.Empty)
                    {
                        MessageBox.Show(" không được để trống");
                        return;
                    }  
                    if(khachthue.ThemKT(kt)==true)
                    {
                        MessageBox.Show("Thành công");
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
           
            txt_makt.Text = bll_sinhma.SinhMa_KhachThue();
            grv_khachthue.DataSource = khachthue.loadBangKT();
            ckb_truongphong.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Bạn có muốn xóa không!", "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                int position = gridView_khachthue.FocusedRowHandle;
                string m = gridView_khachthue.GetRowCellValue(position, "MAKT").ToString();
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
                    MessageBox.Show("Thành công");
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
        private Image bytetoimage(byte[] b)//chuyen byte sang image
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_sua.Enabled = btn_xoa.Enabled = true;
            txt_makt.Enabled = txt_tenkt.Enabled = txt_sdt.Enabled
                = txt_quequan.Enabled = txt_ngaysinh.Enabled = true;
            txt_cmnd.Enabled = rdb_nam.Enabled = rdb_nu.Enabled= true;
            btn_luu.Enabled = true;
            btn_xoa.Enabled = btn_sua.Enabled = false;
            txt_makt.Text = bll_sinhma.SinhMa_KhachThue();
        }

        private void grv_khachthue_Click(object sender, EventArgs e)
        {
            KHACHTHUE kt = new KHACHTHUE();
            btn_sua.Enabled = btn_xoa.Enabled = true;
            btn_them.Enabled = true;
            int position = gridView_khachthue.FocusedRowHandle;
            try
            {
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
            if (bll_datphong.demsohd(cbo_phong.SelectedValue.ToString()) <= sltd)
            {
                btn_them.Enabled = false;
            }
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = khachthue.loadBangKT();
        }
    }
}