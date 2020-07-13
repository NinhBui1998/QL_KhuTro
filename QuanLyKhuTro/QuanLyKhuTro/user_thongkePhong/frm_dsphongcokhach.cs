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

namespace QuanLyKhuTro.user_thongkePhong
{
    public partial class frm_dsphongcokhach : Form
    {
        BLL_KhachThue bll_kt = new BLL_KhachThue();
        BLL_DSPhong bll_ds = new BLL_DSPhong();
        public frm_dsphongcokhach()
        {
            InitializeComponent();
        }

        private void frm_dsphongcokhach_Load(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = bll_kt.loadphongcokhach();
            txt_tongphongdacoc.Text = bll_ds.tongphongcokhach();
        }
        QL_KhuTroDataContext data = new QL_KhuTroDataContext();
        public string laytenphong()
        {
            var kq = (from p in data.PHONGs
                      select p.TENPHONG).FirstOrDefault();
            return kq.ToString();
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
                string saveExcelFile = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\ThongKe_phongcokhach.xlsx";
                string folderPath = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\ThongKe_phongcokhach.xlsx";
                var a = DateTime.Now.Day.ToString();
                var b = DateTime.Now.Month.ToString();
                var c = DateTime.Now.Year.ToString();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    var fileCount = (from file in Directory.EnumerateFiles(folderPath, "*.xlsx", SearchOption.AllDirectories)
                                     select file).Count();
                    var s = fileCount + 1;
                    saveExcelFile = folderPath + "\\TK_phongcokhach" + s + "_" + a + "_" + b + "_" + c + ".xlsx";

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
                row1_TieuDe_ThongKeSanPham.Value2 = "Danh sách phòng có khách thuê";
                //Tạo Ô Số Thứ Tự (STT)
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
                row23_tenphong.Value2 = "Tên phòng";

                //Tạo ô tháng năm :
                Range row23_makt = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_makt.Merge();
                row23_makt.Font.Size = fontSizeTenTruong;
                row23_makt.Font.Name = fontName;
                row23_makt.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_makt.ColumnWidth = 20;
                row23_makt.Value2 = "Mã khách thuê";

                //Tạo ô tên tầng 
                Range row23_Tenkt = ws.get_Range("D2", "D3");//Cột C dòng 2 và dòng 3
                row23_Tenkt.Merge();
                row23_Tenkt.Font.Size = fontSizeTenTruong;
                row23_Tenkt.Font.Name = fontName;
                row23_Tenkt.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_Tenkt.ColumnWidth = 20;
                row23_Tenkt.Value2 = "Tên khách thuê";

                //Tạo ô tên loại 
                Range row23_gt = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
                row23_gt.Merge();
                row23_gt.Font.Size = fontSizeTenTruong;
                row23_gt.Font.Name = fontName;
                row23_gt.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_gt.ColumnWidth = 20;
                row23_gt.Value2 = "Giới tính";
                //Tạo ô tên phong
                Range row23_sdt = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
                row23_sdt.Merge();
                row23_sdt.Font.Size = fontSizeTenTruong;
                row23_sdt.Font.Name = fontName;
                row23_sdt.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_sdt.ColumnWidth = 20;
                row23_sdt.Value2 = "Số điện thoại";

                //Tạo ô tiền phòng
                Range row23_scm = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
                row23_scm.Merge();
                row23_scm.Font.Size = fontSizeTenTruong;
                row23_scm.Font.Name = fontName;
                row23_scm.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_scm.ColumnWidth = 20;
                row23_scm.Value2 = "Số chứng minh";

                //Tạo ô tiền tiền điện
                Range row23_ngaysinh = ws.get_Range("H2", "H3");//Cột C dòng 2 và dòng 3
                row23_ngaysinh.Merge();
                row23_ngaysinh.Font.Size = fontSizeTenTruong;
                row23_ngaysinh.Font.Name = fontName;
                row23_ngaysinh.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_ngaysinh.ColumnWidth = 20;
                row23_ngaysinh.Value2 = "Ngày sinh";

            

                //Tạo ô tiền tiền wifi
                Range row23_quequan = ws.get_Range("I2", "I3");//Cột C dòng 2 và dòng 3
                row23_quequan.Merge();
                row23_quequan.Font.Size = fontSizeTenTruong;
                row23_quequan.Font.Name = fontName;
                row23_quequan.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_quequan.ColumnWidth = 20;
                row23_quequan.Value2 = "Quê quán";

                //Tô nền vàng các cột tiêu đề:
                Range row23_CotTieuDe = ws.get_Range("A2", "I3");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);


                int stt = 0;
                row = 3;//dữ liệu xuất bắt đầu từ dòng số 4 trong file Excel (khai báo 3 để vào vòng lặp nó ++ thành 4)

                for (int i = 0; i < gridView_khachthue.RowCount; i++)
                {
                    stt++;
                    row++;
                    string tp = laytenphong();
                    string mkt= gridView_khachthue.GetRowCellValue(i, "MAKT").ToString();
                    string tenkt= gridView_khachthue.GetRowCellValue(i, "TENKT").ToString();
                    string GT = gridView_khachthue.GetRowCellValue(i, "GIOITINH").ToString();
                    string SDT = gridView_khachthue.GetRowCellValue(i, "SDT").ToString();
                    string SOCMND = gridView_khachthue.GetRowCellValue(i, "SOCMND").ToString();
                    string NGAYSINH = gridView_khachthue.GetRowCellValue(i, "NGAYSINH").ToString().Substring(0, 11);
                    string QUEQUAN = gridView_khachthue.GetRowCellValue(i, "QUEQUAN").ToString();

                    dynamic[] arr = {stt,tp,mkt,tenkt,GT,SDT,SOCMND,NGAYSINH,QUEQUAN };
                    Range rowData = ws.get_Range("A" + row, "I" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;
                }
                //Kẻ khung toàn bộ
                BorderAround(ws.get_Range("A2", "I" + row));

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
