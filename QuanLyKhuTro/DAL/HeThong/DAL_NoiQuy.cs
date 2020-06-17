using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NoiQuy
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<NOIQUY> loadbangNoiQuy()
        {
            var dulieu = (from s in data.NOIQUYs select s);
            return dulieu.ToList<NOIQUY>();
        }
        public NOIQUY loadNoiDung(string pMa)
        {
            return data.NOIQUYs.Where(t => t.MANOIQUY == pMa).FirstOrDefault();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_NoiQuy(string hd)
        {
            var kt = (from h in data.NOIQUYs
                      where h.MANOIQUY == hd
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
        public bool them_NoiQuy(NOIQUY nq)
        {
            try
            {
                data.NOIQUYs.InsertOnSubmit(nq);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_NoiQuy(string pMaNQ)
        {
            try
            {
                NOIQUY nq = data.NOIQUYs.Where(t => t.MANOIQUY== pMaNQ).FirstOrDefault();
                data.NOIQUYs.DeleteOnSubmit(nq);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_NoiQuy(NOIQUY pNoiQuy)
        {
            try
            {
                NOIQUY nq = data.NOIQUYs.Where(t => t.MANOIQUY == pNoiQuy.MANOIQUY).FirstOrDefault();
                if (nq != null)
                {
                    nq.NOIDUNG = pNoiQuy.NOIDUNG;
                    nq.HINHPHAT = pNoiQuy.HINHPHAT;
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
        public bool kt_XoaNQ(string hd)
        {

            var ktx = (from t in data.NOIQUYs
                       from p in data.VIPHAMs
                       where t.MANOIQUY == hd && p.MANOIQUY== hd
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
