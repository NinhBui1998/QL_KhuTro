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
        public List<DatPhong> LoadDatPhongTheoMa(string pten)
        {
            return dp.loaddatPhongtheoMa(pten);
        }
        public List<PHONG>laytenphong( string pmatang, string pmaloai)
        {
            return dp.laytenphong(pmatang, pmaloai);
        }
        public String laymaphong(string pten)
        {
            return dp.Laymaphong(pten);
        }
        public String layslht(string pma)
        {
            return dp.LaySLHTPhong(pma);
        }
        public int demsohd(string pmaphong)
        {
            return dp.demhopdong(pmaphong);
        }
    }
}
