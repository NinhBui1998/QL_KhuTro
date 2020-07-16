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
using DAL.DuLieu;
using DAL;
using DAL.ThongKe;

namespace QuanLyKhuTro.user_thongkePhong
{
    public partial class frm_thongkehopdong : Form
    {
        public frm_thongkehopdong()
        {
            InitializeComponent();
        }
        WordExport we = new WordExport();
        int click;
        public int Click1 { get => click; set => click = value; }
        public DateTime? Tuthang { get => tuthang; set => tuthang = value; }
        public DateTime? Denthang { get => denthang; set => denthang = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
        public DateTime Thangnam { get => thangnam; set => thangnam = value; }

        DateTime? tuthang;
        DateTime? denthang;
        int thang;
        int nam;
        DateTime thangnam;
        DAL_thongkeHopDong dal_tkhd = new DAL_thongkeHopDong();
        private void frm_thongkehopdong_Load(object sender, EventArgs e)
        {
            if (click == 1)
            {
                if (thang != 0)
                {
                    grv_datphong.DataSource = dal_tkhd.loadhopdongtheothang(thang);
                }
                if (nam != 0)
                {
                    grv_datphong.DataSource = dal_tkhd.loadhopdongtheonam(nam);

                }
                if (Thangnam != Convert.ToDateTime("01/01/0001"))
                {
                    grv_datphong.DataSource = dal_tkhd.loadhopdongtheothangnam(Thangnam);
                }
            }
            else if (click == 2)
            {
                grv_datphong.DataSource = dal_tkhd.loadhopdongtheoquy(tuthang, denthang);
            }
            else
            {
                grv_datphong.DataSource = dal_tkhd.loadhopdong();
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
                string saveExcelFile = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\Thongkehopdong.xlsx";
                string folderPath = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\Thongkehopdong.xlsx";
                var a = DateTime.Now.Day.ToString();
                var b = DateTime.Now.Month.ToString();
                var c = DateTime.Now.Year.ToString();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    var fileCount = (from file in Directory.EnumerateFiles(folderPath, "*.xlsx", SearchOption.AllDirectories)
                                     select file).Count();
                    var s = fileCount + 1;
                    saveExcelFile = folderPath + "\\Thongkehopdong" + s + "_" + a + "_" + b + "_" + c + ".xlsx";
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
                row1_TieuDe_ThongKeSanPham.Value2 = "Thống kê doanh thu từ hợp đồng";


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
                row23_makt.Value2 = "Mã hợp đồng ";

                //Tạo ô tháng năm :
                Range row23_tenkt = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_tenkt.Merge();

                row23_tenkt.Font.Size = fontSizeTenTruong;
                row23_tenkt.Font.Name = fontName;
                row23_tenkt.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenkt.ColumnWidth = 20;
                row23_tenkt.Value2 = "Mã phòng";

                //Tạo ô tên tầng 
                Range row23_socm = ws.get_Range("D2", "D3");//Cột C dòng 2 và dòng 3
                row23_socm.Merge();
                row23_socm.Font.Size = fontSizeTenTruong;
                row23_socm.Font.Name = fontName;
                row23_socm.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_socm.ColumnWidth = 20;
                row23_socm.Value2 = "Tên phòng";

                //Tạo ô tên loại 
                Range row23_quequan = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
                row23_quequan.Merge();
                row23_quequan.Font.Size = fontSizeTenTruong;
                row23_quequan.Font.Name = fontName;
                row23_quequan.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_quequan.ColumnWidth = 20;
                row23_quequan.Value2 = "Mã khách thuê";
                //Tạo ô tên phong
                Range row23_matamtru = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
                row23_matamtru.Merge();
                row23_matamtru.Font.Size = fontSizeTenTruong;
                row23_matamtru.Font.Name = fontName;
                row23_matamtru.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_matamtru.ColumnWidth = 20;
                row23_matamtru.Value2 = "Tên khách thuê";

                //Tạo ô tiền phòng
                Range row23_maphong = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
                row23_maphong.Merge();
                row23_maphong.Font.Size = fontSizeTenTruong;
                row23_maphong.Font.Name = fontName;
                row23_maphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_maphong.ColumnWidth = 20;
                row23_maphong.Value2 = "Ngày lập";

                //Tạo ô tiền tiền điện
                Range row23_tenphong = ws.get_Range("H2", "H3");//Cột C dòng 2 và dòng 3
                row23_tenphong.Merge();
                row23_tenphong.Font.Size = fontSizeTenTruong;
                row23_tenphong.Font.Name = fontName;
                row23_tenphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenphong.ColumnWidth = 20;
                row23_tenphong.Value2 = "Ngày kết thúc hợp đồng";



                //Tạo ô tiền tiền wifi
                Range row23_ngaylamgiay = ws.get_Range("I2", "I3");//Cột C dòng 2 và dòng 3
                row23_ngaylamgiay.Merge();
                row23_ngaylamgiay.Font.Size = fontSizeTenTruong;
                row23_ngaylamgiay.Font.Name = fontName;
                row23_ngaylamgiay.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_ngaylamgiay.ColumnWidth = 20;
                row23_ngaylamgiay.Value2 = "Tiền cọc";

              

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


                for (int i = 0; i < gridView_datphong.RowCount; i++)
                {
                    stt++;
                    row++;
                    string mahopdong = gridView_datphong.GetRowCellValue(i, "Mahd").ToString();
                    string maphong = gridView_datphong.GetRowCellValue(i, "MAPHONG1").ToString();
                    string tenphong = gridView_datphong.GetRowCellValue(i, "TenPhong").ToString();
                    string makhach = gridView_datphong.GetRowCellValue(i, "Makt").ToString();
                    string tenkhach = gridView_datphong.GetRowCellValue(i, "Tenkt").ToString();
                    string ngaydat = gridView_datphong.GetRowCellValue(i, "NgayTra").ToString().Substring(0, 11);
                    string ngaytra = gridView_datphong.GetRowCellValue(i, "NgayTra").ToString().Substring(0, 11);
              
                    string tiencoc = String.Format("{0:#,##0.##}", gridView_datphong.GetRowCellValue(i, "Tiencoc").ToString());
                    
                    dynamic[] arr = {stt,mahopdong,maphong,tenphong,makhach,tenkhach,ngaydat,ngaytra, String.Format("{0:#,##0.##}", gridView_datphong.GetRowCellValue(i, "Tiencoc")) };
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
