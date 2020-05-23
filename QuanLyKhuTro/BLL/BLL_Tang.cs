using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class BLL_Tang
    {
        DAL_Tang tang = new DAL_Tang();
        public List<TANG> loadBangTang()
        {
            return tang.loadbangTang();
        }
        //kiểm tra khóa chính
        public bool ktkc_Tang(string pMa)
        {
            return tang.ktakhoachinh_Tang(pMa);
        }
        //Thêm
        public bool themTang(TANG pTang)
        {
            return tang.them_Tang(pTang);
        }
        //Xóa
        public bool xoa_Tang(string pMa)
        {
            return tang.xoaTang(pMa);
        }
        //Sửa
        public bool sua_Tang(TANG pTang)
        {
            return tang.suaTang(pTang);
        }

    }
}
