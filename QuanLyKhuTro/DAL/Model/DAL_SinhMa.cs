using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class DAL_SinhMa
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public String SinhMaHD()
        {
            return data.SINHMA_HOADON();
        }
        public String SinhMaKT()
        {
            return data.SINHMA_KHACHTHUE();
        }
        public String SinhMaHOPDONG()
        {
            return data.SINHMA_HOPDONG();
        }
        public String SinhMaTamTru()
        {
            return data.SINHMA_TAMTRU();
        }
    }
}
