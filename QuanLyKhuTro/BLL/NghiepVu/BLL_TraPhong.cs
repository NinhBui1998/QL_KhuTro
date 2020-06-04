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
    }
}
