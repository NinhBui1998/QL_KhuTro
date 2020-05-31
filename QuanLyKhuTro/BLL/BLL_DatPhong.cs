using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class BLL_DatPhong
    {
        DAL_DatPhong dp = new DAL_DatPhong();
        public List<DatPhong> LoadDatPhong()
        {
            return dp.loaddatphong();
        }
    }
}
