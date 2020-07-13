using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.HeThong;

namespace BLL.HeThong
{
   public class BLL_DichVuDien
    {
        DAL_DichVuDien dal_dvd = new DAL_DichVuDien();
        public List<DICHVUDIEN> loaddichvudien()
        {
            return dal_dvd.loaddvdien();
        }
        public bool sua_dvdien(DICHVUDIEN pdvd)
        {
            return dal_dvd.sua_dichvudien(pdvd);
        }
    }
}
