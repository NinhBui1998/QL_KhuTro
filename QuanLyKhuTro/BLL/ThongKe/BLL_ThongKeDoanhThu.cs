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
        public decimal tongno()
        {
            return dal_tkdt.TongNo();
        }
        public decimal tongnotheothang(int thang)
        {
            return dal_tkdt.TongNotheothang(thang);
        }
        public decimal tongnotheonam(int nam)
        {
            return dal_tkdt.TongNotheonam(nam);
        }
        public decimal tongnotheothangnam(DateTime thangnam)
        {
            return dal_tkdt.TongNotheothangnam(thangnam);
        }
        public decimal tongnotheoquy(DateTime? tuthang, DateTime? denthang)
        {
            return dal_tkdt.TongNotheoquy(tuthang,denthang);
        }
        public decimal tongtiencoc()
        {
            return dal_tkdt.tongtiencoc();
        }
        public decimal tongtiencoctheothang(int thang)
        {
            return dal_tkdt.tongtiencoctheothang(thang);
        }
        public decimal tongtiencoctheonam(int nam)
        {
            return dal_tkdt.tongtiencoctheonam(nam);
        }
        public decimal tongtiencoctheoquy(DateTime? tuthang , DateTime? denthang)
        {
            return dal_tkdt.tongtiencoctheoquy(tuthang, denthang);
        }
        public decimal tongtiencoctheothangnam(DateTime tuthang)
        {
            return dal_tkdt.tongtiencoctheothangnam(tuthang);
        }
        public decimal tongtienvipham()
        {
            return dal_tkdt.tongtienvipham();
        }
        public decimal tongtienviphamtheothang(int thang)
        {
            return dal_tkdt.tongtienviphamthang(thang);
        }
        public decimal tongtienviphamtheonam(int nam)
        {
            return dal_tkdt.tongtienviphamnam(nam);
        }
        public decimal tongtienviphamtheoquy(DateTime? tuthang, DateTime? denthang)
        {
            return dal_tkdt.tongtienviphamquy(tuthang, denthang);
        }
        public decimal tongtienviphamtheothangnam(DateTime tuthang)
        {
            return dal_tkdt.tongtienviphamthangnam(tuthang);
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
        public List<HoaDon> loadtkdoanhthunotheothang(int thang)
        {
            return dal_tkdt.loadHoaDonnotheothang(thang);
        }
        public List<HoaDon> loadHoaDonconno()
        {
            return dal_tkdt.loadHoaDonconno();
        }
        public List<HoaDon> loadtkdoanhthutheonam(int nam)
        {
            return dal_tkdt.loadHoaDontheonam(nam);
        }
        public List<HoaDon> loadtkdoanhthunotheonam(int nam)
        {
            return dal_tkdt.loadHoaDonnotheonam(nam);
        }
        public List<HoaDon> loadtkdoanhthutheothangnam(DateTime thangnam)
        {
            return dal_tkdt.loadHoaDontheothangnam(thangnam);
        }
        public List<HoaDon> loadtkdoanhthunotheothangnam(DateTime thangnam)
        {
            return dal_tkdt.loadHoaDonnotheothangnam(thangnam);
        }

        public List<HoaDon> loadtkdoanhthutheoquy(DateTime? tuthang, DateTime? denthang)
        {
            return dal_tkdt.loadHoaDontheoquy(tuthang,denthang);
        }
        public List<HoaDon> loadtkdoanhthunotheoquy(DateTime? tuthang, DateTime? denthang)
        {
            return dal_tkdt.loadHoaDonnotheoquy(tuthang, denthang);
        }
    }
}
