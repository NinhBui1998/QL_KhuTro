using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
   public class DAL_DSPhong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<DanhsachPhong> loaddsPhong()
        {
            var kt = from s in data.TANGs
                     from l in data.LOAIPHONGs
                     from p in data.PHONGs
                     where s.MATANG == p.MATANG && p.MALOAI == l.MALOAI
                     select new
                     {
                         s.TENTANG,
                         l.TENLOAI,
                         l.GIA,
                         p.TENPHONG,
                         p.SOLUONG_HT,
                         p.SOLUONG_TD,
                     };
            var kq = kt.ToList().ConvertAll(t => new DanhsachPhong()
            {
                TenTang=t.TENTANG,
                TenLoai=t.TENLOAI,
                TenPhong=t.TENPHONG,
                SoLuong_HT=Convert.ToInt32(t.SOLUONG_HT),
                SoLuong_TD=Convert.ToInt32(t.SOLUONG_TD),
                Gia=Convert.ToDouble(t.GIA),
            });
            kq.ToList<DanhsachPhong>();
            return kq;
        }

        public List<DanhsachPhong> loaddsPhong_theoMa(string pmatang,string pmaloai)
        {
            var kt = from s in data.TANGs
                     from l in data.LOAIPHONGs
                     from p in data.PHONGs
                     where s.MATANG == p.MATANG && p.MALOAI == l.MALOAI && p.MATANG==pmatang
                     && p.MALOAI==pmaloai
                     select new
                     {
                         s.TENTANG,
                         l.TENLOAI,
                         l.GIA,
                         p.TENPHONG,
                         p.SOLUONG_HT,
                         p.SOLUONG_TD,
                     };
            var kq = kt.ToList().ConvertAll(t => new DanhsachPhong()
            {
                TenTang = t.TENTANG,
                TenLoai = t.TENLOAI,
                TenPhong = t.TENPHONG,
                SoLuong_HT = Convert.ToInt32(t.SOLUONG_HT),
                SoLuong_TD = Convert.ToInt32(t.SOLUONG_TD),
                Gia = Convert.ToDouble(t.GIA),
            });
            kq.ToList<DanhsachPhong>();
            return kq;
        }
    }
}
