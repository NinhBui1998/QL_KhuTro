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
        public List<PHONG> loadbangPhong()
        {
            var dulieu = (from s in data.PHONGs select s);
            return dulieu.ToList<PHONG>();
        }
        public List<PHONG> loadphongtheoma(string pmatang)
        {
            var dulieu = (from s in data.PHONGs 
                       
                          from t in data.TANGs
                          where s.MATANG==t.MATANG && 
                          t.MATANG==pmatang
                          select s);
            return dulieu.ToList<PHONG>();
        }
        public PHONG loadTenPhong(string pMa)
        {
            return data.PHONGs.Where(t => t.MAPHONG == pMa).FirstOrDefault();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_Phong(string hd)
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
        public bool them_Phong(PHONG p)
        {
            try
            {
                data.PHONGs.InsertOnSubmit(p);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa

        public bool xoa_Phong(string pMaP)
        {
            try
            {
                PHONG p = data.PHONGs.Where(t => t.MAPHONG == pMaP).FirstOrDefault();
                data.PHONGs.DeleteOnSubmit(p);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xóa     
        public bool ktx_phong(string pPhong)
        {
            var ktx = (from nv in data.PHONGs
                       from h in data.HOADONs
                       from tk in data.KHACHTHUEs
                       from tb in data.THIETBI_PHONGs
                       where nv.MAPHONG == h.MAPHONG
                       || nv.MAPHONG == tk.MAPHONG || nv.MAPHONG == tb.MAPHONG && nv.MAPHONG == pPhong
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
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        // sửa số lượng hiện tại
        public bool suaSLHTPhong(PHONG pma)
        {
            try
            {
                PHONG phong = data.PHONGs.Where(t => t.MAPHONG == pma.MAPHONG).FirstOrDefault();
                if (phong != null)
                {

                    phong.TINHTRANG = pma.TINHTRANG;
                    phong.SOLUONG_HT = pma.SOLUONG_HT;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<PHONG> sp(string t)
        {
            var sp = (from s in data.PHONGs where s.MATANG == t select s).ToList<PHONG>();
            return sp;
        }

        public List<TANG> st()
        {
            var sp = (from s in data.TANGs select s).ToList<TANG>();
            return sp;
        }
        public List<PHONG>Laydtphong(string pmat, string pmaloai)
        {
            var sp = (from s in data.PHONGs where s.MATANG == pmat && s.MALOAI==pmaloai select s).ToList<PHONG>();
            return sp;
        }
    }
}
