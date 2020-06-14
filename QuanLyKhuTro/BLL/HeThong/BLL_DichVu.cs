using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;

namespace BLL
{
    public class BLL_DichVu
    {
        DAL_DichVu dichvu = new DAL_DichVu();
        
        public List<DICHVU> loadBang_DV()
        {
            return dichvu.loadbangDichVu();
        }
        //kiểm tra khóa chính
        public bool ktkc_DichVu(string pMa)
        {
            return dichvu.ktakhoachinh_DichVu(pMa);
        }
        //Thêm
        public bool them_DichVu(DICHVU pDichVu)
        {
            return dichvu.them_DichVu(pDichVu);
        }
        //ktra xóa
        public bool ktx_dv(String dv)
        {
            return dichvu.kt_XoaDV(dv);
        }
        //Xóa
        public bool xoa_DichVu(string pMa)
        {
            return dichvu.xoa_DichVu(pMa);
        }
        //Sửa
        public bool sua_DichVu(DICHVU pDichVu)
        {
            return dichvu.sua_DichVu(pDichVu);
        }
    }
}
