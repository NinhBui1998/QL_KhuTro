using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhanQuyen
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<QLPHANQUYEN> loadbang_QLPHANQUYEN()
        {
            var dulieu = (from s in data.QLPHANQUYENs select s);
            return dulieu.ToList<QLPHANQUYEN>();
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_QLPHANQUYEN(string hd, string mamh)
        {
            var kt = (from h in data.QLPHANQUYENs
                      where h.MANHOM == hd && h.MAMANHINH== mamh
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
        public bool them_QLPHANQUYEN(QLPHANQUYEN phanquyen)
        {
            try
            {
                data.QLPHANQUYENs.InsertOnSubmit(phanquyen);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_QLPHANQUYEN(string pMaNhom, string pmamh)
        {
            try
            {
                QLPHANQUYEN manhom = data.QLPHANQUYENs.Where(t => t.MANHOM == pMaNhom && t.MAMANHINH==pmamh).FirstOrDefault();
                data.QLPHANQUYENs.DeleteOnSubmit(manhom);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_QLPHANQUYEN(QLPHANQUYEN pQLPHANQUYEN)
        {
            try
            {
                QLPHANQUYEN phanquyen = data.QLPHANQUYENs.Where(t => t.MANHOM == pQLPHANQUYEN.MANHOM).FirstOrDefault();
                if (phanquyen != null)
                {
                    phanquyen.COQUYEN = pQLPHANQUYEN.COQUYEN;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
