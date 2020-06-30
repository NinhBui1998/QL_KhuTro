using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;

namespace BLL
{
    public class BLL_SinhMa
    {
        DAL_SinhMa dal_sm = new DAL_SinhMa();
        public string SinhMaHoaDon()
        {
            return dal_sm.SinhMaHD();
        }
        public String SinhMa_KhachThue()
        {
            return dal_sm.SinhMaKT();
        }
        public String SinhMa_HopDong()
        {
            return dal_sm.SinhMaHOPDONG();
        }
        public String SinhMa_TAMTRU()
        {
            return dal_sm.SinhMaTamTru();
        }

    }
}
