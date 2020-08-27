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
using DAL.HeThong;

namespace QuanLyKhuTro.NghiepVu
{
    public partial class frm_tamtru : Form
    {
        BLL_tamtru bll_tamtru = new BLL_tamtru();
        BLL_SinhMa bll_sinhma = new BLL_SinhMa();
        BLL_Phong bll_phong = new BLL_Phong();
        BLL_KhachThue bll_khachthue = new BLL_KhachThue();
        BLL_DatPhong bll_datphong = new BLL_DatPhong();
       
        public frm_tamtru()
        {
            InitializeComponent();
        }
        string MaNV;

        public string Manv { get => MaNV; set => MaNV = value; }
        DAL_LoadKhachThue dal_kt = new DAL_LoadKhachThue();
        private void frm_tamtru_Load(object sender, EventArgs e)
        {
            
            cbo_phong.DataSource = bll_phong.loadBang_Phong();
            cbo_phong.DisplayMember = "TENPHONG";
            cbo_phong.ValueMember = "MAPHONG";

            //grv_khachthue.DataSource = bll_khachthue.loadBangKT();
            grv_khachthue.DataSource = dal_kt.loadkhachthue();
            txt_manv.Text = MaNV;
            txt_ngaylamgiay.Text = DateTime.Now.ToShortDateString();
            grv_tamtru.DataSource = bll_tamtru.Loadtamtru();
            txt_matt.Text = bll_sinhma.SinhMa_TAMTRU();
            txt_manv.Enabled = txt_makt.Enabled = txt_ngayhethan.Enabled = txt_quanhect.Enabled = false;
            btn_luu.Enabled = btn_sua.Enabled = btn_xoa.Enabled = false;
            btn_them.Enabled = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_ngayhethan.Clear(); txt_quanhect.Clear();
            txt_matt.Text = bll_sinhma.SinhMa_TAMTRU();
            txt_makt.Enabled = txt_ngayhethan.Enabled = txt_quanhect.Enabled = true;
            btn_luu.Enabled = true;
            btn_huy.Enabled = true;
            btn_sua.Enabled = btn_xoa.Enabled = false;
            txt_manv.Text = MaNV;
            txt_ngaylamgiay.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_makt.Clear(); txt_ngayhethan.Clear(); txt_quanhect.Clear();
        }
        
        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {

            TAMTRU tt = new TAMTRU();
            tt.MATAMTRU = txt_matt.Text;
            tt.MANV = txt_manv.Text;
            tt.MAKT = txt_makt.Text;
            tt.NGAYHETHAN_TAMTRU = Convert.ToDateTime(txt_ngayhethan.Text);
            tt.NGAYLAMGIAY = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            tt.QUANHEVOICHUTRO = txt_quanhect.Text;
            if(txt_makt.Text==string.Empty && txt_matt.Text==string.Empty && txt_manv.Text==string.Empty
                && txt_ngayhethan.Text==string.Empty && txt_ngaylamgiay.Text==string.Empty && txt_quanhect.Text==string.Empty)
            {
                MessageBox.Show("nhập đủ dữ liệu");
                return;
            }    
            if (btn_sua.Enabled == false && btn_them.Enabled == true)
            {
                if (bll_tamtru.them_tamtru(tt) == true)
                {
                    KHACHTHUE kt = new KHACHTHUE();
                    int position = gridView_kt.FocusedRowHandle;
                   
                        string MAKT = gridView_kt.GetRowCellValue(position, "MAKT1").ToString();
                        kt.MAKT = MAKT;

                    DateTime ngaydk = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    DateTime ngayhethan = Convert.ToDateTime(tt.NGAYHETHAN_TAMTRU);
                    TimeSpan Time = ngayhethan - ngaydk;
                    int TongSoNgay = Time.Days;
                    
                    if(TongSoNgay <= 7)
                    {
                        kt.TINHTRANGTAMTRU = "Sắp hết hạn đăng ký";
                    }    
                    if(TongSoNgay > 7)
                    {
                        kt.TINHTRANGTAMTRU = "đã đăng ký";
                    }    
                    if(bll_khachthue.sua_tinhtrangkt(kt)==true)
                    {
                        MessageBox.Show("Thành công");
                        //grv_khachthue.DataSource = bll_khachthue.loadBangKTtheoma(cbo_phong.SelectedValue.ToString());
                    }
                    else
                    {
                       MessageBox.Show("thất bại ");
                    }

                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            if (btn_sua.Enabled == true && btn_them.Enabled == false)
            {
                KHACHTHUE kt = new KHACHTHUE();
                int position = gridView_kt.FocusedRowHandle;

                string MAKT = gridView_kt.GetRowCellValue(position, "MAKT").ToString();
                kt.MAKT = MAKT;

                DateTime ngaydk = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                DateTime ngayhethan = Convert.ToDateTime(tt.NGAYHETHAN_TAMTRU);
                TimeSpan Time = ngayhethan - ngaydk;
                int TongSoNgay = Time.Days;

                if (TongSoNgay <= 7)
                {
                    kt.TINHTRANGTAMTRU = "Sắp hết hạn đăng ký";
                }
                if (TongSoNgay > 7)
                {
                    kt.TINHTRANGTAMTRU = "đã đăng ký";
                }
                if(bll_tamtru.sua_tamtru(tt)==true)
                    {   
                    if (bll_khachthue.sua_tinhtrangkt(kt) == true)
                    {
                        MessageBox.Show("Thành công");
                        grv_khachthue.DataSource = bll_khachthue.loadBangKTtheoma(cbo_phong.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("thất bại ");
                    }
                }
                    else
                    {
                        MessageBox.Show("thất bại ");
                    }
                }
            }
           catch
            {
                MessageBox.Show("Thất bại");
            }
            
            grv_tamtru.DataSource = bll_tamtru.Loadtamtrukt(txt_makt.Text);
            txt_matt.Text = bll_sinhma.SinhMa_TAMTRU();
            btn_luu.Enabled = btn_huy.Enabled = false;

        }

        private void grv_tamtru_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = false;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;
            btn_them.Enabled = true;
            int position = gridView_tamtru.FocusedRowHandle;
            try
            {
                txt_matt.Text = gridView_tamtru.GetRowCellValue(position, "MATT1").ToString();
                txt_manv.Text = gridView_tamtru.GetRowCellValue(position, "MANV1").ToString();
                txt_makt.Text = gridView_tamtru.GetRowCellValue(position, "MAKT1").ToString();
                txt_ngayhethan.Text = gridView_tamtru.GetRowCellValue(position, "NGAYHETHAN1").ToString();
                txt_ngaylamgiay.Text = gridView_tamtru.GetRowCellValue(position, "NGAYLAMGIAY1").ToString();
                txt_quanhect.Text = gridView_tamtru.GetRowCellValue(position, "QUANHEVOICHUTRO1").ToString();
            }
            catch { }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_luu.Enabled = true;
            btn_xoa.Enabled = false;
            btn_sua.Enabled = true;
            btn_huy.Enabled = true;
            btn_them.Enabled = false;
            txt_ngayhethan.Enabled = true;
            txt_ngaylamgiay.Text= DateTime.Now.ToShortDateString();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int position = gridView_tamtru.FocusedRowHandle;
            try
            {
                txt_matt.Text = gridView_tamtru.GetRowCellValue(position, "MATT1").ToString();
                if (bll_tamtru.xoa_tamtru(txt_matt.Text) == true)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }

            catch
            {
                return;
            }
            frm_tamtru_Load(sender,e);
        }

        private void btn_tatcahd_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = dal_kt.loadkhachthue();
            grv_tamtru.DataSource = bll_tamtru.Loadtamtru();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            grv_khachthue.DataSource = dal_kt.loadkhachthuetheomaphong(cbo_phong.SelectedValue.ToString());
        }

