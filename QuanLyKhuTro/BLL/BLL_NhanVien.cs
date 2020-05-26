using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public class BLL_NhanVien
    {
        DAL_NhanVien dnv = new DAL_NhanVien();
        public List<NHANVIEN> loadBangNV()
        {
            return dnv.loadbangNhanvien();
        }
        //kiểm tra khóa chính
        public bool ktkc_nhanvien(string pMa)
        {
            return dnv.ktakhoachinh_NhanVien(pMa);
        }
        //Thêm
        public bool ThemNV(NHANVIEN pnv)
        {
            return dnv.them_NhanVien(pnv);
        }
        //ktra xóa
        public bool ktx_nhanvien(String t)
        {
            return dnv.kt_NhanVien(t);
        }
        //Xóa
        public bool xoa_Nhanvien(string pMa)
        {
            return dnv.xoa_NhanVien(pMa);
        }
        //Sửa
        public bool sua_nhanvien(NHANVIEN pnv)
        {
            return dnv.suaNhanVien(pnv);
        }
    }
}
