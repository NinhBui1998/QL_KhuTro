using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;

namespace QuanLyKhuTro.DuLieu
{
   
   public class capnhatdulieu
    {
        DAL_SinhMa dal_sm = new DAL_SinhMa();
       public void update()
        { 
           dal_sm.updatekhachthuesaphethantt();
            dal_sm.updatekhachthuedadktt();
            dal_sm.updatekhachthuedahethantt();
            dal_sm.updatehopdongconthoihan();
            dal_sm.updatehopdonghethan();
            dal_sm.updatehopdongsaphethan();
            dal_sm.Capnhapphongdacoc();
        }
    }
}
