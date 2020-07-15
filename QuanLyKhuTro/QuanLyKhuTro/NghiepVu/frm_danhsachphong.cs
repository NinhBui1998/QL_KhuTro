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
using DevExpress.Export;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraExport.Helpers;
using Microsoft.Office.Interop.Word;
using QuanLyKhuTro.DuLieu;
using QuanLyKhuTro.NghiepVu;

namespace QuanLyKhuTro
{
    public partial class frm_test : Form
    {
        BLL_Phong p = new BLL_Phong();
        BLL_DatPhong dp = new BLL_DatPhong();
        BLL_LoaiPhong bll_loai = new BLL_LoaiPhong();
        BLL_Tang bll_tang = new BLL_Tang();
        BLL_DSPhong bll_dsp = new BLL_DSPhong();
        BLL_HopDong bll_hd = new BLL_HopDong();
        capnhatdulieu cn = new capnhatdulieu();
       
        public frm_test()
        {
            InitializeComponent();
        }
        string MaNV;
        public string MaNhanVien
        {
            get { return MaNV; }
            set { MaNV = value; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cn.update();
            
            lb_saptoihantra.Text = bll_dsp.tongphongsapdenhan();
            lb_cokhach.Text = bll_dsp.tongphongcokhach();
            lb_cokhachdat.Text = bll_dsp.tongphongcokhachcoc();
            lb_Phongtrong.Text = bll_dsp.tongphongtrong();
            lb_phongsuachua.Text = bll_dsp.tongphongdangsua();



            cbo_loai.DataSource = bll_loai.loadBangLoaiPhong();
            cbo_loai.DisplayMember = "TENLOAI";
            cbo_loai.ValueMember = "MALOAI";

           

            //grv_phong.DataSource = bll_dsp.LoadDSPhong();
            //tạo control động
            int x = 0;
            int y = 0;
            for (int j = 0; j < p.stang().Count; j++)
            {
                Label l = new Label();
                l.Text = ("Tầng" + (j + 1).ToString());
                l.Tag = (j + 1).ToString();
                l.Size = new Size(60, 30);
                l.Location = new System.Drawing.Point(x, y);
                panel1.Controls.Add(l);
                for (int i = 0; i < p.sphong(p.stang()[j].MATANG.ToString()).Count; i++)
                {
                  
                    ///
                    x += 100;
                    Button b = new Button();
                    b.Text = p.sphong(p.stang()[j].MATANG.ToString())[i].TENPHONG.ToString();
                    b.Tag = (i + 1).ToString();
                    b.Size = new Size(90, 60);
                    b.Location = new System.Drawing.Point(x, y);
                    b.BackColor = Color.White;
                    
                    if (p.sphong(p.stang()[j].MATANG.ToString())[i].TINHTRANG==true)
                    {

                        if (p.sphong(p.stang()[j].MATANG.ToString())[i].TINHTRANGHOPDONG == "Sắp hết hạn hợp đồng")
                        {
                            if (p.sphong(p.stang()[j].MATANG.ToString())[i].TRANGTHAIPHONG == "Gia hạn hợp đồng")
                            {
                                b.BackColor = Color.Red;
                                b.Image = new Bitmap("dautick.png");
                                b.ImageAlign = ContentAlignment.TopRight;
                                b.Click += showformdatphong;
                            }
                            else
                            { 
                                b.BackColor = Color.Red;
                                    b.Click += showdialog;
                            }


                        }
                        else if (p.sphong(p.stang()[j].MATANG.ToString())[i].TINHTRANGHOPDONG == "Đã có khách cọc")
                        {
                            b.BackColor = Color.Gray;
                            b.Click += show;
                        }
                        else
                        {
                            b.BackColor = Color.SeaGreen;
                            b.Click += showformtraphong;
                        }
                    }
                    ////////////////////////////////////////// 
                    else
                    {
                        b.BackColor = Color.White;
                        frm_datphong frm = new frm_datphong(this);
                       
                        b.Click += showformdatphong;
                    }
                    if (p.sphong(p.stang()[j].MATANG.ToString())[i].TRANGTHAIPHONG == "Đang sửa chữa")
                    {
                        b.BackgroundImage = new Bitmap("suachua.png");
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Enabled = false;
                    }
                   

                    ///////


                    panel1.Controls.Add(b);
                    
                }
                
                x = 0;
                y += 60;
            }
            
        }
        void showdialog(object sender, EventArgs e)
        {
            dialog_datphong frm = new dialog_datphong();
            Button btn = (Button)sender;
            frm.TenPhong = btn.Text;
            frm.MaNhanVien = MaNV;
            Visible = false;
            frm.ShowDialog();
        }
        void show(object sender, EventArgs e)
        {
            frm_dialog frm = new frm_dialog();
            Button btn = (Button)sender;
            frm.TenPhong = btn.Text;
            frm.MaNhanVien = MaNV;
            Visible = false;
            frm.ShowDialog();
        }
        void showformtraphong(object sender, EventArgs e)
        {
            frm_traphong frm = new frm_traphong();
            Button btn = (Button)sender;
            frm.TenPhong = btn.Text;
            frm.MaNhanVien = MaNV;
            Visible = false;
            frm.ShowDialog();
        }
        void showformdatphong(object sender, EventArgs e)
        {
            frm_datphong frm = new frm_datphong(this);
            frm.MaNhanVien = MaNV;
            Button btn = (Button)sender;
            frm.TenPhong = btn.Text;
            //frm.UpdateEventHandler += F2_UpdateEventHandler;
            Visible = false;
            frm.ShowDialog();
            
        }
        //private void F2_UpdateEventHandler(object sender, frm_datphong.UpdateEventArgs args)
        //{
        //    frm_test frm = new frm_test();
        //    frm.Show();
        //}
      

        private void gridView_Phong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //PHONG p = new PHONG();
            ////TANG t = new TANG();
            ////LOAIPHONG lp = new LOAIPHONG();
            //int position = gridView_Phong.FocusedRowHandle;
            //try
            //{
            //    p.MATANG = gridView_Phong.GetRowCellValue(position, "MATANG").ToString();
            //    p.MALOAI = gridView_Phong.GetRowCellValue(position, "MALOAI").ToString();
            //    p.TENPHONG = gridView_Phong.GetRowCellValue(position, "TENPHONG").ToString();                 
            //    p.SOLUONG_HT = Convert.ToInt32(gridView_Phong.GetRowCellValue(position, "SOLUONG_HT").ToString());
            //    p.SOLUONG_TD = Convert.ToInt32(gridView_Phong.GetRowCellValue(position, "SOLUONG_TD").ToString());
            //}
            //catch { }
        }

