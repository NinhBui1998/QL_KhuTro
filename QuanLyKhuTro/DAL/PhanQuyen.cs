using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class PhanQuyen
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<QLPHANQUYEN> laydsmanhinh(String pmanhom)
        {
            return data.QLPHANQUYENs.Where(t => t.MANHOM == pmanhom).ToList<QLPHANQUYEN>();
        }
        public QLND_NHOMND laymanhom(String pTendn)
        {
            return data.QLND_NHOMNDs.Where(t => t.TENDN == pTendn).FirstOrDefault();
        }
    }
}
