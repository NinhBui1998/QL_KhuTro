using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ThongKe
{
   public class DAL_ThongKeDoanhThu
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public Decimal TinhTong()
        {
            var kq = (from hd in data.HOADONs
                      select hd.TONGTIEN).Sum();
            return Convert.ToDecimal( kq);
        }
        public Decimal TinhTongTienDien()
        {
            var kq = (from hd in data.HOADONs
                      select hd.TIENDIEN).Sum();
            return Convert.ToDecimal(kq);
        }
        public Decimal TinhTongTienNuoc()
        {
            var kq = (from hd in data.HOADONs
                      select hd.TIENNUOC).Sum();
            return Convert.ToDecimal(kq);
        }
        public decimal TinhTongTienWifi()
        {
            var kq = (from hd in data.HOADONs
                      select hd.WIFI).Sum();
            return Convert.ToDecimal(kq);
        }
        public decimal TinhTongTienRac()
        {
            var kq = (from hd in data.HOADONs
                      select hd.RAC).Sum();
            return Convert.ToDecimal(kq);
        }
        public decimal TinhTongTienPhong()
        {
            var kq = (from hd in data.HOADONs
                      from p in data.PHONGs
                      from l in data.LOAIPHONGs
                      where hd.MAPHONG==p.MAPHONG && l.MALOAI==p.MALOAI
                      select l.GIA).Sum();
            return Convert.ToDecimal(kq);
        }

        public List<HoaDon> loadHoaDontheothang(string thang)
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.HOADONs
                     from cs in data.CHISO_DIENNUOCs
                     from lp in data.LOAIPHONGs
                     from nv in data.NHANVIENs
                     where p.MAPHONG == hd.MAPHONG && hd.MAHOADON == cs.MAHOADON
                     && hd.MANV == nv.MANV && p.MATANG == t.MATANG && 
                     lp.MALOAI == p.MALOAI &&hd.THANGNAM.Substring(0,2)==thang
                     select new
                     {
                         hd.MAHOADON,
                         nv.TENNV,
                         t.TENTANG,
                         p.TENPHONG,
                         lp.GIA,
                         hd.WIFI,
                         hd.RAC,
                         cs.SODIEN,
                         cs.SONUOC,
                         hd.TIENDIEN,
                         hd.TIENNUOC,
                         hd.TONGTIEN,
                         hd.TINHTRANG,
                         hd.NGAYLAP,
                         cs.SODIENMOI,
                         cs.SODIENCU,
                         cs.SONUOCCU,
                         cs.SONUOCMOI,
                         hd.THANGNAM,
                         lp.TENLOAI

                     };
            var kq = kt.ToList().ConvertAll(t => new HoaDon()
            {
                MaHD = t.MAHOADON,
                TenNV = t.TENNV,
                TenTang = t.TENTANG,
                TenPhong = t.TENPHONG,
                Wifi = Convert.ToDouble(t.WIFI),
                Rac = Convert.ToDouble(t.RAC),
                SoDien = Convert.ToInt32(t.SODIEN),
                SoNuoc = Convert.ToInt32(t.SONUOC),
                TienDien = Convert.ToDouble(t.TIENDIEN),
                TienNuoc = Convert.ToDouble(t.TIENNUOC),
                TongTien = Convert.ToDouble(t.TONGTIEN),
                NgayLap = Convert.ToDateTime(t.NGAYLAP),
                TinhTrang = Convert.ToBoolean(t.TINHTRANG),
                SoDienCu = Convert.ToInt32(t.SODIENCU),
                SoDienMoi = Convert.ToInt32(t.SODIENMOI),
                SoNuocCu = Convert.ToInt32(t.SONUOCCU),
                SoNuocMoi = Convert.ToInt32(t.SONUOCMOI),
                ThangNam = t.THANGNAM,
                TENLOAI1 = t.TENLOAI,
                TIENPHONG1 = Convert.ToDecimal(t.GIA)

            }); ; ; ;
            kq.ToList<HoaDon>();
            return kq;
        }
        public List<HoaDon> loadHoaDontheonam(string nam)
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.HOADONs
                     from cs in data.CHISO_DIENNUOCs
                     from lp in data.LOAIPHONGs
                     from nv in data.NHANVIENs
                     where p.MAPHONG == hd.MAPHONG && hd.MAHOADON == cs.MAHOADON
                     && hd.MANV == nv.MANV && p.MATANG == t.MATANG &&
                     lp.MALOAI == p.MALOAI && hd.THANGNAM.Substring(hd.THANGNAM.Length - 4, 4) == nam
                     select new
                     {
                         hd.MAHOADON,
                         nv.TENNV,
                         t.TENTANG,
                         p.TENPHONG,
                         hd.WIFI,
                         hd.RAC,
                         cs.SODIEN,
                         cs.SONUOC,
                         hd.TIENDIEN,
                         lp.GIA,
                         hd.TIENNUOC,
                         hd.TONGTIEN,
                         hd.TINHTRANG,
                         hd.NGAYLAP,
                         cs.SODIENMOI,
                         cs.SODIENCU,
                         cs.SONUOCCU,
                         cs.SONUOCMOI,
                         hd.THANGNAM,
                         lp.TENLOAI

                     };
            var kq = kt.ToList().ConvertAll(t => new HoaDon()
            {
                MaHD = t.MAHOADON,
                TenNV = t.TENNV,
                TenTang = t.TENTANG,
                TenPhong = t.TENPHONG,
                Wifi = Convert.ToDouble(t.WIFI),
                Rac = Convert.ToDouble(t.RAC),
                SoDien = Convert.ToInt32(t.SODIEN),
                SoNuoc = Convert.ToInt32(t.SONUOC),
                TienDien = Convert.ToDouble(t.TIENDIEN),
                TienNuoc = Convert.ToDouble(t.TIENNUOC),
                TongTien = Convert.ToDouble(t.TONGTIEN),
                NgayLap = Convert.ToDateTime(t.NGAYLAP),
                TinhTrang = Convert.ToBoolean(t.TINHTRANG),
                SoDienCu = Convert.ToInt32(t.SODIENCU),
                SoDienMoi = Convert.ToInt32(t.SODIENMOI),
                SoNuocCu = Convert.ToInt32(t.SONUOCCU),
                SoNuocMoi = Convert.ToInt32(t.SONUOCMOI),
                ThangNam = t.THANGNAM,
                TENLOAI1 = t.TENLOAI,
                TIENPHONG1 = Convert.ToDecimal(t.GIA)

            }); ; ; ;
            kq.ToList<HoaDon>();
            return kq;
        }
        public List<HoaDon> loadHoaDontheothangnam(string thangnam)
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.HOADONs
                     from cs in data.CHISO_DIENNUOCs
                     from lp in data.LOAIPHONGs
                     from nv in data.NHANVIENs
                     where p.MAPHONG == hd.MAPHONG && hd.MAHOADON == cs.MAHOADON
                     && hd.MANV == nv.MANV && p.MATANG == t.MATANG &&
                     lp.MALOAI == p.MALOAI && hd.THANGNAM == thangnam
                     select new
                     {
                         hd.MAHOADON,
                         nv.TENNV,
                         t.TENTANG,
                         p.TENPHONG,
                         hd.WIFI,
                         hd.RAC,
                         cs.SODIEN,
                         cs.SONUOC,
                         hd.TIENDIEN,
                         hd.TIENNUOC,
                         hd.TONGTIEN,
                         hd.TINHTRANG,
                         hd.NGAYLAP,
                         cs.SODIENMOI,
                         cs.SODIENCU,
                         cs.SONUOCCU,
                         cs.SONUOCMOI,
                         hd.THANGNAM,
                         lp.TENLOAI,
                         lp.GIA,

                     };
            var kq = kt.ToList().ConvertAll(t => new HoaDon()
            {
                MaHD = t.MAHOADON,
                TenNV = t.TENNV,
                TenTang = t.TENTANG,
                TenPhong = t.TENPHONG,
                Wifi = Convert.ToDouble(t.WIFI),
                Rac = Convert.ToDouble(t.RAC),
                SoDien = Convert.ToInt32(t.SODIEN),
                SoNuoc = Convert.ToInt32(t.SONUOC),
                TienDien = Convert.ToDouble(t.TIENDIEN),
                TienNuoc = Convert.ToDouble(t.TIENNUOC),
                TongTien = Convert.ToDouble(t.TONGTIEN),
                NgayLap = Convert.ToDateTime(t.NGAYLAP),
                TinhTrang = Convert.ToBoolean(t.TINHTRANG),
                SoDienCu = Convert.ToInt32(t.SODIENCU),
                SoDienMoi = Convert.ToInt32(t.SODIENMOI),
                SoNuocCu = Convert.ToInt32(t.SONUOCCU),
                SoNuocMoi = Convert.ToInt32(t.SONUOCMOI),
                ThangNam = t.THANGNAM,
                TENLOAI1 = t.TENLOAI,
                TIENPHONG1 = Convert.ToDecimal(t.GIA)

            }); ; ; ;
            kq.ToList<HoaDon>();
            return kq;
        }
        public List<HoaDon> loadHoaDontheoquy(DateTime? tuthang, DateTime? denthang)
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.HOADONs
                     from cs in data.CHISO_DIENNUOCs
                     from lp in data.LOAIPHONGs
                     from nv in data.NHANVIENs
                     where p.MAPHONG == hd.MAPHONG && hd.MAHOADON == cs.MAHOADON
                     && hd.MANV == nv.MANV && p.MATANG == t.MATANG &&
                     lp.MALOAI == p.MALOAI &&  tuthang<= hd.NGAYLAP &&
                    denthang >= hd.NGAYLAP
                     select new
                     {
                         hd.MAHOADON,
                         nv.TENNV,
                         t.TENTANG,
                         p.TENPHONG,
                         hd.WIFI,
                         hd.RAC,
                         cs.SODIEN,
                         cs.SONUOC,
                         hd.TIENDIEN,
                         hd.TIENNUOC,
                         hd.TONGTIEN,
                         hd.TINHTRANG,
                         hd.NGAYLAP,
                         cs.SODIENMOI,
                         cs.SODIENCU,
                         cs.SONUOCCU,
                         cs.SONUOCMOI,
                         hd.THANGNAM,
                         lp.GIA,
                         lp.TENLOAI

                     };
            var kq = kt.ToList().ConvertAll(t => new HoaDon()
            {
                MaHD = t.MAHOADON,
                TenNV = t.TENNV,
                TenTang = t.TENTANG,
                TenPhong = t.TENPHONG,
                Wifi = Convert.ToDouble(t.WIFI),
                Rac = Convert.ToDouble(t.RAC),
                SoDien = Convert.ToInt32(t.SODIEN),
                SoNuoc = Convert.ToInt32(t.SONUOC),
                TienDien = Convert.ToDouble(t.TIENDIEN),
                TienNuoc = Convert.ToDouble(t.TIENNUOC),
                TongTien = Convert.ToDouble(t.TONGTIEN),
                NgayLap = Convert.ToDateTime(t.NGAYLAP),
                TinhTrang = Convert.ToBoolean(t.TINHTRANG),
                SoDienCu = Convert.ToInt32(t.SODIENCU),
                SoDienMoi = Convert.ToInt32(t.SODIENMOI),
                SoNuocCu = Convert.ToInt32(t.SONUOCCU),
                SoNuocMoi = Convert.ToInt32(t.SONUOCMOI),
                ThangNam = t.THANGNAM,
                TENLOAI1 = t.TENLOAI,
                TIENPHONG1 = Convert.ToDecimal(t.GIA)

            }); ; ; ;
            kq.ToList<HoaDon>();
            return kq;
        }
    }
}
