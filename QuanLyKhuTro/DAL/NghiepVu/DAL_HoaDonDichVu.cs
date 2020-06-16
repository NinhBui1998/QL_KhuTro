using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
    public class DAL_HoaDonDichVu
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<HOADON_DICHVU> loadbangHoaDon_DV()
        {
            var dulieu = (from s in data.HOADON_DICHVUs select s);
            return dulieu.ToList<HOADON_DICHVU>();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_hoadon_dv(string madv, string hd)
        {
            var kt = (from h in data.HOADON_DICHVUs
                      where h.MADV == madv && h.MAHOADON == hd
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
        public bool them_HoaDon_DV(HOADON_DICHVU tn)
        {
            try
            {
                data.HOADON_DICHVUs.InsertOnSubmit(tn);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa

        public bool xoa_HoaDon_DV(string pMadv, string pmahd)
        {
            try
            {
                HOADON_DICHVU dv = data.HOADON_DICHVUs.Where(t => t.MADV==pMadv &&t.MAHOADON==pmahd).FirstOrDefault();
                data.HOADON_DICHVUs.DeleteOnSubmit(dv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_HoaDon_DV(HOADON_DICHVU ptn)
        {
            try
            {
                HOADON_DICHVU nv = data.HOADON_DICHVUs.Where(t => t.MAHOADON == ptn.MAHOADON && t.MADV==ptn.MADV).FirstOrDefault();
                if (nv != null)
                {
                    nv.MAHOADON = ptn.MAHOADON;
                    nv.MADV = ptn.MADV;
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
