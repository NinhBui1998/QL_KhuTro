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
    public partial class frm_backup : UserControl
    {

        public frm_backup()
        {
            InitializeComponent();

        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlconn;
                sqlconn = new SqlConnection(@"Data Source=DESKTOP-T8SC55E\SQLEXPRESS;Initial Catalog=QL_NHATRO;Integrated Security=True");
                if (sqlconn.State == ConnectionState.Closed)
                {
                    sqlconn.Open();
                }
                string st = "BACKUP DATABASE [" + sqlconn.Database + "] TO  DISK = N'" + txt_links.Text + "\\QL_NhaTro.bak'";
                SqlCommand cmd = new SqlCommand(st, sqlconn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sao Lưu thành công");
                if (sqlconn.State == ConnectionState.Open)
                {
                    sqlconn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
        }
        private void btn_links_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txt_links.Text = fd.SelectedPath;
            }
        }
    }
}
