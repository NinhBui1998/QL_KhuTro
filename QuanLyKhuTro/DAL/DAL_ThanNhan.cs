using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThanNhan
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<THANNHAN> loadbangDichVu()
        {
            var dulieu = (from s in data.THANNHANs select s);
            return dulieu.ToList<THANNHAN>();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_ThanNhan(string hd)
        {
            var kt = (from h in data.THANNHANs
                      where h.MATN == hd
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
        public bool them_ThanNhan(THANNHAN tn)
        {
            try
            {
                data.THANNHANs.InsertOnSubmit(tn);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa

        public bool xoa_ThanNhan(string pMatn)
        {
            try
            {
                THANNHAN dv = data.THANNHANs.Where(t => t.MATN == pMatn).FirstOrDefault();
                data.THANNHANs.DeleteOnSubmit(dv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_thannhan(THANNHAN ptn)
        {
            try
            {
                THANNHAN nv = data.THANNHANs.Where(t => t.MATN == ptn.MATN).FirstOrDefault();
                if (nv != null)
                {
                    nv.TENTN = ptn.TENTN;
                    nv.SOCMNDTN = ptn.SOCMNDTN;
                    nv.GIOITINH_TN = ptn.GIOITINH_TN;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ktx_thannhan(string pmatn)
        {
            var ktx = (from t in data.THANNHANs
                       from p in data.THANNHAN_TAMTRUs
                       where t.MATN == pmatn && p.MATN == p.MATN
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
