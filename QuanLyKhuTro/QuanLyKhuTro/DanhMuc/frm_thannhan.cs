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

namespace QuanLyKhuTro.DanhMuc
{
    public partial class frm_thannhan : DevExpress.XtraEditors.XtraUserControl
    {
        public frm_thannhan()
        {
            InitializeComponent();
        }
        BLL_ThanNhan bll_thannhan = new BLL_ThanNhan();
        BLL_Phong bll_phong = new BLL_Phong();
        BLL_KhachThue bll_khachthue = new BLL_KhachThue();
        DAL_ThanNhan_TamTru dal_tntamtru = new DAL_ThanNhan_TamTru();
        BLL_SinhMa bll_sinhma = new BLL_SinhMa();
        BLL_KhachThue khachthue = new BLL_KhachThue();

        private void frm_thannhan_Load(object sender, EventArgs e)
        {
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";

            cbo_makt.DataSource = bll_khachthue.loadBangKT();
            cbo_makt.DisplayMember = "MAKT";
            cbo_makt.ValueMember = "MAKT";

            rdo_nam.Checked = true;

            grv_thannhan.DataSource = dal_tntamtru.loadthannhantheoma();
            txt_matn.Text = bll_sinhma.SINHMATHANNHAN();

            btn_huy.Enabled = btn_luu.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_tentn.Enabled = txt_scm.Enabled = txt_ngayra.Enabled = txt_ngayvao.Enabled = false;
            txt_matn.Enabled = false;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_huy.Enabled = btn_luu.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_tentn.Enabled = txt_scm.Enabled = txt_ngayra.Enabled = txt_ngayvao.Enabled = true;
            txt_tentn.Clear(); txt_scm.Clear(); txt_ngayvao.Clear(); txt_ngayra.Clear();
            txt_matn.Text = bll_sinhma.SINHMATHANNHAN();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_tentn.Clear(); txt_scm.Clear(); txt_ngayvao.Clear(); txt_ngayra.Clear();
            txt_matn.Text = bll_sinhma.SINHMATHANNHAN();
            btn_huy.Enabled = btn_luu.Enabled = false;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_tentn.Enabled = txt_scm.Enabled = txt_ngayra.Enabled = txt_ngayvao.Enabled = false;
            txt_matn.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            btn_huy.Enabled = btn_luu.Enabled = true;
            txt_tentn.Enabled = txt_scm.Enabled = txt_ngayra.Enabled = txt_ngayvao.Enabled = true;

        }

        private void grv_thannhan_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = btn_sua.Enabled = true;
            int position = gridView_tntamtru.FocusedRowHandle;
            try
            {
                txt_matn.Text = gridView_tntamtru.GetRowCellValue(position, "MATN1").ToString();
                txt_tentn.Text = gridView_tntamtru.GetRowCellValue(position, "TENTN1").ToString();
                txt_scm.Text = gridView_tntamtru.GetRowCellValue(position, "SOCM1").ToString();
                if (gridView_tntamtru.GetRowCellValue(position, "GIOITINH1").ToString() == "Nam")
                {
                    rdo_nam.Checked = true;
                }
                if (gridView_tntamtru.GetRowCellValue(position, "GIOITINH1").ToString() == "Nữ")
                {
                    rdo_nu.Checked = true;
                }
                //txt_ngayra.Text = gridView_tntamtru.GetRowCellValue(position, "NGAYRA1").ToString();
                txt_ngayvao.Text = gridView_tntamtru.GetRowCellValue(position, "NGAVAO1").ToString();
            }
            catch
            {
                return;
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_matn.Text == string.Empty || txt_tentn.Text == string.Empty || txt_scm.Text == string.Empty
                    || txt_ngayvao.Text == string.Empty )
            {
                txt_tentn_Validating(sender, e);
                txt_scm_Validating(sender, e);
                //txt_ngayra_Validating(sender, e);
                txt_ngayvao_Validating(sender, e);
                return;
            }
            THANNHAN tn = new THANNHAN();
            tn.MATN = txt_matn.Text;
            tn.TENTN = txt_tentn.Text;
            tn.SOCMNDTN=txt_scm.Text;
            if(rdo_nam.Checked==true)
            {
                tn.GIOITINH_TN = "Nam";
            }    
            else
            {
                tn.GIOITINH_TN = "true";
            }

