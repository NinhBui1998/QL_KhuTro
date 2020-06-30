using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QuanLyKhuTro.HeThong
{
   public class cauhinh
    {
        public int Check_Config()
        {
            if (Properties.Settings.Default.QL_NHATROConnectionString1== string.Empty)
                return 1;// Chuỗi cấu hình không tồn tại
            SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.QL_NHATROConnectionString1);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;// Kết nối thành công chuỗi cấu hình hợp lệ
            }
            catch
            {
                return 2;// Chuỗi không phù hợp
            }
        }
        public LoginResult Check_User(String pUser, String pPass)
        {

            SqlDataAdapter da = new SqlDataAdapter("select * from QUANLYND where TENDN='" + pUser + "' and MK='" + pPass + "'", Properties.Settings.Default.QL_NHATROConnectionString1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
                return LoginResult.Invalid;
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "false")
                return LoginResult.Disable;
            return LoginResult.Success;

        }

        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public DataTable GetDBName(String pServer)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases", "Data Source=" + pServer + "; Initial Catalog=master; Integrated Security=True");
            da.Fill(dt);
            return dt;

        }

        public void SaveConfig(String pServer, String pUser, String pPass, String pDBname)
        {
            Properties.Settings.Default.QuanLyKhuTro = @"Data Source=" + pServer + "; Initial Catalog=" + pDBname + "; Initial Catalog=master; User ID=" + pUser + ";Password=" + pPass + "";
            Properties.Settings.Default.Save();
        }
        public List<string> GetDatabaseName(string pServerName, string pUser, string pPass)
        {
            List<string> _list = new List<string>();
            DataTable dt = new DataTable();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT name FROM sys.databases", "Data Source = " + pServerName + " ; Initial Catalog = " + "master" + "; User ID = " + pUser + "; Password = " + pPass + "");
                da.Fill(dt);
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    foreach (System.Data.DataColumn col in dt.Columns)
                    {
                        _list.Add(row[col].ToString());
                    }
                }
            }
            catch
            {
                return null;
            }
            return _list;
        }
    }
}
