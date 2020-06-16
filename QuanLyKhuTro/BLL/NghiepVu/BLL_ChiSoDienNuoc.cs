using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.NghiepVu;

namespace BLL.NghiepVu
{
   public class BLL_ChiSoDienNuoc
    {
        DAL_ChiSoDienNuoc dal_csdn = new DAL_ChiSoDienNuoc();
        public List<CHISO_DIENNUOC> LoadChisodn()
        {
            return dal_csdn.loadbangChiSoDN();
        }
        //kiểm tra khóa chính
        public bool ktkc_ChiSodn(string pMa)
        {
            return dal_csdn.ktakhoachinh_ChisoDN(pMa);
        }
        //Thêm
        public bool Them_ChiSonc(CHISO_DIENNUOC pkt)
        {
            return dal_csdn.them_CHiSoDN(pkt);
        }
        //ktra xóa
        public bool ktx_Chisonc(String t)
        {
            return dal_csdn.ktakhoachinh_ChisoDN(t);
        }
        //Xóa
        public bool xoa_Chisonc(string pMa)
        {
            return dal_csdn.xoa_ChiSoDienNuoc(pMa);
        }
        //Sửa
        public bool sua_ChiSonc(CHISO_DIENNUOC pkt)
        {
            return dal_csdn.sua_ChisoDN(pkt);
        }

    }
}
