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

namespace QuanLyKhuTro
{
    public partial class frm_test : UserControl
    {
        BLL_Phong p = new BLL_Phong();
        public frm_test()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            for (int j = 0; j < p.stang().Count; j++)
            {
                Label l = new Label();
                l.Text = ("tầng" + (j + 1).ToString());
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
                    }
                    else if (1<=p.sphong(p.stang()[j].MATANG.ToString())[i].SOLUONG_HT && p.sphong(p.stang()[j].MATANG.ToString())[i].SOLUONG_HT<p.sphong(p.stang()[j].MATANG.ToString())[i].SOLUONG_TD)
                    {
                        b.BackColor = Color.SeaGreen;
                    }
                    else
                    {
                        b.BackColor = Color.White;
                    }    
                    b.Click += btn_Click;
                    panel1.Controls.Add(b);
                }
                x = 0;
                y += 60;
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa có gì");
        }
    }
}
