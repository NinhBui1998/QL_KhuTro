using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
   public class DanhsachPhong
    {
        String TENTANG;
        String TENLOAI;
        Double GIA;
        String TENPHONG;
        int SOLUONG_HT;
        int SOLUONG_TD;
        public Double Gia
        {
            get { return GIA; }
            set { GIA = value; }
        }

        public String TenPhong
        {
            get { return TENPHONG; }
            set { TENPHONG = value; }
        }
        public int SoLuong_HT
        {
            get { return SOLUONG_HT; }
            set { SOLUONG_HT = value; }
        }
        public int SoLuong_TD
        {
            get { return SOLUONG_TD; }
            set { SOLUONG_TD = value; }
        }
        public String TenTang
        {
            get { return TENTANG; }
            set { TENTANG = value; }
        }
        public String TenLoai
        {
            get { return TENLOAI; }
            set { TENLOAI = value; }
        }


    }
}
