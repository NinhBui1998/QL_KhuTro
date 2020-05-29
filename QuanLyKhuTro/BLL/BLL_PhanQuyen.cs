using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_PhanQuyen
    {
        public class BLL_NguoiDung_NhomNguoiDung
        {
            DAL_PhanQuyen phanquyen = new DAL_PhanQuyen();
            public List<QLPHANQUYEN> loadBang_QLPHANQUYEN()
            {
                return phanquyen.loadbang_QLPHANQUYEN();
            }
            //kiểm tra khóa chính
            public bool ktkc_QLPHANQUYEN(string pMa, string pmamh)
            {
                return phanquyen.ktakhoachinh_QLPHANQUYEN(pMa,pmamh);
            }
            //Thêm
            public bool them_QLPHANQUYEN(QLPHANQUYEN pQLPHANQUYEN)
            {
                return phanquyen.them_QLPHANQUYEN(pQLPHANQUYEN);
            }
            //Xóa
            public bool xoa_QLPHANQUYEN(string pMa)
            {
                return phanquyen.xoa_QLPHANQUYEN(pMa);
            }
            //Sửa
            public bool sua_QLPHANQUYEN(QLPHANQUYEN pQLPHANQUYEN)
            {
                return phanquyen.sua_QLPHANQUYEN(pQLPHANQUYEN);
            }
        }
    }
}
