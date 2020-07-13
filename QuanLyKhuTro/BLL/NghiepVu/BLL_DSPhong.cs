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
   public class BLL_DSPhong
    {
        DAL_DSPhong dal_dsp = new DAL_DSPhong();
        public List<DanhsachPhong> LoadDSPhong()
        {
            return dal_dsp.loaddsPhong ();
        }
      
        public List<DanhsachPhong> LoadDSPhongTheoMa(string pmaloai)
        {
            return dal_dsp.loaddsPhong_theoMa( pmaloai);
        }
        public string tongphongtrong()
        {
            return dal_dsp.Tinhtongphongtrong();
        }
        public string tongphongcokhach()
        {
            return dal_dsp.Tinhtongphongcokhach();
        }
        public string tongphongcokhachcoc()
        {
            return dal_dsp.Tinhtongphongcokhachcoc();
        }
        public string tongphongsapdenhan()
        {
            return dal_dsp.Tinhtongphongsaphethan();
        }
        public string laytinhtranghopdong()
        {
            return dal_dsp.laytinhtranghopdong();
        }

        public string layngaytra()
        {
            return dal_dsp.layngaytronghopdong();
        }
        public string tongphongdangsua()
        {
            return dal_dsp.tongphongdangsua();
        }
    }
}
