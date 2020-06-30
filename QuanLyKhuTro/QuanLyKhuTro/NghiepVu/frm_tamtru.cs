using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using BLL.NghiepVu;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_tamtru : Form
    {
        BLL_tamtru bll_tamtru = new BLL_tamtru();
        BLL_SinhMa bll_sinhma = new BLL_SinhMa();
        public frm_tamtru()
        {
            InitializeComponent();
        }
        string MaNV;

        public string Manv { get => MaNV; set => MaNV = value; }

        private void frm_tamtru_Load(object sender, EventArgs e)
        {
            txt_manv.Text = MaNV;
            txt_ngaylamgiay.Text = DateTime.Now.ToShortDateString();
            grv_tamtru.DataSource = bll_tamtru.Loadtamtru();
            txt_matt.Text = bll_sinhma.SinhMa_TAMTRU();
            txt_manv.Enabled = txt_makt.Enabled = txt_ngayhethan.Enabled = txt_quanhect.Enabled = false;
            btn_luu.Enabled = btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_them.Enabled = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_makt.Clear(); txt_ngayhethan.Clear(); txt_quanhect.Clear();
            txt_matt.Text = bll_sinhma.SinhMa_TAMTRU();
            txt_makt.Enabled = txt_ngayhethan.Enabled = txt_quanhect.Enabled = true;
            btn_luu.Enabled = true;
            btn_huy.Enabled = true;
            txt_manv.Text = MaNV;
            txt_ngaylamgiay.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_makt.Clear(); txt_ngayhethan.Clear(); txt_quanhect.Clear();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            TAMTRU tt = new TAMTRU();
            tt.MATAMTRU = txt_matt.Text;
            tt.MANV = txt_manv.Text;
            tt.MAKT = txt_makt.Text;
            tt.NGAYHETHAN_TAMTRU = Convert.ToDateTime(txt_ngayhethan.Text);
            tt.NGAYLAMGIAY = Convert.ToDateTime(txt_ngaylamgiay.Text);
            tt.QUANHEVOICHUTRO = txt_quanhect.Text;
            if(txt_makt.Text==string.Empty && txt_matt.Text==string.Empty && txt_manv.Text==string.Empty
                && txt_ngayhethan.Text==string.Empty && txt_ngaylamgiay.Text==string.Empty && txt_quanhect.Text==string.Empty)
            {
                MessageBox.Show("nhập đủ dữ liệu");
                return;
            }    
            if (btn_sua.Enabled == false && btn_them.Enabled == true)
            {
                if (bll_tamtru.them_tamtru(tt) == true)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            if (btn_sua.Enabled == true && btn_them.Enabled == false)
            {
                if (bll_tamtru.sua_tamtru(tt) == true)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            frm_tamtru_Load(sender, e);

        }

        private void grv_tamtru_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = false;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;
            btn_them.Enabled = true;
            int position = gridView_tamtru.FocusedRowHandle;
            try
            {
                txt_matt.Text = gridView_tamtru.GetRowCellValue(position, "MATT1").ToString();
                txt_manv.Text = gridView_tamtru.GetRowCellValue(position, "MANV1").ToString();
                txt_makt.Text = gridView_tamtru.GetRowCellValue(position, "MAKT1").ToString();
                txt_ngayhethan.Text = gridView_tamtru.GetRowCellValue(position, "NGAYHETHAN1").ToString();
                txt_ngaylamgiay.Text = gridView_tamtru.GetRowCellValue(position, "NGAYLAMGIAY1").ToString();
                txt_quanhect.Text = gridView_tamtru.GetRowCellValue(position, "QUANHEVOICHUTRO1").ToString();
            }
            catch { }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_sua.Enabled = true;
            btn_huy.Enabled = true;
            btn_them.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int position = gridView_tamtru.FocusedRowHandle;
            try
            {
                txt_matt.Text = gridView_tamtru.GetRowCellValue(position, "MATT1").ToString();
                if (bll_tamtru.xoa_tamtru(txt_matt.Text) == true)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }

            catch
            {
                return;
            }
            frm_tamtru_Load(sender,e);
        }
    }
}
