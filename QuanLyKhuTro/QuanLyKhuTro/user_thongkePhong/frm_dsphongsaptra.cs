using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using BLL.ThongKe;
using DAL;
using BLL;
using BLL.NghiepVu;

namespace QuanLyKhuTro.user_thongkePhong
{
    public partial class frm_dsphongsaptra : Form
    {
        BLL_ThongKePhong bll_tkp = new BLL_ThongKePhong();
        BLL_DSPhong bll_dsp = new BLL_DSPhong();
        BLL_Phong bll_phong = new BLL_Phong();
        public frm_dsphongsaptra()
        {
            InitializeComponent();
        }
        
        
        private void frm_dsphongsaptra_Load(object sender, EventArgs e)
        {
            grv_tkphong.DataSource = bll_tkp.loadphongsapdenhan();
            txt_tongphongdacoc.Text = bll_dsp.tongphongsapdenhan();
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
                string saveExcelFile = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\TK_phongsaptra.xlsx";
                string folderPath = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\TK_phongsaptra.xlsx";
                var a = DateTime.Now.Day.ToString();
                var b = DateTime.Now.Month.ToString();
                var c = DateTime.Now.Year.ToString();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    var fileCount = (from file in Directory.EnumerateFiles(folderPath, "*.xlsx", SearchOption.AllDirectories)
                                     select file).Count();
                    var s = fileCount + 1;
                    saveExcelFile = folderPath + "\\TK_phongsaptra" + s + "_" + a + "_" + b + "_" + c + ".xlsx";

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
                Range row1_TieuDe_ThongKeSanPham = ws.get_Range("A1", "I1");
                row1_TieuDe_ThongKeSanPham.Merge();
                row1_TieuDe_ThongKeSanPham.Font.Size = fontSizeTieuDe;
                row1_TieuDe_ThongKeSanPham.Font.Name = fontName;
                row1_TieuDe_ThongKeSanPham.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe_ThongKeSanPham.Value2 = "Danh sách phòng sắp trả";
                Range row23_STT = ws.get_Range("A2", "A3");//Cột A dòng 2 và dòng 3
                row23_STT.Merge();
                row23_STT.Font.Size = fontSizeTenTruong;
                row23_STT.Font.Name = fontName;
                row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_STT.Value2 = "STT";

                //Tạo Ô Mã loại hóa đơn :
                Range row23_tenphong = ws.get_Range("B2", "B3");//Cột B dòng 2 và dòng 3
                row23_tenphong.Merge();
                row23_tenphong.Font.Size = fontSizeTenTruong;
                row23_tenphong.Font.Name = fontName;
                row23_tenphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenphong.Value2 = "Mã phòng";

                //Tạo Ô Mã loại hóa đơn :
                Range row23_maphong = ws.get_Range("C2", "C3");//Cột B dòng 2 và dòng 3
                row23_maphong.Merge();
                row23_maphong.Font.Size = fontSizeTenTruong;
                row23_maphong.Font.Name = fontName;
                row23_maphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_maphong.Value2 = "Tên phòng";

                //Tạo ô tháng năm :
                Range row23_slht = ws.get_Range("D2", "D3");//Cột C dòng 2 và dòng 3
                row23_slht.Merge();
                row23_slht.Font.Size = fontSizeTenTruong;
                row23_slht.Font.Name = fontName;
                row23_slht.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_slht.ColumnWidth = 20;
                row23_slht.Value2 = "Số lượng hiện tại";

                //Tạo ô tên tầng 
                Range row23_sltoida = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
                row23_sltoida.Merge();
                row23_sltoida.Font.Size = fontSizeTenTruong;
                row23_sltoida.Font.Name = fontName;
                row23_sltoida.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sltoida.ColumnWidth = 20;
                row23_sltoida.Value2 = "Số lượng tối đa";
                //Tạo ô tên loại 
                Range row23_tinhtrang = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
                row23_tinhtrang.Merge();
                row23_tinhtrang.Font.Size = fontSizeTenTruong;
                row23_tinhtrang.Font.Name = fontName;
                row23_tinhtrang.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tinhtrang.ColumnWidth = 20;
                row23_tinhtrang.Value2 = "Tình trạng";
                //Tạo ô tên loại 
                Range row23_tentang = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
                row23_tentang.Merge();
                row23_tentang.Font.Size = fontSizeTenTruong;
                row23_tentang.Font.Name = fontName;
                row23_tentang.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tentang.ColumnWidth = 20;
                row23_tentang.Value2 = "Tên tầng";
                //Tạo ô tên phong
                Range row23_tenloai = ws.get_Range("H2", "H3");//Cột C dòng 2 và dòng 3
                row23_tenloai.Merge();
                row23_tenloai.Font.Size = fontSizeTenTruong;
                row23_tenloai.Font.Name = fontName;
                row23_tenloai.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenloai.ColumnWidth = 20;
                row23_tenloai.Value2 = "Tên loại";





                //Tô nền vàng các cột tiêu đề:
                Range row23_CotTieuDe = ws.get_Range("A2", "H3");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);


                int stt = 0;
                row = 3;//dữ liệu xuất bắt đầu từ dòng số 4 trong file Excel (khai báo 3 để vào vòng lặp nó ++ thành 4)

                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    stt++;
                    row++;

                    string mp = gridView3.GetRowCellValue(i, "MAPHONG1").ToString();
                    string tenp = gridView3.GetRowCellValue(i, "TENPHONG1").ToString();
                    string slht = gridView3.GetRowCellValue(i, "SOLUONG_HT1").ToString();
                    string sltd = gridView3.GetRowCellValue(i, "SOLUONG_TD1").ToString();
                    string tinhtrang = gridView3.GetRowCellValue(i, "TINHTRANG1").ToString();
                    string tentang = gridView3.GetRowCellValue(i, "TENTANG1").ToString();
                    string tenloai = gridView3.GetRowCellValue(i, "TENLOAI1").ToString();


                    dynamic[] arr = { stt, mp, tenp, slht, sltd, tinhtrang, tenloai, tentang };
                    Range rowData = ws.get_Range("A" + row, "H" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;
                }
                //Kẻ khung toàn bộ
                BorderAround(ws.get_Range("A2", "H" + row));

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
