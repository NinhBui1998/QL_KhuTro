using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public List<KHACHTHUE> loadbangphongcokhachthue()
        {
            var dulieu = (from s in data.KHACHTHUEs 
                          from hd in data.HOPDONGs
                          where s.MAKT==hd.MAKT
                          select s);
            return dulieu.ToList<KHACHTHUE>();
        }
        public List<KHACHTHUE> loadbangKhachThuetheoten(string pmaphong)
        {
            var dulieu =(from s in data.KHACHTHUEs 
                         
                         from p in data.PHONGs
                         where p.MAPHONG==s.MAPHONG 
                         && p.MAPHONG==pmaphong 
                         select s);
            return dulieu.ToList<KHACHTHUE>();
        }
        public KHACHTHUE loadTenKT(string pMa)
        {
            return data.KHACHTHUEs.Where(t => t.MAKT == pMa).FirstOrDefault();
        }
        public string Laytenkt(string pma)
        {
            var kq = (from k in data.KHACHTHUEs
                      where k.MAKT == pma
                      select k.TENKT).FirstOrDefault();
            return kq.ToString();
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
                       from tr in data.THANNHAN_TAMTRUs
                       from tk in data.VIPHAMs
                       where kt.MAKT== tr.MAKT && kt.MAKT == pkt
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
                    kt.TINHTRANGTAMTRU = pkt.TINHTRANGTAMTRU;
                    
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_tinhtrangkt(KHACHTHUE pkt)
        {
            try
            {
                KHACHTHUE kt = data.KHACHTHUEs.Where(t => t.MAKT == pkt.MAKT).FirstOrDefault();
                if (kt != null)
                {

                    kt.TINHTRANGTAMTRU = pkt.TINHTRANGTAMTRU;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_tinhtrangOkhachthue(KHACHTHUE pkt)
        {
            try
            {
                KHACHTHUE kt = data.KHACHTHUEs.Where(t => t.MAKT == pkt.MAKT).FirstOrDefault();
                if (kt != null)
                {

                    kt.TINHTRANG = pkt.TINHTRANG;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool KT_SCMKT(string socm)
        {

            //var kq = (from kc in data.KHACHCOCPHONGs
            //          from kt in data.KHACHTHUEs
            //          from p in data.PHONGs
            //          where kc.MAPHONG == p.MAPHONG && p.MAPHONG == kt.MAPHONG &&
            //              kt.SOCMND == socm || kc.MAPHONG == p.MAPHONG && p.MAPHONG == kt.MAPHONG && kc.SOCMND == socm
            //          select kt).Count();
            var kq = (from kt in data.KHACHTHUEs
                      where kt.SOCMND == socm
                      select kt).Count();
            var kq1 = (from kt in data.KHACHCOCPHONGs
                       where kt.SOCMND == socm
                       select kt).Count();
            var kq2 = (from kt in data.THANNHANs
                       where kt.SOCMNDTN == socm
                       select kt).Count();
            if (kq>0 || kq1>0|| kq2>0)
            {
                return true;
            }    
            else
            {
                return false;
            }    
            
        }
        public bool KT_SODT(string Sodt)
        {

            //var kq = (from kc in data.KHACHCOCPHONGs
            //          from kt in data.KHACHTHUEs
            //          from p in data.PHONGs
            //          where kc.MAPHONG == p.MAPHONG && p.MAPHONG == kt.MAPHONG &&
            //              kt.SOCMND == socm || kc.MAPHONG == p.MAPHONG && p.MAPHONG == kt.MAPHONG && kc.SOCMND == socm
            //          select kt).Count();
            var kq = (from kt in data.KHACHTHUEs
                      where kt.SDT == Sodt
                      select kt).Count();
            var kq1 = (from kt in data.KHACHCOCPHONGs
                      where kt.SODT == Sodt
                      select kt).Count();
            
            if (kq > 0|| kq1>0)
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
