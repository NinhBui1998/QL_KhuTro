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
using BLL.NghiepVu;
using DAL;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_thongkekhachthue : Form
    {
        BLL_KhachThue bll_khachthue = new BLL_KhachThue();
        BLL_Phong bll_phong = new BLL_Phong();
        BLL_tamtru bll_tamtru = new BLL_tamtru();
        public frm_thongkekhachthue()
        {
            InitializeComponent();
        }
        string Manv;

        public string MaNV { get => Manv; set => Manv = value; }

        private void frm_thongkekhachthue_Load(object sender, EventArgs e)
        {
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";
            grv_khachthue.DataSource = bll_khachthue.loadBangKT();
            grv_tamtru.DataSource = bll_tamtru.Loadtamtru();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = bll_khachthue.loadBangKTtheoma(cbo_phong.SelectedValue.ToString());
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = bll_khachthue.loadBangKT();
            grv_tamtru.DataSource = bll_tamtru.Loadtamtru();
        }

        private void btn_tinh_Click(object sender, EventArgs e)
        {
            if(ckb_ngay.Checked==true && ckb_thang.Checked==false && ckb_nam.Checked==false)
            {
                if(ckb_ngay.Text==string.Empty)
                {
                    MessageBox.Show("Không được để trống ngày");
                    return;
                }    
            }
            else if(ckb_ngay.Checked == false && ckb_thang.Checked == true && ckb_nam.Checked == false)
            {
                MessageBox.Show("Không được để trống tháng");
                return;
            }   
            else if (ckb_ngay.Checked == false && ckb_thang.Checked == false && ckb_nam.Checked == true)
            {
                MessageBox.Show("Không được để trống năm");
                return;
            }
            else if (ckb_ngay.Checked == true && ckb_thang.Checked == true && ckb_nam.Checked == false)
            {
                MessageBox.Show("Không được để trống ngày tháng");
                return;
            }
            
            else if (ckb_ngay.Checked == false && ckb_thang.Checked == true && ckb_nam.Checked == true)
            {
                MessageBox.Show("Không được để trống tháng năm");
                return;
            }
            else if (ckb_ngay.Checked == true && ckb_thang.Checked == true && ckb_nam.Checked == true)
            {
                MessageBox.Show("Không được để trống ngày tháng năm");
                return;
            }
            else { return; }
        }
    }
}
