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
        string TENNV;
        string MAKT;
        string TENKT;
        DateTime NGAYLAP;
        DateTime NGAYTRA;
        Decimal TIENCOC;
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
        public String Tennv
        {
            get { return TENNV; }
            set { TENNV = value; }
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
       
        public Decimal Tiencoc
        {
            get { return TIENCOC; }
            set { TIENCOC = value; }
        }

        public DateTime NgayTra
        { get => NGAYTRA; set => NGAYTRA = value; }
    }
}
