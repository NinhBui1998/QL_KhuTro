using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Utils.Extensions;
using QuanLyKhuTro.DanhMuc;
using QuanLyKhuTro.NghiepVu;
using QuanLyKhuTro.DuLieu;
using DAL;
using BLL;
using QuanLyKhuTro.HeThong;
using QuanLyKhuTro.ThongKe;

namespace QuanLyKhuTro
{
    public partial class frm_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        PhanQuyen pq = new PhanQuyen();
        public frm_main()
        {
            InitializeComponent();
        }
        String TenDN;
        public string Tendn
        {
            get { return TenDN; }
            set { TenDN = value; }
        }
        string MK;
        public string MatKhau
        {
            get { return MK; }
            set { MK = value; }
        }
        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel theme = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            theme.LookAndFeel.SkinName = "Office 2019 Colorful";
        }
        public void showForm(Form a)
        {
            a.Dock = DockStyle.Fill;
            a.MdiParent = this;
            a.Show();
        }
        private Form kiemtraform(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }
        private void btn_tang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Form frm = kiemtraform(typeof(frm_tang));
            //if (frm == null)
            //{
              frm_tang forms = new frm_tang();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(forms);
               //forms.MdiParent = this;
            //    forms.Show();
            //}
            //else
            //{
            //    frm.Activate();
            //}
            
        }
        private void btn_loaiphong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_loaiphong forms = new frm_loaiphong();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(forms);
        }

        private void btn_thietbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_thietbi forms = new frm_thietbi();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(forms);
        }

        private void btn_phong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_phong forms = new frm_phong();
            forms.TopLevel = false;
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(forms);
            forms.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            forms.Dock = DockStyle.Fill;
            forms.Show();
            
            //pnl_main.Controls.Clear();
            //pnl_main.Controls.Add(forms);
        }

        private void btn_noiquy_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_noiquy forms = new frm_noiquy();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(forms);
        }

        private void btn_dichvu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_dichvu forms = new frm_dichvu();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(forms);
        }

        private void btn_nhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_nhanvien forms = new frm_nhanvien();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(forms);
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            try { 
            skins();
            //lb_manv.Text = Tendn;
            List<QLPHANQUYEN> manhinh = new List<QLPHANQUYEN>();
            QLND_NHOMND nhom = new QLND_NHOMND();
            nhom = pq.laymanhom(Tendn);
            manhinh = pq.laydsmanhinh(nhom.MANHOM);

            for (int i = 0; i < manhinh.Count(); i++)
            {
                if (manhinh[i].MAMANHINH == "MH001")
                {

                }
               else if(manhinh[i].MAMANHINH == "MH002")
                {
                    btn_nhanvien.Enabled =btn_phanquyen.Enabled = false;

                } 
                else
                {
                    ribbonPageGroup1.Visible = ribbonPageGroup7.Visible= ribbonPageGroup8.Visible 
                        = ribbonPageGroup9 .Visible= ribbonPageGroup10 .Visible= ribbonPageGroup3 .Visible=
                        ribbonPageGroup4 .Visible= ribbonPageGroup5 .Visible= false;
                }    
            }
            }
            catch
            {
                ribbonPageGroup1.Visible = ribbonPageGroup7.Visible = ribbonPageGroup8.Visible
                        = ribbonPageGroup9.Visible = ribbonPageGroup10.Visible = ribbonPageGroup3.Visible =
                        ribbonPageGroup4.Visible = ribbonPageGroup5.Visible = false;
            }


          }
        private void btn_datphong_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            //pnl_main.Controls.Clear();
            //pnl_main.Controls.Add(forms);
        }

        private void btn_saoluu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_backup backup = new frm_backup();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(backup);
        }

        private void btn_khoiphuc_ItemClick(object sender, ItemClickEventArgs e)
        {

            frm_Restore backup = new frm_Restore();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(backup);
        }

        private void btn_khachthue_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_khachthue kt = new frm_khachthue();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(kt);
        }

        private void btn_traphong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_traphong forms = new frm_traphong();
            forms.ShowDialog();
        }

        private void btn_phanquyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_phanquyen pq = new frm_phanquyen();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(pq);
        }

        private void btn_doimatkhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_doimatkhau dmk = new frm_doimatkhau();
            pnl_main.Controls.Clear();
            dmk.MatKhau = MatKhau;
            dmk.Tendn = Tendn;
            pnl_main.Controls.Add(dmk);
        }

        private void btn_dangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btn_thannhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_thannhan tn = new frm_thannhan();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(tn);
        }

        private void btn_tienphong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_tienphong tn = new frm_tienphong();
            tn.MaNhanVien = TenDN;
            tn.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            pnl_main.Controls.Clear();
            frm_test forms = new frm_test();
            forms.MaNhanVien = Tendn;
            Visible = false;
            forms.ShowDialog();
            //frm_test test = new frm_test();
            
            
            //pnl_main.Controls.Add(test);
        }

        private void btn_vipham_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_vipham vp = new frm_vipham();
            vp.TopLevel = false;
            pnl_main.Controls.Clear();
            vp.MaNV = Tendn;
            pnl_main.Controls.Add(vp);

            vp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            vp.Dock = DockStyle.Fill;
            vp.Show();
            //pnl_main.Controls.Clear();
            //pnl_main.Controls.Add(vp);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_quanlyhoadon qlhd = new frm_quanlyhoadon();
            pnl_main.Controls.Clear();
            pnl_main.AddControl(qlhd);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_khachthue frm = new frm_khachthue();
            //frm.TopLevel = false;
            //pnl_main.Controls.Clear();
            //pnl_main.Controls.Add(frm);
            //frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           
            //frm.Dock = DockStyle.Fill;
            frm.Show();
            //// Xóa hết controls đang tồn tại trong pnlContain (nếu có)
            //this.pnl_main.Controls.Clear();

            //frm_khachthue frmChild = new frm_khachthue();
            //frmChild.TopLevel = false;

            //// Gắn vào panel
            //this.pnl_main.Controls.Add(frmChild);

            //// Hiển thị form
            //frmChild.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_tamtru frm = new frm_tamtru();
            frm.TopLevel = false;
            frm.Manv = Tendn;
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(frm);

            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_tkkhachthue frm = new frm_tkkhachthue();
            frm.ShowDialog();
            //frm.TopLevel = false;
            ////frm.MaNV = Tendn;
            //pnl_main.Controls.Clear();
            //pnl_main.Controls.Add(frm);

            //frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //frm.Dock = DockStyle.Fill;
            //frm.Show();
        }

        private void btn_thongkedoanhthu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_tkdoanhthu frm = new frm_tkdoanhthu();

            frm.TopLevel = false;
            
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(frm);

            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void btn_thongkephong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_tkphong frm = new frm_tkphong();
            frm.ShowDialog();
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_dangnhap frm = new frm_dangnhap();
            
            Visible = false;
            frm.ShowDialog();
        }

        private void btn_qlhopdong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_quanlyhopdong frm = new frm_quanlyhopdong();

            frm.TopLevel = false;

            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(frm);

            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}