using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
   public class DAL_ChiSoDienNuoc
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<CHISO_DIENNUOC> loadbangChiSoDN()
        {
            var dulieu = (from s in data.CHISO_DIENNUOCs select s);
            return dulieu.ToList<CHISO_DIENNUOC>();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_ChisoDN(string hd)
        {
            var kt = (from h in data.CHISO_DIENNUOCs
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
        public bool them_CHiSoDN(CHISO_DIENNUOC tn)
        {
            try
            {
                data.CHISO_DIENNUOCs.InsertOnSubmit(tn);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa

        public bool xoa_ChiSoDienNuoc(string pMatn)
        {
            try
            {
                CHISO_DIENNUOC dv = data.CHISO_DIENNUOCs.Where(t => t.MAHOADON == pMatn).FirstOrDefault();
                data.CHISO_DIENNUOCs.DeleteOnSubmit(dv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_ChisoDN(CHISO_DIENNUOC ptn)
        {
            try
            {
                CHISO_DIENNUOC nv = data.CHISO_DIENNUOCs.Where(t => t.MAHOADON == ptn.MAHOADON).FirstOrDefault();
                if (nv != null)
                {
                    nv.SODIENMOI = ptn.SODIENMOI;
                    nv.SONUOCMOI = ptn.SONUOCMOI;
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
