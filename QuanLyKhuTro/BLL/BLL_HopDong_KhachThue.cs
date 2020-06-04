using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_HopDong_KhachThue
    {
        DAL_HopDong_KhachThue hopdong_khachthue = new DAL_HopDong_KhachThue();
        //Thêm
        public bool them_HopDong_KhachThue(HOPDONG_KT phd_kt)
        {
            return hopdong_khachthue.them_HopDong_KhachThue(phd_kt);
        }
        //Xóa
        public bool xoa_HopDong_KhachThue(string pMaHD, string pMaKT)
        {
            return hopdong_khachthue.xoa_HopDong_KhachThue(pMaHD, pMaKT);
        }
        //Sửa
        public bool sua_HopDong_KhachThue(HOPDONG_KT phd_kt)
        {
            return hopdong_khachthue.sua_HopDong_KhachThue(phd_kt);
        }
    }
}
