using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu
{
  public  class DAL_TamTru
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<tamtru> loadtamtru()
        {
            var kt = from s in data.TAMTRUs
                     from kth in data.KHACHTHUEs
                     from p in data.PHONGs
                     from nv in data.NHANVIENs
                     where s.MAKT == kth.MAKT && kth.MAPHONG == p.MAPHONG && s.MANV == nv.MANV
                     select new
                     {
                         s. MAKT,
                         kth. TENKT,
                         nv. MANV,
                         nv. TENNV,
                         p. TENPHONG,
                         s. NGAYLAMGIAY,
                         s. NGAYHETHAN_TAMTRU,
                         s. MATAMTRU,
                         s. QUANHEVOICHUTRO

        };
            var kq = kt.ToList().ConvertAll(t => new tamtru()
            {
                MAKT1=t.MAKT,
                TENKT1=t.TENKT,
                MANV1=t.MANV,
                TENNV1=t.TENNV,
                TENPHONG1=t.TENPHONG,
                NGAYLAMGIAY1=Convert.ToDateTime(t.NGAYLAMGIAY),
                NGAYHETHAN1=Convert.ToDateTime(t.NGAYHETHAN_TAMTRU),
                MATT1=t.MATAMTRU,
                QUANHEVOICHUTRO1=t.QUANHEVOICHUTRO,

            }); ;
            kq.ToList<tamtru>();
            return kq;
        }
        public bool ktakhoachinh_tamtru(string hd)
        {
            var kt = (from h in data.TAMTRUs
                      where h.MATAMTRU == hd
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
        public bool them_tamtru(TAMTRU tt)
        {
            //try
            //{
            data.TAMTRUs.InsertOnSubmit(tt);
            data.SubmitChanges();
            return true;
            //}
            //catch
            //{
            //    return false;
            //}

        }

        //Xóa
        public bool xoa_tamtru(string pMaHD)
        {
            try
            {
                TAMTRU hd = data.TAMTRUs.Where(t => t.MATAMTRU == pMaHD).FirstOrDefault();
                data.TAMTRUs.DeleteOnSubmit(hd);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_Tamtru(TAMTRU ptamtru)
        {
            try
            {
                TAMTRU hd = data.TAMTRUs.Where(t => t.MATAMTRU == ptamtru.MATAMTRU).FirstOrDefault();
                if (hd != null)
                {
                    hd.NGAYHETHAN_TAMTRU = ptamtru.NGAYHETHAN_TAMTRU;

                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
