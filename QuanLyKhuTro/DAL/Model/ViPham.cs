using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
   public class Vipham
    {
        string MAVIPHAM11;
        string Manoiquy1;
        string Makt1;
        string Tenkt1;
        string Socmnd1;
        DateTime Ngayvipham1;
        int Solan1;
        string Ghichu1;
        string Noidung1;
        decimal Hinhphat1;
        decimal TIENPHAT;
        string MAPHONG;
        string TENPHONG;

        public string MAVIPHAM1{ get => MAVIPHAM11; set => MAVIPHAM11 = value; }
        public string Manoiquy{ get => Manoiquy1; set => Manoiquy1 = value; }
        public string Makt { get => Makt1; set => Makt1 = value; }
        public string Tenkt { get => Tenkt1; set => Tenkt1 = value; }
        public string Socmnd { get => Socmnd1; set => Socmnd1 = value; }
        public DateTime Ngayvipham { get => Ngayvipham1; set => Ngayvipham1 = value; }
        public int Solan { get => Solan1; set => Solan1 = value; }
        public string Ghichu { get => Ghichu1; set => Ghichu1 = value; }
        public string Noidung { get => Noidung1; set => Noidung1 = value; }
        public decimal Hinhphat { get => Hinhphat1; set => Hinhphat1 = value; }
        public decimal TIENPHAT1 { get => TIENPHAT; set => TIENPHAT = value; }
        public string MAPHONG1 { get => MAPHONG; set => MAPHONG = value; }
        public string TENPHONG1 { get => TENPHONG; set => TENPHONG = value; }
    }
}
