using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
   public class DAL_KHACHTHUEPHONG
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<KHACHTHUEPHONG> loadbangktp()
        {
            var dulieu = (from s in data.KHACHTHUEPHONGs select s);
            return dulieu.ToList<KHACHTHUEPHONG>();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_khachthuephong(string pma)
        {
            var kt = (from h in data.KHACHTHUEPHONGs
                      where h.MAKTP==pma
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
        public bool them_khachthuephong(KHACHTHUEPHONG dv)
        {
            try
            {
                data.KHACHTHUEPHONGs.InsertOnSubmit(dv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa

        public bool xoa_khachthuephong(string pma)
        {
            try
            {
                KHACHTHUEPHONG dv = data.KHACHTHUEPHONGs.Where(t => t.MAKTP==pma).FirstOrDefault();
                data.KHACHTHUEPHONGs.DeleteOnSubmit(dv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_ktphong(KHACHTHUEPHONG pDichVu)
        {
            try
            {
                KHACHTHUEPHONG nv = data.KHACHTHUEPHONGs.Where(t => t.MAPHONG == pDichVu.MAPHONG && t.MAKT==pDichVu.MAKT).FirstOrDefault();
                if (nv != null)
                {
                    nv.MAKT = pDichVu.MAKT;
                    nv.MAPHONG = pDichVu.MAPHONG;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ktKhachthuephong(string pmaphong, string pmakt)
        {
            var kq = (from p in data.KHACHTHUEPHONGs
                      where p.MAPHONG == pmaphong && p.MAKT == pmakt
                      select p).Count();
            if(kq>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ktkhachthue(string psdt)
        {
            var kq = (from p in data.KHACHTHUEs
                      where p.SDT==psdt
                      select p).Count();
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
