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
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(forms);
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
            frm_test test = new frm_test();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(test);
          }
        private void btn_datphong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_datphong forms = new frm_datphong();
            forms.ShowDialog();
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
    }
}