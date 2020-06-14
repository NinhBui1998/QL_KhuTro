using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;

namespace BLL
{
    public class BLL_TraPhong
    {
        DAL_TraPhong tp = new DAL_TraPhong();
        public List<TraPhong> LoadTraPhong()
        {
            return tp.loadtraphong();
        }
        public List<TraPhong> LoadTraPhongtheoten(string pten)
        {
            return tp.loadtraphongtheoma(pten);
        }
        public String laySoDien(string pma)
        {
            return tp.LaysoDien(pma);
        }
        public String laySoNuoc(string pma)
        {
            return tp.LaysoNuoc(pma);
        }
    }
}
