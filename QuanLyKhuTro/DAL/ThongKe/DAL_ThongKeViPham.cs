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
        public List<ViPham> loadtkvipham()
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && p.MAPHONG==s.MAPHONG
                     select new
                     {
                         s.MAPHONG,
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
            var kq = kt.ToList().ConvertAll(t => new ViPham()
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
            kq.ToList<ViPham>();
            return kq;
        }

        public List<ViPham> loadtkviphamtheothang(int thang)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && p.MAPHONG == s.MAPHONG
                        && k.NGAYVIPHAM.Value.Month==thang
                     select new
                     {
                         s.MAPHONG,
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
            var kq = kt.ToList().ConvertAll(t => new ViPham()
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
            kq.ToList<ViPham>();
            return kq;
        }
        public List<ViPham> loadtkviphamtheonam(int nam)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && p.MAPHONG == s.MAPHONG
                        && k.NGAYVIPHAM.Value.Year == nam
                     select new
                     {
                         s.MAPHONG,
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
            var kq = kt.ToList().ConvertAll(t => new ViPham()
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
            kq.ToList<ViPham>();
            return kq;
        }
        public List<ViPham> loadtkviphamtheothangnam(DateTime thangnam)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && p.MAPHONG == s.MAPHONG
                        && k.NGAYVIPHAM.Value.Month == thangnam.Month && k.NGAYVIPHAM.Value.Year == thangnam.Year
                     select new
                     {
                         s.MAPHONG,
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
            var kq = kt.ToList().ConvertAll(t => new ViPham()
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
            kq.ToList<ViPham>();
            return kq;
        }
     
        public List<ViPham> loadtkviphamtheoquy(DateTime? tuthang, DateTime? denthang)
        {
            var kt = from s in data.KHACHTHUEs
                     from k in data.VIPHAMs
                     from kth in data.NOIQUYs
                     from p in data.PHONGs
                     where s.MAKT == k.MAKT && k.MANOIQUY == kth.MANOIQUY && p.MAPHONG == s.MAPHONG
                        && k.NGAYVIPHAM>=tuthang && k.NGAYVIPHAM<=denthang
                     select new
                     {
                         s.MAPHONG,
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
            var kq = kt.ToList().ConvertAll(t => new ViPham()
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
            kq.ToList<ViPham>();
            return kq;
        }

    }
}
