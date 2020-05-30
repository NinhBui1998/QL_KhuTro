using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_Nguoidung
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        //xóa quản lý người dùng
        public bool xoa_QLND(string ptendn)
        {
            try
            {
                QUANLYND tendn = data.QUANLYNDs.Where(t => t.TENDN == ptendn).FirstOrDefault();
                data.QUANLYNDs.DeleteOnSubmit(tendn);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // sua người dùng
        public bool sua_QLND(QUANLYND pqlnd)
        {
            try
            {
                QUANLYND qlnd = data.QUANLYNDs.Where(t => t.TENDN == pqlnd.TENDN).FirstOrDefault();
                if (qlnd != null)
                {
                    qlnd.HOATDONG = pqlnd.HOATDONG;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //load bảng người dùng
        public List<QUANLYND> loadbang_QLND()
        {
            var dulieu = (from s in data.QUANLYNDs select s);
            return dulieu.ToList<QUANLYND>();
        }
        public bool them_nguoidung(QUANLYND lp)
        {
            try
            {
                data.QUANLYNDs.InsertOnSubmit(lp);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
