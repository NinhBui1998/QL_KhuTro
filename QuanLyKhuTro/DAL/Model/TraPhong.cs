using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class TraPhong
    {
        string MAHD;
        DateTime NGAYLAP;
        DateTime NGAYTRA;
        string MAKT;
        string TENKT;
        string SDT;
        string CMND;

        string MAPHONG;
        string TENPHONG;

        string MANV;
        string TENNV;
        Boolean TRACOC;

        public string Mahd { get => MAHD; set => MAHD = value; }
        public DateTime Ngaylap { get => NGAYLAP; set => NGAYLAP = value; }
        public DateTime Ngaytra { get => NGAYTRA; set => NGAYTRA = value; }
        public string Makt{ get => MAKT; set => MAKT = value; }
        public string Tenkt { get => TENKT; set => TENKT = value; }
        public string Sdt{ get => SDT; set => SDT = value; }
        public string Cmnd { get => CMND; set => CMND = value; }
        public string Maphong{ get => MAPHONG; set => MAPHONG = value; }
        public string Tenphong { get => TENPHONG; set => TENPHONG = value; }
        public string Manv { get => MANV; set => MANV = value; }
        public string Tennv { get => TENNV; set => TENNV = value; }
        //public bool TRACOC1 { get => TRACOC; set => TRACOC = value; }
        public bool Tracoc { get => TRACOC; set => TRACOC = value; }
    }
}
