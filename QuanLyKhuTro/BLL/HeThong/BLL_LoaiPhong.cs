using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class BLL_LoaiPhong
    {
        DAL_LoaiPhong lp = new DAL_LoaiPhong();
        public List<LOAIPHONG> loadBangLoaiPhong()
        {
            return lp.loadbangLoaiPhong();
        }
        //kiểm tra khóa chính
        public bool ktkc_LoaiPhong(string pMa)
        {
            return lp.ktakhoachinh_LoaiPhong(pMa);
        }
        //Thêm
        public bool ThemLoaiPhong(LOAIPHONG ploai)
        {
            return lp.them_LoaiPhong(ploai);
        }
        //ktra xóa
        public bool ktx_loaiPhong(String t)
        {
            return lp.kt_XoaLoaiPhong(t);
        }
        //Xóa
        public bool xoa_LoaiPhong(string pMa)
        {
            return lp.xoa_LoaiPhong(pMa);
        }
        //Sửa
        public bool sua_LoaiPhong(LOAIPHONG pLoai)
        {
            return lp.suaLoaiPhong(pLoai);
        }
    }
}
