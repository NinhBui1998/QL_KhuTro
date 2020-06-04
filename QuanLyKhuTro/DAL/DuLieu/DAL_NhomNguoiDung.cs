using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhomNguoiDung
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<QLNHOMND> loadbang_QLNHOMND()
        {
            var dulieu = (from s in data.QLNHOMNDs select s);
            return dulieu.ToList<QLNHOMND>();
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_QLNHOMND(string hd)
        {
            var kt = (from h in data.QLNHOMNDs
                      where h.MANHOM == hd
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
        public bool them_QLNHOMND(QLNHOMND nhomND)
        {
            try
            {
                data.QLNHOMNDs.InsertOnSubmit(nhomND);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_QLNHOMND(string pMaNhom)
        {
            try
            {
                QLNHOMND manhom = data.QLNHOMNDs.Where(t => t.MANHOM == pMaNhom).FirstOrDefault();
                data.QLNHOMNDs.DeleteOnSubmit(manhom);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_QLNHOMND(QLNHOMND pQLNHOMND)
        {
            try
            {
                QLNHOMND nhomND = data.QLNHOMNDs.Where(t => t.MANHOM == pQLNHOMND.MANHOM).FirstOrDefault();
                if (nhomND != null)
                {
                    nhomND.TENNHOMND = pQLNHOMND.TENNHOMND;
                    nhomND.GHICHU = pQLNHOMND.GHICHU;            
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
        //public bool kt_XoaQLNHOMND(string hd)
        //{

        //    var ktx = (from t in data.THIETBIs
        //               from p in data.THIETBI_PHONGs
        //               where t.MATHIETBI == hd && p.MATHIETBI == hd
        //               select t).Count();
        //    if (ktx > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }

}
