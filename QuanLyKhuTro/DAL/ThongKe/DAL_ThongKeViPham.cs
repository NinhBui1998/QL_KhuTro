using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ThongKe
{
    public class DAL_ThongKeViPham
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<Vipham> loadtkvipham()
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     from kp in data.KHACHTHUEPHONGs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && p.MAPHONG==kp.MAPHONG && kp.MAKT==s.MAKT
                     select new
                     {
                         kp.MAPHONG,
                         p.TENPHONG,
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
                MAVIPHAM1 = t.MAVIPHAM,
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
                MAPHONG1=t.MAPHONG,
                TENPHONG1=t.TENPHONG,

            }); ;
            kq.ToList<Vipham>();
            return kq;
        }

        public List<Vipham> loadtkviphamtheothang(int thang)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     from kp in data.KHACHTHUEPHONGs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && p.MAPHONG == kp.MAPHONG && kp.MAKT==s.MAKT
                        && k.NGAYVIPHAM.Value.Month==thang
                     select new
                     {
                         kp.MAPHONG,
                         p.TENPHONG,
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
                MAVIPHAM1 = t.MAVIPHAM,
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
                MAPHONG1 = t.MAPHONG,
                TENPHONG1 = t.TENPHONG,

            }); ;
            kq.ToList<Vipham>();
            return kq;
        }
        public List<Vipham> loadtkviphamtheonam(int nam)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                      from kp in data.KHACHTHUEPHONGs
                     where kp.MAKT == k.MAKT && kp.MAPHONG == p.MAPHONG && s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY 
                        && k.NGAYVIPHAM.Value.Year == nam
                     select new
                     {
                         kp.MAPHONG,
                         p.TENPHONG,
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
                MAVIPHAM1 = t.MAVIPHAM,
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
                MAPHONG1 = t.MAPHONG,
                TENPHONG1 = t.TENPHONG,

            }); ;
            kq.ToList<Vipham>();
            return kq;
        }
        public List<Vipham> loadtkviphamtheothangnam(DateTime thangnam)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     from kp in data.KHACHTHUEPHONGs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && p.MAPHONG == kp.MAPHONG && kp.MAKT==s.MAKT
                        && k.NGAYVIPHAM.Value.Month == thangnam.Month && k.NGAYVIPHAM.Value.Year == thangnam.Year
                     select new
                     {
                         kp.MAPHONG,
                         p.TENPHONG,
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
                MAVIPHAM1 = t.MAVIPHAM,
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
                MAPHONG1 = t.MAPHONG,
                TENPHONG1 = t.TENPHONG,

            }); ;
            kq.ToList<Vipham>();
            return kq;
        }
     
        public List<Vipham> loadtkviphamtheoquy(DateTime? tuthang, DateTime? denthang)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     from kp in data.KHACHTHUEPHONGs
                     where kp.MAKT == s.MAKT && kp.MAPHONG == p.MAPHONG && s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY 
                        && k.NGAYVIPHAM>=tuthang && k.NGAYVIPHAM<=denthang
                     select new
                     {
                         kp.MAPHONG,
                         p.TENPHONG,
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
                MAVIPHAM1 = t.MAVIPHAM,
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
                MAPHONG1 = t.MAPHONG,
                TENPHONG1 = t.TENPHONG,

            }); ;
            kq.ToList<Vipham>();
            return kq;
        }

    }
}
