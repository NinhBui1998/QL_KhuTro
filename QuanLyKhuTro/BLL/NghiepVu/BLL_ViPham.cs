using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
using DAL.NghiepVu;

namespace BLL
{
    public class BLL_ViPham
    {
        DAL_ViPham vp = new DAL_ViPham();

        public List<ViPham> LoadViPham()
        {
            return vp.loadvipham();
        }
        public List<ViPham> Loadviphamtheoma(string pmakt)
        {
            return vp.loadviphamtheoma(pmakt);
        }
        public bool them_vipham(VIPHAM ptamtru)
        {
            return vp.them_vipham(ptamtru);
        }

        //Xóa
        public bool xoa_vipham(string pMa)
        {
            return vp.xoa_vipham(pMa);
        }
        //Sửa
        public bool sua_vipham(VIPHAM pvipham)
        {
            return vp.sua_vipham(pvipham);
        }
        public int laylanvipham(string makt, string mavp )
        {
            return vp.laylanvipham(makt,mavp);
        }
    }   
}
