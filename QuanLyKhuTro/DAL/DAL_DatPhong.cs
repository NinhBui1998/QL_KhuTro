using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_DatPhong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<DatPhong> loaddatphong()
        {
            var kt = from s in data.HOPDONGs
                     from k in data.HOPDONG_KTs
                     from kth in data.KHACHTHUEs
                     where s.MAHD == k.MAHD && k.MAKT==kth.MAKT
                     select new
                     {
                         s.MAHD,
                         s.MANV,
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         s.THOIHAN,
                         s.TIENCOC,
                     };
            var kq = kt.ToList().ConvertAll(t => new DatPhong()
            {
                Mahd=t.MAHD,
                Manv=t.MANV,
                Makt=t.MAKT,
                Tenkt=t.TENKT,
                NgayLap = Convert.ToDateTime(t.NGAYLAPHD),
                Thoihan=t.THOIHAN,
                Tiencoc= Convert.ToDouble(t.TIENCOC),
            });
            kq.ToList<DatPhong>();
            return kq;
        }
    }
}
