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
using DAL.NghiepVu;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_thongkedoanhthu : UserControl
    {
        BLL_DatPhong bll_datphong = new BLL_DatPhong();
        BLL_TienPhongHangThang bll_tp = new BLL_TienPhongHangThang();
        BLL_Phong bll_phong = new BLL_Phong();

        public frm_thongkedoanhthu()
        {
            InitializeComponent();
        }

        private void frm_thongkedoanhthu_Load(object sender, EventArgs e)
        {
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";

            grv_datphong.DataSource = bll_datphong.LoadDatPhong();
            grv_hoadon.DataSource = bll_tp.LoadDataHoaDon();
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_datphong.DataSource = bll_datphong.LoadDatPhong();
            grv_hoadon.DataSource = bll_tp.LoadDataHoaDon();
            txt_tongdt.Text = String.Format("{0:#,##0.##}", Convert.ToDouble(tongtientheophong()));
        }
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public double tongtientheophong()
        {
            var tkd = (from hd in data.HOADONs
                       where hd.MAPHONG == cbo_phong.SelectedValue.ToString()
                       select hd.TONGTIEN).Sum();
            var tdp = (from dp in data.HOPDONGs
                       from kt in data.KHACHTHUEs
                       where dp.MAKT == kt.MAKT && kt.MAPHONG == cbo_phong.SelectedValue.ToString()
                       select dp.TIENCOC).Sum();
            return Convert.ToDouble(tkd) + Convert.ToDouble(tdp);
        }
       
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_datphong.DataSource = bll_datphong.LoadDatPhongTheoMa(cbo_phong.Text);
            grv_hoadon.DataSource = bll_tp.LoadDataHoaDontheomaphong(cbo_phong.SelectedValue.ToString());
            txt_tongdt.Text = String.Format("{0:#,##0.##}", Convert.ToDouble(tongtientheophong()));
        }
        DAL_DatPhong dal_dp = new DAL_DatPhong();
        DAL_TienPhongHangThang dal_tp = new DAL_TienPhongHangThang();

        private void btn_tinh_Click(object sender, EventArgs e)
        {
            if (rdo_ngay.Checked == true)
            {
                grv_datphong.DataSource = dal_dp.loaddatPhongtheongay(cbo_ngay.Text);
                grv_hoadon.DataSource = dal_tp.loadHoaDontheongay(cbo_ngay.Text);
                txt_tongdt.Text = String.Format("{0:#,##0.##}", Convert.ToDouble(tongtientheongay(cbo_ngay.Text)));
            }
            else if (rdo_thang.Checked == true)
            {
                grv_datphong.DataSource = dal_dp.loaddatPhongtheongay(cbo_thang.Text);
                grv_hoadon.DataSource = dal_tp.loadHoaDontheongay(cbo_thang.Text);
                txt_tongdt.Text = String.Format("{0:#,##0.##}", Convert.ToDouble(tongtientheongay(cbo_thang.Text)));
            }
            else if (rdo_nam.Checked == true)
            {
                grv_datphong.DataSource = dal_dp.loaddatPhongtheongay(cbo_nam.Text);
                grv_hoadon.DataSource = dal_tp.loadHoaDontheongay(cbo_nam.Text);
                txt_tongdt.Text = String.Format("{0:#,##0.##}", Convert.ToDouble(tongtientheongay(cbo_nam.Text)));
            }
            else
            {
                MessageBox.Show("vui lòng chọn");
            }
        }
          public double tongtientheongay(string ngay)
            {
                var tkd = (from hd in data.HOADONs
                           where hd.NGAYLAP.Value.Day.ToString() == ngay || hd.NGAYLAP.Value.Month.ToString() == ngay
                           || hd.NGAYLAP.Value.Year.ToString() == ngay
                           select hd.TONGTIEN).Sum();
                var tdp = (from dp in data.HOPDONGs
                          
                           where dp.NGAYLAPHD.Value.Day.ToString() == ngay || dp.NGAYLAPHD.Value.Month.ToString() == ngay
                           || dp.NGAYLAPHD.Value.Year.ToString() == ngay
                           select dp.TIENCOC).Sum();
                return Convert.ToDouble(tkd) + Convert.ToDouble(tdp);
            }
        
    }
}
