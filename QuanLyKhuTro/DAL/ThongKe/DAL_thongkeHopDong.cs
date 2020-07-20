using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ThongKe
{
  public  class DAL_thongkeHopDong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<DatPhong> loadhopdong()
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     from kp in data.KHACHTHUEPHONGs
                     where kp.MAKT == kth.MAKT && kp.MAPHONG == p.MAPHONG &&s.MAPHONG==p.MAPHONG && s.MANV == nv.MANV
                            
                     select new
                     {
                         p.MAPHONG,
                         s.MAHD,
                         nv.TENNV,
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         s.NGAYTRA,
                         s.TIENCOC,
                         p.TENPHONG,
                     };
            var kq = kt.ToList().ConvertAll(t => new DatPhong()
            {
                Mahd = t.MAHD,
                Tennv = t.TENNV,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                NgayLap = Convert.ToDateTime(t.NGAYLAPHD),
                NgayTra = Convert.ToDateTime(t.NGAYTRA),
                Tiencoc = Convert.ToDecimal(t.TIENCOC),/* string.Format("{0:#,##0.00}",t.TIENCOC),*/
                TenPhong = t.TENPHONG,
                MAPHONG1 = t.MAPHONG,
            }); ;
            kq.ToList<DatPhong>();
            return kq;
        }
        public List<DatPhong> loadhopdongtheothang(int thang)
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     from kp in data.KHACHTHUEPHONGs
                     where kp.MAKT == kth.MAKT && kp.MAPHONG == p.MAPHONG && s.MAPHONG==p.MAPHONG && s.MANV == nv.MANV
                            && s.NGAYLAPHD.Value.Month==thang
                     select new
                     {
                         p.MAPHONG,
                         s.MAHD,
                         nv.TENNV,
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         s.NGAYTRA,
                         s.TIENCOC,
                         p.TENPHONG,
                     };
            var kq = kt.ToList().ConvertAll(t => new DatPhong()
            {
                Mahd = t.MAHD,
                Tennv = t.TENNV,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                NgayLap = Convert.ToDateTime(t.NGAYLAPHD),
                NgayTra = Convert.ToDateTime(t.NGAYTRA),
                Tiencoc = Convert.ToDecimal(t.TIENCOC),/* string.Format("{0:#,##0.00}",t.TIENCOC),*/
                TenPhong = t.TENPHONG,
                MAPHONG1 = t.MAPHONG,
            }); ;
            kq.ToList<DatPhong>();
            return kq;
        }
        public List<DatPhong> loadhopdongtheonam(int nam)
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     from kp in data.KHACHTHUEPHONGs
                     where kp.MAKT == kth.MAKT && kp.MAPHONG == p.MAPHONG && s.MAPHONG==p.MAPHONG && s.MANV == nv.MANV
                            && s.NGAYLAPHD.Value.Year == nam
                     select new
                     {
                         p.MAPHONG,
                         s.MAHD,
                         nv.TENNV,
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         s.NGAYTRA,
                         s.TIENCOC,
                         p.TENPHONG,
                     };
            var kq = kt.ToList().ConvertAll(t => new DatPhong()
            {
                Mahd = t.MAHD,
                Tennv = t.TENNV,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                NgayLap = Convert.ToDateTime(t.NGAYLAPHD),
                NgayTra = Convert.ToDateTime(t.NGAYTRA),
                Tiencoc = Convert.ToDecimal(t.TIENCOC),/* string.Format("{0:#,##0.00}",t.TIENCOC),*/
                TenPhong = t.TENPHONG,
                MAPHONG1 = t.MAPHONG,
            }); ;
            kq.ToList<DatPhong>();
            return kq;
        }
        public List<DatPhong> loadhopdongtheothangnam(DateTime thangnam)
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     from kp in data.KHACHTHUEPHONGs
                     where kp.MAKT == kth.MAKT && kp.MAPHONG == p.MAPHONG && s.MAPHONG==p.MAPHONG && s.MANV == nv.MANV
                            && s.NGAYLAPHD.Value.Month == thangnam.Month && s.NGAYLAPHD.Value.Year==thangnam.Year
                     select new
                     {
                         p.MAPHONG,
                         s.MAHD,
                         nv.TENNV,
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         s.NGAYTRA,
                         s.TIENCOC,
                         p.TENPHONG,
                     };
            var kq = kt.ToList().ConvertAll(t => new DatPhong()
            {
                Mahd = t.MAHD,
                Tennv = t.TENNV,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                NgayLap = Convert.ToDateTime(t.NGAYLAPHD),
                NgayTra = Convert.ToDateTime(t.NGAYTRA),
                Tiencoc = Convert.ToDecimal(t.TIENCOC),/* string.Format("{0:#,##0.00}",t.TIENCOC),*/
                TenPhong = t.TENPHONG,
                MAPHONG1 = t.MAPHONG,
            }); ;
            kq.ToList<DatPhong>();
            return kq;
        }
        public List<DatPhong> loadhopdongtheoquy(DateTime? tuthang, DateTime? denthang)
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     from kp in data.KHACHTHUEPHONGs
                     where s.MAPHONG==p.MAPHONG && kp.MAKT==kth.MAKT && kp.MAPHONG == p.MAPHONG && s.MANV == nv.MANV
                            && s.NGAYLAPHD>=tuthang && s.NGAYLAPHD<=denthang
                     select new
                     {
                         kp.MAPHONG,
                         s.MAHD,
                         nv.TENNV,
                         kth.MAKT,
                         kth.TENKT,
                         s.NGAYLAPHD,
                         s.NGAYTRA,
                         s.TIENCOC,
                         p.TENPHONG,
                     };
            var kq = kt.ToList().ConvertAll(t => new DatPhong()
            {
                Mahd = t.MAHD,
                Tennv = t.TENNV,
                Makt = t.MAKT,
                Tenkt = t.TENKT,
                NgayLap = Convert.ToDateTime(t.NGAYLAPHD),
                NgayTra = Convert.ToDateTime(t.NGAYTRA),
                Tiencoc = Convert.ToDecimal(t.TIENCOC),/* string.Format("{0:#,##0.00}",t.TIENCOC),*/
                TenPhong = t.TENPHONG,
                MAPHONG1 = t.MAPHONG,
            }); ;
            kq.ToList<DatPhong>();
            return kq;
        }
    }
}
