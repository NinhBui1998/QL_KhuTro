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

namespace QuanLyKhuTro.DanhMuc
{
    public partial class frm_khachthue : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_KhachThue khachthue = new BLL_KhachThue();
        public frm_khachthue()
        {
            InitializeComponent();
        }

        private void frm_khachthue_Load(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = khachthue.loadBangKT();
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_makt.Enabled = txt_tenkt.Enabled = txt_sdt.Enabled = txt_quequan.Enabled = txt_ngaysinh.Enabled = false;
            txt_cmnd.Enabled = rdb_nam.Enabled = rdb_nu.Enabled = false;
        }

        private void gridView_khachthue_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            KHACHTHUE kt = new KHACHTHUE();
            btn_sua.Enabled = btn_xoa.Enabled = true;
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

            }
            catch { }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
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
            kt.SOCMND = txt_cmnd.Text;
            kt.NGAYSINH = Convert.ToDateTime(txt_ngaysinh.Text);
            kt.QUEQUAN = txt_quequan.Text;
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
            else
            {
                MessageBox.Show("Lỗi");
            }
            frm_khachthue_Load(sender, e);
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
            open.Filter = "All Text File (.jpg)|.jpg";
            open.FilterIndex = 1;
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                pic_anhkt.ImageLocation = open.FileName;
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
    }
}