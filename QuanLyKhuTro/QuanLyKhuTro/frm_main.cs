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

namespace QuanLyKhuTro
{
    public partial class frm_main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_main()
        {
            InitializeComponent();
        }
        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel theme = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            theme.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
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
        }

        private void btn_datphong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_datphong forms = new frm_datphong();
            forms.Show();
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
    }
}