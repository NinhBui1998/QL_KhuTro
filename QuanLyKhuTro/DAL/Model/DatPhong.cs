using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DatPhong
    {
        string MAHD;
        string MANV;
        string MAKT;
        string TENKT;
        DateTime NGAYLAP;
        string THOIHAN;
        Double TIENCOC;
        string TENPHONG;

        public String Mahd
        {
            get { return MAHD; }
            set { MAHD = value; }
        }
        public String TenPhong
        {
            get { return TENPHONG; }
            set { TENPHONG = value; }
        }
        public String Manv
        {
            get { return MANV; }
            set { MANV = value; }
        }
        public String Makt
        {
             get { return MAKT; }
             set { MAKT = value; }
        }
        public String Tenkt
        {
            get { return TENKT; }
            set { TENKT = value; }
        }
        public DateTime NgayLap
        {
            get { return NGAYLAP; }
            set { NGAYLAP = value; }
        }
        public String Thoihan
        {
            get { return THOIHAN; }
            set { THOIHAN = value; }
        }
        public Double Tiencoc
        {
            get { return TIENCOC; }
            set { TIENCOC = value; }
        }
    }
}
