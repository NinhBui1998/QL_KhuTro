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
using DevExpress.Export;
using DevExpress.Utils.Extensions;
using DevExpress.XtraExport.Helpers;
using QuanLyKhuTro.NghiepVu;

namespace QuanLyKhuTro
{
    public partial class frm_test : UserControl
    {
        BLL_Phong p = new BLL_Phong();
        BLL_DatPhong dp = new BLL_DatPhong();
       
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
            //tạo control động
            int x = 0;
            int y = 0;
            for (int j = 0; j < p.stang().Count; j++)
            {
                Label l = new Label();
                l.Text = ("Tầng" + (j + 1).ToString());
                l.Tag = (j + 1).ToString();
                l.Size = new Size(60, 30);
                l.Location = new Point(x, y);
                panel1.Controls.Add(l);

                for (int i = 0; i < p.sphong(p.stang()[j].MATANG.ToString()).Count; i++)
                {
                    x += 100;
                    Button b = new Button();
                    b.Text = p.sphong(p.stang()[j].MATANG.ToString())[i].TENPHONG.ToString();
                    b.Tag = (i + 1).ToString();
                    b.Size = new Size(90, 60);
                    b.Location = new Point(x, y);
                    b.BackColor = Color.White;
                    if (p.sphong(p.stang()[j].MATANG.ToString())[i].SOLUONG_TD- p.sphong(p.stang()[j].MATANG.ToString())[i].SOLUONG_HT==0)
                    {
                        b.BackColor = Color.Gray;
                        b.Click += showformtraphong;

                    }
                    else if (1<=p.sphong(p.stang()[j].MATANG.ToString())[i].SOLUONG_HT && p.sphong(p.stang()[j].MATANG.ToString())[i].SOLUONG_HT<p.sphong(p.stang()[j].MATANG.ToString())[i].SOLUONG_TD)
                    {
                        b.BackColor = Color.SeaGreen;                                          
                        b.Click += showdialog;

                    }
                    else
                    {
                        b.BackColor = Color.White;
                        frm_datphong frm = new frm_datphong(this);
                        //TenPhong = b.Text;
                        frm.UpdateEventHandler += F2_UpdateEventHandler;
                        b.Click += showformdatphong;
                    }
                    //b.Click += btn_Click;
                    panel1.Controls.Add(b);
                    
                }
                
                x = 0;
                y += 60;
            }
        }
        void showdialog(object sender, EventArgs e)
        {
            dialog_datphong dialog = new dialog_datphong();
            dialog.Show();
        }
        void showformtraphong(object sender, EventArgs e)
        {
            frm_traphong frm = new frm_traphong();
            Button btn = (Button)sender;
            frm.TenPhong = btn.Text;
            frm.ShowDialog();
        }
        void showformdatphong(object sender, EventArgs e)
        {
            frm_datphong frm = new frm_datphong(this);
            frm.MaNhanVien = MaNV;
            Button btn = (Button)sender;
            frm.TenPhong = btn.Text;
            frm.UpdateEventHandler += F2_UpdateEventHandler;
            frm.ShowDialog();
        }
        private void F2_UpdateEventHandler(object sender, frm_datphong.UpdateEventArgs args)
        {
            Form1_Load(sender, args);
        }
        private void btn_restart_Click(object sender, EventArgs e)
        {
            frm_test t = new frm_test();
        }
    }
}