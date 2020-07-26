using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThietBi
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<THIETBI> loadbangThietBi()
        {
            var dulieu = (from s in data.THIETBIs select s);
            return dulieu.ToList<THIETBI>();
        }

       public string laytentb(string pma)
        {
            var kq = (from t in data.THIETBIs
                      where t.MATHIETBI == pma
                      select t.TENTB).FirstOrDefault();
            return kq.ToString();
        }
        //kiểm tra khóa chính
        public bool ktakhoachinh_ThietBi(string hd)
        {
            var kt = (from h in data.THIETBIs
                      where h.MATHIETBI == hd
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
        public bool ktakhoachinh_ThietBiphong(string hd, string pmaphong)
        {
            var kt = (from h in data.THIETBI_PHONGs
                      where h.MATHIETBI == hd && h.MAPHONG==pmaphong
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
        public List<THIETBI_PHONG> loadthietbihuhai()
        {
            var kq = (from tb in data.THIETBI_PHONGs
                      where tb.TRANGTHAI == "Hư hỏng"
                      select tb).ToList<THIETBI_PHONG>();
            return kq;
        }

        //Thêm
        public bool them_ThietBi(THIETBI tb)
        {
            try
            {
                data.THIETBIs.InsertOnSubmit(tb);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        public bool xoa_ThietBi(string pMaTB)
        {
            try
            {
                THIETBI tb = data.THIETBIs.Where(t => t.MATHIETBI == pMaTB).FirstOrDefault();
                data.THIETBIs.DeleteOnSubmit(tb);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_ThietBi(THIETBI pThietBi)
        {
            try
            {
                THIETBI nv = data.THIETBIs.Where(t => t.MATHIETBI == pThietBi.MATHIETBI).FirstOrDefault();
                if (nv != null)
                {
                    nv.TENTB = pThietBi.TENTB;
                    //nv.GIATB = pThietBi.GIATB;
                    //nv.SOLUONG_PHANBO = pThietBi.SOLUONG_PHANBO;
                    //nv.SOLUONG_HUHONG = pThietBi.SOLUONG_HUHONG;
                    //nv.SOLUONG_TONKHO = pThietBi.SOLUONG_TONKHO;
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
        public bool kt_XoaTB(string hd)
        {

            var ktx = (from t in data.THIETBIs
                       from p in data.THIETBI_PHONGs
                       where t.MATHIETBI == hd && p.MATHIETBI == hd
                       select t).Count();
            if (ktx > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<THIETBI_PHONG> loadbangThietBiPhong()
        {
            var dulieu = (from s in data.THIETBI_PHONGs select s);
            return dulieu.ToList<THIETBI_PHONG>();
        }
        public List<THIETBI_PHONG> loadbangThietBiPhong(string pma)
        {
            var dulieu = (from s in data.THIETBI_PHONGs 
                          where s.MAPHONG==pma select s);
            return dulieu.ToList<THIETBI_PHONG>();
        }

        public List<THIETBI_PHONG> loadbangThietBiPhongtheomaphong(string pma)
        {
            var dulieu = (from s in data.THIETBI_PHONGs 
                          where s.MAPHONG==pma
                          select s);
            return dulieu.ToList<THIETBI_PHONG>();
        }
        public bool them_ThietBiphong(THIETBI_PHONG tb)
        {
            try
            {
                data.THIETBI_PHONGs.InsertOnSubmit(tb);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        //Xóa
        
        public bool xoa_ThietBiphong(string pMaTB, string pmaphong)
        {
            try
            {
                THIETBI_PHONG tb = data.THIETBI_PHONGs.Where(t => t.MATHIETBI == pMaTB && t.MAPHONG==pmaphong).FirstOrDefault();
                data.THIETBI_PHONGs.DeleteOnSubmit(tb);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_ThietBiphong(THIETBI_PHONG pThietBi)
        {
            try
            {
                THIETBI_PHONG nv = data.THIETBI_PHONGs.Where(t => t.MATHIETBI == pThietBi.MATHIETBI && t.MAPHONG==pThietBi.MAPHONG).FirstOrDefault();
                if (nv != null)
                {
                    nv.TRANGTHAI = pThietBi.TRANGTHAI;
                  
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<thietbi> loadthietbihuhaitheophong(string pma)
        {
            var kt = from t in data.THIETBIs
                     from tb in data.THIETBI_PHONGs
                     where t.MATHIETBI ==tb.MATHIETBI && tb.MAPHONG==pma
                     select new
                     {
                         tb.MATHIETBI,
                         t.TENTB,
                         t.GIADENBUHUHAI,
                     };
            var kq = kt.ToList().ConvertAll(t => new thietbi()
            {
                MATB1=t.MATHIETBI,
                TENTB1=t.TENTB,
                GIADENBU1=Convert.ToDecimal(t.GIADENBUHUHAI),
            });
            kq.ToList<thietbi>();
            return kq;
        }
        public List<thietbi> loadthietbihuhaitheophong1(string pma)
        {
            var kt = from t in data.THIETBIs
                     from tb in data.THIETBI_PHONGs
                     where t.MATHIETBI == tb.MATHIETBI && tb.MAPHONG == pma && tb.TRANGTHAI== "Hư hỏng"
                     select new
                     {
                         tb.MATHIETBI,
                         t.TENTB,
                         t.GIADENBUHUHAI,
                     };
            var kq = kt.ToList().ConvertAll(t => new thietbi()
            {
                MATB1 = t.MATHIETBI,
                TENTB1 = t.TENTB,
                GIADENBU1 = Convert.ToDecimal(t.GIADENBUHUHAI),
            });
            kq.ToList<thietbi>();
            return kq;
        }
    }
}
