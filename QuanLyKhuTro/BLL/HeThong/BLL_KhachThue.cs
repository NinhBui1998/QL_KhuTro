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

        public List<KHACHTHUE> loadBangKTtheoma(string pmaphong)
        {
            return dkt.loadbangKhachThuetheoten(pmaphong );
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
    }
}
