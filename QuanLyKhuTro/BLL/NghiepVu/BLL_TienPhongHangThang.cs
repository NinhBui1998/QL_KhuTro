using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
using DAL.NghiepVu;

namespace BLL.NghiepVu
{
   public class BLL_TienPhongHangThang
    {
        DAL_TienPhongHangThang dal_tienphong = new DAL_TienPhongHangThang();
        public List<HoaDon> LoadDataHoaDon()
        {
            return dal_tienphong.loadHoaDon();
        }
        public List<HoaDon> LoadDataHoaDontheomaphong(String pmaphong)
        {
            return dal_tienphong.loadHoaDontheophong(pmaphong);
        }
    }
}