        private void grv_khachthue_Click(object sender, EventArgs e)
        {
            int position = gridView_kt.FocusedRowHandle;
            try
            {
               string MAKT = gridView_kt.GetRowCellValue(position, "MAKT1").ToString();
                txt_makt.Text = MAKT;
                grv_tamtru.DataSource = bll_tamtru.Loadtamtrukt(MAKT);
            }
            catch
            {
                return;
            }
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
                string saveExcelFile = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\dstamtru.xlsx";
                string folderPath = @"E:\DA_TotNghiep\GitHub\QL_KhuTro\dstamtru.xlsx";
                var a = DateTime.Now.Day.ToString();
                var b = DateTime.Now.Month.ToString();
                var c = DateTime.Now.Year.ToString();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    var fileCount = (from file in Directory.EnumerateFiles(folderPath, "*.xlsx", SearchOption.AllDirectories)
                                     select file).Count();
                    var s = fileCount + 1;
                    saveExcelFile = folderPath + "\\dstamtru" + s + "_" + a + "_" + b + "_" + c + ".xlsx";

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
                row1_TieuDe_ThongKeSanPham.Value2 = "Danh sách tạm trú khách thuê";


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
                row23_makt.Value2 = "Mã tạm trú";

                //Tạo ô tháng năm :
                Range row23_tenkt = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_tenkt.Merge();

                row23_tenkt.Font.Size = fontSizeTenTruong;
                row23_tenkt.Font.Name = fontName;
                row23_tenkt.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenkt.ColumnWidth = 20;
                row23_tenkt.Value2 = "Mã khách thuê";

                //Tạo ô tên tầng 
                Range row23_socm = ws.get_Range("D2", "D3");//Cột C dòng 2 và dòng 3
                row23_socm.Merge();
                row23_socm.Font.Size = fontSizeTenTruong;
                row23_socm.Font.Name = fontName;
                row23_socm.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_socm.ColumnWidth = 20;
                row23_socm.Value2 = "Tên khách thuê";

                //Tạo ô tên loại 
                Range row23_quequan = ws.get_Range("E2", "E3");//Cột C dòng 2 và dòng 3
                row23_quequan.Merge();
                row23_quequan.Font.Size = fontSizeTenTruong;
                row23_quequan.Font.Name = fontName;
                row23_quequan.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_quequan.ColumnWidth = 20;
                row23_quequan.Value2 = "Mã phòng";
                //Tạo ô tên phong
                Range row23_matamtru = ws.get_Range("F2", "F3");//Cột C dòng 2 và dòng 3
                row23_matamtru.Merge();
                row23_matamtru.Font.Size = fontSizeTenTruong;
                row23_matamtru.Font.Name = fontName;
                row23_matamtru.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_matamtru.ColumnWidth = 20;
                row23_matamtru.Value2 = "Tên phòng";

                //Tạo ô tiền phòng
                Range row23_maphong = ws.get_Range("G2", "G3");//Cột C dòng 2 và dòng 3
                row23_maphong.Merge();
                row23_maphong.Font.Size = fontSizeTenTruong;
                row23_maphong.Font.Name = fontName;
                row23_maphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_maphong.ColumnWidth = 20;
                row23_maphong.Value2 = "Ngày làm giấy";

                //Tạo ô tiền tiền điện
                Range row23_tenphong = ws.get_Range("H2", "H3");//Cột C dòng 2 và dòng 3
                row23_tenphong.Merge();
                row23_tenphong.Font.Size = fontSizeTenTruong;
                row23_tenphong.Font.Name = fontName;
                row23_tenphong.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_tenphong.ColumnWidth = 20;
                row23_tenphong.Value2 = "Ngày hết hạn";



                //Tạo ô tiền tiền wifi
                Range row23_ngaylamgiay = ws.get_Range("I2", "I3");//Cột C dòng 2 và dòng 3
                row23_ngaylamgiay.Merge();
                row23_ngaylamgiay.Font.Size = fontSizeTenTruong;
                row23_ngaylamgiay.Font.Name = fontName;
                row23_ngaylamgiay.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_ngaylamgiay.ColumnWidth = 20;
                row23_ngaylamgiay.Value2 = "Tình trạng";
                
                //Tạo ô tiền số nước
                Range row23_quanhechutro = ws.get_Range("J2", "J3");//Cột C dòng 2 và dòng 3
                row23_quanhechutro.Merge();
                row23_quanhechutro.Font.Size = fontSizeTenTruong;
                row23_quanhechutro.Font.Name = fontName;
                row23_quanhechutro.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_quanhechutro.ColumnWidth = 20;
                row23_quanhechutro.Value2 = "Quan hệ với chủ trọ";
                
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

              
                    for (int i = 0; i < gridView_tamtru.RowCount; i++)
                    {
                        stt++;
                        row++;

                        string matamtru = gridView_tamtru.GetRowCellValue(i, "MATT1").ToString();
                        string makhach = gridView_tamtru.GetRowCellValue(i, "MAKT1").ToString();
                        string tenkhach = gridView_tamtru.GetRowCellValue(i, "TENKT1").ToString();
                        string tenphong= gridView_tamtru.GetRowCellValue(i, "TENPHONG1").ToString();
                        string maphong = bll_datphong.laymaphong(tenphong);
                        string ngaylamgiay= gridView_tamtru.GetRowCellValue(i, "NGAYLAMGIAY1").ToString().Substring(0,11);
                        string ngayhethan= gridView_tamtru.GetRowCellValue(i, "NGAYHETHAN1").ToString().Substring(0, 11);
                    DateTime ngayht = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        DateTime ngayhethantt = Convert.ToDateTime(gridView_tamtru.GetRowCellValue(i, "NGAYHETHAN1"));
                        TimeSpan Time = ngayhethantt - ngayht;
                        int ngay = Time.Days;
                        string tinhtrang;
                        if (ngay<=7)
                        {
                             tinhtrang = "Sắp hết hạn tạm trú";
                        }
                         else if (ngay == 0)
                        {
                            tinhtrang = "Đã hết hạn đăng ký tạm trú";
                        }
                        else 
                        {
                            tinhtrang = "Đã đăng ký tạm trú";
                        }
                        string quanhechutro= gridView_tamtru.GetRowCellValue(i, "QUANHEVOICHUTRO1").ToString();


                    dynamic[] arr = {stt,matamtru,makhach,tenkhach,maphong, tenphong,ngaylamgiay, ngayhethan, tinhtrang, quanhechutro };
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
    }
}
