using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_NhanVien
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        //lấy tất cả dữ liệu
        public List<NHANVIEN> loadbangNhanvien()
        {
            var dulieu = (from s in data.NHANVIENs select s);
            return dulieu.ToList<NHANVIEN>();
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_NhanVien(string hd)
        {
            var kt = (from h in data.NHANVIENs
                      where h.MANV == hd
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
        public bool them_NhanVien(NHANVIEN nv)
        {
            try
            {
                data.NHANVIENs.InsertOnSubmit(nv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_NhanVien(string pmanv)
        {
            try
            {
                NHANVIEN lp = data.NHANVIENs.Where(t => t.MANV == pmanv).FirstOrDefault();
                data.NHANVIENs.DeleteOnSubmit(lp);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool kt_NhanVien(string pnv)
        {
            var ktx = (from nv in data.NHANVIENs
                       from h in data.HOPDONGs
                       from tr in data.TAMTRUs
                       from tk in data.QUANLYNDs
                       where nv.MANV == h.MANV && nv.MANV == pnv || nv.MANV==tr.MANV && nv.MANV==pnv
                       ||nv.MANV==tk.TENDN && nv.MANV==pnv
                       
                       
                       select nv).Count();
            if (ktx > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool suaNhanVien(NHANVIEN pnv)
        {
            try
            {
                NHANVIEN nv = data.NHANVIENs.Where(t => t.MANV == pnv.MANV).FirstOrDefault();
                if (nv != null)
                {
                    nv.TENNV = pnv.TENNV;
                    nv.CMND_NV = pnv.CMND_NV;
                    nv.SODT_CT = pnv.SODT_CT;
                    nv.DIACHI = pnv.DIACHI;
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