        private void btn_taohd_Click(object sender, EventArgs e)
        {
            //grv_phong.DataSource = bll_dsp.LoadDSPhongTheoMa(cbo_tang.SelectedValue.ToString(), cbo_loai.SelectedValue.ToString());
            panel1.Controls.Clear();
            int x = 0;
            int y = 0;
            for (int j = 0; j < p.stang().Count; j++)
            {
                Label l = new Label();
                l.Text = ("Tầng" + (j + 1).ToString());
                l.Tag = (j + 1).ToString();
                l.Size = new Size(60, 30);
                l.Location = new System.Drawing.Point(x, y);
                panel1.Controls.Add(l);
                //for (int i = 0; i < p.sphong(p.stang()[j].MATANG.ToString()).Count; i++)
                for (int i = 0; i < p.loadphong(p.stang()[j].MATANG.ToString(),cbo_loai.SelectedValue.ToString()).Count; i++)
                {
                    x += 100;
                    Button b = new Button();
                    //b.Text = p.sphong(p.stang()[j].MATANG.ToString())[i].TENPHONG.ToString();
                    b.Text = p.loadphong(p.stang()[j].MATANG.ToString(), cbo_loai.SelectedValue.ToString())[i].TENPHONG.ToString();
                    b.Tag = (i + 1).ToString();
                    b.Size = new Size(90, 60);
                    b.Location = new System.Drawing.Point(x, y);
                    b.BackColor = Color.White;
                    if (p.loadphong(p.stang()[j].MATANG.ToString(), cbo_loai.SelectedValue.ToString())[i].TINHTRANG==true)
                    {
                        if (p.loadphong(p.stang()[j].MATANG.ToString(), cbo_loai.SelectedValue.ToString())[i].TINHTRANGHOPDONG == "Sắp hết hạn hợp đồng")
                        {
                            if (p.loadphong(p.stang()[j].MATANG.ToString(), cbo_loai.SelectedValue.ToString())[i].TRANGTHAIPHONG == "Gia hạn hợp đồng")
                            {
                                b.BackColor = Color.Red;
                                b.Image = new Bitmap("dautick.png");
                                b.ImageAlign = ContentAlignment.TopRight;
                                b.Click += showformdatphong;
                            }
                            else
                            {
                                b.BackColor = Color.Red;
                                b.Click += showdialog;
                            }
                        }
                        else if (p.loadphong(p.stang()[j].MATANG.ToString(), cbo_loai.SelectedValue.ToString())[i].TINHTRANGHOPDONG == "Đã có khách cọc")
                        {
                            b.BackColor = Color.Gray;
                            b.Click += show;
                        }
                        else
                        {
                            b.BackColor = Color.SeaGreen;
                            b.Click += showformtraphong;
                        }
                    }
                    else
                    {
                        b.BackColor = Color.White;
                        frm_datphong frm = new frm_datphong(this);

                        b.Click += showformdatphong;
                    }
                    if (p.loadphong(p.stang()[j].MATANG.ToString(), cbo_loai.SelectedValue.ToString())[i].TRANGTHAIPHONG == "Đang sửa chữa")
                    {
                        b.BackgroundImage = new Bitmap("suachua.png");
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Enabled = false;
                    }

                    panel1.Controls.Add(b);

                }

                x = 0;
                y += 60;
            }
        }
        private void btn_tatcaphong_Click(object sender, EventArgs e)
        {
            //grv_phong.DataSource = bll_dsp.LoadDSPhong();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form1_Load(sender, e);
        }

        private void frm_test_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_main frm = new frm_main();
            frm.Tendn = MaNV;
            Visible = false;
            frm.ShowDialog();
        }

      
    }
}