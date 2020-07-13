using DAL.Model;
using System;
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

        public List<Thannhantamtru> loadthannhantheoma()
        {
            var kt = from p in data.PHONGs
                     from k in data.KHACHTHUEs
                     from tn in data.THANNHANs
                     from tntt in data.THANNHAN_TAMTRUs
                     where p.MAPHONG==k.MAPHONG && k.MAKT==tntt.MAKT && tn.MATN==tntt.MATN
                     select new
                     {
                        p.TENPHONG,
                        k.MAKT,
                        k.TENKT,
                        tn.MATN,
                        tn.TENTN,
                        tn.SOCMNDTN,
                        tn.GIOITINH_TN,
                        tntt.NGAYVAO,
                        tntt.NGAYRA

                     };
            var kq = kt.ToList().ConvertAll(t => new Thannhantamtru()
            {
                TENPHONG1 = t.TENPHONG,
                MAKT1 = t.MAKT,
                TENKT1 = t.TENKT,
                MATN1 = t.MATN,
                TENTN1 = t.TENTN,
                GIOITINH1 = t.GIOITINH_TN,
                SOCM1 = t.SOCMNDTN,
                NGAVAO1 = Convert.ToDateTime(t.NGAYVAO),
                NGAYRA1=Convert.ToDateTime(t.NGAYRA),

            }) ;
            ; 
            kq.ToList<Thannhantamtru>();
            return kq;
        }
    }
}