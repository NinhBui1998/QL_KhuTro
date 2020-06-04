using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThietBi
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<THIETBI> loadbangThietBi()
        {
            var dulieu = (from s in data.THIETBIs select s);
            return dulieu.ToList<THIETBI>();
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_ThietBi(string hd)
        {
            var kt = (from h in data.THIETBIs
                      where h.MATHIETBI == hd
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
        public bool them_ThietBi(THIETBI tb)
        {
            try
            {
                data.THIETBIs.InsertOnSubmit(tb);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_ThietBi(string pMaTB)
        {
            try
            {
                THIETBI tb = data.THIETBIs.Where(t => t.MATHIETBI == pMaTB).FirstOrDefault();
                data.THIETBIs.DeleteOnSubmit(tb);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_ThietBi(THIETBI pThietBi)
        {
            try
            {
                THIETBI nv = data.THIETBIs.Where(t => t.MATHIETBI == pThietBi.MATHIETBI).FirstOrDefault();
                if (nv != null)
                {
                    nv.TENTB = pThietBi.TENTB;
                    nv.GIATB = pThietBi.GIATB;
                    nv.SOLUONG_PHANBO = pThietBi.SOLUONG_PHANBO;
                    nv.SOLUONG_HUHONG = pThietBi.SOLUONG_HUHONG;
                    nv.SOLUONG_TONKHO = pThietBi.SOLUONG_TONKHO;
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
        public bool kt_XoaTB(string hd)
        {

            var ktx = (from t in data.THIETBIs
                       from p in data.THIETBI_PHONGs
                       where t.MATHIETBI == hd && p.MATHIETBI == hd
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
