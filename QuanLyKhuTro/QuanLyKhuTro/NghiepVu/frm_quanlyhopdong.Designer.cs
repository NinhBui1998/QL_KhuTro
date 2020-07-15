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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grv_datphong = new DevExpress.XtraGrid.GridControl();
            this.gridView_datphong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MAHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYLAPHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIENCOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_datphong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_datphong)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 938F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.grv_datphong, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(938, 480);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grv_datphong
            // 
            this.grv_datphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grv_datphong.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.grv_datphong.Location = new System.Drawing.Point(3, 59);
            this.grv_datphong.MainView = this.gridView_datphong;
            this.grv_datphong.Name = "grv_datphong";
            this.grv_datphong.Size = new System.Drawing.Size(932, 418);
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
            this.label1.Location = new System.Drawing.Point(317, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ HỢP ĐỒNG";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã phòng";
            this.gridColumn2.FieldName = "MAPHONG1";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // frm_quanlyhopdong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 480);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_quanlyhopdong";
            this.Text = "frm_quanlyhopdong";
            this.Load += new System.EventHandler(this.frm_quanlyhopdong_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_datphong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_datphong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grv_datphong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_datphong;
        private DevExpress.XtraGrid.Columns.GridColumn MAHD;
        private DevExpress.XtraGrid.Columns.GridColumn TENPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn MANV;
        private DevExpress.XtraGrid.Columns.GridColumn MAKT;
        private DevExpress.XtraGrid.Columns.GridColumn TENKT;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYLAPHD;
        private DevExpress.XtraGrid.Columns.GridColumn NgayTra;
        private DevExpress.XtraGrid.Columns.GridColumn TIENCOC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}