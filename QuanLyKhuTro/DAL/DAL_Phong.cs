using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Phong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        //lấy tất cả dữ liệu
        public List<PHONG> loadBangPhong()
        {
            var dulieu = (from s in data.PHONGs select s);
            return dulieu.ToList<PHONG>();
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_phong(string hd)
        {
            var kt = (from h in data.PHONGs
                      where h.MAPHONG == hd
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
        public bool them_phong(PHONG phong)
        {
            try
            {
                data.PHONGs.InsertOnSubmit(phong);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_phong(string pmap)
        {
            try
            {
                PHONG lp = data.PHONGs.Where(t => t.MAPHONG == pmap).FirstOrDefault();
                data.PHONGs.DeleteOnSubmit(lp);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ktx_phong(string pPhong)
        {
            var ktx = (from nv in data.PHONGs
                       from h in data.HOADONs
                       from tr in data.DICHVU_PHONGs
                       from tk in data.HOPDONGs
                       from tb in data.THIETBI_PHONGs
                       where nv.MAPHONG == h.MAPHONG || nv.MAPHONG == tr.MAPHONG
                       || nv.MAPHONG == tk.MAPHONG|| nv.MAPHONG==tb.MAPHONG && nv.MAPHONG == pPhong
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

        public bool suaPhong(PHONG phong)
        {
            try
            {
                PHONG p = data.PHONGs.Where(t => t.MAPHONG == phong.MAPHONG).FirstOrDefault();
                if (p != null)
                {
                    p.TENPHONG = phong.TENPHONG;
                    p.TINHTRANG = phong.TINHTRANG;
                    p.SOLUONG_HT = phong.SOLUONG_HT;
                    p.SOLUONG_TD = phong.SOLUONG_TD;
                    p.MATANG = phong.MATANG;
                    p.MALOAI = phong.MALOAI;
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
}
