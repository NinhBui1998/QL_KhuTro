using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_NguoiDung_NhomNguoiDung
    {
        DAL_NguoiDung_NhomNguoiDung ND_nhomND = new DAL_NguoiDung_NhomNguoiDung();
        public List<QLND_NHOMND> loadBang_QLND_NHOMND()
        {
            return ND_nhomND.loadbang_QLND_NHOMND();
        }
        //kiểm tra khóa chính
        public bool ktkc_QLND_NHOMND(string pMa, string ptennd)
        {
            return ND_nhomND.ktakhoachinh_QLND_NHOMND(pMa,ptennd);
        }
        //Thêm
        public bool them_QLND_NHOMND(QLND_NHOMND pQLND_NHOMND)
        {
            return ND_nhomND.them_QLND_NHOMND(pQLND_NHOMND);
        }
        //Xóa
        public bool xoa_QLND_NHOMND(string pMa, string ptendn)
        {
            return ND_nhomND.xoa_QLND_NHOMND(pMa, ptendn);
        }
        //Sửa
        public bool sua_QLND_NHOMND(QLND_NHOMND pQLND_NHOMND)
        {
            return ND_nhomND.sua_QLND_NHOMND(pQLND_NHOMND);
        }
    }
}
