using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using BLL.NghiepVu;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.XtraEditors.Filtering.Templates;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_quanlyhoadon : UserControl
    {
        BLL_TienPhongHangThang bll_tienPhong = new BLL_TienPhongHangThang();
        BLL_Phong bll_phong = new BLL_Phong();
        public frm_quanlyhoadon()
        {
            InitializeComponent();
        }

        private void frm_quanlyhoadon_Load(object sender, EventArgs e)
        {
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";
            grv_hoadon.DataSource = bll_tienPhong.LoadDataHoaDon();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_hoadon.DataSource = bll_tienPhong.LoadDataHoaDontheomaphong(cbo_phong.SelectedValue.ToString());
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_hoadon.DataSource = bll_tienPhong.LoadDataHoaDon();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
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
                string saveExcelFile = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\dshoadon.xlsx";
                string folderPath = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\dshoadon.xlsx";
                var a = DateTime.Now.Day.ToString();
                var b = DateTime.Now.Month.ToString();
                var c = DateTime.Now.Year.ToString();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    var fileCount = (from file in Directory.EnumerateFiles(folderPath, "*.xlsx", SearchOption.AllDirectories)
                                     select file).Count();
                    var s = fileCount + 1;
                    saveExcelFile = folderPath + "\\dshoadon" + s + "_" + a + "_" + b + "_" + c + ".xlsx";

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
                Range row1_TieuDe_ThongKeSanPham = ws.get_Range("A1", "R1");
                row1_TieuDe_ThongKeSanPham.Merge();
                row1_TieuDe_ThongKeSanPham.Font.Size = fontSizeTieuDe;
                row1_TieuDe_ThongKeSanPham.Font.Name = fontName;
                row1_TieuDe_ThongKeSanPham.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe_ThongKeSanPham.Value2 = "Danh sách hóa đơn";


                //Tạo Ô Số Thứ Tự (STT)
                Range row23_STT = ws.get_Range("A2", "A3");//Cột A dòng 2 và dòng 3
                row23_STT.Merge();
                row23_STT.Font.Size = fontSizeTenTruong;
                row23_STT.Font.Name = fontName;
                row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_STT.Value2 = "STT";


                //Tạo Ô Mã loại hóa đơn :
                Range row23_mahd = ws.get_Range("B2", "B3");//Cột B dòng 2 và dòng 3
                row23_mahd.Merge();
                row23_mahd.Font.Size = fontSizeTenTruong;
                row23_mahd.Font.Name = fontName;
                row23_mahd.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_mahd.Value2 = "Mã hóa đơn";

                //Tạo ô tháng năm :
                Range row23_thangnam = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_thangnam.Merge();
                
                row23_thangnam.Font.Size = fontSizeTenTruong;
                row23_thangnam.Font.Name = fontName;
                row23_thangnam.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_thangnam.ColumnWidth = 20;
                row23_thangnam.Value2 = "Tháng năm";

                //Tạo ô tên tầng 
                Range row23_tentang = ws.get_Range("D2", "D3");//Cột C dòng 2 và dòng 3
                row23_tentang.Merge();
                row23_tentang.Font.Size = fontSizeTenTruong;
                row23_tentang.Font.Name = fontName;
                row23_tentang.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tentang.ColumnWidth = 20;
                row23_tentang.Value2 = "Tên tầng";

                //Tạo ô tên loại 
                Range row23_tenphong = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
                row23_tenphong.Merge();
                row23_tenphong.Font.Size = fontSizeTenTruong;
                row23_tenphong.Font.Name = fontName;
                row23_tenphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenphong.ColumnWidth = 20;
                row23_tenphong.Value2 = "Tên phòng";
                //Tạo ô tên phong
                Range row23_sodiencu = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
                row23_sodiencu.Merge();
                row23_sodiencu.Font.Size = fontSizeTenTruong;
                row23_sodiencu.Font.Name = fontName;
                row23_sodiencu.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sodiencu.ColumnWidth = 20;
                row23_sodiencu.Value2 = "Số điện cũ";

                //Tạo ô tiền phòng
                Range row23_sodienmoi = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
                row23_sodienmoi.Merge();
                row23_sodienmoi.Font.Size = fontSizeTenTruong;
                row23_sodienmoi.Font.Name = fontName;
                row23_sodienmoi.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sodienmoi.ColumnWidth = 20;
                row23_sodienmoi.Value2 = "Số điện mới";

                //Tạo ô tiền tiền điện
                Range row23_sodien = ws.get_Range("H2", "H3");//Cột C dòng 2 và dòng 3
                row23_sodien.Merge();
                row23_sodien.Font.Size = fontSizeTenTruong;
                row23_sodien.Font.Name = fontName;
                row23_sodien.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sodien.ColumnWidth = 20;
                row23_sodien.Value2 = "Số điện";



                //Tạo ô tiền tiền wifi
                Range row23_tiendien = ws.get_Range("I2", "I3");//Cột C dòng 2 và dòng 3
                row23_tiendien.Merge();
                row23_tiendien.Font.Size = fontSizeTenTruong;
                row23_tiendien.Font.Name = fontName;
                row23_tiendien.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tiendien.ColumnWidth = 20;
                row23_tiendien.Value2 = "Tiền điện";

                
                //Tạo ô tiền tiền wifi
                Range row23_sonuoccu = ws.get_Range("J2", "J3");//Cột C dòng 2 và dòng 3
                row23_sonuoccu.Merge();
                row23_sonuoccu.Font.Size = fontSizeTenTruong;
                row23_sonuoccu.Font.Name = fontName;
                row23_sonuoccu.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sonuoccu.ColumnWidth = 20;
                row23_sonuoccu.Value2 = "Số nước cũ";
                //Tạo ô tiền số nước
                Range row23_sonuocmoi = ws.get_Range("K2", "K3");//Cột C dòng 2 và dòng 3
                row23_sonuocmoi.Merge();
                row23_sonuocmoi.Font.Size = fontSizeTenTruong;
                row23_sonuocmoi.Font.Name = fontName;
                row23_sonuocmoi.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sonuocmoi.ColumnWidth = 20;
                row23_sonuocmoi.Value2 = "Số nước mới";
                //Tạo ô tiền số nước
                Range row23_sonuoc = ws.get_Range("L2", "L3");//Cột C dòng 2 và dòng 3
                row23_sonuoc.Merge();
                row23_sonuoc.Font.Size = fontSizeTenTruong;
                row23_sonuoc.Font.Name = fontName;
                row23_sonuoc.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sonuoc.ColumnWidth = 20;
                row23_sonuoc.Value2 = "Số nước";

                //Tạo ô tiền số nước
                Range row23_tiennuoc = ws.get_Range("M2", "M3");//Cột C dòng 2 và dòng 3
                row23_tiennuoc.Merge();
                row23_tiennuoc.Font.Size = fontSizeTenTruong;
                row23_tiennuoc.Font.Name = fontName;
                row23_tiennuoc.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tiennuoc.ColumnWidth = 20;
                row23_tiennuoc.Value2 = "Tiền nước";

                //Tạo ô tiền số nước
                Range row23_rac = ws.get_Range("N2", "N3");//Cột C dòng 2 và dòng 3
                row23_rac.Merge();
                row23_rac.Font.Size = fontSizeTenTruong;
                row23_rac.Font.Name = fontName;
                row23_rac.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_rac.ColumnWidth = 20;
                row23_rac.Value2 = "Rác";

                //Tạo ô tiền số nước
                Range row23_wifi = ws.get_Range("O2", "O3");//Cột C dòng 2 và dòng 3
                row23_wifi.Merge();
                row23_wifi.Font.Size = fontSizeTenTruong;
                row23_wifi.Font.Name = fontName;
                row23_wifi.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_wifi.ColumnWidth = 20;
                row23_wifi.Value2 = "Wifi";

                //Tạo ô tiền số nước
                Range row23_tongtien = ws.get_Range("P2", "P3");//Cột C dòng 2 và dòng 3
                row23_tongtien.Merge();
                row23_tongtien.Font.Size = fontSizeTenTruong;
                row23_tongtien.Font.Name = fontName;
                row23_tongtien.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tongtien.ColumnWidth = 20;
                row23_tongtien.Value2 = "Tổng tiền";
                //Tạo ô tiền số nước
                Range row23_ngaylap = ws.get_Range("Q2", "Q3");//Cột C dòng 2 và dòng 3
                row23_ngaylap.Merge();
                row23_ngaylap.Font.Size = fontSizeTenTruong;
                row23_ngaylap.Font.Name = fontName;
                row23_ngaylap.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_ngaylap.ColumnWidth = 20;
                row23_ngaylap.Value2 = "Ngày lập";
                //Tạo ô tiền số nước
                Range row23_tinhtrang = ws.get_Range("R2", "R3");//Cột C dòng 2 và dòng 3
                row23_tinhtrang.Merge();
                row23_tinhtrang.Font.Size = fontSizeTenTruong;
                row23_tinhtrang.Font.Name = fontName;
                row23_tinhtrang.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tinhtrang.ColumnWidth = 20;
                row23_tinhtrang.Value2 = "Ngày lập";
                //Tô nền vàng các cột tiêu đề:
                Range row23_CotTieuDe = ws.get_Range("A2", "R3");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);


                int stt = 0;
                row = 3;//dữ liệu xuất bắt đầu từ dòng số 4 trong file Excel (khai báo 3 để vào vòng lặp nó ++ thành 4)
               
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    stt++;
                    row++;

                    string mahd = gridView1.GetRowCellValue(i, "MaHD").ToString();
                    string s = Convert.ToDateTime(gridView1.GetRowCellValue(i, "ThangNam")).ToString();
                    string thangnam = s.Substring(3, 7);
                    string TenTang = gridView1.GetRowCellValue(i, "TenTang").ToString();
                    string tenphong = gridView1.GetRowCellValue(i, "TenPhong").ToString();
                    string sodiencu = gridView1.GetRowCellValue(i, "SoDienCu").ToString();
                    string sodienmoi = gridView1.GetRowCellValue(i, "SoDienMoi").ToString();
                    string sodien = gridView1.GetRowCellValue(i, "SoDien").ToString();
                   
                    string Sonuoccu = gridView1.GetRowCellValue(i, "SoNuocCu").ToString();
                    string Sonuocmoi = gridView1.GetRowCellValue(i, "SoNuocMoi").ToString();
                    string SoNuoc = gridView1.GetRowCellValue(i, "SoNuoc").ToString();
                 
                   
                    
                    string ngaylap = gridView1.GetRowCellValue(i, "NgayLap").ToString().Substring(0, 11);
                    string tinhtrang = gridView1.GetRowCellValue(i, "TinhTrang").ToString();



                    dynamic[] arr = { stt, mahd, thangnam, TenTang, tenphong, sodiencu, sodienmoi, sodien, String.Format("{0:#,##0.##}", Convert.ToDecimal( gridView1.GetRowCellValue(i, "TienDien"))), Sonuoccu, Sonuocmoi, SoNuoc, String.Format("{0:#,##0.##}", Convert.ToDecimal(gridView1.GetRowCellValue(i, "TienNuoc"))), String.Format("{0:#,##0.##}", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Rac"))), String.Format("{0:#,##0.##}", Convert.ToDecimal( gridView1.GetRowCellValue(i, "Wifi"))), String.Format("{0:#,##0.##}",Convert.ToDecimal( gridView1.GetRowCellValue(i, "TongTien"))), ngaylap, tinhtrang};
                    Range rowData = ws.get_Range("A" + row, "R" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;
                }
                //Kẻ khung toàn bộ
                BorderAround(ws.get_Range("A2", "R" + row));

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
    }
}
