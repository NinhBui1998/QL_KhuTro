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
        public List<DanhsachPhong> LoadDSPhongTheoMa(string pmatang, string pmaloai)
        {
            return dal_dsp.loaddsPhong_theoMa(pmatang, pmaloai);
        }
    }
}
