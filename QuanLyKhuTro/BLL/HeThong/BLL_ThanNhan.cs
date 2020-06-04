using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_ThanNhan
    {
        DAL_ThanNhan tn = new DAL_ThanNhan();
        public List<THANNHAN> loadThanNhan()
        {
            return tn.loadbangThanNhan();
        }
        public bool ktkc(string pma)
        {
            return tn.ktakhoachinh_ThanNhan(pma);
        }
        public bool ktx_thannhan(string pma)
        {
            return tn.ktx_thannhan(pma);
        }
        public bool Them_ThanNhan(THANNHAN thannhan)
        {
            return tn.them_ThanNhan(thannhan);
        }
        public bool sua_thanNhan(THANNHAN thannhan)
        {
            return tn.sua_thannhan(thannhan);
        }
        public bool xoa(string pma)
        {
            return tn.xoa_ThanNhan(pma);
        }
    }
}
