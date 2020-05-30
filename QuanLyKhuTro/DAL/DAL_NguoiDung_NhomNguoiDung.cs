using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NguoiDung_NhomNguoiDung
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<QLND_NHOMND> loadbang_QLND_NHOMND()
        {
            var dulieu = (from s in data.QLND_NHOMNDs select s);
            return dulieu.ToList<QLND_NHOMND>();
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_QLND_NHOMND(string hd, string tendn)
        {
            var kt = (from h in data.QLND_NHOMNDs
                      where h.MANHOM == hd && h.TENDN==tendn
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
        public bool them_QLND_NHOMND(QLND_NHOMND ND_nhomND)
        {
            try
            {
                data.QLND_NHOMNDs.InsertOnSubmit(ND_nhomND);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_QLND_NHOMND(string pMaNhom, string ptendn)
        {
            try
            {
                QLND_NHOMND manhom = data.QLND_NHOMNDs.Where(t => t.MANHOM == pMaNhom && t.TENDN==ptendn).FirstOrDefault();
                data.QLND_NHOMNDs.DeleteOnSubmit(manhom);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_QLND_NHOMND(QLND_NHOMND pQLND_NHOMND)
        {
            try
            {
                QLND_NHOMND ND_nhomND = data.QLND_NHOMNDs.Where(t => t.MANHOM == pQLND_NHOMND.MANHOM).FirstOrDefault();
                if (ND_nhomND != null)
                {
                    ND_nhomND.GHICHU = pQLND_NHOMND.GHICHU;                 
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
