﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HopDong
    {
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();

        //lấy tất cả dữ liệu
        public List<HOPDONG> loadbangHopDong()
        {
            var dulieu = (from s in data.HOPDONGs select s);
            return dulieu.ToList<HOPDONG>();
        }
        public HOPDONG loadbangHd()
        {
            var dulieu = (from s in data.HOPDONGs select s).FirstOrDefault();
            return dulieu;
        }

        //kiểm tra khóa chính
        public bool ktakhoachinh_HopDong(string hd)
        {
            var kt = (from h in data.HOPDONGs
                      where h.MAHD == hd
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
        public bool them_HopDong(HOPDONG hd)
        {
            //try
            //{
                data.HOPDONGs.InsertOnSubmit(hd);
                data.SubmitChanges();
                return true;
            //}
            //catch
            //{
            //    return false;
            //}

        }

        //Xóa
        public bool xoa_HopDong(string pMaHD)
        {
            try
            {
                HOPDONG hd = data.HOPDONGs.Where(t => t.MAHD == pMaHD).FirstOrDefault();
                data.HOPDONGs.DeleteOnSubmit(hd);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Sửa
        public bool sua_HopDong(HOPDONG pHopDong)
        {
            try
            {
                HOPDONG hd = data.HOPDONGs.Where(t => t.MAHD == pHopDong.MAHD).FirstOrDefault();
                if (hd != null)
                {
                    hd.TIENCOC = pHopDong.TIENCOC;
                    hd.NGAYTRA = pHopDong.NGAYTRA;
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_TinhtrangHopDong(HOPDONG pHopDong)
        {
            try
            {
                HOPDONG hd = data.HOPDONGs.Where(t => t.MAHD == pHopDong.MAHD).FirstOrDefault();
                if (hd != null)
                {
                    hd.TINHTRANG = pHopDong.TINHTRANG;

                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //kiểm tra có đang được sử dụng


    }
}
