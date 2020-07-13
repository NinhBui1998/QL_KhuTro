using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;
using DAL.NghiepVu;

namespace BLL.NghiepVu
{
   public class BLL_CocPhong
    {
        DAL_CocPhong dal_cocphong = new DAL_CocPhong();
        public List<KHACHCOCPHONG> Loadcocphong()
        {
            return dal_cocphong.loadkhachcocphong();
        }

        public KHACHCOCPHONG loadkhcocphong(string pma)
        {
            return dal_cocphong.loadkhcocphong(pma);
        }
        public List<Cocphong> Loadbangcocphong()
        {
            return dal_cocphong.loadcocphong();
        }
        public bool kt_phongcococ(string pma)
        {
            return dal_cocphong.kt_phongcococ(pma);
        }

        public List<Cocphong> Loadbangcocphongtheo(string pma)
        {
            return dal_cocphong.loadcocphongtheoma(pma);
        }
        //kiểm tra khóa chính
        public bool ktkc_cocphong(string pMa)
        {
            return dal_cocphong.ktkc_khachcoc(pMa);
        }
        //Thêm
        public bool themcocphong(KHACHCOCPHONG ptamtru)
        {
            return dal_cocphong.them_khachcoc(ptamtru);
        }

        //Xóa
        public bool xoacocphong(string pMa)
        {
            return dal_cocphong.xoa_khachcoc(pMa);
        }
        //Sửa
        public bool sua_khachcoc(KHACHCOCPHONG ptamtru)
        {
            return dal_cocphong.sua_khaccoc(ptamtru);
        }
        public bool kt_sdt(string sdt)
        {
            return dal_cocphong.KTSDT(sdt);
        }
        public bool kt_scm(string pscm)
        {
            return dal_cocphong.KTSCM(pscm);
        }
    }
}
