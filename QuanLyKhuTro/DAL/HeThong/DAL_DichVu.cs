using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DichVu
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<DICHVU> loadbangDichVu()
        {
            var dulieu = (from s in data.DICHVUs select s);
            return dulieu.ToList<DICHVU>();
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_DichVu(string hd)
        {
            var kt = (from h in data.DICHVUs
                      where h.MADV == hd
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
        public bool them_DichVu(DICHVU dv)
        {
            try
            {
                data.DICHVUs.InsertOnSubmit(dv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa

        public bool xoa_DichVu(string pMaDV)
        {
            try
            {
                DICHVU dv = data.DICHVUs.Where(t => t.MADV == pMaDV).FirstOrDefault();
                data.DICHVUs.DeleteOnSubmit(dv);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_DichVu(DICHVU pDichVu)
        {
            try
            {
                DICHVU nv = data.DICHVUs.Where(t => t.MADV == pDichVu.MADV).FirstOrDefault();
                if (nv != null)
                {
                    nv.TENDV = pDichVu.TENDV;
                    nv.GIADV = pDichVu.GIADV;
                    nv.DONVI = pDichVu.DONVI;               
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //kiểm tra tầng có đang được sử dụng
        public bool kt_XoaDV(string hd)
        {

            var ktx = (from t in data.DICHVUs
                       from p in data.HOADON_DICHVUs
                       where t.MADV == hd && p.MADV == hd
                       select t).Count();
            if (ktx > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
