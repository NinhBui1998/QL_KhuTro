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
using DAL.Model;
using DevExpress.Utils.Extensions;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_traphong : DevExpress.XtraEditors.XtraForm
    {
        DAL_Tang dal_tang = new DAL_Tang();
        DAL_LoaiPhong dal_loaiphong = new DAL_LoaiPhong();
        DAL_KhachThue dal_khachthue = new DAL_KhachThue();
        DAL_Phong ph = new DAL_Phong();

        BLL_Phong phong = new BLL_Phong();
        BLL_TraPhong traphong = new BLL_TraPhong();
        BLL_HopDong_KhachThue hopdong_khachthue = new BLL_HopDong_KhachThue();
        BLL_HopDong hopdong = new BLL_HopDong();
        BLL_KhachThue khachthue = new BLL_KhachThue();
        public frm_traphong()
        {
            InitializeComponent();
        }

        private void frm_traphong_Load(object sender, EventArgs e)
        {
            grv_traphong.DataSource = traphong.LoadTraPhong();
        }

        private void gridView_traphong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            HOPDONG hd = new HOPDONG();
            HOPDONG_KT hd_kt = new HOPDONG_KT();
            TraPhong tp = new TraPhong();
            PHONG p = new PHONG();
            int position = gridView_traphong.FocusedRowHandle;
            try
            {
                tp.Mahd= gridView_traphong.GetRowCellValue(position, "Mahd").ToString();
                p.MAPHONG = gridView_traphong.GetRowCellValue(position, "Maphong").ToString();
                tp.Makt = gridView_traphong.GetRowCellValue(position, "Makt").ToString();
                tp.Tenkt = gridView_traphong.GetRowCellValue(position, "Tenkt").ToString();
                tp.Ngaylap = Convert.ToDateTime(gridView_traphong.GetRowCellValue(position, "Ngaylap").ToString());
                tp.Ngaytra = Convert.ToDateTime(gridView_traphong.GetRowCellValue(position, "Ngaytra").ToString());
                hd_kt.TRACOC = Convert.ToBoolean(gridView_traphong.GetRowCellValue(position,"Tracoc").ToString());


                txt_mahd.Text = tp.Mahd.ToString();
                txt_maphong.Text = p.MAPHONG.ToString();
                txt_makt.Text = tp.Makt.ToString();
                txt_tenkt.Text = tp.Tenkt.ToString();
                txt_ngaylap.Text = tp.Ngaylap.ToString();
                txt_ngaytra.Text = tp.Ngaytra.ToString();
                ckb_tracoc.Checked = hd_kt.TRACOC.Value;
                if(ckb_tracoc.Checked==true)
                {
                    ckb_tracoc.Text = "Rồi";
                }
                else
                {
                    ckb_tracoc.Text = "Chưa";
                }
            }
            catch { }
        }

        private void txt_maphong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PHONG p = new PHONG();
                TANG t = new TANG();
                LOAIPHONG lp = new LOAIPHONG();
                p = ph.loadTenPhong(txt_maphong.Text);
                t = dal_tang.loadTenTang(p.MATANG);
                lp = dal_loaiphong.loadTenLoaiPhong(p.MALOAI);

                txt_tang.Text = t.TENTANG;
                txt_loaiphong.Text = lp.TENLOAI;
              
                txt_tenphong.Text = p.TENPHONG;
                ckb_tinhtrang.Checked = p.TINHTRANG.Value;
                if (ckb_tinhtrang.Checked == true)
                {
                    ckb_tinhtrang.Text = "Đã thuê";
                }
                else if(ckb_tinhtrang.Checked == false)
                {
                    ckb_tinhtrang.Text = "Chưa thuê";
                }
                txt_slhientai.Text = p.SOLUONG_HT.ToString();
                txt_sltoida.Text = p.SOLUONG_TD.ToString();
            }
            catch { MessageBox.Show("Lỗi hệ thống");           }
        }

        private void txt_makt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                KHACHTHUE kt = new KHACHTHUE();
                kt = dal_khachthue.loadTenKhachThue(txt_makt.Text);
                txt_cmnd.Text = kt.SOCMND;
                txt_sdt.Text = kt.SDT;
            }
            catch { MessageBox.Show("Lỗi hệ thống"); }
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Xác nhận trả phòng!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                int position = gridView_traphong.FocusedRowHandle;
                string m = gridView_traphong.GetRowCellValue(position, "Makt").ToString();
                string n= gridView_traphong.GetRowCellValue(position, "Mahd").ToString(); 
                if (hopdong_khachthue.xoa_HopDong_KhachThue(n,m) == true)
                {
                    if(hopdong.xoa_HopDong(n)==true)
                    {
                        if(khachthue.xoa_KhachThue(m)==true)
                        {
                            grv_traphong.DataSource = traphong.LoadTraPhong();
                            MessageBox.Show("Thành công");
                        }                                             
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
            frm_traphong_Load(sender, e);
        }
    }
}