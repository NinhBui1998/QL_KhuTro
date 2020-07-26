namespace QuanLyKhuTro.NghiepVu
{
    partial class frm_quanlyhoadon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_quanlyhoadon));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grb_thongtinphong = new System.Windows.Forms.GroupBox();
            this.grv_hoadon = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THANGNAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenTang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SODIENCU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SODIENMOI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoDien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TienDien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SONUOCCU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SONUOCMOI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TienNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Wifi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TINHTRANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_timkiem = new DevExpress.XtraEditors.SimpleButton();
            this.cbo_phong = new System.Windows.Forms.ComboBox();
            this.btn_tatcahd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grb_thongtinphong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_hoadon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(919, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(322, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ HÓA ĐƠN";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.grb_thongtinphong, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 82);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(913, 415);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // grb_thongtinphong
            // 
            this.grb_thongtinphong.Controls.Add(this.grv_hoadon);
            this.grb_thongtinphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb_thongtinphong.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_thongtinphong.ForeColor = System.Drawing.Color.Red;
            this.grb_thongtinphong.Location = new System.Drawing.Point(3, 3);
            this.grb_thongtinphong.Name = "grb_thongtinphong";
            this.grb_thongtinphong.Size = new System.Drawing.Size(907, 409);
            this.grb_thongtinphong.TabIndex = 11;
            this.grb_thongtinphong.TabStop = false;
            this.grb_thongtinphong.Text = "Thông tin hóa đơn tiền phòng";
            // 
            // grv_hoadon
            // 
            this.grv_hoadon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grv_hoadon.Location = new System.Drawing.Point(3, 26);
            this.grv_hoadon.MainView = this.gridView1;
            this.grv_hoadon.Name = "grv_hoadon";
            this.grv_hoadon.Size = new System.Drawing.Size(901, 380);
            this.grv_hoadon.TabIndex = 2;
            this.grv_hoadon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaHD,
            this.THANGNAM,
            this.TenTang,
            this.TenPhong,
            this.SODIENCU,
            this.SODIENMOI,
            this.SoDien,
            this.TienDien,
            this.SONUOCCU,
            this.SONUOCMOI,
            this.SoNuoc,
            this.TienNuoc,
            this.Wifi,
            this.Rac,
            this.gridColumn1,
            this.NgayLap,
            this.TongTien,
            this.TenNV,
            this.TINHTRANG});
            this.gridView1.GridControl = this.grv_hoadon;
            this.gridView1.Name = "gridView1";
            // 
            // MaHD
            // 
            this.MaHD.Caption = "Mã hóa đơn";
            this.MaHD.FieldName = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.Visible = true;
            this.MaHD.VisibleIndex = 0;
            // 
            // THANGNAM
            // 
            this.THANGNAM.Caption = "Tháng năm";
            this.THANGNAM.FieldName = "ThangNam";
            this.THANGNAM.Name = "THANGNAM";
            this.THANGNAM.Visible = true;
            this.THANGNAM.VisibleIndex = 1;
            // 
            // TenTang
            // 
            this.TenTang.Caption = "Tên tầng";
            this.TenTang.FieldName = "TenTang";
            this.TenTang.Name = "TenTang";
            this.TenTang.Visible = true;
            this.TenTang.VisibleIndex = 2;
            // 
            // TenPhong
            // 
            this.TenPhong.Caption = "Tên Phòng";
            this.TenPhong.FieldName = "TenPhong";
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.Visible = true;
            this.TenPhong.VisibleIndex = 3;
            // 
            // SODIENCU
            // 
            this.SODIENCU.Caption = "Số điện cũ";
            this.SODIENCU.FieldName = "SoDienCu";
            this.SODIENCU.Name = "SODIENCU";
            this.SODIENCU.Visible = true;
            this.SODIENCU.VisibleIndex = 4;
            // 
            // SODIENMOI
            // 
            this.SODIENMOI.Caption = "Số điện mới";
            this.SODIENMOI.FieldName = "SoDienMoi";
            this.SODIENMOI.Name = "SODIENMOI";
            this.SODIENMOI.Visible = true;
            this.SODIENMOI.VisibleIndex = 5;
            // 
            // SoDien
            // 
            this.SoDien.Caption = "Số điện";
            this.SoDien.FieldName = "SoDien";
            this.SoDien.Name = "SoDien";
            this.SoDien.Visible = true;
            this.SoDien.VisibleIndex = 6;
            // 
            // TienDien
            // 
            this.TienDien.Caption = "Tiền điện";
            this.TienDien.DisplayFormat.FormatString = "#,###";
            this.TienDien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TienDien.FieldName = "TienDien";
            this.TienDien.Name = "TienDien";
            this.TienDien.Visible = true;
            this.TienDien.VisibleIndex = 7;
            // 
            // SONUOCCU
            // 
            this.SONUOCCU.Caption = "Số nước cũ";
            this.SONUOCCU.FieldName = "SoNuocCu";
            this.SONUOCCU.Name = "SONUOCCU";
            this.SONUOCCU.Visible = true;
            this.SONUOCCU.VisibleIndex = 8;
            // 
            // SONUOCMOI
            // 
            this.SONUOCMOI.Caption = "Số nước mới";
            this.SONUOCMOI.FieldName = "SoNuocMoi";
            this.SONUOCMOI.Name = "SONUOCMOI";
            this.SONUOCMOI.Visible = true;
            this.SONUOCMOI.VisibleIndex = 9;
            // 
            // SoNuoc
            // 
            this.SoNuoc.Caption = "Số nước";
            this.SoNuoc.FieldName = "SoNuoc";
            this.SoNuoc.Name = "SoNuoc";
            this.SoNuoc.Visible = true;
            this.SoNuoc.VisibleIndex = 10;
            // 
            // TienNuoc
            // 
            this.TienNuoc.Caption = "Tiền nước";
            this.TienNuoc.DisplayFormat.FormatString = "#,###";
            this.TienNuoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TienNuoc.FieldName = "TienNuoc";
            this.TienNuoc.Name = "TienNuoc";
            this.TienNuoc.Visible = true;
            this.TienNuoc.VisibleIndex = 11;
            // 
            // Wifi
            // 
            this.Wifi.Caption = "Tiền Wifi";
            this.Wifi.DisplayFormat.FormatString = "#,###";
            this.Wifi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Wifi.FieldName = "Wifi";
            this.Wifi.Name = "Wifi";
            this.Wifi.Visible = true;
            this.Wifi.VisibleIndex = 12;
            // 
            // Rac
            // 
            this.Rac.Caption = "Tiền rác";
            this.Rac.DisplayFormat.FormatString = "#,###";
            this.Rac.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Rac.FieldName = "Rac";
            this.Rac.Name = "Rac";
            this.Rac.Visible = true;
            this.Rac.VisibleIndex = 13;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tiền phòng";
            this.gridColumn1.DisplayFormat.FormatString = "#,###";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "TIENPHONG1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 14;
            // 
            // NgayLap
            // 
            this.NgayLap.Caption = "Ngày lập";
            this.NgayLap.FieldName = "NgayLap";
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.Visible = true;
            this.NgayLap.VisibleIndex = 15;
            // 
            // TongTien
            // 
            this.TongTien.Caption = "Tổng tiền";
            this.TongTien.DisplayFormat.FormatString = "#,###";
            this.TongTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TongTien.FieldName = "TongTien";
            this.TongTien.Name = "TongTien";
            this.TongTien.Visible = true;
            this.TongTien.VisibleIndex = 16;
            // 
            // TenNV
            // 
            this.TenNV.Caption = "Tên nhân viên";
            this.TenNV.FieldName = "TenNV";
            this.TenNV.Name = "TenNV";
            this.TenNV.Visible = true;
            this.TenNV.VisibleIndex = 17;
            // 
            // TINHTRANG
            // 
            this.TINHTRANG.Caption = "Tình trạng";
            this.TINHTRANG.FieldName = "TinhTrang";
            this.TINHTRANG.Name = "TINHTRANG";
            this.TINHTRANG.Visible = true;
            this.TINHTRANG.VisibleIndex = 18;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.47387F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.52613F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel3.Controls.Add(this.btn_timkiem, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbo_phong, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_tatcahd, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.simpleButton3, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(913, 37);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_timkiem.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.Appearance.Options.UseFont = true;
            this.btn_timkiem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_timkiem.ImageOptions.SvgImage")));
            this.btn_timkiem.Location = new System.Drawing.Point(164, 8);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(30, 21);
            this.btn_timkiem.TabIndex = 7;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // cbo_phong
            // 
            this.cbo_phong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_phong.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_phong.FormattingEnabled = true;
            this.cbo_phong.Location = new System.Drawing.Point(3, 5);
            this.cbo_phong.Name = "cbo_phong";
            this.cbo_phong.Size = new System.Drawing.Size(155, 27);
            this.cbo_phong.TabIndex = 3;
            // 
            // btn_tatcahd
            // 
            this.btn_tatcahd.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tatcahd.Appearance.Options.UseFont = true;
            this.btn_tatcahd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tatcahd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_tatcahd.ImageOptions.SvgImage")));
            this.btn_tatcahd.Location = new System.Drawing.Point(592, 3);
            this.btn_tatcahd.Name = "btn_tatcahd";
            this.btn_tatcahd.Size = new System.Drawing.Size(143, 31);
            this.btn_tatcahd.TabIndex = 9;
            this.btn_tatcahd.Text = "Tất cả hóa đơn";
            this.btn_tatcahd.Click += new System.EventHandler(this.btn_tatcahd_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(741, 3);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(169, 31);
            this.simpleButton3.TabIndex = 10;
            this.simpleButton3.Text = "Xuất danh sách hóa đơn";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // frm_quanlyhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_quanlyhoadon";
            this.Size = new System.Drawing.Size(919, 500);
            this.Load += new System.EventHandler(this.frm_quanlyhoadon_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grb_thongtinphong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grv_hoadon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grb_thongtinphong;
        private DevExpress.XtraGrid.GridControl grv_hoadon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MaHD;
        private DevExpress.XtraGrid.Columns.GridColumn TenTang;
        private DevExpress.XtraGrid.Columns.GridColumn TenPhong;
        private DevExpress.XtraGrid.Columns.GridColumn SODIENCU;
        private DevExpress.XtraGrid.Columns.GridColumn SODIENMOI;
        private DevExpress.XtraGrid.Columns.GridColumn SoDien;
        private DevExpress.XtraGrid.Columns.GridColumn TienDien;
        private DevExpress.XtraGrid.Columns.GridColumn SONUOCCU;
        private DevExpress.XtraGrid.Columns.GridColumn SONUOCMOI;
        private DevExpress.XtraGrid.Columns.GridColumn SoNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn TienNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn Wifi;
        private DevExpress.XtraGrid.Columns.GridColumn Rac;
        private DevExpress.XtraGrid.Columns.GridColumn NgayLap;
        private DevExpress.XtraGrid.Columns.GridColumn TongTien;
        private DevExpress.XtraGrid.Columns.GridColumn TenNV;
        private DevExpress.XtraGrid.Columns.GridColumn TINHTRANG;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbo_phong;
        private DevExpress.XtraEditors.SimpleButton btn_timkiem;
        private DevExpress.XtraEditors.SimpleButton btn_tatcahd;
        private DevExpress.XtraGrid.Columns.GridColumn THANGNAM;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}