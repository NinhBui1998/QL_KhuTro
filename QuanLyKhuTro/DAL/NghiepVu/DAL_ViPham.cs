using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
    public class DAL_ViPham
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<ViPham> loadvipham()
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     where s.MAKT== k.MAKT && k.MANOIQUY == kth.MANOIQUY
                     select new
                     {
                         s.MAKT,
                         s.TENKT,
                         s.SOCMND,
                         k.NGAYVIPHAM,
                         k.SOLAN,
                         k.GHICHU,
                         kth.MANOIQUY,
                         kth.NOIDUNG,
                         kth.HINHPHAT
                     };
            var kq = kt.ToList().ConvertAll(t => new ViPham()
            {
                Manoiquy = t.MANOIQUY,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                Socmnd = t.SOCMND,
                Ngayvipham = Convert.ToDateTime(t.NGAYVIPHAM),
                Solan = Convert.ToInt32(t.SOLAN),
                Ghichu=t.GHICHU,
                Noidung=t.NOIDUNG,
                Hinhphat=t.HINHPHAT
            }); 
            kq.ToList<ViPham>();
            return kq;
        }
        public String laynoidung(string mMa)
        {
            var nd = (from nq in data.NOIQUYs
                      where nq.MANOIQUY == mMa
                      select nq.NOIDUNG).FirstOrDefault();
            return nd.ToString();
        }
        public NOIQUY loadnoiquy(string pMa)
        {
            return data.NOIQUYs.Where(t => t.MANOIQUY == pMa).FirstOrDefault();
        }

    }
   
}
