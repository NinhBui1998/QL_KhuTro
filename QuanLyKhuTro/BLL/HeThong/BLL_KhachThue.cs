using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_KhachThue
    {
        DAL_KhachThue dkt = new DAL_KhachThue();
        public List<KHACHTHUE> loadBangKT()
        {
            return dkt.loadbangKhachThue();
        }
        public List<KHACHTHUE> loadphongcokhach()
        {
            return dkt.loadbangphongcokhachthue();
        }
        public KHACHTHUE layttkt(string pma)
        {
            return dkt.loadTenKT(pma);
        }
        public List<KHACHTHUE> loadBangKTtheoma(string pmaphong)
        {
            return dkt.loadbangKhachThuetheoten(pmaphong );
        }
        public string Laytenkt (string pmakt)
        {
            return dkt.Laytenkt(pmakt);
        }
        //kiểm tra khóa chính
        public bool ktkc_khachthue(string pMa)
        {
            return dkt.ktakhoachinh_KhachThue(pMa);
        }
        //Thêm
        public bool ThemKT(KHACHTHUE pkt)
        {
            return dkt.them_KhachThue(pkt);
        }
        //ktra xóa
        public bool ktx_khachthue(String t)
        {
            return dkt.kt_KhachThue(t);
        }
        //Xóa
        public bool xoa_KhachThue(string pMa)
        {
            return dkt.xoa_KhachThue(pMa);
        }
        //Sửa
        public bool sua_khachthue(KHACHTHUE pkt)
        {
            return dkt.sua_KhachThue(pkt);
        }
        public bool sua_tinhtrangkt(KHACHTHUE pkt)
        {
            return dkt.sua_tinhtrangkt(pkt);
        }

        public bool sua_tinhtrangOKhachthue(KHACHTHUE pkt)
        {
            return dkt.sua_tinhtrangOkhachthue(pkt);
        }
        public Array layanh(string pma)
        {
            try
            {
                return dkt.layanh(pma);
            }
            catch
            {
                return null;
            }
            
        }
        public bool kt_Socm(string scm)
        {
            return dkt.KT_SCMKT(scm);
        }
        public bool kt_SoDT(string sdt)
        {
            return dkt.KT_SODT(sdt);
        }
    }
}
