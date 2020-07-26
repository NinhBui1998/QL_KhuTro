namespace QuanLyKhuTro.NghiepVu
{
    partial class frm_quanlyhopdong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_quanlyhopdong));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_timkiem = new DevExpress.XtraEditors.SimpleButton();
            this.cbo_phong = new System.Windows.Forms.ComboBox();
            this.btn_tatcahd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.grv_datphong = new DevExpress.XtraGrid.GridControl();
            this.gridView_datphong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MAHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYLAPHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIENCOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_datphong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_datphong)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 938F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grv_datphong, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.85585F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.14415F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 368F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(938, 480);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(932, 43);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_timkiem.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.Appearance.Options.UseFont = true;
            this.btn_timkiem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_timkiem.ImageOptions.SvgImage")));
            this.btn_timkiem.Location = new System.Drawing.Point(164, 10);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(30, 23);
            this.btn_timkiem.TabIndex = 7;
            // 
            // cbo_phong
            // 
            this.cbo_phong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_phong.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_phong.FormattingEnabled = true;
            this.cbo_phong.Location = new System.Drawing.Point(3, 8);
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
            this.btn_tatcahd.Location = new System.Drawing.Point(606, 3);
            this.btn_tatcahd.Name = "btn_tatcahd";
            this.btn_tatcahd.Size = new System.Drawing.Size(148, 37);
            this.btn_tatcahd.TabIndex = 9;
            this.btn_tatcahd.Text = "Tất cả hợp đồng";
            this.btn_tatcahd.Click += new System.EventHandler(this.btn_tatcahd_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(760, 3);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(169, 37);
            this.simpleButton3.TabIndex = 10;
            this.simpleButton3.Text = "Xuất danh sách hợp đồng";
            // 
            // grv_datphong
            // 
            this.grv_datphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grv_datphong.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.grv_datphong.Location = new System.Drawing.Point(3, 114);
            this.grv_datphong.MainView = this.gridView_datphong;
            this.grv_datphong.Name = "grv_datphong";
            this.grv_datphong.Size = new System.Drawing.Size(932, 363);
            this.grv_datphong.TabIndex = 3;
            this.grv_datphong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_datphong});
            // 
            // gridView_datphong
            // 
            this.gridView_datphong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MAHD,
            this.gridColumn2,
            this.TENPHONG,
            this.MANV,
            this.MAKT,
            this.TENKT,
            this.NGAYLAPHD,
            this.NgayTra,
            this.TIENCOC,
            this.gridColumn1});
            this.gridView_datphong.GridControl = this.grv_datphong;
            this.gridView_datphong.Name = "gridView_datphong";
            // 
            // MAHD
            // 
            this.MAHD.Caption = "Mã hợp đồng";
            this.MAHD.FieldName = "Mahd";
            this.MAHD.Name = "MAHD";
            this.MAHD.Visible = true;
            this.MAHD.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã phòng";
            this.gridColumn2.FieldName = "MAPHONG1";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // TENPHONG
            // 
            this.TENPHONG.Caption = "Tên phòng";
            this.TENPHONG.FieldName = "TenPhong";
            this.TENPHONG.Name = "TENPHONG";
            this.TENPHONG.Visible = true;
            this.TENPHONG.VisibleIndex = 2;
            // 
            // MANV
            // 
            this.MANV.Caption = "Tên nhân viên";
            this.MANV.FieldName = "Tennv";
            this.MANV.Name = "MANV";
            this.MANV.Visible = true;
            this.MANV.VisibleIndex = 3;
            // 
            // MAKT
            // 
            this.MAKT.Caption = "Mã khách thuê";
            this.MAKT.FieldName = "Makt";
            this.MAKT.Name = "MAKT";
            this.MAKT.Visible = true;
            this.MAKT.VisibleIndex = 4;
            // 
            // TENKT
            // 
            this.TENKT.Caption = "Tên khách thuê";
            this.TENKT.FieldName = "Tenkt";
            this.TENKT.Name = "TENKT";
            this.TENKT.Visible = true;
            this.TENKT.VisibleIndex = 5;
            // 
            // NGAYLAPHD
            // 
            this.NGAYLAPHD.Caption = "Ngày lập";
            this.NGAYLAPHD.FieldName = "NgayLap";
            this.NGAYLAPHD.Name = "NGAYLAPHD";
            this.NGAYLAPHD.Visible = true;
            this.NGAYLAPHD.VisibleIndex = 6;
            // 
            // NgayTra
            // 
            this.NgayTra.Caption = "Ngày kết thúc hợp đồng";
            this.NgayTra.FieldName = "NgayTra";
            this.NgayTra.Name = "NgayTra";
            this.NgayTra.Visible = true;
            this.NgayTra.VisibleIndex = 7;
            // 
            // TIENCOC
            // 
            this.TIENCOC.Caption = "Tiền cọc";
            this.TIENCOC.DisplayFormat.FormatString = "#,###";
            this.TIENCOC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TIENCOC.FieldName = "Tiencoc";
            this.TIENCOC.Name = "TIENCOC";
            this.TIENCOC.Visible = true;
            this.TIENCOC.VisibleIndex = 8;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tình trạng";
            this.gridColumn1.FieldName = "TINHTRANG1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(317, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ HỢP ĐỒNG";
            // 
            // frm_quanlyhopdong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 480);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_quanlyhopdong";
            this.Load += new System.EventHandler(this.frm_quanlyhopdong_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grv_datphong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_datphong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btn_timkiem;
        private System.Windows.Forms.ComboBox cbo_phong;
        private DevExpress.XtraEditors.SimpleButton btn_tatcahd;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraGrid.GridControl grv_datphong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_datphong;
        private DevExpress.XtraGrid.Columns.GridColumn MAHD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn TENPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn MANV;
        private DevExpress.XtraGrid.Columns.GridColumn MAKT;
        private DevExpress.XtraGrid.Columns.GridColumn TENKT;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYLAPHD;
        private DevExpress.XtraGrid.Columns.GridColumn NgayTra;
        private DevExpress.XtraGrid.Columns.GridColumn TIENCOC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Label label1;
    }
}