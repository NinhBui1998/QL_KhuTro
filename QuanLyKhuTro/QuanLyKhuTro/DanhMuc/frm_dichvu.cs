﻿using System;
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
using BLL.HeThong;

namespace QuanLyKhuTro.DanhMuc
{
    public partial class frm_dichvu : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_DichVu dichvu = new BLL_DichVu();
        BLL_DichVuDien bll_dvdien = new BLL_DichVuDien();
        public frm_dichvu()
        {
            InitializeComponent();
        }
        
        private void frm_dichvu_Load(object sender, EventArgs e)
        {
            txt_madichvu.Enabled = false;
            grv_dichvu.DataSource = dichvu.loadBang_DV();
            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled = txt_madichvu.Enabled
                = txt_tendichvu.Enabled=txt_gia.Enabled=txt_donvi.Enabled = false;
            btn_them.Enabled = true;
            txt_madvd.Enabled = txt_luytuyen.Enabled = txt_giadvd.Enabled = false;
            grv_dvdien.DataSource = bll_dvdien.loaddichvudien();
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_madichvu.Clear();
            txt_tendichvu.Clear();
            txt_gia.Clear();
            txt_donvi.Clear();
            txt_tendichvu.Enabled=txt_gia.Enabled=txt_donvi.Enabled = true;
            txt_madichvu.Enabled = false;
           
            //sinh mã
            string pos = gridView_DichVu.GetRowCellValue(gridView_DichVu.RowCount - 1, "MADV").ToString();
            pos = pos.Substring(2);
            int k = (int.Parse(pos) + 1);
            if (k < 10)
            {
                txt_madichvu.Text = "DV00" + k;
            }
            else if (k > 10 && k < 100)
            {
                txt_madichvu.Text = "DV0" + k;
            }

            btn_luu.Enabled = btn_huy.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Bạn có muốn xóa không!", "xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                int position = gridView_DichVu.FocusedRowHandle;
                string m = gridView_DichVu.GetRowCellValue(position, "MADV").ToString();
                if (m == string.Empty)
                {
                    MessageBox.Show("Mã dịch vụ không được để trống");
                    return;
                }
                
                if (dichvu.xoa_DichVu(m) == true)
                {
                    grv_dichvu.DataSource = dichvu.loadBang_DV();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            else
            {

            }

            frm_dichvu_Load(sender, e);
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_madichvu.Enabled = false;
            btn_luu.Enabled = true;
            btn_xoa.Enabled = btn_them.Enabled = false;
            txt_tendichvu.Enabled =txt_gia.Enabled=txt_donvi.Enabled= true;
            txt_giadvd.Enabled = false;
            txt_luytuyen.Enabled = false;
            txt_giadvd.Enabled = true;
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {

            DICHVU dv = new DICHVU();
            if (btn_them.Enabled == true)
            {
                dv.MADV = txt_madichvu.Text;
                dv.TENDV = txt_tendichvu.Text;
                dv.GIADV = decimal.Parse(txt_gia.Text);
                dv.DONVI = txt_donvi.Text;
                if (txt_madichvu.Text == string.Empty && txt_tendichvu.Text == string.Empty
                    && txt_gia.Text == string.Empty && txt_donvi.Text == string.Empty)
                {
                    MessageBox.Show("không được để trống");
                    return;
                }
                //kiểm tra khóa chính
                if (dichvu.ktkc_DichVu(dv.MADV) == true)
                {
                    MessageBox.Show("TRùng khóa chính");
                    return;
                }
                if (dichvu.them_DichVu(dv) == true)
                {

                    grv_dichvu.DataSource = dichvu.loadBang_DV();
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                frm_dichvu_Load(sender, e);
            }
            if (btn_sua.Enabled == true)
            {
               
                try
                {
                    if (txt_tendichvu.Text == string.Empty)
                    {
                        MessageBox.Show("Tên tầng không được để trống");
                        return;
                    }
                    if (txt_gia.Text == string.Empty)
                    {
                        MessageBox.Show("Giá dịch vụ không được để trống");
                        return;
                    }
                    dv.MADV = txt_madichvu.Text;
                    dv.TENDV = txt_tendichvu.Text;
                    dv.GIADV = decimal.Parse(txt_gia.Text);
                    dv.DONVI = txt_donvi.Text;
                    DICHVUDIEN dvd = new DICHVUDIEN();
                    dvd.MADVD = txt_madvd.Text;
                    dvd.GIA = Convert.ToDecimal(txt_giadvd.Text);
                    if (dichvu.sua_DichVu(dv) == true && bll_dvdien.sua_dvdien(dvd)==true)
                    {
                        grv_dichvu.DataSource = dichvu.loadBang_DV();
                        grv_dvdien.DataSource = bll_dvdien.loaddichvudien();
                        MessageBox.Show("Thành công");
                    }
                }
                catch
                {
                    MessageBox.Show("thất bại");
                }
            }
            frm_dichvu_Load(sender, e);
        }
        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_madichvu.Clear();
            txt_tendichvu.Clear();
            txt_gia.Clear();
            txt_donvi.Clear();
            btn_them.Enabled = true;
            txt_madvd.Clear();
            txt_luytuyen.Clear();
            txt_giadvd.Clear();

            frm_dichvu_Load(sender, e);
        }

      

        private void gridControl1_Click(object sender, EventArgs e)
        {
          
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_dichcudien.FocusedRowHandle;
            try
            {
               txt_madvd.Text = gridView_dichcudien.GetRowCellValue(position, "MADVD").ToString();
              txt_luytuyen.Text= gridView_dichcudien.GetRowCellValue(position, "LUYTUYEN").ToString();
                decimal giadien = Convert.ToDecimal(gridView_dichcudien.GetRowCellValue(position, "GIA").ToString());
                txt_giadvd.Text = String.Format("{0:#,##0.##}", giadien);


            }
            catch { }
        }

       

        private void grv_dichvu_Click_1(object sender, EventArgs e)
        {
            DICHVU dv = new DICHVU();
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_DichVu.FocusedRowHandle;
            try
            {
                dv.TENDV = gridView_DichVu.GetRowCellValue(position, "TENDV").ToString();
                dv.MADV = gridView_DichVu.GetRowCellValue(position, "MADV").ToString();
                dv.GIADV = decimal.Parse(gridView_DichVu.GetRowCellValue(position, "GIADV").ToString());
                dv.DONVI = gridView_DichVu.GetRowCellValue(position, "DONVI").ToString();

                txt_madichvu.Text = dv.MADV.ToString();
                txt_tendichvu.Text = dv.TENDV.ToString();
                txt_gia.Text = String.Format("{0:#,##0.##} VNĐ", dv.GIADV);
                txt_donvi.Text = dv.DONVI.ToString();
            }
            catch { }
        }

        private void gridView_DichVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DICHVU dv = new DICHVU();
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_DichVu.FocusedRowHandle;
            try
            {
                dv.TENDV = gridView_DichVu.GetRowCellValue(position, "TENDV").ToString();
                dv.MADV = gridView_DichVu.GetRowCellValue(position, "MADV").ToString();
                dv.GIADV = decimal.Parse(gridView_DichVu.GetRowCellValue(position, "GIADV").ToString());
                dv.DONVI = gridView_DichVu.GetRowCellValue(position, "DONVI").ToString();

                txt_madichvu.Text = dv.MADV.ToString();
                txt_tendichvu.Text = dv.TENDV.ToString();
                txt_gia.Text = String.Format("{0:#,##0.##}", dv.GIADV);
                txt_donvi.Text = dv.DONVI.ToString();
            }
            catch { }
        }

        private void gridView_dichcudien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btn_xoa.Enabled = btn_sua.Enabled = btn_huy.Enabled = true;
            btn_them.Enabled = false;
            int position = gridView_dichcudien.FocusedRowHandle;
            try
            {
                txt_madvd.Text = gridView_dichcudien.GetRowCellValue(position, "MADVD").ToString();
                txt_luytuyen.Text = gridView_dichcudien.GetRowCellValue(position, "LUYTUYEN").ToString();
                decimal giadien =Convert.ToDecimal( gridView_dichcudien.GetRowCellValue(position, "GIA").ToString());
                txt_giadvd.Text = String.Format("{0:#,##0.##}", giadien);


            }
            catch { }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txt_giadvd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_giadvd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //địng dạng tiền tệ
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txt_giadvd.Text, System.Globalization.NumberStyles.AllowThousands);
                txt_giadvd.Text = String.Format(culture, "{0:N0}", value);
                //texbox1.Text = String.Format(culture, "{0:N0}", value);
                txt_giadvd.Select(txt_giadvd.Text.Length, 0);
            }
            catch
            {
                return;
            }
        }

        private void txt_gia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //địng dạng tiền tệ
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txt_gia.Text, System.Globalization.NumberStyles.AllowThousands);
                txt_gia.Text = String.Format(culture, "{0:N0}", value);
                //texbox1.Text = String.Format(culture, "{0:N0}", value);
                txt_gia.Select(txt_gia.Text.Length, 0);
            }
            catch
            {
                return;
            }
        }
    }
}