using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ThongKe
{
   public class DAL_ThongKeKhachThue
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
      
        public string tongkt()
        {
            var dulieu = (from k in data.KHACHTHUEs
                          select k).Count();
            return dulieu.ToString();
        }
        public string tongkhachthuetheophong(string mphong)
        {
            var kq= (from k in data.KHACHTHUEs
                     from kp in data.KHACHTHUEPHONGs
                     where kp.MAKT==k.MAKT && kp.MAPHONG==mphong
                     select k).Count();
            return kq.ToString();
        }
        public List<KHACHTHUE> loadbangKhachThuechuadktamtru()
        {
            var dulieu = (from s in data.KHACHTHUEs where s.TINHTRANGTAMTRU== "chưa đăng ký" select s);
            return dulieu.ToList<KHACHTHUE>();
        }
        public List<KHACHTHUE> loadbangKhachsaphethantt()
        {
            var dulieu = (from s in data.KHACHTHUEs where s.TINHTRANGTAMTRU == "Sắp hết hạn đăng ký" select s);
            return dulieu.ToList<KHACHTHUE>();
        }
        //public List<Thongkekhach> loadthongkechuatamtru()
        //{
        //    var kt = from tt in data.TAMTRUs
        //             from k in data.KHACHTHUEs
        //             from p in data.PHONGs
        //             from nv in data.NHANVIENs
        //             where tt.MAKT == k.MAKT && p.MAPHONG == k.MAPHONG && tt.MANV == nv.MANV && k.TINHTRANGTAMTRU== "chưa đăng ký"
        //             select new
        //             {

        //                 k.MAKT,
        //                 k.TENKT,
        //                 tt.MANV,
        //                 nv.TENNV,
        //                 p.TENPHONG,
        //                 tt.NGAYLAMGIAY,
        //                 tt.NGAYHETHAN_TAMTRU,
        //                 k.TINHTRANGTAMTRU,
        //                 tt.QUANHEVOICHUTRO

        //             };
        //    var kq = kt.ToList().ConvertAll(t => new Thongkekhach()
        //    {
        //        MAKT1 = t.MAKT,
        //        TENKT1=t.TENKT,
        //        MANV1=t.MANV,
        //        TENNV1=t.TENNV,
        //        TENPHONG1=t.TENPHONG,
        //        NGAYLAMGIAY1=Convert.ToDateTime(t.NGAYLAMGIAY),
        //        NGAYHETHANG1=Convert.ToDateTime(t.NGAYHETHAN_TAMTRU),
        //        TINHTRANG1=t.TINHTRANGTAMTRU,
        //        QUANHECHUTRO1=t.QUANHEVOICHUTRO

        //    });
        //    kq.ToList<Thongkekhach>();
        //    return kq;
        //}
        //public List<Thongkekhach> loadthongkesaptoihandk()
        //{
        //    var kt = from p in data.PHONGs
        //             from k in data.KHACHTHUEs
        //             from tt in data.TAMTRUs
        //             from nv in data.NHANVIENs
        //             where p.MAPHONG == k.MAPHONG && k.MAKT == tt.MAKT &&
        //             tt.MANV == nv.MANV && k.TINHTRANGTAMTRU == "Sắp hết hạn đăng ký"
        //             select new
        //             {
        //                 tt.MATAMTRU,
        //                 k.MAKT,
        //                 k.TENKT,
        //                 tt.MANV,
        //                 nv.TENNV,
        //                 p.TENPHONG,
        //                 tt.NGAYLAMGIAY,
        //                 tt.NGAYHETHAN_TAMTRU,
        //                 k.TINHTRANGTAMTRU,
        //                 tt.QUANHEVOICHUTRO,


        //             };
        //    var kq = kt.ToList().ConvertAll(t => new Thongkekhach()
        //    {
        //        MATT1 = t.MATAMTRU,
        //        MAKT1 = t.MAKT,
        //        TENKT1 = t.TENKT,
        //        MANV1 = t.MANV,
        //        TENNV1 = t.TENNV,
        //        TENPHONG1 = t.TENPHONG,
        //        NGAYLAMGIAY1 = Convert.ToDateTime(t.NGAYLAMGIAY),
        //        NGAYHETHANG1 = Convert.ToDateTime(t.NGAYHETHAN_TAMTRU),
        //        TINHTRANG1 = t.TINHTRANGTAMTRU,
        //        QUANHECHUTRO1 = t.QUANHEVOICHUTRO,


        //    });
        //    kq.ToList<Thongkekhach>();
        //    return kq;
        //}
    }
}
