using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
   public class DAL_Tang
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
       
        //lấy tất cả dữ liệu
        public List<TANG> loadbangTang()
        {
            var dulieu = (from s in data.TANGs select s);
            return dulieu.ToList<TANG>();
        }    
        public TANG loadTenTang(string pMa)
        {
            return data.TANGs.Where(t => t.MATANG == pMa).FirstOrDefault();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_Tang(string hd)
        {
            var kt = (from h in data.TANGs
                      where h.MATANG == hd
                      select h).Count();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Thêm
        public bool them_Tang(TANG tg)
        {
            try
            {
                data.TANGs.InsertOnSubmit(tg);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa

        public bool xoaTang(string pMaTang)
        {
            try
            {
                TANG tg = data.TANGs.Where(t => t.MATANG == pMaTang).FirstOrDefault();
                data.TANGs.DeleteOnSubmit(tg);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool suaTang(TANG pTang)
        {
            try
            {
                TANG nv = data.TANGs.Where(t => t.MATANG == pTang.MATANG).FirstOrDefault();
                if (nv != null)
                {
                    nv.TENTANG = pTang.TENTANG; 
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //kiểm tra tầng có đang được sử dụng
        public bool kt_XoaTang(string hd)
        {

            var ktx = (from t in data.TANGs
                       from p in data.PHONGs
                       where t.MATANG==hd && p.MATANG==hd
                       select t).Count();
            if (ktx > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //public string SinhMa()
        //{
        //    var a = data.TANGs.Select(t => t);
        //    var resultTable = new DataTable();
        //    bool firstPass = true;
        //    string ma = "T00";
            
        //    foreach (var item in a)
        //    {
        //        if (firstPass)
        //        {
        //            Array.ForEach(item.GetType().GetProperties(), p => resultTable.Columns.Add(new DataColumn(p.Name)));
        //            firstPass = false;
        //        }
        //        var newRow = resultTable.NewRow();
        //        Array.ForEach(item.GetType().GetProperties(), p => newRow[p.Name] = p.GetValue(item, null));
        //        resultTable.Rows.Add(newRow);
        //    }
        //    try
        //    {
        //        int i = resultTable.Rows.Count;
        //        string x = resultTable.Rows[i - 1][2].ToString();
        //        int Str3 = int.Parse(x.Substring(2));
        //        int Str4 = Str3 + 1;
        //        if (Str4 < 10)
        //        {
        //            return ma + "00"+Str4;
        //        }
        //        else 
        //        {
        //            return ma + "0" + (Str3 + 1);
        //        }
     
        //    }
        //    catch
        //    {
        //        return ma + "001";
        //    }
        //}
    }
}
