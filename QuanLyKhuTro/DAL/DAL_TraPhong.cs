using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TraPhong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<TraPhong> loadtraphong()
        {
            var kt = from s in data.HOPDONGs
                     from k in data.HOPDONG_KTs
                     from kth in data.KHACHTHUEs
                     where s.MAHD == k.MAHD && k.MAKT == kth.MAKT
                     select new
                     {
                         s.MAHD,
                         s.MANV,
                         s.MAPHONG,                       
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         k.NGAYTRA,
                         k.TRACOC                       
                     };
            var kq = kt.ToList().ConvertAll(t => new TraPhong()
            {
                Mahd = t.MAHD,
                Manv = t.MANV,
                Maphong = t.MAPHONG,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                Ngaylap = Convert.ToDateTime(t.NGAYLAPHD),
                Ngaytra = Convert.ToDateTime(t.NGAYTRA),
                Tracoc = Convert.ToBoolean(t.TRACOC),
            });
            kq.ToList<TraPhong>();
            return kq;
        }
    }
}
