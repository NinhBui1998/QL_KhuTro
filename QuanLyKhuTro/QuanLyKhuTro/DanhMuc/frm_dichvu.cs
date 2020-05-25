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

namespace QuanLyKhuTro.DanhMuc
{
    public partial class frm_dichvu : DevExpress.XtraEditors.XtraUserControl
    {
        BLL_DichVu dv = new BLL_DichVu();
        public frm_dichvu()
        {
            InitializeComponent();
        }

        private void gridView_DichVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }
        private void frm_dichvu_Load(object sender, EventArgs e)
        {
            txt_madichvu.Enabled = false;
            grv_dichvu.DataSource = dv.loadBang_DV();
            btn_sua.Enabled = btn_xoa.Enabled = btn_huy.Enabled = btn_luu.Enabled = txt_madichvu.Enabled
                = txt_tendichvu.Enabled = false;
            btn_them.Enabled = true;
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_madichvu.Clear();
            txt_tendichvu.Clear();
            txt_hinhphat.Clear();
            txt_tendichvu.Enabled = true;
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

        private void btn_luu_Click(object sender, EventArgs e)
        {
           
        }
    }
}