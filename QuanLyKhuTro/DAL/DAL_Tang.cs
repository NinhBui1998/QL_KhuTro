using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_Tang
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
       
        //lấy tất cả dữ liệu
        public List<TANG> loadbangTang()
        {
            var dulieu = (from s in data.TANGs select s);
            return dulieu.ToList<TANG>();
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_Tang(string hd)
        {
            var kt = (from h in data.TANGs
                      where h.MATANG == hd
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
        public bool them_Tang(TANG tg)
        {
            try
            {
                data.TANGs.InsertOnSubmit(tg);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa

        public bool xoaTang(string pMaTang)
        {
            try
            {
                TANG tg = data.TANGs.Where(t => t.MATANG == pMaTang).FirstOrDefault();
                data.TANGs.DeleteOnSubmit(tg);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool suaTang(TANG pTang)
        {
            try
            {
                TANG nv = data.TANGs.Where(t => t.MATANG == pTang.MATANG).FirstOrDefault();
                if (nv != null)
                {
                    nv.TENTANG = pTang.TENTANG; 
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
