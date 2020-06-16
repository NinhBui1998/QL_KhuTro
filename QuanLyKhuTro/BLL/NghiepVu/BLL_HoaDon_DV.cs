using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.NghiepVu;

namespace BLL.NghiepVu
{
   public class BLL_HoaDon_DV
    {
        DAL_HoaDonDichVu dal_hddv = new DAL_HoaDonDichVu();
        public List<HOADON_DICHVU> LoadHoaDonDV()
        {
            return dal_hddv.loadbangHoaDon_DV();
        }
        //kiểm tra khóa chính
        public bool ktkc_hoadon_dv(string pMadv, string pmahd)
        {
            return dal_hddv.ktakhoachinh_hoadon_dv(pMadv,pmahd);
        }
        //Thêm
        public bool Them_HoaDon_dv(HOADON_DICHVU pkt)
        {
            return dal_hddv.them_HoaDon_DV(pkt);
        }
        //ktra xóa
        public bool ktx_hoadon_dv(String pmadv,string pmahd)
        {
            return dal_hddv.ktakhoachinh_hoadon_dv(pmadv,pmahd);
        }
        //Xóa
        public bool xoa_Hoadon_dv(string pMadv, string pmahd)
        {
            return dal_hddv.xoa_HoaDon_DV(pMadv,pmahd);
        }
        //Sửa
        public bool sua_hoadon_dv(HOADON_DICHVU pkt)
        {
            return dal_hddv.sua_HoaDon_DV(pkt);
        }
    }
}
