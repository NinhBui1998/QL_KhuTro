using DAL.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HeThong
{
   public class DAL_LoadKhachThue
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<KhachThue> loadkhachthue()
        {
            var kq1 =from kt in data.KHACHTHUEs
                     from p in data.PHONGs
                     from kp in data.KHACHTHUEPHONGs
                     where kt.MAKT==kp.MAKT && kp.MAPHONG==p.MAPHONG
                     select new
                     {
                         kt.MAKT,
                         kt.TENKT,
                         kt.GIOITINH,
                         kt.ANH,
                         kt.SDT,
                         kt.QUEQUAN,
                         kt.SOCMND,
                         kt.TRUONGPHONG,
                         kt.TINHTRANGTAMTRU,
                         kt.MK,
                         kt.GHICHU,
                         kt.QUANHE,
                         p.MAPHONG,
                         p.TENPHONG,
                         kt.TINHTRANG,
                         kt.NGAYSINH,
                    };
            var kq = kq1.ToList().ConvertAll(t => new KhachThue()
            {
                        MAKT1= t.MAKT,
                        TENKT1 = t.TENKT,
                        GIOITINH1  = t.GIOITINH,
                        ANH1 = t.ANH.ToArray(),
                        SDT1 = t.SDT,
                        QUEQUAN1 = t.QUEQUAN,
                        SOCMND1  = t.SOCMND,
                        TRUONGPHONG1=Convert.ToBoolean (t.TRUONGPHONG),
                        TINHTRANGTAMTRU1 = t.TINHTRANGTAMTRU,
                        MK1 = t.MK,
                        GHICHU1 = t.GHICHU,
                        QUANHE1 = t.QUANHE,
                        MAPHONG1 = t.MAPHONG,
                        TENPHONG1 = t.TENPHONG,
                        TINHTRANG1 =Convert.ToBoolean( t.TINHTRANG),
                        NGAYSINH1 = Convert.ToDateTime( t.NGAYSINH),
            });
            kq.ToList<KhachThue>().Distinct();
            return kq;
        }
        public List<KhachThue> loadkhachthuetheomaphong(string pmaphong)
        {
            var kq1 =
                     from kt in data.KHACHTHUEs
                     from p in data.PHONGs
                     from kp in data.KHACHTHUEPHONGs
                     where kt.MAKT == kp.MAKT && kp.MAPHONG == p.MAPHONG && p.MAPHONG==pmaphong && kt.TINHTRANG==true
                     select new
                     {
                         kt.MAKT,
                         kt.TENKT,
                         kt.GIOITINH,
                         kt.ANH,
                         kt.SDT,
                         kt.QUEQUAN,
                         kt.SOCMND,
                         kt.TRUONGPHONG,
                         kt.TINHTRANGTAMTRU,
                         kt.MK,
                         kt.GHICHU,
                         kt.QUANHE,
                         p.MAPHONG,
                         p.TENPHONG,
                         kt.TINHTRANG,
                         kt.NGAYSINH,
                     };
            var kq = kq1.ToList().ConvertAll(t => new KhachThue()
            {
                MAKT1 = t.MAKT,
                TENKT1 = t.TENKT,
                GIOITINH1 = t.GIOITINH,
                ANH1 = t.ANH.ToArray(),
                SDT1 = t.SDT,
                QUEQUAN1 = t.QUEQUAN,
                SOCMND1 = t.SOCMND,
                TRUONGPHONG1 = Convert.ToBoolean(t.TRUONGPHONG),
                TINHTRANGTAMTRU1 = t.TINHTRANGTAMTRU,
                MK1 = t.MK,
                GHICHU1 = t.GHICHU,
                QUANHE1 = t.QUANHE,
                MAPHONG1 = t.MAPHONG,
                TENPHONG1 = t.TENPHONG,
                TINHTRANG1 = Convert.ToBoolean(t.TINHTRANG),
                NGAYSINH1 = Convert.ToDateTime(t.NGAYSINH),
            });
            kq.ToList<KhachThue>();
            return kq;
        }
        public List<KhachThue> loadkhachthuecono()
        {
            var kq1 = from kt in data.KHACHTHUEs
                      from p in data.PHONGs
                      from kp in data.KHACHTHUEPHONGs
                      where kt.MAKT == kp.MAKT && kp.MAPHONG == p.MAPHONG && kt.TINHTRANG==true
                      select new
                      {
                          kt.MAKT,
                          kt.TENKT,
                          kt.GIOITINH,
                          kt.ANH,
                          kt.SDT,
                          kt.QUEQUAN,
                          kt.SOCMND,
                          kt.TRUONGPHONG,
                          kt.TINHTRANGTAMTRU,
                          kt.MK,
                          kt.GHICHU,
                          kt.QUANHE,
                          p.MAPHONG,
                          p.TENPHONG,
                          kt.TINHTRANG,
                          kt.NGAYSINH,
                      };
            var kq = kq1.ToList().ConvertAll(t => new KhachThue()
            {
                MAKT1 = t.MAKT,
                TENKT1 = t.TENKT,
                GIOITINH1 = t.GIOITINH,
                ANH1 = t.ANH.ToArray(),
                SDT1 = t.SDT,
                QUEQUAN1 = t.QUEQUAN,
                SOCMND1 = t.SOCMND,
                TRUONGPHONG1 = Convert.ToBoolean(t.TRUONGPHONG),
                TINHTRANGTAMTRU1 = t.TINHTRANGTAMTRU,
                MK1 = t.MK,
                GHICHU1 = t.GHICHU,
                QUANHE1 = t.QUANHE,
                MAPHONG1 = t.MAPHONG,
                TENPHONG1 = t.TENPHONG,
                TINHTRANG1 = Convert.ToBoolean(t.TINHTRANG),
                NGAYSINH1 = Convert.ToDateTime(t.NGAYSINH),
            });
            kq.ToList<KhachThue>().Distinct();
            return kq;
        }
    }
}
