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

namespace QuanLyKhuTro.NghiepVu
{
    
    public partial class frm_quanlyhopdong : Form
    {
        BLL_DatPhong datphong = new BLL_DatPhong();
        public frm_quanlyhopdong()
        {
            InitializeComponent();
        }

        private void frm_quanlyhopdong_Load(object sender, EventArgs e)
        {
            grv_datphong.DataSource = datphong.LoadDatPhong();
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_datphong.DataSource = datphong.LoadDatPhong();
        }
    }
}
