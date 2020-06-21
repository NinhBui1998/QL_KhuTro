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
    }   
}
