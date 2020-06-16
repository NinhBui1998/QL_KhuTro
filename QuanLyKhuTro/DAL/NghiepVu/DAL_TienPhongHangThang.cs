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
        //public List<HoaDon> loadTienPhong()
        //{
        //    var kt = from p in data.PHONGs
        //             from t in data.TANGs
        //             from hd in data.HOADONs
        //             from cs in data.CHISO_DIENNUOCs
        //             from dv in data.DICHVUs
        //             from hddv in data.HOADON_DICHVUs
        //             from nv in data.NHANVIENs
        //             where p.MATANG==t.MATANG && p.MAPHONG==hd.MAPHONG 
        //             select new
        //             {
        //                 //s.MAHD,
        //                 //s.MANV,
        //                 //kth.MAKT,
        //                 //kth.TENKT,
        //                 //s.NGAYLAPHD,
        //                 //s.THOIHAN,
        //                 //s.TIENCOC,
        //                 //p.TENPHONG,
        //             };
            //var kq = kt.ToList().ConvertAll(t => new DatPhong()
            //{
            //    //Mahd = t.MAHD,
            //    //Manv = t.MANV,
            //    //Makt = t.MAKT,
            //    //Tenkt = t.TENKT,
            //    //NgayLap = Convert.ToDateTime(t.NGAYLAPHD),
            //    //Thoihan = t.THOIHAN,
            //    //Tiencoc = Convert.ToDouble(t.TIENCOC),
            //    //TenPhong = t.TENPHONG,
            //});
            ////kq.ToList<DatPhong>();
            //return kq;
        //}
    }
}
