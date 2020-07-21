using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_NoiQuy
    {
        DAL_NoiQuy noiquy= new DAL_NoiQuy();
        public List<NOIQUY> loadBang_NoiQuy()
        {
            return noiquy.loadbangNoiQuy();
        }
        //kiểm tra khóa chính
        public bool ktkc_NoiQuy(string pMa)
        {
            return noiquy.ktakhoachinh_NoiQuy(pMa);
        }
       
        //Thêm
        public bool them_NoiQuy(NOIQUY pNoiQuy)
        {
            return noiquy.them_NoiQuy(pNoiQuy);
        }
        //ktra xóa
        public bool ktx_nq(String nq)
        {
            return noiquy.kt_XoaNQ(nq);
        }
        //Xóa
        public bool xoa_NoiQuy(string pMa)
        {
            return noiquy.xoa_NoiQuy(pMa);
        }
        //Sửa
        public bool sua_NoiQuy(NOIQUY pNoiQuy)
        {
            return noiquy.sua_NoiQuy(pNoiQuy);
        }
    }
}
