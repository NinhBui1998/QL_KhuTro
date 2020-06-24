using DAL.Export;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.DuLieu
{
    public class WordExport
    {
        #region ---- Constants & Enum -----

        
        private const string FILE_QUYETDINHKHENTHUONG = "BM11";


        #endregion

        #region --- Member Variables ----

        private bool _IsPringPriview = false;

        #endregion

        #region --- Private medthods ---


        /// PrinPreview the document
        /// </summary>
        /// <param name="fileToPrint"></param>
        private void PrinPriview(string fileToPrint)
        {
            object missing = System.Type.Missing;
            object objFile = fileToPrint;
            object readOnly = true;
            object addToRecentOpen = false;

            // Create  a new Word application           
            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            try
            {
                // Create a new file based on our template
                Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Open(ref objFile, ref missing, ref readOnly, ref addToRecentOpen);

                wordApplication.Options.SaveNormalPrompt = false;

                if (wordDocument != null)
                {
                    // Show print preview
                    wordApplication.Visible = true;
                    wordDocument.PrintPreview();
                    wordDocument.Activate();
                    //wordDocument.op
                    while (!_IsPringPriview)
                    {
                        wordDocument.ActiveWindow.View.Magnifier = true;
                        Thread.Sleep(500);
                    }

                    wordDocument.Close(ref missing, ref missing, ref missing);
                    wordDocument = null;
                }
            }
            catch
            {
                //I didn't include a default error handler so i'm just throwing the error
                // throw ex;
            }
            finally
            {
                // Finally, Close our Word application
                wordApplication.Quit(ref missing, ref missing, ref missing);
                wordApplication = null;
            }
        }

        /// <summary>
        /// Manage WordExport_DocumentBeforeClose
        /// </summary>
        /// <param name="Doc"></param>
        /// <param name="Cancel"></param>
        private void WordExport_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
        {
            _IsPringPriview = false;
        }

        /// <summary>
        /// Merges the specified files to merge.
        /// </summary>
        /// <param name="filesToMerge">The files to merge.</param>
        /// <param name="outputFilename">The output filename.</param>
        /// <param name="insertPageBreaks">if set to <c>true</c> [insert page breaks].</param>
        private void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            string fileTempate = Global.AppPath + Constants.FOLDER_TEMPLATES +
                                 Constants.CHAR_FLASH + Constants.FILE_NORMAL_DOT;
            Merge(filesToMerge, outputFilename, insertPageBreaks, fileTempate);
        }

        /// <summary>
        /// A function that merges Microsoft Word Documents that uses a template specified by the user
        /// </summary>
        /// <param name="filesToMerge">An array of files that we want to merge</param>
        /// <param name="outputFilename">The filename of the merged document</param>
        /// <param name="insertPageBreaks">Set to true if you want to have page breaks inserted after each document</param>
        /// <param name="documentTemplate">The word document you want to use to serve as the template</param>
        private void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks, string documentTemplate)
        {
            object defaultTemplate = documentTemplate;
            object missing = System.Type.Missing;
            object pageBreak = Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
            object outputFile = outputFilename;

            // Create  a new Word application
            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            if (filesToMerge.Count() == 1)
                pageBreak = false;
            try
            {
                // Create a new file based on our template
                Microsoft.Office.Interop.Word._Document wordDocument = wordApplication.Documents.Add(ref defaultTemplate, ref missing, ref missing, ref missing);

                // Make a Word selection object.
                Microsoft.Office.Interop.Word.Selection selection = wordApplication.Selection;

                int index = 0;

                // Loop thru each of the Word documents
                foreach (string file in filesToMerge)
                {
                    // Insert the files to our template
                    selection.InsertFile(file, ref missing, ref missing, ref missing, ref missing);

                    //Do we want page breaks added after each documents?
                    if (insertPageBreaks && index != filesToMerge.Count() - 1)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }

                    index++;
                }

                // Save the document to it's output file.
                wordDocument.SaveAs(ref outputFile, ref missing, ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing, ref missing, ref missing,
                                     ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                // Clean up!
                wordDocument.Close(ref missing, ref missing, ref missing);
                wordDocument = null;
            }
            catch (Exception ex)
            {
                //I didn't include a default error handler so i'm just throwing the error
                throw ex;
            }
            finally
            {
                // Finally, Close our Word application
                wordApplication.Quit(ref missing, ref missing, ref missing);
            }
        }

        /// <summary>
        /// Page setup the word document
        /// </summary>
        /// <param name="document"></param>
        private void PageSetup(ref WordDocument document)
        {
            foreach (WSection section in document.Sections)
            {

                // Setting Page Margins
                section.PageSetup.Margins.Top = 72f;
                section.PageSetup.Margins.Bottom = 90f;
                section.PageSetup.Margins.Left = 72f;
                section.PageSetup.Margins.Right = 72f;

                section.PageSetup.HeaderDistance = 1;
                section.PageSetup.FooterDistance = 1;

                //Setup page size
                section.PageSetup.PageSize = PageSize.A4;

                // Setting the Page Orientation as Portrait or Landscape
                section.PageSetup.Orientation = PageOrientation.Landscape;
            }
        }

        #endregion

        public void QuyetDinhKhenThuong(string pNgay, string pThang, string pNam, string pHoVaTen, string pSoQD)
        {
            #region ===== Core======
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileThongtinSV = string.Empty;
            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;
            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }
            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOC);
            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }
            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHKHENTHUONG;
            try
            {
                // Read template
                mStream = new MemoryStream(File.ReadAllBytes("abc.doc").ToArray());// I
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch
            {

                return;
            }

            fileThongtinSV = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + "abc" + Constants.FILE_EXT_DOC;// II

            //Prepare to mailMerg
            DateTime SysDate = DateTime.Now;
            #endregion =====  End Core=====

            #region === Set value =====//III



            string[] fields = new string[] { "Ngay", "Thang", "Nam", "HoVaTen", "SoQD" };


            string[] values = new string[] { pNgay, pThang, pNam, pHoVaTen, pSoQD };


            #endregion End Set Value=====

            #region =====Core=====
            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileThongtinSV, FormatType.Doc);

            // Close the document after save
            document.Close();


            this.PrinPriview(fileThongtinSV);

            #endregion =====  End Core=====
        }

        public void ThongTinHopDong(string pMaHD, string pNgay, string pThang, string pNam, string pTenNV, string pNgaySinhNV,
            string pCmndNV, string pQueQuanNV,string pSdtNV,string pTenKT,string pNgaySinhKT, string pCmndKT,string pQueQuanKT,
            string pSdtKT,string pTenPhong, string pLoaiPhong,string pTang,string pGiaThue,string pTienCoc,
            string pNgayKT,string pThangKT,string pNamKT)
        {
            #region ===== Core======
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileThongtinhopdong = string.Empty;
            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;
            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }
            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOCS);
            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }
            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHKHENTHUONG;
            try
            {
                // Read template
                mStream = new MemoryStream(File.ReadAllBytes("thongtinhopdong.docx").ToArray());// I
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch (Exception ex)
            {

                return;
            }


            fileThongtinhopdong = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + "thongtinhopdong" + Constants.FILE_EXT_DOCS;// II

            //Prepare to mailMerg
            DateTime SysDate = DateTime.Now;
            #endregion =====  End Core=====

            #region === Set value =====//III



            string[] fields = new string[] {"MaHD","Ngay", "Thang", "Nam","TenNV", "NgaySinhNV","CmndNV","QueQuanNV","SdtNV",
                "TenKT","NgaySinhKT","CmndKT","QueQuanKT","SdtKT","TenPhong","LoaiPhong","Tang","GiaThue","TienCoc","NgayKT","ThangKT","NamKT"};

            string[] values = new string[] {pMaHD,pNgay, pThang, pNam,pTenNV,pNgaySinhNV,pCmndNV, pQueQuanNV,pSdtNV,pTenKT,
                pNgaySinhKT,pCmndKT,pQueQuanKT,pSdtKT,pTenPhong, pLoaiPhong,pTang, pGiaThue, pTienCoc,pNgayKT,pThangKT,pNamKT};
          
            #endregion End Set Value=====

            #region =====Core=====
            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileThongtinhopdong, FormatType.Docx);

            // Close the document after save
            document.Close();


            this.PrinPriview(fileThongtinhopdong);

            #endregion =====  End Core=====
        }

        public void ThongTinTraPhong(string pNgayTra, string pTenPhong, string pTenKT, string pTraCoc, string pCSDDau,
            string pCSDCuoi, string pDonGiaDien, string pTienDien, string pCSNDau, string pCSNCuoi, string PDonGiaNuoc,
            string pTienNuoc, string pDonGiaWifi, string pDonGiaRac, string pTongTien)
        {
            #region ===== Core======
            MemoryStream mStream = null;
            WordDocument document = null;
            string fileThongtintraphong= string.Empty;
            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;
            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }
            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOCS);
            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }
            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHKHENTHUONG;
            try
            {
                // Read template
                mStream = new MemoryStream(File.ReadAllBytes("thongtintraphong.docx").ToArray());// I
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch (Exception ex)
            {

                return;
            }


            fileThongtintraphong = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + "thongtintraphong" + Constants.FILE_EXT_DOCS;// II

            //Prepare to mailMerg
            DateTime SysDate = DateTime.Now;
            #endregion =====  End Core=====

            #region === Set value =====//III



            string[] fields = new string[] {"NgayTra","TenPhong", "TenKT", "TraCoc","CSDDau", "CSDCuoi","DonGiaDien",
                "TienDien","CSNDau","CSNCuoi","DonGiaNuoc","TienNuoc","DonGiaWifi","DonGiaRac","TongTien"};

            string[] values = new string[] {pNgayTra,pTenPhong, pTenKT, pTraCoc,pCSDDau,pCSDCuoi,pDonGiaDien, pTienDien,
                pCSNDau,pCSNCuoi,PDonGiaNuoc,pTienNuoc,pDonGiaWifi,pDonGiaRac,pTongTien};

            #endregion End Set Value=====

            #region =====Core=====
            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(fileThongtintraphong, FormatType.Docx);

            // Close the document after save
            document.Close();


            this.PrinPriview(fileThongtintraphong);

            #endregion =====  End Core=====
        }
        public void PhieuThuTienTro(string pNgayLap, string pTenPhong,string pTenTang, string pTienPhong, string pCSDDau,
           string pCSDCuoi, string pDonGiaDien, string pTienDien, string pCSNDau, string pCSNCuoi, string PDonGiaNuoc,
           string pTienNuoc, string pDonGiaWifi, string pDonGiaRac, string pTongTien,string pMaPhieuThu, string pMaNV, string pTenNV)
        {
            #region ===== Core======
            MemoryStream mStream = null;
            WordDocument document = null;
            string filePhieuThuTienTro = string.Empty;
            // Create currency format
            CultureInfo vietnam = new CultureInfo(1066);
            NumberFormatInfo vnfi = vietnam.NumberFormat;
            vnfi.CurrencySymbol = Constants.VN_UNIT;
            vnfi.CurrencyDecimalSeparator = Constants.CHAR_COMMA;
            vnfi.CurrencyDecimalDigits = 0;
            //Create Temp Folder if it does not exist
            if (!Directory.Exists(Global.AppPath + Constants.FOLDER_TEMP))
            {
                Directory.CreateDirectory(Global.AppPath + Constants.FOLDER_TEMP);
            }
            //Gets DocFile is Existed
            string[] DocFile = Directory.GetFiles(Global.AppPath + Constants.FOLDER_TEMP +
                        Constants.CHAR_FLASH, Constants.CHAR_STAR + Constants.FILE_EXT_DOCS);
            //Delete *.doc file if existed
            foreach (string file in DocFile)
            {
                File.Delete(file);
            }
            //string path = Global.AppPath + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + FILE_QUYETDINHKHENTHUONG;
            try
            {
                // Read template
                mStream = new MemoryStream(File.ReadAllBytes("phieuthutientro.docx").ToArray());// I
                document = new WordDocument(mStream);
                mStream.Close();
            }
            catch (Exception ex)
            {

                return;
            }


            filePhieuThuTienTro = Global.AppPath + Constants.FOLDER_TEMP +
                            Constants.CHAR_FLASH + "phieuthutientro" + Constants.FILE_EXT_DOCS;// II

            //Prepare to mailMerg
            DateTime SysDate = DateTime.Now;
            #endregion =====  End Core=====

            #region === Set value =====//III



            string[] fields = new string[] {"NgayLap","TenPhong","TenTang", "TienPhong","CSDDau", "CSDCuoi","DonGiaDien",
                "TienDien","CSNDau","CSNCuoi","DonGiaNuoc","TienNuoc","DonGiaWifi","DonGiaRac","TongTien","MaPhieuThu","MaNV","TenNV"};

            string[] values = new string[] {pNgayLap,pTenPhong,pTenTang, pTienPhong,pCSDDau,pCSDCuoi,pDonGiaDien, pTienDien,
                pCSNDau,pCSNCuoi,PDonGiaNuoc,pTienNuoc,pDonGiaWifi,pDonGiaRac,pTongTien,pMaPhieuThu,pMaNV,pTenNV};

            #endregion End Set Value=====

            #region =====Core=====
            // Begin mailMerg document
            document.MailMerge.Execute(fields, values);

            // Save document to file
            document.Save(filePhieuThuTienTro, FormatType.Docx);

            // Close the document after save
            document.Close();


            this.PrinPriview(filePhieuThuTienTro);

            #endregion =====  End Core=====
        }
    }
}
