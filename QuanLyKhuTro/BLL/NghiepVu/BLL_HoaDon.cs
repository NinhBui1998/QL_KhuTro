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
    public class BLL_HoaDon
    {
        DAL_HoaDon dall_hoadon = new DAL_HoaDon();
        DAL_TienPhongHangThang tpht = new DAL_TienPhongHangThang();
        public List<HOADON> Loadhoadon()
        {
            return dall_hoadon.loadbangHoaDon();
        }
      
        //kiểm tra khóa chính
        public bool ktkc_HoaDon(string pMa)
        {
            return dall_hoadon.ktakhoachinh_hoadon(pMa);
        }
        //Thêm
        public bool Them_HoaDon(HOADON pkt)
        {
            return dall_hoadon.them_HoaDon(pkt);
        }
        //ktra xóa
        public bool ktx_HoaDon(String t)
        {
            return dall_hoadon.ktx_hoadon(t);
        }
        //Xóa
        public bool xoa_hoaDon(string pMa)
        {
            return dall_hoadon.xoa_HoaDon(pMa);
        }
        //Sửa
        public bool sua_HoaDon(HOADON pkt)
        {
            return dall_hoadon.sua_HoaDon(pkt);
        }
       
    }
}
