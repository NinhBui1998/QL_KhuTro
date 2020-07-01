using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
using DAL.NghiepVu;

namespace BLL.NghiepVu
{
   public class BLL_tamtru
    {
        DAL_TamTru tt = new DAL_TamTru();
        public List<tamtru> Loadtamtru()
        {
            return tt.loadtamtru();
        }
        public List<tamtru> Loadtamtrukt(string pmakt)
        {
            return tt.loadtamtrukt(pmakt);
        }
        //kiểm tra khóa chính
        public bool ktkc_tamtru(string pMa)
        {
            return tt.ktakhoachinh_tamtru(pMa);
        }
        //Thêm
        public bool them_tamtru(TAMTRU ptamtru)
        {
            return tt.them_tamtru(ptamtru);
        }

        //Xóa
        public bool xoa_tamtru(string pMa)
        {
            return tt.xoa_tamtru(pMa);
        }
        //Sửa
        public bool sua_tamtru(TAMTRU ptamtru)
        {
            return tt.sua_Tamtru(ptamtru);
        }
    }
}
