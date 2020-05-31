﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_HopDong
    {
        DAL_HopDong hopdong = new DAL_HopDong();
        public List<HOPDONG> loadBang_HD()
        {
            return hopdong.loadbangHopDong();
        }
        //kiểm tra khóa chính
        public bool ktkc_HopDong(string pMa)
        {
            return hopdong.ktakhoachinh_HopDong(pMa);
        }
        //Thêm
        public bool them_HopDong(HOPDONG pHopDong)
        {
            return hopdong.them_HopDong(pHopDong);
        }
        //ktra xóa
        public bool ktx_hd(String hd)
        {
            return hopdong.kt_XoaHD(hd);
        }
        //Xóa
        public bool xoa_HopDong(string pMa)
        {
            return hopdong.xoa_HopDong(pMa);
        }
        //Sửa
        public bool sua_HopDong(HOPDONG pHopDong)
        {
            return hopdong.sua_HopDong(pHopDong);
        }
    }
}
