using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DAL
{
    public class DAL_TraPhong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<TraPhong> loadtraphong()
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     where s.MAKT == kth.MAKT && kth.MAPHONG==p.MAPHONG && s.MANV==nv.MANV
                     select new
                     {
                         s.MAHD,
                         s.MANV,
                         nv.TENNV,
                         p.TENPHONG,                       
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         s.NGAYTRA,
                                            
                     };
            var kq = kt.ToList().ConvertAll(t => new TraPhong()
            {
                Mahd = t.MAHD,
                Manv = t.MANV,
                Tenphong = t.TENPHONG,
                Tennv=t.TENNV,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                Ngaylap = Convert.ToDateTime(t.NGAYLAPHD),
                Ngaytra = Convert.ToDateTime(t.NGAYTRA),
                
            });
            kq.ToList<TraPhong>();
            return kq;
        }
        public List<TraPhong> loadtraphongtheoma(string pten)
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     where s.MAKT == kth.MAKT && kth.MAPHONG == p.MAPHONG &&
                     s.MANV == nv.MANV && p.TENPHONG==pten
                     select new
                     {
                         s.MAHD,
                         s.MANV,
                         nv.TENNV,
                         p.TENPHONG,
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         s.NGAYTRA,

                     };
            var kq = kt.ToList().ConvertAll(t => new TraPhong()
            {
                Mahd = t.MAHD,
                Manv = t.MANV,
                Tenphong = t.TENPHONG,
                Tennv = t.TENNV,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                Ngaylap = Convert.ToDateTime(t.NGAYLAPHD),
                Ngaytra = Convert.ToDateTime(t.NGAYTRA),

            });
            kq.ToList<TraPhong>();
            return kq;
        }
        public String LaysoDien(string pma )
        {
             var kq = (from p in data.PHONGs
                          from c in data.CHISO_DIENNUOCs
                          from hd in data.HOADONs
                          where p.MAPHONG == hd.MAPHONG && c.MAHOADON == hd.MAHOADON && p.MAPHONG == pma
                          select c.SODIEN).Sum();
                return kq.ToString();
            
        }
        public String LaysoNuoc(string pma)
        {
            var kq = (from p in data.PHONGs
                      from c in data.CHISO_DIENNUOCs
                      from hd in data.HOADONs
                      where p.MAPHONG == hd.MAPHONG && c.MAHOADON == hd.MAHOADON && p.MAPHONG == pma
                      select c.SONUOC).Sum();
            return kq.ToString();

        }

    }
}
