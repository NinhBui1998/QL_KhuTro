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
using DAL;
using BLL;
using BLL.NghiepVu;
using BLL.ThongKe;
using DevExpress.XtraGrid.Views.Grid;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace QuanLyKhuTro.ThongKe
{
    public partial class frm_tkdoanhthu : DevExpress.XtraEditors.XtraForm
    {
        BLL_TienPhongHangThang bll_tienphong = new BLL_TienPhongHangThang();
        BLL_HoaDon bll_hd = new BLL_HoaDon();
        BLL_ThongKeDoanhThu bll_thongkedt = new BLL_ThongKeDoanhThu();
        public frm_tkdoanhthu()
        {
            InitializeComponent();
        }

        private void frm_tkdoanhthu_Load(object sender, EventArgs e)
        {


            grv_hoadon.DataSource = bll_tienphong.LoadDataHoaDon();
            decimal TongDoanhThu = bll_thongkedt.tinhtongdoanhthu() + bll_thongkedt.tongtiencoc() + bll_thongkedt.tongtienvipham();
            txt_tongdt.Text = String.Format("{0:#,##0.##}", TongDoanhThu);
            txt_tongtiendien.Text = String.Format("{0:#,##0.##}", bll_thongkedt.tinhtongtiendien());
            txt_tongtiennuoc.Text = String.Format("{0:#,##0.##}", bll_thongkedt.tinhtongtiennuoc());
            txt_tongtienphong.Text = String.Format("{0:#,##0.##}", bll_thongkedt.tinhtongtienphong());
            txt_tongtienrac.Text = String.Format("{0:#,##0.##}", bll_thongkedt.tinhtongtienrac());
            txt_tienwifi.Text = String.Format("{0:#,##0.##}", bll_thongkedt.tinhtongTienwifi());
            txt_tiencoc.Text = String.Format("{0:#,##0.##}", bll_thongkedt.tongtiencoc());
            txt_tienvipham.Text = String.Format("{0:#,##0.##}", bll_thongkedt.tongtienvipham());
            txt_no.Text = String.Format("{0:#,##0.##}", bll_thongkedt.tongno());

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ckb_thang.Checked == true)
            {

                grv_hoadon.DataSource = bll_thongkedt.loadtkdoanhthutheothang(Convert.ToInt32(cbb_thang.Text));


            }
            if (ckb_nam.Checked == true)
            {
                grv_hoadon.DataSource = bll_thongkedt.loadtkdoanhthutheonam(Convert.ToInt32( txt_nam.Text));

            }

            if (ckb_thang.Checked == true && ckb_nam.Checked == true)
            {
                if (txt_nam.Text == string.Empty)
                {
                    MessageBox.Show("nhâp năm");
                    return;
                }
                grv_hoadon.DataSource = bll_thongkedt.loadtkdoanhthutheothangnam(Convert.ToDateTime("05"+cbb_thang.Text + '/' + txt_nam.Text));
            }
            if (ckb_thang.Checked == false && ckb_nam.Checked == false)
            {
                if (txt_nam.Text == string.Empty)
                {
                    MessageBox.Show("nhâp năm");
                    return;
                }
                grv_hoadon.DataSource = bll_thongkedt.loadtkdoanhthutheothangnam(Convert.ToDateTime("05" + cbb_thang.Text + '/' + txt_nam.Text));
            }
            //tong doanh thu
            Decimal Tong = 0;
            for (int k = 0; k < gridView_hoadon.RowCount; k++)
            {
                DataRow drAmount = gridView_hoadon.GetDataRow(k);
                Tong += Convert.ToDecimal(gridView_hoadon.GetRowCellValue(k, "TongTien"));
            }
            txt_tongdt.Text = string.Empty;
            txt_tongdt.Text = String.Format("{0:#,##0.##}", Tong);
            //tong phong
            Decimal Tong1 = 0;
            for (int k = 0; k < gridView_hoadon.RowCount; k++)
            {
                DataRow drAmount = gridView_hoadon.GetDataRow(k);
                Tong1 += Convert.ToDecimal(gridView_hoadon.GetRowCellValue(k, "TIENPHONG1"));
            }
            txt_tongtienphong.Text = string.Empty;
            txt_tongtienphong.Text = String.Format("{0:#,##0.##}", Tong1);
            //tong rac
            Decimal Tong2 = 0;
            for (int k = 0; k < gridView_hoadon.RowCount; k++)
            {
                DataRow drAmount = gridView_hoadon.GetDataRow(k);
                Tong2 += Convert.ToDecimal(gridView_hoadon.GetRowCellValue(k, "Rac"));
            }
            txt_tongtienrac.Text = string.Empty;
            txt_tongtienrac.Text = String.Format("{0:#,##0.##}", Tong2);
            // tong điện
            Decimal Tong3 = 0;
            for (int k = 0; k < gridView_hoadon.RowCount; k++)
            {
                DataRow drAmount = gridView_hoadon.GetDataRow(k);
                Tong3 += Convert.ToDecimal(gridView_hoadon.GetRowCellValue(k, "TienDien"));
            }
            txt_tongtiendien.Text = string.Empty;
            txt_tongtiendien.Text = String.Format("{0:#,##0.##}", Tong3);
            //tổng nước
            Decimal Tong4 = 0;
            for (int k = 0; k < gridView_hoadon.RowCount; k++)
            {
                DataRow drAmount = gridView_hoadon.GetDataRow(k);
                Tong4 += Convert.ToDecimal(gridView_hoadon.GetRowCellValue(k, "TienNuoc"));
            }
            txt_tongtiennuoc.Text = string.Empty;
            txt_tongtiennuoc.Text = String.Format("{0:#,##0.##}", Tong4);
            //tổng tiền wifi
            Decimal Tong5 = 0;
            for (int k = 0; k < gridView_hoadon.RowCount; k++)
            {
                DataRow drAmount = gridView_hoadon.GetDataRow(k);
                Tong5 += Convert.ToDecimal(gridView_hoadon.GetRowCellValue(k, "Wifi"));
            }
            txt_tienwifi.Text = string.Empty;
            txt_tienwifi.Text = String.Format("{0:#,##0.##}", Tong5);

        }

        private void btn_tinhtunam_Click(object sender, EventArgs e)
        {
            if (txt_tuthang.Text == string.Empty)
            {
                MessageBox.Show("Nhập năm");
                return;
            }
            if (txt_denthang.Text == string.Empty)
            {
                MessageBox.Show("Nhập năm");
                return;
            }
            DateTime? tuthang =Convert.ToDateTime("01"+"/"+ cbb_tuthang.Text + '/' + txt_tuthang.Text);
            DateTime? denthang = Convert.ToDateTime("30" + "/" + cbb_denthang.Text + '/' + txt_denthang.Text);
            
            grv_hoadon.DataSource = bll_thongkedt.loadtkdoanhthutheoquy(tuthang, denthang);
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
                string saveExcelFile = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\ThongKe_DT.xlsx";
                string folderPath = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\ThongKe_DT.xlsx";
                var a = DateTime.Now.Day.ToString();
                var b = DateTime.Now.Month.ToString();
                var c = DateTime.Now.Year.ToString();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    var fileCount = (from file in Directory.EnumerateFiles(folderPath, "*.xlsx", SearchOption.AllDirectories)
                                     select file).Count();
                    var s = fileCount + 1;
                    saveExcelFile = folderPath + "\\BB_doanhthu" + s + "_" + a + "_" + b + "_" + c + ".xlsx";

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
                Range row1_TieuDe_ThongKeSanPham = ws.get_Range("A1", "N1");
                row1_TieuDe_ThongKeSanPham.Merge();
                row1_TieuDe_ThongKeSanPham.Font.Size = fontSizeTieuDe;
                row1_TieuDe_ThongKeSanPham.Font.Name = fontName;
                row1_TieuDe_ThongKeSanPham.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe_ThongKeSanPham.Value2 = "Thống kê doanh thu";

                //Tạo Ô Số Thứ Tự (STT)
                Range row23_STT = ws.get_Range("A2", "A3");//Cột A dòng 2 và dòng 3
                row23_STT.Merge();
                row23_STT.Font.Size = fontSizeTenTruong;
                row23_STT.Font.Name = fontName;
                row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_STT.Value2 = "STT";

                //Tạo Ô Mã loại hóa đơn :
                Range row23_Loaihodon = ws.get_Range("B2", "B3");//Cột B dòng 2 và dòng 3
                row23_Loaihodon.Merge();
                row23_Loaihodon.Font.Size = fontSizeTenTruong;
                row23_Loaihodon.Font.Name = fontName;
                row23_Loaihodon.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_Loaihodon.Value2 = "Mã hóa đơn";

                //Tạo ô tháng năm :
                Range row23_Thangnam = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_Thangnam.Merge();
                row23_Thangnam.Font.Size = fontSizeTenTruong;
                row23_Thangnam.Font.Name = fontName;
                row23_Thangnam.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_Thangnam.ColumnWidth = 20;
                row23_Thangnam.Value2 = "Tháng năm";

                //Tạo ô tên tầng 
                Range row23_Tang = ws.get_Range("D2", "D3");//Cột C dòng 2 và dòng 3
                row23_Tang.Merge();
                row23_Tang.Font.Size = fontSizeTenTruong;
                row23_Tang.Font.Name = fontName;
                row23_Tang.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_Tang.ColumnWidth = 20;
                row23_Tang.Value2 = "Tầng";

                //Tạo ô tên loại 
                Range row23_Loại = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
                row23_Loại.Merge();
                row23_Loại.Font.Size = fontSizeTenTruong;
                row23_Loại.Font.Name = fontName;
                row23_Loại.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_Loại.ColumnWidth = 20;
                row23_Loại.Value2 = "Loại";

                //Tạo ô tên phong
                Range row23_phong = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
                row23_phong.Merge();
                row23_phong.Font.Size = fontSizeTenTruong;
                row23_phong.Font.Name = fontName;
                row23_phong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_phong.ColumnWidth = 20;
                row23_phong.Value2 = "Phòng";
                //Tạo ô tiền phòng
                Range row23_tienphong = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
                row23_tienphong.Merge();
                row23_tienphong.Font.Size = fontSizeTenTruong;
                row23_tienphong.Font.Name = fontName;
                row23_tienphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tienphong.ColumnWidth = 20;
                row23_tienphong.Value2 = "Tiền phòng";

                //Tạo ô tiền tiền điện
                Range row23_tiendien = ws.get_Range("H2", "H3");//Cột C dòng 2 và dòng 3
                row23_tiendien.Merge();
                row23_tiendien.Font.Size = fontSizeTenTruong;
                row23_tiendien.Font.Name = fontName;
                row23_tiendien.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tiendien.ColumnWidth = 20;
                row23_tiendien.Value2 = "Tiền điện";

                //Tạo ô tiền tiền nước
                Range row23_tiennuoc = ws.get_Range("I2", "I3");//Cột C dòng 2 và dòng 3
                row23_tiennuoc.Merge();
                row23_tiennuoc.Font.Size = fontSizeTenTruong;
                row23_tiennuoc.Font.Name = fontName;
                row23_tiennuoc.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tiennuoc.ColumnWidth = 20;
                row23_tiennuoc.Value2 = "Tiền nước";

                //Tạo ô tiền tiền wifi
                Range row23_tienwifi = ws.get_Range("J2", "J3");//Cột C dòng 2 và dòng 3
                row23_tienwifi.Merge();
                row23_tienwifi.Font.Size = fontSizeTenTruong;
                row23_tienwifi.Font.Name = fontName;
                row23_tienwifi.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tienwifi.ColumnWidth = 20;
                row23_tienwifi.Value2 = "Tiền wifi";


                //Tạo ô tiền tiền rác
                Range row23_tienrac = ws.get_Range("K2", "K3");//Cột C dòng 2 và dòng 3
                row23_tienrac.Merge();
                row23_tienrac.Font.Size = fontSizeTenTruong;
                row23_tienrac.Font.Name = fontName;
                row23_tienrac.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tienrac.ColumnWidth = 20;
                row23_tienrac.Value2 = "Tiền rác";

                //Tạo ô tiền ngày lập 
                Range row23_ngaylap = ws.get_Range("L2", "L3");//Cột C dòng 2 và dòng 3
                row23_ngaylap.Merge();
                row23_ngaylap.Font.Size = fontSizeTenTruong;
                row23_ngaylap.Font.Name = fontName;
                row23_ngaylap.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_ngaylap.ColumnWidth = 20;
                row23_ngaylap.Value2 = "Ngày lập";

                //Tạo ô tiền Tổng tiền
                Range row23_tongtien = ws.get_Range("M2", "M3");//Cột C dòng 2 và dòng 3
                row23_tongtien.Merge();
                row23_tongtien.Font.Size = fontSizeTenTruong;
                row23_tongtien.Font.Name = fontName;
                row23_tongtien.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tongtien.ColumnWidth = 20;
                row23_tongtien.Value2 = "Tổng tiền";

                //Tạo ô tiền Tên nhân viên
                Range row23_nhanvien = ws.get_Range("N2", "N3");//Cột C dòng 2 và dòng 3
                row23_nhanvien.Merge();
                row23_nhanvien.Font.Size = fontSizeTenTruong;
                row23_nhanvien.Font.Name = fontName;
                row23_nhanvien.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_nhanvien.ColumnWidth = 20;
                row23_nhanvien.Value2 = "Tên nhân viên ";

                //Tạo ô tiền Tên nhân viên
                //Range row23_tinhtrang = ws.get_Range("O2", "O3");//Cột C dòng 2 và dòng 3
                //row23_tinhtrang.Merge();
                //row23_tinhtrang.Font.Size = fontSizeTenTruong;
                //row23_tinhtrang.Font.Name = fontName;
                //row23_tinhtrang.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //row23_tinhtrang.ColumnWidth = 20;
                //row23_tinhtrang.Value2 = "Tình trạng";

                //Tô nền vàng các cột tiêu đề:
                Range row23_CotTieuDe = ws.get_Range("A2", "N3");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Green);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);


                int stt = 0;
                row = 3;//dữ liệu xuất bắt đầu từ dòng số 4 trong file Excel (khai báo 3 để vào vòng lặp nó ++ thành 4)

                for (int i = 0; i < gridView_hoadon.RowCount; i++)
                {
                    stt++;
                    row++;
                    String s = gridView_hoadon.GetRowCellValue(i, "ThangNam").ToString();
                    string ng = gridView_hoadon.GetRowCellValue(i, "NgayLap").ToString().Substring(0, 11);
                    dynamic[] arr = { stt, gridView_hoadon.GetRowCellValue(i, "MaHD"), s, gridView_hoadon.GetRowCellValue(i, "TenTang"), gridView_hoadon.GetRowCellValue(i, "TENLOAI1"), gridView_hoadon.GetRowCellValue(i, "TenPhong"), String.Format("{0:#,##0.##}", gridView_hoadon.GetRowCellValue(i, "TIENPHONG1")), String.Format("{0:#,##0.##}", gridView_hoadon.GetRowCellValue(i, "TienDien")), String.Format("{0:#,##0.##}", gridView_hoadon.GetRowCellValue(i, "TienNuoc")), String.Format("{0:#,##0.##}", gridView_hoadon.GetRowCellValue(i, "Wifi")), String.Format("{0:#,##0.##}", gridView_hoadon.GetRowCellValue(i, "Rac")), ng, String.Format("{0:#,##0.##}", gridView_hoadon.GetRowCellValue(i, "TongTien")), gridView_hoadon.GetRowCellValue(i, "TenNV") };

                    Range rowData = ws.get_Range("A" + row, "N" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;
                }
                //Kẻ khung toàn bộ
                BorderAround(ws.get_Range("A2", "N" + row));

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

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            grv_hoadon.DataSource = bll_thongkedt.loadHoaDonconno();

        }
    }
}