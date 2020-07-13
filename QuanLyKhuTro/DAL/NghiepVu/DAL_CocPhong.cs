using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
   public class DAL_CocPhong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<KHACHCOCPHONG> loadkhachcocphong()
        {
            var dulieu = (from s in data.KHACHCOCPHONGs select s);
            return dulieu.ToList<KHACHCOCPHONG>();
        }

        public KHACHCOCPHONG loadkhcocphong(string pma)
        {
            return data.KHACHCOCPHONGs.Where(t =>t.MAPHONG==pma).FirstOrDefault();
        }
        public bool kt_phongcococ(string pmaphong)
        {
            var kq = (from kc in data.KHACHCOCPHONGs
                      where kc.MAPHONG == pmaphong
                      select kc).Count();
            if (kq > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
               

        }
        //kiểm tra khóa chính
        public bool ktkc_khachcoc(string hd)
        {
            var kt = (from h in data.KHACHCOCPHONGs
                      where h.MAKHCP == hd
                      select h).Count();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Thêm
        public bool them_khachcoc(KHACHCOCPHONG hd)
        {
            try
            {
                data.KHACHCOCPHONGs.InsertOnSubmit(hd);
            data.SubmitChanges();
            return true;
            }
            catch
            {
                return false;
            }
        }

        //Xóa
        public bool xoa_khachcoc(string pMaHD)
        {
            try
            {
                KHACHCOCPHONG hd = data.KHACHCOCPHONGs.Where(t => t.MAKHCP == pMaHD).FirstOrDefault();
                data.KHACHCOCPHONGs.DeleteOnSubmit(hd);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_khaccoc(KHACHCOCPHONG pHopDong)
        {
            try
            {
                KHACHCOCPHONG hd = data.KHACHCOCPHONGs.Where(t => t.MAKHCP == pHopDong.MAKHCP).FirstOrDefault();
                if (hd != null)
                {
                    hd.TEN = pHopDong.TEN;
                    hd.SOCMND = pHopDong.SOCMND;
                    hd.SODT = pHopDong.SODT;
                    hd.GIOITINHKC = pHopDong.GIOITINHKC;
                    hd.QUEQUAN = pHopDong.GIOITINHKC;
                    hd.TIENCOCPHONG = pHopDong.TIENCOCPHONG;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool KTSDT(string sdt)
        {
           
            var kq = (from kc in data.KHACHCOCPHONGs
                          where kc.SODT == sdt
                          select kc.SODT).Count();
            var kq1=(from kc in data.KHACHTHUEs
                    where kc.SDT == sdt
                    select kc.SDT).Count();
            if (kq>0 || kq1>0)
            {
                return true;
            }    
            else
            {
                return false;
            }      
        }
        public bool KTSCM(string scm)
        {

            var kq = (from kc in data.KHACHCOCPHONGs
                      where kc.SOCMND == scm
                      select kc.SOCMND).Count();
            var kq1 = (from kc in data.KHACHTHUEs
                       where kc.SOCMND == scm
                       select kc.SOCMND).Count();
            if (kq > 0 || kq1 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        public List<Cocphong> loadcocphong()
        {
            var kt = from p in data.PHONGs
                     from kc in data.KHACHCOCPHONGs
                     where p.MAPHONG == kc.MAPHONG
                     select new
                     {
                         kc.MAKHCP,
                         kc.TEN,
                         p.TENPHONG,
                         kc.GIOITINHKC,
                         kc.NGAYCOC,
                         kc.SODT,
                         kc.SOCMND,
                         kc.TIENCOCPHONG,
                         kc.QUEQUAN

                         
                     };
            var kq = kt.ToList().ConvertAll(t => new Cocphong()
            {
               MAKHCP1=t.MAKHCP,
               TEN1=t.TEN,
               TENPHONG1=t.TENPHONG,
               GIOITINHKC1=t.GIOITINHKC,
               NGAYCOC1=Convert.ToDateTime(t.NGAYCOC),
               SODT1=t.SODT,
               SOCMND1=t.SOCMND,
               TIENCOCPHONG1= t.TIENCOCPHONG.ToString(),
               QUEQUAN1=t.QUEQUAN
               
            }); ;
            kq.ToList<Cocphong>();
            return kq;
        }

        public List<Cocphong> loadcocphongtheoma(string pma)
        {
            var kt = from p in data.PHONGs
                     from kc in data.KHACHCOCPHONGs
                     where p.MAPHONG == kc.MAPHONG && p.MAPHONG==pma
                     select new
                     {
                         kc.MAKHCP,
                         kc.TEN,
                         p.TENPHONG,
                         kc.GIOITINHKC,
                         kc.NGAYCOC,
                         kc.SODT,
                         kc.SOCMND,
                         kc.TIENCOCPHONG,
                         kc.QUEQUAN


                     };
            var kq = kt.ToList().ConvertAll(t => new Cocphong()
            {
                MAKHCP1 = t.MAKHCP,
                TEN1 = t.TEN,
                TENPHONG1 = t.TENPHONG,
                GIOITINHKC1 = t.GIOITINHKC,
                NGAYCOC1 = Convert.ToDateTime(t.NGAYCOC),
                SODT1 = t.SODT,
                SOCMND1 = t.SOCMND,
                TIENCOCPHONG1 = t.TIENCOCPHONG.ToString(),
                QUEQUAN1 = t.QUEQUAN

            }); ;
            kq.ToList<Cocphong>();
            return kq;
        }
    }
}
