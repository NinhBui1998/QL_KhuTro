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
        public string laytenthietbi(string pma)
        {
            return thietbi.laytentb(pma);
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

        public List<THIETBI_PHONG> loadBang_TBPhong()
        {
            return thietbi.loadbangThietBiPhong();
        }
        //kiểm tra khóa chính
        public bool ktkc_ThietBiphong(string pMa, string pmaphong)
        {
            return thietbi.ktakhoachinh_ThietBiphong(pMa,pmaphong);
        }
        //Thêm
        public bool them_ThietBiphong(THIETBI_PHONG pThietBi)
        {
            return thietbi.them_ThietBiphong(pThietBi);
        }
        //ktra xóa
     
        //Xóa
        public bool xoa_ThietBiphong(string pMa, string pmaphong)
        {
            return thietbi.xoa_ThietBiphong(pMa,pmaphong);
        }
        //Sửa
        public bool sua_ThietBiphong(THIETBI_PHONG pThietBi)
        {
            return thietbi.sua_ThietBiphong(pThietBi);
        }

    }
}
