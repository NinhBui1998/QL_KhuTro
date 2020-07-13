using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HeThong
{
  public  class DAL_DichVuDien
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<DICHVUDIEN> loaddvdien()
        {
            var dulieu = (from dvd in data.DICHVUDIENs
                      select dvd);
            return dulieu.ToList<DICHVUDIEN>();
        }
        public bool sua_dichvudien(DICHVUDIEN dv)
        {
            try
            {
                DICHVUDIEN hd = data.DICHVUDIENs.Where(t => t.MADVD == dv.MADVD).FirstOrDefault();
                if (hd != null)
                {
                    hd.GIA = dv.GIA;

                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
