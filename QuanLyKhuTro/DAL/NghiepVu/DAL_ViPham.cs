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
        public List<Vipham> loadvipham()
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     where s.MAKT== k.MAKT && k.MANOIQUY == kth.MANOIQUY
                     select new
                     {
                         k.TIENPHAT,
                         k.MAVIPHAM,
                         s.MAKT,
                         s.TENKT,
                         s.SOCMND,
                         k.NGAYVIPHAM,
                         k.LAN,
                         k.GHICHU,
                         kth.MANOIQUY,
                         kth.NOIDUNG,
                         kth.HINHPHAT
                     };
            var kq = kt.ToList().ConvertAll(t => new Vipham()
            {
                MAVIPHAM1=t.MAVIPHAM,
                Manoiquy = t.MANOIQUY,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                Socmnd = t.SOCMND,
                Ngayvipham = Convert.ToDateTime(t.NGAYVIPHAM),
                Solan = Convert.ToInt32(t.LAN),
                Ghichu = t.GHICHU,
                Noidung=t.NOIDUNG,
                Hinhphat=Convert.ToDecimal( t.HINHPHAT),
                TIENPHAT1= Convert.ToDecimal(t.TIENPHAT),

            });; 
            kq.ToList<Vipham>();
            return kq;
        }

        public List<Vipham> loadviphamtheoma( string pmakt)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && k.MAKT==pmakt
                     select new
                     {
                         k.MAVIPHAM,
                         s.MAKT,
                         s.TENKT,
                         s.SOCMND,
                         k.NGAYVIPHAM,
                         k.LAN,
                         k.GHICHU,
                         kth.MANOIQUY,
                         kth.NOIDUNG,
                         kth.HINHPHAT,
                         k.TIENPHAT,
                     };
            var kq = kt.ToList().ConvertAll(t => new Vipham()
            {
                MAVIPHAM1=t.MAVIPHAM,
                Manoiquy = t.MANOIQUY,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                Socmnd = t.SOCMND,
                Ngayvipham = Convert.ToDateTime(t.NGAYVIPHAM),
                Solan = Convert.ToInt32(t.LAN),
                Ghichu = t.GHICHU,
                Noidung = t.NOIDUNG,
                Hinhphat = Convert.ToDecimal(t.HINHPHAT),
                TIENPHAT1 = Convert.ToDecimal(t.TIENPHAT),
            });
            kq.ToList<Vipham>();
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
        public List< NOIQUY> loadBANGnoiquy()
        {
            return data.NOIQUYs.Select(t => t).ToList<NOIQUY>();
        }
        public bool ktakhoachinh_ViPham(string manq)
        {
            var kt = (from h in data.VIPHAMs
                      where h.MAVIPHAM == manq 
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
        public bool xoa_vipham(string pmanq)
        {
            try
            {
                VIPHAM hd = data.VIPHAMs.Where(t => t.MAVIPHAM == pmanq).FirstOrDefault();
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
                VIPHAM hd = data.VIPHAMs.Where(t => t.MAVIPHAM==pvipham.MAVIPHAM).FirstOrDefault();
                if (hd != null)
                {
                   
                    hd.MANOIQUY = pvipham.MANOIQUY;
                    hd.NGAYVIPHAM = pvipham.NGAYVIPHAM;
                    hd.GHICHU = pvipham.GHICHU;
                    hd.TIENPHAT = pvipham.TIENPHAT;
                    hd.LAN = pvipham.LAN;
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
                      from kp in data.KHACHTHUEPHONGs
                      where kt.MAKT==kp.MAKT
                      select kp.MAPHONG).FirstOrDefault();
            return kq.ToString();
        }
        public int laylanvipham (string makt, string pmanq)
        {

            var kq = (from vp in data.VIPHAMs
                      where vp.MAKT == makt && vp.MANOIQUY == pmanq
                      select vp).Count();
            if (kq > 0)
            {
                return kq;
            }
            else
            {
                return 0;
            }    

        }
    }
   
}
