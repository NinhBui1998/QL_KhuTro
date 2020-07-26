using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class BLL_ThietBi
    {
        DAL_ThietBi thietbi = new DAL_ThietBi();
        public List<THIETBI> loadBang_TB()
        {
            return thietbi.loadbangThietBi();
        }
        //kiểm tra khóa chính
        public bool ktkc_ThietBi(string pMa)
        {
            return thietbi.ktakhoachinh_ThietBi(pMa);
        }
        public string laytenthietbi(string pma)
        {
            return thietbi.laytentb(pma);
        }
        //Thêm
        public bool them_ThietBi(THIETBI pThietBi)
        {
            return thietbi.them_ThietBi(pThietBi);
        }
        //ktra xóa
        public bool ktx_tb(String tb)
        {
            return thietbi.kt_XoaTB(tb);
        }
        //Xóa
        public bool xoa_ThietBi(string pMa)
        {
            return thietbi.xoa_ThietBi(pMa);
        }
        //Sửa
        public bool sua_ThietBi(THIETBI pThietBi)
        {
            return thietbi.sua_ThietBi(pThietBi);
        }

        public List<THIETBI_PHONG> loadBang_TBPhong()
        {
            return thietbi.loadbangThietBiPhong();
        }
        public List<THIETBI_PHONG> loadBang_TBPhong(string pma)
        {
            return thietbi.loadbangThietBiPhong(pma);
        }
        public List<THIETBI_PHONG> loadbangThietBiPhongtheomaphong(string pma)
        {
            
            return thietbi.loadbangThietBiPhongtheomaphong(pma);
        }
        //kiểm tra khóa chính
        public bool ktkc_ThietBiphong(string pMa, string pmaphong)
        {
            return thietbi.ktakhoachinh_ThietBiphong(pMa, pmaphong);
        }
        public List<thietbi> loadthietbihuhaitheophong(string pma)
        {
            return thietbi.loadthietbihuhaitheophong(pma);
        }
        public List<thietbi>loadhuhai(string pma)
        {
            return thietbi.loadthietbihuhaitheophong1(pma);
        }
        public List<THIETBI_PHONG> loadthietbihuhai()
        {
            return thietbi.loadthietbihuhai();
        }
        //Thêm
        public bool them_ThietBiphong(THIETBI_PHONG pThietBi)
        {
            return thietbi.them_ThietBiphong(pThietBi);
        }
        //ktra xóa

        //Xóa
        public bool xoa_ThietBiphong(string pMa, string pmaphong)
        {
            return thietbi.xoa_ThietBiphong(pMa, pmaphong);
        }
        //Sửa
        public bool sua_ThietBiphong(THIETBI_PHONG pThietBi)
        {
            return thietbi.sua_ThietBiphong(pThietBi);
        }

    }
}
