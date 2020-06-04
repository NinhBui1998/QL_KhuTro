using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HopDong_KhachThue
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu       
        //kiểm tra khóa chính      
        //Thêm
        public bool them_HopDong_KhachThue(HOPDONG_KT hd_kt)
        {
            try
            {
                data.HOPDONG_KTs.InsertOnSubmit(hd_kt);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_HopDong_KhachThue(string pMaHD, string pMaKT)
        {
            try
            {
                HOPDONG_KT hd_kt= data.HOPDONG_KTs.Where(t => t.MAHD == pMaHD && t.MAKT== pMaKT).FirstOrDefault();
                data.HOPDONG_KTs.DeleteOnSubmit(hd_kt);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_HopDong_KhachThue(HOPDONG_KT hd_kt)
        {
            try
            {
                HOPDONG_KT hopdong_kt= data.HOPDONG_KTs.Where(t => t.MAHD == hd_kt.MAHD).FirstOrDefault();
                if (hd_kt != null)
                {
                    hopdong_kt.TRACOC= hd_kt.TRACOC;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
