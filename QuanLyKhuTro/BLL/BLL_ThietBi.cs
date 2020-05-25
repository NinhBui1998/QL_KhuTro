using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_ThietBi
    {
        DAL_ThietBi thietbi = new DAL_ThietBi();
        public List<THIETBI> loadBang_TB()
        {
            return thietbi.loadbangThietBi();
        }
        //kiểm tra khóa chính
        public bool ktkc_ThietBi(string pMa)
        {
            return thietbi.ktakhoachinh_ThietBi(pMa);
        }
        //Thêm
        public bool them_ThietBi(THIETBI pThietBi)
        {
            return thietbi.them_ThietBi(pThietBi);
        }
        //ktra xóa
        public bool ktx_tb(String tb)
        {
            return thietbi.kt_XoaTB(tb);
        }
        //Xóa
        public bool xoa_ThietBi(string pMa)
        {
            return thietbi.xoa_ThietBi(pMa);
        }
        //Sửa
        public bool sua_ThietBi(THIETBI pThietBi)
        {
            return thietbi.sua_ThietBi(pThietBi);
        }
    }
}
