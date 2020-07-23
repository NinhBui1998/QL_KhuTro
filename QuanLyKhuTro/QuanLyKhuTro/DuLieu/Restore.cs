using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKhuTro.DuLieu
{
    public partial class frm_Restore : UserControl
    {
        //SqlConnection sqlconn = new SqlConnection(QuanLyKhuTro.Properties.Settings.Default.Database);
        SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-T8SC55E\SQLEXPRESS;Integrated Security=True");
        public frm_Restore()
        {
            InitializeComponent();
        }

        private void btn_links_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup file(*.bak)|*.bak";
            ofd.Title = "Select backup File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_links.Text = ofd.FileName;
            }
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlconn.State == ConnectionState.Closed)
                {
                    sqlconn.Open();
                }

                string st = "USE [master] RESTORE DATABASE [DLDEMO] FROM DISK = N'" + txt_links.Text + "'with replace";
                SqlCommand cmd = new SqlCommand(st, sqlconn);
                cmd.ExecuteNonQuery();
                if (sqlconn.State == ConnectionState.Open)
                {
                    sqlconn.Close();
                }
                MessageBox.Show("Khôi phục thành công ");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
