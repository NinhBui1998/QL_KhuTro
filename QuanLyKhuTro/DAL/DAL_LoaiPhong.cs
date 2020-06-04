using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class DAL_LoaiPhong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<LOAIPHONG> loadbangLoaiPhong()
        {
            var dulieu = (from s in data.LOAIPHONGs select s);
            return dulieu.ToList<LOAIPHONG>();
        }
        public LOAIPHONG loadTenLoaiPhong(string pMa)
        {
            return data.LOAIPHONGs.Where(t => t.MALOAI == pMa).FirstOrDefault();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_LoaiPhong(string hd)
        {
            var kt = (from h in data.LOAIPHONGs
                      where h.MALOAI == hd
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
        public bool them_LoaiPhong(LOAIPHONG lp)
        {
            try
            {
                data.LOAIPHONGs.InsertOnSubmit(lp);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        //Xóa
        public bool xoa_LoaiPhong(string pMaLoai)
        {
            try
            {
                LOAIPHONG lp = data.LOAIPHONGs.Where(t => t.MALOAI == pMaLoai).FirstOrDefault();
                data.LOAIPHONGs.DeleteOnSubmit(lp);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool kt_XoaLoaiPhong(string hd)
        {

            var ktx = (from t in data.LOAIPHONGs
                       from p in data.PHONGs
                       where t.MALOAI == hd && p.MALOAI == t.MALOAI
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

        public bool suaLoaiPhong(LOAIPHONG pLoaiPhong)
        {
            try
            {
                LOAIPHONG nv = data.LOAIPHONGs.Where(t => t.MALOAI == pLoaiPhong.MALOAI).FirstOrDefault();
                if (nv != null)
                {
                    nv.TENLOAI = pLoaiPhong.TENLOAI;
                    nv.GIA = pLoaiPhong.GIA;
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
