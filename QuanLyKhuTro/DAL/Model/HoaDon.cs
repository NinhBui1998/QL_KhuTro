using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
   public class HoaDon
    {
        string MAHD;
        string TENNV;
        string TENTANG;
        string TENPHONG;
        int SODIEN;
        int SONUOC;
        double TIENNUOC;
        double TIENDIEN;
        double WIFI;
        double RAC;
        double TONGTIEN;
        DateTime NGAYLAP;

        public String MaHD
        {
            get { return MAHD; }
            set { MAHD = value; }
        }
        public String TenNV
        {
            get { return TENNV; }
            set { TENNV = value; }
        }
        public String TenTang
        {
            get { return TENTANG; }
            set { TENTANG = value; }
        }
        public String TenPhong
        {
            get { return TENPHONG; }
            set { TENPHONG = value; }
        }
        public int SoDien
        {
            get { return SODIEN; }
            set { SODIEN = value; }
        }
        public DateTime NgayLap
        {
            get { return NGAYLAP; }
            set { NGAYLAP = value; }
        }
        public int SoNuoc
        {
            get { return SONUOC; }
            set { SONUOC = value; }
        }
        public Double TienNuoc
        {
            get { return TIENNUOC; }
            set { TIENNUOC = value; }
        }
        public Double TienDien
        {
            get { return TIENDIEN; }
            set { TIENDIEN = value; }
        }
        public Double Rac
        {
            get { return RAC; }
            set { RAC = value; }
        }
        public Double Wifi
        {
            get { return WIFI; }
            set { WIFI = value; }
        }
        public Double TongTien
        {
            get { return TONGTIEN; }
            set { TONGTIEN = value; }
        }
       

    }
}
