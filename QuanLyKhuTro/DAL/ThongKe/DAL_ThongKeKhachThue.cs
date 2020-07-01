using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ThongKe
{
   public class DAL_ThongKeKhachThue
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        //public List<KHACHTHUE> loadbangKhachThue(DateTime ngaylaphd)
        //{
        //    var dulieu = (from s in data.KHACHTHUEs 
        //                  from hd in data.HOPDONGs
        //                  where s.MAKT==hd.MAKT && 
        //                  select s);
        //    return dulieu.ToList<KHACHTHUE>();
        //}
        //public int Demsokt()
        //{
        //    var dulieu = (from s in data.KHACHTHUEs select s).Sum();
        //    return dulieu
        //}
    }
}
