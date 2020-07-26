using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DuLieu;
using System.Drawing;
using BLL.NghiepVu;
using QuanLyKhuTro.DuLieu;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_cocphong : Form
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
        BLL_CocPhong bll_cocphong = new BLL_CocPhong();
        public frm_cocphong()
        {
            InitializeComponent();
        }
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
        private void frm_cocphong_Load(object sender, EventArgs e)
        {
            txt_phong.Text = Ten;
            txt_makt.Text = bll_sinhma.SinhMa_khachcoc();
            txt_tenkt.Enabled = txt_sdt.Enabled = txt_cmnd.Enabled = txt_quequan.Enabled = txt_tiencoc.Enabled = false;
            btn_them.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled= false;
            btn_luu.Enabled = btn_huy.Enabled = false;
            grv_cocphong.DataSource = bll_cocphong.Loadbangcocphongtheo(datphong.laymaphong(txt_phong.Text));
        }

        private void txt_tiencoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
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

        private void frm_cocphong_FormClosing(object sender, FormClosingEventArgs e)
        {

            frm_test frm = new frm_test();
            frm.MaNhanVien = MaNV;
            Visible = false;
            frm.ShowDialog();
        }

        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_makt.Text = bll_sinhma.SinhMa_khachcoc();
            btn_luu.Enabled = btn_huy.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_tenkt.Clear();
            txt_sdt.Clear();
            txt_cmnd.Clear();
            txt_quequan.Clear();
            txt_tiencoc.Clear();
            txt_tenkt.Enabled = txt_sdt.Enabled = txt_cmnd.Enabled = txt_quequan.Enabled = txt_tiencoc.Enabled = true;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_tenkt.Clear();
            txt_sdt.Clear();
            txt_cmnd.Clear();
            txt_quequan.Clear();
            txt_tiencoc.Clear();
            frm_cocphong_Load(sender, e);
        }
        
        private void txt_sdt_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_sdt_Validating(object sender, CancelEventArgs e)
        {
            if (bll_cocphong.kt_sdt(txt_sdt.Text) == true)
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
            if (bll_cocphong.kt_scm(txt_cmnd.Text) == true)
            {
                errorProvider1.SetError(txt_cmnd, "trùng số chứng minh");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_cmnd, null);
            }
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_cocphong.DataSource = bll_cocphong.Loadbangcocphong();
        }

        private void grv_cocphong_Click(object sender, EventArgs e)
        {
           
            btn_xoa.Enabled = btn_sua.Enabled = true;
            btn_them.Enabled = false;
            btn_huy.Enabled = true;
            int position = gridView_cocphong.FocusedRowHandle;
            try
            {
                txt_makt.Text = gridView_cocphong.GetRowCellValue(position, "MAKHCP1").ToString();
                txt_tenkt.Text = gridView_cocphong.GetRowCellValue(position, "TEN1").ToString();
                txt_sdt.Text= gridView_cocphong.GetRowCellValue(position, "SODT1").ToString();
                txt_cmnd.Text = gridView_cocphong.GetRowCellValue(position, "SOCMND1").ToString();
                txt_tiencoc.Text = String.Format("{0:#,##0.##}", gridView_cocphong.GetRowCellValue(position, "TIENCOCPHONG1").ToString());
                txt_quequan.Text = gridView_cocphong.GetRowCellValue(position, "QUEQUAN1").ToString();
                if (gridView_cocphong.GetRowCellValue(position, "GIOITINHKC1").ToString() == "Nam")
                {
                    rdb_nam.Checked = true;
                }
                if (gridView_cocphong.GetRowCellValue(position, "GIOITINHKC1").ToString() == "Nữ")
                {
                    rdb_nu.Checked = true;
                }

            }
            catch { }
        }
        capnhatdulieu update = new capnhatdulieu();
        private void btn_luu_Click(object sender, EventArgs e)
        {
            KHACHCOCPHONG lp = new KHACHCOCPHONG();
                lp.MAKHCP = txt_makt.Text;
                lp.TEN = txt_tenkt.Text;
                lp.SOCMND = txt_cmnd.Text;
                lp.SODT = txt_sdt.Text;
                lp.MAPHONG = datphong.laymaphong(txt_phong.Text);
                lp.TIENCOCPHONG = Convert.ToDecimal(txt_tiencoc.Text);
                if (rdb_nam.Checked == true)
                {
                    lp.GIOITINHKC = "Nam";
                }
                if (rdb_nu.Checked == true)
                {
                    lp.GIOITINHKC = "Nữ";
                }

                lp.QUEQUAN = txt_quequan.Text;
                lp.NGAYCOC = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            if (btn_them.Enabled == true && btn_sua.Enabled == false)
            {
              
                if (txt_tenkt.Text == string.Empty && txt_sdt.Text == string.Empty && txt_cmnd.Text == string.Empty && txt_quequan.Text == string.Empty && txt_tiencoc.Text == string.Empty)
                {
                    MessageBox.Show("Không được để trống");
                    return;
                }
                if (bll_cocphong.ktkc_cocphong(lp.MAKHCP) == true)
                {
                    MessageBox.Show("trùng khóa chính");
                    return;
                }
                if (bll_cocphong.themcocphong(lp) == true)
                {
                    update.update();
                    MessageBox.Show("Thành công");

                }
                else
                {
                    MessageBox.Show("thất bại");
                }
                grv_cocphong.DataSource = bll_cocphong.Loadbangcocphongtheo(datphong.laymaphong(txt_phong.Text));

            }
            if (btn_sua.Enabled == true && btn_them.Enabled == false)
            {
                try
                {
                    if (txt_tenkt.Text == string.Empty && txt_sdt.Text == string.Empty && txt_cmnd.Text == string.Empty && txt_quequan.Text == string.Empty && txt_tiencoc.Text == string.Empty)
                    {
                        MessageBox.Show("Không được để trống");
                        return;
                    }
                    if (bll_cocphong.sua_khachcoc(lp))
                    {
                        update.update();
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
                grv_cocphong.DataSource = bll_cocphong.Loadbangcocphongtheo(datphong.laymaphong(txt_phong.Text));
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int position = gridView_cocphong.FocusedRowHandle;
            try
            {
                txt_makt.Text = gridView_cocphong.GetRowCellValue(position, "MAKHCP1").ToString();
                if (bll_cocphong.xoacocphong(gridView_cocphong.GetRowCellValue(position, "MAKHCP1").ToString())) ;
                update.update();
                MessageBox.Show("Thành công");

            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
            grv_cocphong.DataSource = bll_cocphong.Loadbangcocphongtheo(datphong.laymaphong(txt_phong.Text));
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = btn_xoa.Enabled = false;
            btn_luu.Enabled = btn_huy.Enabled = true;
            txt_tenkt.Enabled = txt_sdt.Enabled = txt_cmnd.Enabled = txt_quequan.Enabled = txt_tiencoc.Enabled = true;
        }
    }
}
