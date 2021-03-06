﻿using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
    public class DAL_TienPhongHangThang
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<HoaDon> loadHoaDon()
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.HOADONs
                     from cs in data.CHISO_DIENNUOCs
                     from lp in data.LOAIPHONGs
                     from nv in data.NHANVIENs
                     where p.MAPHONG == hd.MAPHONG && hd.MAHOADON == cs.MAHOADON
                     && hd.MANV == nv.MANV && p.MATANG == t.MATANG && lp.MALOAI==p.MALOAI
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
                SoDienCu=Convert.ToInt32(t.SODIENCU),
                SoDienMoi = Convert.ToInt32(t.SODIENMOI),
                SoNuocCu = Convert.ToInt32(t.SONUOCCU),
                SoNuocMoi = Convert.ToInt32(t.SONUOCMOI),
                TIENPHONG1=Convert.ToDecimal(t.GIA),
                ThangNam=Convert.ToDateTime( t.THANGNAM),
                TENLOAI1=t.TENLOAI,

            });;; ;
            kq.ToList<HoaDon>();
            return kq;
        }
        public List<HoaDon> loadHoaDontheophong(string pmaphong)
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.HOADONs
                     from cs in data.CHISO_DIENNUOCs
                     from lp in data.LOAIPHONGs
                     from nv in data.NHANVIENs
                     where lp.MALOAI==p.MALOAI && p.MAPHONG == hd.MAPHONG && hd.MAHOADON == cs.MAHOADON
                     && hd.MANV == nv.MANV && p.MATANG == t.MATANG && hd.MAPHONG == pmaphong
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
                ThangNam =Convert.ToDateTime( t.THANGNAM),
                TIENPHONG1=Convert.ToDecimal(t.GIA)

            }); ;
            kq.ToList<HoaDon>();
            return kq;
        }
        public List<HoaDon> loadHoaDontheongay(string ngay)
        {
            var kt = from p in data.PHONGs
                     from t in data.TANGs
                     from hd in data.HOADONs
                     from cs in data.CHISO_DIENNUOCs

                     from nv in data.NHANVIENs
                     where p.MAPHONG == hd.MAPHONG && hd.MAHOADON == cs.MAHOADON
                     && hd.MANV == nv.MANV && p.MATANG == t.MATANG && 
                     (hd.NGAYLAP.Value.Day.ToString() == ngay || hd.NGAYLAP.Value.Month.ToString() == ngay
                   || hd.NGAYLAP.Value.Year.ToString() == ngay)
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
                         hd.THANGNAM
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
                ThangNam = Convert.ToDateTime( t.THANGNAM),

            }); ;
            kq.ToList<HoaDon>();
            return kq;
        }
    }

}
