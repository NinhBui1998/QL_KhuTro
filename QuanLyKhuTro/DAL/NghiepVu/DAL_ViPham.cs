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
                Hinhphat=Convert.ToDecimal( t.HINHPHAT)
            }); 
            kq.ToList<ViPham>();
            return kq;
        }

        public List<ViPham> loadviphamtheoma( string pmakt)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && k.MAKT==pmakt
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
                Ghichu = t.GHICHU,
                Noidung = t.NOIDUNG,
                Hinhphat = Convert.ToDecimal(t.HINHPHAT)
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
        public bool ktakhoachinh_ViPham(string manq, string makt)
        {
            var kt = (from h in data.VIPHAMs
                      where h.MANOIQUY == manq && h.MAKT ==makt
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
        public bool them_vipham(VIPHAM tt)
        {
            try
            {
                data.VIPHAMs.InsertOnSubmit(tt);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_vipham(string pmanq, string pmakt)
        {
            try
            {
                VIPHAM hd = data.VIPHAMs.Where(t => t.MANOIQUY == pmanq && t.MAKT==pmakt).FirstOrDefault();
                data.VIPHAMs.DeleteOnSubmit(hd);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_vipham(VIPHAM pvipham)
        {
            try
            {
                VIPHAM hd = data.VIPHAMs.Where(t => t.MANOIQUY == pvipham.MANOIQUY && t.MAKT== pvipham.MAKT).FirstOrDefault();
                if (hd != null)
                {
                    hd.SOLAN = pvipham.SOLAN;
                    hd.GHICHU = pvipham.GHICHU;

                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string laymaphong (string makt)
        {
            var kq = (from kt in data.KHACHTHUEs
                      select kt.MAPHONG).FirstOrDefault();
            return kq.ToString();
        }
    }
   
}
