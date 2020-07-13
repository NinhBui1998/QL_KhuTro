using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DAL_DatPhong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<DatPhong> loaddatphong()
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     where s.MAKT == kth.MAKT && kth.MAPHONG == p.MAPHONG && s.MANV == nv.MANV
                     select new
                     {
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
            }); ;
            kq.ToList<DatPhong>();
            return kq;
        }

        public List<DatPhong> loaddatPhongtheoMa(string pten)
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     where s.MAKT == kth.MAKT && kth.MAPHONG == p.MAPHONG && s.MANV == nv.MANV
                            && p.TENPHONG == pten && s.TINHTRANG == true
                     select new
                     {
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
            }); ;
            kq.ToList<DatPhong>();
            return kq;
        }
        public List<PHONG> laytenphong(string pmatang, string pmaloai)
        {
            var l = (from p in data.PHONGs
                     from lp in data.LOAIPHONGs
                     from t in data.TANGs
                     where p.MALOAI == lp.MALOAI && p.MATANG == t.MATANG && p.MALOAI == pmaloai
                     && t.MATANG == pmatang
                     select p);
            return l.ToList<PHONG>();
        }
        //lấy mã phòng theo tên phòng
        public String Laymaphong(string ten)
        {
            var kq = (from p in data.PHONGs
                      where p.TENPHONG == ten
                      select p.MAPHONG).FirstOrDefault();

            return kq.ToString();
        }
        public String Laytenphongtheoma(string ma)
        {
            var kq = (from p in data.PHONGs
                      where p.MAPHONG == ma
                      select p.TENPHONG).FirstOrDefault();

            return kq.ToString();
        }

        public string LaySLHTPhong(string pMa)
        {
            var kq = (from p in data.PHONGs
                      where p.MAPHONG == pMa
                      select p.SOLUONG_HT).FirstOrDefault();
            return kq.ToString();
        }
        //public string LaySLTDhong(string pMa)
        //{
        //    var kq = (from p in data.PHONGs
        //              where p.MAPHONG == pMa
        //              select p.SOLUONG_TD).FirstOrDefault();
        //    return kq.ToString();
        //}
        public int demhopdong(string pmaphong)
        {
            var kq = (from hd in data.KHACHTHUEs
                      where hd.MAPHONG == pmaphong && hd.TINHTRANG==true
                      select hd).Count();
            return kq;
        }
        public string laysoLuongtd(string pmaphong)
        {
            var kq = (from p in data.PHONGs
                      where p.MAPHONG == pmaphong
                      select p.SOLUONG_TD).FirstOrDefault();
            return kq.ToString();
        }
        public string laymakt(string pmahd)
        {
            var kq = (from hd in data.HOPDONGs
                      where hd.MAHD == pmahd
                      select hd.MAKT).FirstOrDefault();
            return kq.ToString();
        }
        //public List<PHONG> laytenphong(string pmatang, string pmaloai)
        //{
        //    var l = (from p in data.PHONGs
        //             from lp in data.LOAIPHONGs
        //             from t in data.TANGs
        //             where p.MALOAI == lp.MALOAI && p.MATANG == t.MATANG && p.MALOAI == pmaloai
        //             && t.MATANG == pmatang
        //             select p);
        //    return l.ToList<PHONG>();
        //}
        public List<DatPhong> loaddatPhongtheongay(string ngay)
        {
            var kt = from s in data.HOPDONGs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     where s.MAKT == kth.MAKT && kth.MAPHONG == p.MAPHONG && s.MANV == nv.MANV && 
                   (  s.NGAYLAPHD.Value.Day.ToString() == ngay || s.NGAYLAPHD.Value.Month.ToString() == ngay
                   || s.NGAYLAPHD.Value.Year.ToString() == ngay)
                     select new
                     {
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
            }); ;
            kq.ToList<DatPhong>();
            return kq;
        }
 
        
    }
}
