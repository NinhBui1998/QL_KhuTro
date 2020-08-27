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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.XtraEditors;

namespace QuanLyKhuTro.NghiepVu
{
    
    public partial class frm_quanlyhopdong : XtraForm
    {
        BLL_DatPhong datphong = new BLL_DatPhong();
        BLL_Phong bll_phong = new BLL_Phong();
        public frm_quanlyhopdong()
        {
            InitializeComponent();
        }

        private void frm_quanlyhopdong_Load(object sender, EventArgs e)
        {
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";
            grv_datphong.DataSource = datphong.LoadDatPhong();
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_datphong.DataSource = datphong.LoadDatPhong();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_datphong.DataSource = datphong.LoadDatPhongTheoten(cbo_phong.Text);
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
                    folderPath = System.IO.Path.GetDirectoryName(folderBrowser.FileName);
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
                Range row1_TieuDe_ThongKeSanPham = ws.get_Range("A1", "J1");
                row1_TieuDe_ThongKeSanPham.Merge();
                row1_TieuDe_ThongKeSanPham.Font.Size = fontSizeTieuDe;
                row1_TieuDe_ThongKeSanPham.Font.Name = fontName;
                row1_TieuDe_ThongKeSanPham.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe_ThongKeSanPham.Value2 = "Danh sách hợp đồng";


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
                row23_mahd.Value2 = "Mã hợp đồng";

                //Tạo ô tháng năm :
                Range row23_thangnam = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_thangnam.Merge();

                row23_thangnam.Font.Size = fontSizeTenTruong;
                row23_thangnam.Font.Name = fontName;
                row23_thangnam.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_thangnam.ColumnWidth = 20;
                row23_thangnam.Value2 = "Tên phòng";

                //Tạo ô tên tầng 
                Range row23_tentang = ws.get_Range("D2", "D3");//Cột C dòng 2 và dòng 3
                row23_tentang.Merge();
                row23_tentang.Font.Size = fontSizeTenTruong;
                row23_tentang.Font.Name = fontName;
                row23_tentang.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tentang.ColumnWidth = 20;
                row23_tentang.Value2 = "Tên nhân viên";

                //Tạo ô tên loại 
                Range row23_tenphong = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
                row23_tenphong.Merge();
                row23_tenphong.Font.Size = fontSizeTenTruong;
                row23_tenphong.Font.Name = fontName;
                row23_tenphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenphong.ColumnWidth = 20;
                row23_tenphong.Value2 = "Mã khách thuê";
                //Tạo ô tên phong
                Range row23_sodiencu = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
                row23_sodiencu.Merge();
                row23_sodiencu.Font.Size = fontSizeTenTruong;
                row23_sodiencu.Font.Name = fontName;
                row23_sodiencu.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sodiencu.ColumnWidth = 20;
                row23_sodiencu.Value2 = "Tên khách thuê";

                //Tạo ô tiền phòng
                Range row23_sodienmoi = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
                row23_sodienmoi.Merge();
                row23_sodienmoi.Font.Size = fontSizeTenTruong;
                row23_sodienmoi.Font.Name = fontName;
                row23_sodienmoi.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sodienmoi.ColumnWidth = 20;
                row23_sodienmoi.Value2 = "Ngày lập";

                //Tạo ô tiền tiền điện
                Range row23_sodien = ws.get_Range("H2", "H3");//Cột C dòng 2 và dòng 3
                row23_sodien.Merge();
                row23_sodien.Font.Size = fontSizeTenTruong;
                row23_sodien.Font.Name = fontName;
                row23_sodien.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sodien.ColumnWidth = 20;
                row23_sodien.Value2 = "Ngày trả";



                //Tạo ô tiền tiền wifi
                Range row23_tiendien = ws.get_Range("I2", "I3");//Cột C dòng 2 và dòng 3
                row23_tiendien.Merge();
                row23_tiendien.Font.Size = fontSizeTenTruong;
                row23_tiendien.Font.Name = fontName;
                row23_tiendien.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tiendien.ColumnWidth = 20;
                row23_tiendien.Value2 = "Tiền cọc";


                //Tạo ô tiền tiền wifi
                Range row23_sonuoccu = ws.get_Range("J2", "J3");//Cột C dòng 2 và dòng 3
                row23_sonuoccu.Merge();
                row23_sonuoccu.Font.Size = fontSizeTenTruong;
                row23_sonuoccu.Font.Name = fontName;
                row23_sonuoccu.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sonuoccu.ColumnWidth = 20;
                row23_sonuoccu.Value2 = "Tình trạng";
                
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

                for (int i = 0; i < gridView_datphong.RowCount; i++)
                {
                    stt++;
                    row++;

                    string mahd = gridView_datphong.GetRowCellValue(i, "Mahd").ToString();
                    string maphong= gridView_datphong.GetRowCellValue(i, "MAPHONG1").ToString();
                    string tenphong= gridView_datphong.GetRowCellValue(i, "TenPhong").ToString();
                    string tennv= gridView_datphong.GetRowCellValue(i, "Tennv").ToString();
                    string makt= gridView_datphong.GetRowCellValue(i, "Makt").ToString();
                    string tenkt= gridView_datphong.GetRowCellValue(i, "Tenkt").ToString();
                    string ngaylap= gridView_datphong.GetRowCellValue(i, "NgayLap").ToString().Substring(0, 11);
                    string ngaytra= gridView_datphong.GetRowCellValue(i, "NgayTra").ToString().Substring(0, 11);
                    string coc= String.Format("{0:#,##0.##}", Convert.ToDecimal(gridView_datphong.GetRowCellValue(i, "Tiencoc").ToString()));
                    string tinhtrang= gridView_datphong.GetRowCellValue(i, "TINHTRANG1").ToString();


                    dynamic[] arr = {stt, mahd,tenphong,tennv,makt,tenkt,ngaylap,ngaytra,coc,tinhtrang  };
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
