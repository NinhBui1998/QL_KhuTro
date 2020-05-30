using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public  class BLL_Quanlynguoidung
    {
        DAL_Nguoidung nd = new DAL_Nguoidung();
        public List<QUANLYND> loadnd()
        {
            return nd.loadbang_QLND();
        }
        public bool xoand(string pMa)
        {
            return nd.xoa_QLND(pMa);
        }
        //Sửa
        public bool sua_ND(QUANLYND pnd)
        {
            return nd.sua_QLND(pnd);
        }
        public bool them_nguoidung(QUANLYND pnd)
        {
            return nd.them_nguoidung(pnd);
        }
    }
}
