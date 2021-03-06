﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_Phong
    {
        DAL_Phong phong = new DAL_Phong();
        public List<PHONG> loadBang_Phong()
        {
            return phong.loadbangPhong();
        }

        
        public List<PHONG> loadBang_Phongtheoma( string pmatang)
        {
            return phong.loadphongtheoma( pmatang);
        }

        //public List<PHONG> LoadDL_Phong(string pma)
        //{
        //    //return phong.LoadDL_phong(pma);
        //}
        //kiểm tra khóa chính
        public bool ktkc_Phong(string pMa)
        {
            return phong.ktakhoachinh_Phong(pMa);
        }
        //Thêm
        public bool them_Phong(PHONG pPhong)
        {
            return phong.them_Phong(pPhong);
        }
        //ktra xóa
        public bool ktx_p(String p)
        {
            return phong.ktx_phong(p);
        }
        //Xóa
        public bool xoa_Phong(string pMa)
        {
            return phong.xoa_Phong(pMa);
        }
        //Sửa
        public bool sua_Phong(PHONG pPhong)
        {
            return phong.suaPhong(pPhong);
        }

        public List<PHONG> sphong(string tdal)
        {
            return phong.sp(tdal);
        }
        public List<TANG> stang()
        {
            return phong.st();
        }
        public bool sua_slhientai(PHONG p)
        {
            return phong.suaSLHTPhong(p);
        }
        public bool sua_sl(PHONG p)
        {
            return phong.suaSLH(p);
        }
        public List<PHONG>loadphong(string pmatang, string pmaloai)
        {
            return phong.Laydtphong(pmatang, pmaloai);
        }
    }
}
