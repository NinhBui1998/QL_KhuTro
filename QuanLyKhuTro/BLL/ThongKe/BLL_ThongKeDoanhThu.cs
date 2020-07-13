using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
using DAL.ThongKe;

namespace BLL.ThongKe
{
   public class BLL_ThongKeDoanhThu
    {
        DAL_ThongKeDoanhThu dal_tkdt = new DAL_ThongKeDoanhThu();
        public decimal tinhtongdoanhthu()
        {
            return dal_tkdt.TinhTong();
        }
        public decimal tinhtongtiendien()
        {
            return dal_tkdt.TinhTongTienDien();
        }
        public decimal tinhtongtiennuoc()
        {
            return dal_tkdt.TinhTongTienNuoc();
        }
        public decimal tinhtongTienwifi()
        {
            return dal_tkdt.TinhTongTienWifi();
        }
        public decimal tinhtongtienrac()
        {
            return dal_tkdt.TinhTongTienRac();
        }
        public decimal tinhtongtienphong()
        {
            return dal_tkdt.TinhTongTienPhong();
        }
        public List<HoaDon> loadtkdoanhthutheothang(int thang)
        {
            return dal_tkdt.loadHoaDontheothang(thang);
        }
        public List<HoaDon> loadtkdoanhthutheonam(int nam)
        {
            return dal_tkdt.loadHoaDontheonam(nam);
        }
        public List<HoaDon> loadtkdoanhthutheothangnam(DateTime thangnam)
        {
            return dal_tkdt.loadHoaDontheothangnam(thangnam);
        }
        public List<HoaDon> loadtkdoanhthutheoquy(DateTime? tuthang, DateTime? denthang)
        {
            return dal_tkdt.loadHoaDontheoquy(tuthang,denthang);
        }
    }
}
