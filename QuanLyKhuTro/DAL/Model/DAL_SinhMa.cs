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
        public string SINHMAVIPHAM()
        {
            return data.SINHMA_ViPham();
        }
        public String SinhMaTamTru()
        {
            return data.SINHMA_TAMTRU();
        }
        public String SinhMaKHACHCOC()
        {
            return data.SINHMA_KHACHCOC();
        }
        public String SINHMA_THANNHAN()
        {
            return data.SINHMA_Thannhan();
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
        public int updatetinhtrangKT(string pma)
        {
            return data.updatetinhtrangKT(pma);
        }
    }
}
