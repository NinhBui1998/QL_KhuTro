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
        public int updatekhachthuesaphethantt()
        {
            return data.updatehopdongsaphethan();
        }
        public int updatekhachthuedadktt()
        {
            return data.updatekhachthuedadktt();
        }
        public int updatekhachthuedahethantt()
        {
            return data.updatekhachthuedahethantt();
        }
        public int updatehopdongsaphethan()
        {
            return data.updatehopdongsaphethan();
        }
        public int updatehopdongconthoihan()
        {
            return data.updatehopdongconthoihan();
        }
        public int updatehopdonghethan()
        {
            return data.updatehopdonghethan();
        }

        public int Capnhapphongdacoc()
        {
            return data.updatephongdacoc();
        }
    }
}
