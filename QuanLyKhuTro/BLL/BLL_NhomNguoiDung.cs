using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_NhomNguoiDung
    {
        DAL_NhomNguoiDung nhomND = new DAL_NhomNguoiDung();
        public List<QLNHOMND> loadBang_TB()
        {
            return nhomND.loadbang_QLNHOMND();
        }
        //kiểm tra khóa chính
        public bool ktkc_QLNHOMND(string pMa)
        {
            return nhomND.ktakhoachinh_QLNHOMND(pMa);
        }
        //Thêm
        public bool them_QLNHOMND(QLNHOMND pQLNHOMND)
        {
            return nhomND.them_QLNHOMND(pQLNHOMND);
        }
        //Xóa
        public bool xoa_QLNHOMND(string pMa)
        {
            return nhomND.xoa_QLNHOMND(pMa);
        }
        //Sửa
        public bool sua_QLNHOMND(QLNHOMND pQLNHOMND)
        {
            return nhomND.sua_QLNHOMND(pQLNHOMND);
        }
        //ktra xóa
        //public bool ktx_QLNHOMND(String tb)
        //{
        //    return thietbi.kt_XoaTB(tb);
        //}

    }
}
