using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using DAL;
using DAL.NghiepVu;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using DAL.DuLieu;
using DAL.HeThong;
using Syncfusion.XlsIO;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_vipham : DevExpress.XtraEditors.XtraForm
    {
        WordExport we = new WordExport();
        DAL_ViPham dal_vipham = new DAL_ViPham();
        BLL_ViPham bll_vipham = new BLL_ViPham();
        BLL_NoiQuy bll_noiquy = new BLL_NoiQuy();
        BLL_KhachThue bll_khachthue = new BLL_KhachThue();
        BLL_Phong bll_phong = new BLL_Phong();
        public frm_vipham()
        {
            InitializeComponent();
        }
        string Manv;
        public string MaNV { get => Manv; set => Manv = value; }
        private void frm_vipham_Load(object sender, EventArgs e)
        {
            txt_mavp.Text = bll_sm.Sinhma_vipham();
            grv_khachthue.DataSource = dal_loadkt.loadkhachthuecono();
            //cbb_manoiquy.DataSource = bll_noiquy.loadBang_NoiQuy();
            cbb_manoiquy.DataSource = bll_vipham.loadBANGnoiquy();
            //cbb_manoiquy.ValueMember = "MANOIQUY";
            cbb_manoiquy.DisplayMember = "MANOIQUY";

            grv_vipham.DataSource = bll_vipham.LoadViPham();
         
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";
            txt_manv.Text = MaNV;

            btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_huy.Enabled = btn_luu.Enabled=txt_ngayvipham.Enabled = false;
            btn_them.Enabled = true;
            txt_solan.Enabled = txt_ghichu.Enabled = false;
            //txt_ngayvipham.Text = DateTime.Now.ToShortDateString();
            txt_mavp.Enabled = false;
        }
        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = dal_loadkt.loadkhachthuecono();
            grv_vipham.DataSource = bll_vipham.LoadViPham();
        }

        DAL_LoadKhachThue dal_loadkt = new DAL_LoadKhachThue();
        
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = dal_loadkt.loadkhachthuetheomaphong(cbo_phong.SelectedValue.ToString());
        } 
        private void grv_khachthue_Click(object sender, EventArgs e)
        {
            int position = gridView_kt.FocusedRowHandle;
            try
            {
                NOIQUY nq = new NOIQUY();
                nq = dal_vipham.loadnoiquy(cbb_manoiquy.Text);
                string MAKT = gridView_kt.GetRowCellValue(position, "MAKT1").ToString();
   
                    txt_solan.Text = (bll_vipham.laylanvipham(MAKT, cbb_manoiquy.Text) + 1).ToString();
                if(Convert.ToInt32(txt_solan.Text)>=4)
                { 
                    txt_tienphat.Text = String.Format("{0:#,##0.##}", (Convert.ToDecimal(nq.HINHPHAT) * 2));
                }
                grv_vipham.DataSource = bll_vipham.Loadviphamtheoma(MAKT);
            }
            catch
            {
                return;
            }
        }
        BLL_SinhMa bll_sm = new BLL_SinhMa();
        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_solan.Enabled = txt_ghichu.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_huy.Enabled = btn_luu.Enabled = true;
            txt_mavp.Text = bll_sm.Sinhma_vipham();
            txt_ngayvipham.Enabled = true;
            txt_solan.Enabled = false;
            txt_ngayvipham.Enabled = true;
            txt_hinhphat.Enabled = false;
        }
        string makt;
        private void grv_vipham_Click(object sender, EventArgs e)
        {
            if(gridView_ViPham.RowCount>0)
            {
  
                int position = gridView_ViPham.FocusedRowHandle;
                try
                {
                    txt_solan.Text = gridView_ViPham.GetRowCellValue(position, "Solan").ToString();
                   // txt_ghichu.Text = gridView_ViPham.GetRowCellValue(position, "Ghichu").ToString();
                    cbb_manoiquy.Text = gridView_ViPham.GetRowCellValue(position, "Manoiquy").ToString();
                    txt_noidung.Text = gridView_ViPham.GetRowCellValue(position, "Noidung").ToString();
                    txt_mavp.Text= gridView_ViPham.GetRowCellValue(position, "MAVIPHAM1").ToString();
                    makt= gridView_ViPham.GetRowCellValue(position, "Makt").ToString();
                    txt_tienphat.Text = String.Format("{0:#,##0.##}", gridView_ViPham.GetRowCellValue(position, "TIENPHAT1"));
                    txt_ngayvipham.Text= gridView_ViPham.GetRowCellValue(position, "Ngayvipham").ToString();

                    btn_sua.Enabled = true;
                    btn_xoa.Enabled = true;
                    btn_them.Enabled = false;
                    btn_huy.Enabled = true;

                }
                catch { }

            }
            else
            {
                return;
            }    
        }
        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_solan.Clear();
            txt_ghichu.Clear();
            txt_ngayvipham.Clear();
            txt_tienphat.Clear();
            //btn_them.Enabled = true;
            //btn_sua.Enabled = false;
            //btn_xoa.Enabled = false;
            //btn_luu.Enabled = false;
            frm_vipham_Load(sender, e);
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            VIPHAM vp = new VIPHAM();
            vp.MAVIPHAM = txt_mavp.Text;
            int position = gridView_kt.FocusedRowHandle;
            vp.MANOIQUY = gridView_ViPham.GetRowCellValue(position, "Manoiquy").ToString();
            vp.MAKT = gridView_ViPham.GetRowCellValue(position, "Makt").ToString();

            if (bll_vipham.xoa_vipham(txt_mavp.Text) == true)
            {
                MessageBox.Show("Xóa thành công");
                grv_vipham.DataSource = bll_vipham.Loadviphamtheoma(vp.MAKT);
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            txt_solan.Enabled = false;
            txt_ghichu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_luu.Enabled = true;
            txt_ngayvipham.Enabled = true;
            
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int position = gridView_kt.FocusedRowHandle;
         
            string MAKT = gridView_kt.GetRowCellValue(position, "MAKT1").ToString();
          
            VIPHAM vp = new VIPHAM();
            vp.MAVIPHAM = txt_mavp.Text;
            vp.MANOIQUY = cbb_manoiquy.Text;
            vp.MAKT = MAKT;
            vp.NGAYVIPHAM = Convert.ToDateTime(txt_ngayvipham.Text);
            vp.LAN =Convert.ToInt32( txt_solan.Text);
            vp.GHICHU = txt_ghichu.Text;
            vp.MANV = txt_manv.Text;
            vp.TIENPHAT = Convert.ToDecimal(txt_tienphat.Text);
            if(txt_solan.Text==string.Empty && txt_ngayvipham.Text==string.Empty)
            {
                MessageBox.Show("Không được để trống");
            }    
            if(btn_them.Enabled==true && btn_sua.Enabled==false)
            {
                if(bll_vipham.them_vipham(vp)==true)
                {
                    MessageBox.Show("Thêm thành công");
                    grv_vipham.DataSource = bll_vipham.Loadviphamtheoma(MAKT);
                }    
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }    
            }
            if (btn_them.Enabled == false && btn_sua.Enabled == true)
            {
                //vp.MANOIQUY = gridView_ViPham.GetRowCellValue(position, "Manoiquy").ToString();
                vp.MANOIQUY = cbb_manoiquy.Text;
                vp.MAKT = makt;
                if (bll_vipham.sua_vipham(vp) == true)
                {
                    MessageBox.Show("sửa thành công");
                    grv_vipham.DataSource = bll_vipham.Loadviphamtheoma(MAKT);
                }
                else
                {
                    MessageBox.Show("sửa thất bại");
                }
            }
            btn_them.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_luu.Enabled = btn_huy.Enabled = false;
            txt_ngayvipham.Clear();
            txt_mavp.Text = bll_sm.Sinhma_vipham();
            txt_solan.Enabled = false;
            txt_tienphat.Enabled = false;
            txt_solan.Clear();
            txt_mavp.Clear();
          
        }
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public bool KTMANQ(string pma)
        {
            var kq = (from nq in data.NOIQUYs
                      where nq.MANOIQUY == pma
                      select nq).Count();
            if (kq > 0)
                return true;
            else
                return false;
        }
        private void cbb_manoiquy_Click(object sender, EventArgs e)
        {
            if(KTMANQ(cbb_manoiquy.Text)==false)
            {
                return;
            }    
            if (cbb_manoiquy.SelectedValue !=null)
            {
                NOIQUY nq = new NOIQUY();
                nq = dal_vipham.loadnoiquy(cbb_manoiquy.Text);
                txt_noidung.Text = nq.NOIDUNG;
                txt_hinhphat.Text = String.Format("{0:#,##0.##}", Convert.ToDecimal(nq.HINHPHAT));
                txt_tienphat.Text = String.Format("{0:#,##0.##}", (Convert.ToDecimal(nq.HINHPHAT)));
                int position = gridView_kt.FocusedRowHandle;
                try
                {
                    string MAKT = gridView_kt.GetRowCellValue(position, "MAKT1").ToString();
                    txt_solan.Text = (bll_vipham.laylanvipham(MAKT, cbb_manoiquy.Text) + 1).ToString();
                    if (Convert.ToInt32(txt_solan.Text) >= 4)
                    {
                        txt_tienphat.Text = String.Format("{0:#,##0.##}", (Convert.ToDecimal(nq.HINHPHAT) * 2));
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        private void btn_xuathd_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog folderBrowser = new OpenFileDialog();
                // Set validate names and check file exists to false otherwise windows will
                // not let you select "Folder Selection."
                folderBrowser.ValidateNames = false;
                folderBrowser.CheckFileExists = false;
                folderBrowser.CheckPathExists = true;
                // Always default to Folder Selection.
                folderBrowser.FileName = "Folder Selection.";
                string saveExcelFile = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\dsvipham.xlsx";
                string folderPath = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\dsvipham.xlsx";
                var a = DateTime.Now.Day.ToString();
                var b = DateTime.Now.Month.ToString();
                var c = DateTime.Now.Year.ToString();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    var fileCount = (from file in Directory.EnumerateFiles(folderPath, "*.xlsx", SearchOption.AllDirectories)
                                     select file).Count();
                    var s = fileCount + 1;
                    saveExcelFile = folderPath + "\\dsvipham" + s + "_" + a + "_" + b + "_" + c + ".xlsx";
                }

                // If directory does not exist, don't even try   folderPath
                Excel.Application xlApp = new Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("Lỗi không thể sử dụng được thư viện EXCEL");
                    return;
                }
                xlApp.Visible = false;

                object misValue = System.Reflection.Missing.Value;

                Workbook wb = xlApp.Workbooks.Add(misValue);

                Worksheet ws = (Worksheet)wb.Worksheets[1];

                if (ws == null)
                {
                    MessageBox.Show("Không thể tạo được WorkSheet");
                    return;
                }
                int row = 1;
                string fontName = "Times New Roman";
                int fontSizeTieuDe = 18;
                int fontSizeTenTruong = 14;
                int fontSizeNoiDung = 12;

                //Xuất dòng Tiêu đề của File báo cáo: Lưu ý 
                Range row1_TieuDe_ThongKeSanPham = ws.get_Range("A1", "J1");
                row1_TieuDe_ThongKeSanPham.Merge();
                row1_TieuDe_ThongKeSanPham.Font.Size = fontSizeTieuDe;
                row1_TieuDe_ThongKeSanPham.Font.Name = fontName;
                row1_TieuDe_ThongKeSanPham.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe_ThongKeSanPham.Value2 = "Danh sách vi phạm";


                //Tạo Ô Số Thứ Tự (STT)
                Range row23_STT = ws.get_Range("A2", "A3");//Cột A dòng 2 và dòng 3
                row23_STT.Merge();
                row23_STT.Font.Size = fontSizeTenTruong;
                row23_STT.Font.Name = fontName;
                row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_STT.Value2 = "STT";


                //Tạo Ô Mã loại hóa đơn :
                Range row23_makt = ws.get_Range("B2", "B3");//Cột B dòng 2 và dòng 3
                row23_makt.Merge();
                row23_makt.Font.Size = fontSizeTenTruong;
                row23_makt.Font.Name = fontName;
                row23_makt.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_makt.Value2 = "Mã nội dung ";

                //Tạo ô tháng năm :
                Range row23_tenkt = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_tenkt.Merge();

                row23_tenkt.Font.Size = fontSizeTenTruong;
                row23_tenkt.Font.Name = fontName;
                row23_tenkt.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenkt.ColumnWidth = 20;
                row23_tenkt.Value2 = "Nội dung";

                //Tạo ô tên tầng 
                Range row23_socm = ws.get_Range("D2", "D3");//Cột C dòng 2 và dòng 3
                row23_socm.Merge();
                row23_socm.Font.Size = fontSizeTenTruong;
                row23_socm.Font.Name = fontName;
                row23_socm.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_socm.ColumnWidth = 20;
                row23_socm.Value2 = "Mã khách thuê";

                //Tạo ô tên loại 
                Range row23_quequan = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
                row23_quequan.Merge();
                row23_quequan.Font.Size = fontSizeTenTruong;
                row23_quequan.Font.Name = fontName;
                row23_quequan.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_quequan.ColumnWidth = 20;
                row23_quequan.Value2 = "Tên khách thuê";
                //Tạo ô tên phong
                Range row23_matamtru = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
                row23_matamtru.Merge();
                row23_matamtru.Font.Size = fontSizeTenTruong;
                row23_matamtru.Font.Name = fontName;
                row23_matamtru.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_matamtru.ColumnWidth = 20;
                row23_matamtru.Value2 = "Số chứng minh";

                //Tạo ô tiền phòng
                Range row23_maphong = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
                row23_maphong.Merge();
                row23_maphong.Font.Size = fontSizeTenTruong;
                row23_maphong.Font.Name = fontName;
                row23_maphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_maphong.ColumnWidth = 20;
                row23_maphong.Value2 = "Ngày vi phạm";

                //Tạo ô tiền tiền điện
                Range row23_tenphong = ws.get_Range("H2", "H3");//Cột C dòng 2 và dòng 3
                row23_tenphong.Merge();
                row23_tenphong.Font.Size = fontSizeTenTruong;
                row23_tenphong.Font.Name = fontName;
                row23_tenphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenphong.ColumnWidth = 20;
                row23_tenphong.Value2 = "Số lần";



                //Tạo ô tiền tiền wifi
                Range row23_ngaylamgiay = ws.get_Range("I2", "I3");//Cột C dòng 2 và dòng 3
                row23_ngaylamgiay.Merge();
                row23_ngaylamgiay.Font.Size = fontSizeTenTruong;
                row23_ngaylamgiay.Font.Name = fontName;
                row23_ngaylamgiay.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_ngaylamgiay.ColumnWidth = 20;
                row23_ngaylamgiay.Value2 = "Hình phạt";

                //Tạo ô tiền số nước
                Range row23_quanhechutro = ws.get_Range("J2", "J3");//Cột C dòng 2 và dòng 3
                row23_quanhechutro.Merge();
                row23_quanhechutro.Font.Size = fontSizeTenTruong;
                row23_quanhechutro.Font.Name = fontName;
                row23_quanhechutro.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_quanhechutro.ColumnWidth = 20;
                row23_quanhechutro.Value2 = "Ghi chú";

                //Tô nền vàng các cột tiêu đề:
                Range row23_CotTieuDe = ws.get_Range("A2", "J3");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);


                int stt = 0;
                row = 3;//dữ liệu xuất bắt đầu từ dòng số 4 trong file Excel (khai báo 3 để vào vòng lặp nó ++ thành 4)


                for (int i = 0; i < gridView_ViPham.RowCount; i++)
                {
                    stt++;
                    row++;

                    string manoiquy = gridView_ViPham.GetRowCellValue(i, "Manoiquy").ToString();
                    string noidung = gridView_ViPham.GetRowCellValue(i, "Noidung").ToString();
                    string makhach = gridView_ViPham.GetRowCellValue(i, "Makt").ToString();
                    string tenkhach = gridView_ViPham.GetRowCellValue(i, "Tenkt").ToString();
                    string socmnd = gridView_ViPham.GetRowCellValue(i, "Socmnd").ToString();
                    string ngayvipham = gridView_ViPham.GetRowCellValue(i, "Ngayvipham").ToString().Substring(0, 11);
                    string solan = gridView_ViPham.GetRowCellValue(i, "Solan").ToString();
                    string Hinhphat = gridView_ViPham.GetRowCellValue(i, "Hinhphat").ToString();
                    string Ghichu ="";
                   


                    dynamic[] arr = { stt, manoiquy, noidung, makhach, tenkhach, socmnd, ngayvipham, solan, Hinhphat, Ghichu };
                    Range rowData = ws.get_Range("A" + row, "J" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;

                }
                //Kẻ khung toàn bộ
                BorderAround(ws.get_Range("A2", "J" + row));

                //Lưu file excel xuống Ổ cứng
                wb.SaveAs(saveExcelFile);

                //đóng file để hoàn tất quá trình lưu trữ
                wb.Close(true, misValue, misValue);
                //thoát và thu hồi bộ nhớ cho COM
                xlApp.Quit();
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(xlApp);

                //Mở File excel sau khi Xuất thành công
                System.Diagnostics.Process.Start(saveExcelFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Hàm kẻ khung cho Excel
        private void BorderAround(Range range)
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
        }
        //Hàm thu hồi bộ nhớ cho COM Excel
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }

        private void txt_tienphat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        DAL_Phong dal_phong = new DAL_Phong();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            KHACHTHUE kt = new KHACHTHUE();
            kt = dal_phong.loadkt(makt);
            string TenKT = kt.TENKT;
            string socmnd = kt.SOCMND;
            string NgayViPham = txt_ngayvipham.Text;
            string NoiDung = txt_noidung.Text;
            string HinhPhat = txt_tienphat.Text;
            string SoLan = txt_solan.Text;
            we.ThongTinViPham(TenKT, socmnd, NgayViPham, NoiDung, HinhPhat,SoLan);
        }
    }
}