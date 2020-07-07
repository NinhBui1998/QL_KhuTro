using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
using DAL.ThongKe;

namespace BLL.ThongKe
{
   public class BLL_ThongKePhong
    {
        DAL_Thongkephong da_tkp = new DAL_Thongkephong();
        public string laytenphong()
        {
           return da_tkp.laytenphong();
        }    
        public List<Thongkephong> loadphong()
        {
            return da_tkp.Loadphong();
        }
        public List<Thongkephong> loadphongcoc()
        {
            return da_tkp.Loadphongdatcoc();
        }
        public string tongphong()
        {
            return da_tkp.tinhtongphong();
        }
        public List<Thongkephong> loadphongtrong()
        {
            return da_tkp.Loadphongtrong();
        }
    }
}
