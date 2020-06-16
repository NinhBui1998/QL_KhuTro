﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class DAL_ThanNhan_TamTru
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public List<THANNHAN_TAMTRU> loadbangThanNhanTamTru()
        {
            var dulieu = (from s in data.THANNHAN_TAMTRUs select s);
            return dulieu.ToList<THANNHAN_TAMTRU>();
        }

        //kiểm tra khóa chính
        public bool ktkc_thannhan_tamtru(string pmatn, string pmakt)
        {
            var kt = (from h in data.THANNHAN_TAMTRUs
                      where h.MAKT == pmakt && h.MATN == pmatn
                      select h).Count();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Thêm
        public bool them_Thannhantamtru(THANNHAN_TAMTRU tb)
        {
            try
            {
                data.THANNHAN_TAMTRUs.InsertOnSubmit(tb);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_Thannhan_tamtru(string matn, string pMakt)
        {
            try
            {
                THANNHAN_TAMTRU tb = data.THANNHAN_TAMTRUs.Where(t => t.MATN == matn && t.MAKT == pMakt).FirstOrDefault();
                data.THANNHAN_TAMTRUs.DeleteOnSubmit(tb);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_thannhan_tamtru(THANNHAN_TAMTRU ptntamtru)
        {
            try
            {
                THANNHAN_TAMTRU nv = data.THANNHAN_TAMTRUs.Where(t => t.MATN == ptntamtru.MATN && t.MAKT == ptntamtru.MAKT).FirstOrDefault();
                if (nv != null)
                {
                    nv.MAKT = ptntamtru.MAKT;
                    nv.MATN = ptntamtru.MATN;
                    nv.NGAYVAO = ptntamtru.NGAYVAO;
                    nv.NGAYRA = ptntamtru.NGAYRA;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //kiểm tra tầng có đang được sử dụng
        //public bool kt_XoaTn_tamtru(string pmatn, string pmakt)
        //{

        //    var ktx = (from t in data.THANNHAN_TAMTRUs
        //               from p in data.THIETBI_PHONGs
        //               where t.MATHIETBI == hd && p.MATHIETBI == hd
        //               select t).Count();
        //    if (ktx > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
    }
}