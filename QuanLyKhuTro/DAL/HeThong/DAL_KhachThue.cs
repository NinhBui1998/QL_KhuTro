using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_KhachThue
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        //lấy tất cả dữ liệu
        public List<KHACHTHUE> loadbangKhachThue()
        {
            var dulieu = (from s in data.KHACHTHUEs select s);
            return dulieu.ToList<KHACHTHUE>();
        }
        public Array layanh(string pma)
        {
            try
            {
                var q3 = data.KHACHTHUEs.Where(c => c.MAKT == pma).Select(c => c.ANH).FirstOrDefault();
                return q3.ToArray();
            }
            catch
            {
                return null;
            }
        }
        public KHACHTHUE loadTenKhachThue(string pMa)
        {
            return data.KHACHTHUEs.Where(t => t.MAKT == pMa).FirstOrDefault();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_KhachThue(string hd)
        {
            var kt = (from h in data.KHACHTHUEs
                      where h.MAKT == hd
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
        public bool them_KhachThue(KHACHTHUE kt)
        {
            try
            {
                data.KHACHTHUEs.InsertOnSubmit(kt);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_KhachThue(string pmakt)
        {
            try
            {
                KHACHTHUE lp = data.KHACHTHUEs.Where(t => t.MAKT == pmakt).FirstOrDefault();
                data.KHACHTHUEs.DeleteOnSubmit(lp);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool kt_KhachThue(string pkt)
        {
            var ktx = (from kt in data.KHACHTHUEs
                       from h in data.HOPDONG_KTs
                       from tr in data.THANNHAN_TAMTRUs
                       from tk in data.VIPHAMs
                       where kt.MAKT == h.MAKT && kt.MAKT == pkt || kt.MAKT== tr.MAKT && kt.MAKT == pkt
                       || kt.MAKT == tk.MAKT && kt.MAKT== pkt


                       select kt).Count();
            if (ktx > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool sua_KhachThue(KHACHTHUE pkt)
        {
            try
            {
                KHACHTHUE kt= data.KHACHTHUEs.Where(t => t.MAKT == pkt.MAKT).FirstOrDefault();
                if (kt != null)
                {
                    kt.TENKT = pkt.TENKT;
                    kt.GIOITINH = pkt.GIOITINH;
                    kt.SDT= pkt.SDT;
                    kt.ANH = pkt.ANH;

                    kt.QUEQUAN = pkt.QUEQUAN;
                    kt.SOCMND = pkt.SOCMND;
                    kt.NGAYSINH = pkt.NGAYSINH;
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
