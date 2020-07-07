using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ThongKe
{
    public class DAL_Thongkephong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public string laytenphong()
        {
            var kq = (from p in data.PHONGs
                      select p.TENPHONG).FirstOrDefault();
            return kq.ToString();
        }
        public List<Thongkephong> Loadphong()
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.LOAIPHONGs

              
                     where p.MALOAI == hd.MALOAI && p.MATANG == t.MATANG

                     select new
                     {
                         p.MAPHONG,
                         p.TINHTRANG,
                         p.TENPHONG,
                         p.SOLUONG_HT,
                         p.SOLUONG_TD,
                         t.TENTANG,
                         hd.TENLOAI


                     };
            var kq = kt.ToList().ConvertAll(t => new Thongkephong()
            {
                MAPHONG1=t.MAPHONG,
                TINHTRANG1=Convert.ToBoolean( t.TINHTRANG),
                TENPHONG1=t.TENPHONG,
                SOLUONG_HT1=Convert.ToInt32(t.SOLUONG_HT),
                SOLUONG_TD1=Convert.ToInt32(t.SOLUONG_TD),
                TENLOAI1=t.TENLOAI,
                TENTANG1=t.TENTANG

            }); ; ; ;
            kq.ToList<Thongkephong>();
            return kq;
        }
        public string tinhtongphong()
        {
            var kq = (from p in data.PHONGs
                      select p).Count();
            return kq.ToString();
        }

        public List<Thongkephong> Loadphongdatcoc()
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.LOAIPHONGs
                     from kdc in data.KHACHCOCPHONGs
                 
                     where p.MALOAI == hd.MALOAI && p.MATANG == t.MATANG && kdc.MAPHONG==p.MAPHONG

                     select new
                     {
                         p.MAPHONG,
                         p.TINHTRANG,
                         p.TENPHONG,
                         p.SOLUONG_HT,
                         p.SOLUONG_TD,
                         t.TENTANG,
                         hd.TENLOAI,
                         kdc.MAKHCP,
                         kdc.TEN,
                         kdc.SOCMND,
                         kdc.SODT
                     };
            var kq = kt.ToList().ConvertAll(t => new Thongkephong()
            {
                MAPHONG1 = t.MAPHONG,
                TINHTRANG1 = Convert.ToBoolean(t.TINHTRANG),
                TENPHONG1 = t.TENPHONG,
                SOLUONG_HT1 = Convert.ToInt32(t.SOLUONG_HT),
                SOLUONG_TD1 = Convert.ToInt32(t.SOLUONG_TD),
                TENLOAI1 = t.TENLOAI,
                TENTANG1 = t.TENTANG,
                MAKHCP1=t.MAKHCP,
                TEN1=t.TEN,
                SOCMND1=t.SOCMND,
                SODT1=t.SODT

            }); ; ; ;
            kq.ToList<Thongkephong>();
            return kq;
        }

        public List<Thongkephong> Loadphongtrong()
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.LOAIPHONGs


                     where p.MALOAI == hd.MALOAI && p.MATANG == t.MATANG where p.SOLUONG_HT==0

                     select new
                     {
                         p.MAPHONG,
                         p.TINHTRANG,
                         p.TENPHONG,
                         p.SOLUONG_HT,
                         p.SOLUONG_TD,
                         t.TENTANG,
                         hd.TENLOAI


                     };
            var kq = kt.ToList().ConvertAll(t => new Thongkephong()
            {
                MAPHONG1 = t.MAPHONG,
                TINHTRANG1 = Convert.ToBoolean(t.TINHTRANG),
                TENPHONG1 = t.TENPHONG,
                SOLUONG_HT1 = Convert.ToInt32(t.SOLUONG_HT),
                SOLUONG_TD1 = Convert.ToInt32(t.SOLUONG_TD),
                TENLOAI1 = t.TENLOAI,
                TENTANG1 = t.TENTANG

            }); ; ; ;
            kq.ToList<Thongkephong>();
            return kq;
        }
    }
}