            THANNHAN_TAMTRU tntt = new THANNHAN_TAMTRU();
            tntt.MAKT = cbo_makt.Text;
            tntt.MATN = txt_matn.Text;
            tntt.NGAYVAO = Convert.ToDateTime(txt_ngayvao.Text);
            if(txt_ngayra.Text==string.Empty)
            {
                tntt.NGAYRA = Convert.ToDateTime(txt_ngayra.Text);
            }    
            else
            {
                tntt.NGAYRA =null;
            }
           
            if (btn_them.Enabled == true && btn_sua.Enabled==false)
            {
                if(bll_thannhan.ktkc(tn.MATN)==true)
                {
                    MessageBox.Show("trùng khóa chính thân nhân");
                    return;
                }
                if(dal_tntamtru.ktkc_thannhan_tamtru(tntt.MATN,tntt.MAKT)==true)
                {
                    MessageBox.Show("trùng khóa chính thân nhân tạm trú");
                    return;
                } 
                if(bll_thannhan.Them_ThanNhan(tn)==true && dal_tntamtru.them_Thannhantamtru(tntt)==true)
                {
                    MessageBox.Show("Thành công");
                    grv_thannhan.DataSource = dal_tntamtru.loadthannhantheoma();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            if(btn_sua.Enabled==true && btn_luu.Enabled==true)
            {
                tntt.NGAYRA = Convert.ToDateTime(txt_ngayra.Text);
                if (bll_thannhan.sua_thanNhan(tn)==true && dal_tntamtru.sua_thannhan_tamtru(tntt)==true)
                {
                    MessageBox.Show("Thành công");
                    grv_thannhan.DataSource = dal_tntamtru.loadthannhantheoma();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }    
            }    
        }
        private void txt_tentn_Validating(object sender, EventArgs e)
        {
            if (txt_tentn.Text==string.Empty)
            {  
                errorProvider1.SetError(txt_tentn, "Không được để trống!");
            }
            else
            {
                errorProvider1.SetError(txt_tentn, null);
            }
        }

        private void txt_scm_Validating(object sender, EventArgs e)
        {
            if (txt_scm.Text == string.Empty)
            {
                errorProvider1.SetError(txt_scm, "Không được để trống!");
            }
            else
            {
                errorProvider1.SetError(txt_scm, null);
            }
            if (khachthue.kt_Socm(txt_scm.Text) == true)
            {
                errorProvider1.SetError(txt_scm, "trùng số chứng minh");
            }
            else
            {
               
                errorProvider1.SetError(txt_scm, null);
            }
        }

        private void txt_ngayvao_Validating(object sender, EventArgs e)
        {
            if (txt_ngayvao.Text == string.Empty)
            {
                errorProvider1.SetError(txt_ngayvao, "Không được để trống!");
            }
            else
            {
                errorProvider1.SetError(txt_ngayvao, null);
            }
        }

        private void txt_ngayra_Validating(object sender, EventArgs e)
        {
            //if (txt_ngayra.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txt_ngayra, "Không được để trống!");
            //}
            //else
            //{
            //    errorProvider1.SetError(txt_ngayra, null);
            //}
        }

        private void cbo_phong_SelectedValueChanged(object sender, EventArgs e)
        {
            cbo_makt.Text = string.Empty;
            cbo_makt.DataSource = bll_khachthue.loadBangKTtheoma(cbo_phong.SelectedValue.ToString());
        }

        private void cbo_makt_Click(object sender, EventArgs e)
        {
            txt_tenkt.Text = bll_khachthue.Laytenkt(cbo_makt.Text);
           
        }

        private void txt_scm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}