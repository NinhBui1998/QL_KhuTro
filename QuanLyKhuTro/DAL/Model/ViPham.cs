using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ViPham
    {
        string MANOIQUY;
        string MAKT;
        DateTime NGAYVIPHAM;
        int SOLAN;
        string GHICHU;
        string TENKT;
        string SOCMND;
        string NOIDUNG;
        Decimal HINHPHAT;
     

        public string Manoiquy { get => MANOIQUY; set => MANOIQUY = value; }
        public string Makt { get => MAKT; set => MAKT = value; }
        public int Solan { get => SOLAN; set => SOLAN = value; }
        public string Ghichu { get => GHICHU; set => GHICHU = value; }
        public string Tenkt { get => TENKT; set => TENKT = value; }
        public string Socmnd { get => SOCMND; set => SOCMND = value; }
        public string Noidung { get => NOIDUNG; set => NOIDUNG = value; }
        public Decimal Hinhphat { get => HINHPHAT; set => HINHPHAT = value; }
        public DateTime Ngayvipham { get => NGAYVIPHAM; set => NGAYVIPHAM = value; }
    }
}
