using DAL.Model;
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
                     //from dv in data.DICHVUs
                     //from hddv in data.HOADON_DICHVUs
                     from nv in data.NHANVIENs
                     where  p.MAPHONG == hd.MAPHONG && hd.MAHOADON==cs.MAHOADON
                    /* && hd.MAHOADON==hddv.MAHOADON && hddv.MADV==dv.MADV*/ &&hd.MANV==nv.MANV && p.MATANG == t.MATANG
                     select new
                     {
                         hd.MAHOADON,
                         nv.TENNV,
                         t.TENTANG,
                         p.TENPHONG,
                         cs.SODIEN,
                         cs.SONUOC,
                         hd.TIENDIEN,
                         hd.TIENNUOC,
                         hd.TONGTIEN,
                         hd.NGAYLAP
                     };
            var kq = kt.ToList().ConvertAll(t => new HoaDon()
            {
                MaHD = t.MAHOADON,
                TenNV = t.TENNV,
                TenTang = t.TENTANG,
                TenPhong = t.TENPHONG,            
                SoDien = Convert.ToInt32( t.SODIEN),
                SoNuoc= Convert.ToInt32(t.SONUOC),
                TienDien=Convert.ToDouble(t.TIENDIEN),
                TienNuoc=Convert.ToDouble(t.TIENNUOC),
                TongTien=Convert.ToDouble(t.TONGTIEN),
                NgayLap = Convert.ToDateTime(t.NGAYLAP),
            });
            kq.ToList<HoaDon>();
            return kq;
        }
    }
}
