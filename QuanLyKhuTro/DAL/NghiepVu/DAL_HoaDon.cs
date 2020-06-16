using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
   public class DAL_HoaDon
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<HOADON> loadbangHoaDon()
        {
            var dulieu = (from s in data.HOADONs select s);
            return dulieu.ToList<HOADON>();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_hoadon(string hd)
        {
            var kt = (from h in data.HOADONs
                      where h.MAHOADON == hd
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
        public bool them_HoaDon(HOADON tn)
        {
            try
            {
                data.HOADONs.InsertOnSubmit(tn);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa

        public bool xoa_HoaDon(string pMatn)
        {
            try
            {
                HOADON dv = data.HOADONs.Where(t => t.MAHOADON == pMatn).FirstOrDefault();
                data.HOADONs.DeleteOnSubmit(dv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_HoaDon(HOADON ptn)
        {
            try
            {
                HOADON nv = data.HOADONs.Where(t => t.MAHOADON == ptn.MAHOADON).FirstOrDefault();
                if (nv != null)
                {
                    nv.MAPHONG = ptn.MAPHONG;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ktx_hoadon(string pmatn)
        {
            var ktx = (from t in data.HOADONs
                       from p in data.HOADON_DICHVUs
                       from cs in data.CHISO_DIENNUOCs
                       where t.MAHOADON == p.MAHOADON || p.MAHOADON==cs.MAHOADON && t.MAHOADON==pmatn
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
    }
}
