namespace QuanLyKhuTro.user_thongkePhong
{
    partial class frm_thongkehopdong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_thongkehopdong));
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_xuathd = new DevExpress.XtraEditors.SimpleButton();
            this.grv_datphong = new DevExpress.XtraGrid.GridControl();
            this.gridView_datphong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MAHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYLAPHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIENCOC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_datphong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_datphong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(290, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "DOANH THU HỢP ĐỒNG PHÒNG";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.Controls.Add(this.btn_xuathd, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 40);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(936, 48);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grv_datphong, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(942, 493);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btn_xuathd
            // 
            this.btn_xuathd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xuathd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_xuathd.ImageOptions.Image")));
            this.btn_xuathd.Location = new System.Drawing.Point(809, 4);
            this.btn_xuathd.Name = "btn_xuathd";
            this.btn_xuathd.Size = new System.Drawing.Size(124, 40);
            this.btn_xuathd.TabIndex = 14;
            this.btn_xuathd.Text = "Xuất danh thu";
            this.btn_xuathd.Click += new System.EventHandler(this.btn_xuathd_Click);
            // 
            // grv_datphong
            // 
            this.grv_datphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grv_datphong.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.grv_datphong.Location = new System.Drawing.Point(3, 94);
            this.grv_datphong.MainView = this.gridView_datphong;
            this.grv_datphong.Name = "grv_datphong";
            this.grv_datphong.Size = new System.Drawing.Size(936, 396);
            this.grv_datphong.TabIndex = 12;
            this.grv_datphong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_datphong});
            // 
            // gridView_datphong
            // 
            this.gridView_datphong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MAHD,
            this.gridColumn1,
            this.gridColumn2,
            this.MAKT,
            this.TENKT,
            this.NGAYLAPHD,
            this.NgayTra,
            this.TIENCOC});
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
            // MAKT
            // 
            this.MAKT.Caption = "Mã khách thuê";
            this.MAKT.FieldName = "Makt";
            this.MAKT.Name = "MAKT";
            this.MAKT.Visible = true;
            this.MAKT.VisibleIndex = 3;
            // 
            // TENKT
            // 
            this.TENKT.Caption = "Tên khách thuê";
            this.TENKT.FieldName = "Tenkt";
            this.TENKT.Name = "TENKT";
            this.TENKT.Visible = true;
            this.TENKT.VisibleIndex = 4;
            // 
            // NGAYLAPHD
            // 
            this.NGAYLAPHD.Caption = "Ngày lập";
            this.NGAYLAPHD.FieldName = "NgayLap";
            this.NGAYLAPHD.Name = "NGAYLAPHD";
            this.NGAYLAPHD.Visible = true;
            this.NGAYLAPHD.VisibleIndex = 5;
            // 
            // NgayTra
            // 
            this.NgayTra.Caption = "Ngày kết thúc hợp đồng";
            this.NgayTra.FieldName = "NgayTra";
            this.NgayTra.Name = "NgayTra";
            this.NgayTra.Visible = true;
            this.NgayTra.VisibleIndex = 6;
            // 
            // TIENCOC
            // 
            this.TIENCOC.Caption = "Tiền cọc";
            this.TIENCOC.DisplayFormat.FormatString = "#,###";
            this.TIENCOC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TIENCOC.FieldName = "Tiencoc";
            this.TIENCOC.Name = "TIENCOC";
            this.TIENCOC.Visible = true;
            this.TIENCOC.VisibleIndex = 7;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã phòng";
            this.gridColumn1.FieldName = "MAPHONG1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên phòng";
            this.gridColumn2.FieldName = "TenPhong";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // frm_thongkehopdong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 493);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_thongkehopdong";
            this.Text = "frm_thongkehopdong";
            this.Load += new System.EventHandler(this.frm_thongkehopdong_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_datphong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_datphong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_xuathd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grv_datphong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_datphong;
        private DevExpress.XtraGrid.Columns.GridColumn MAHD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn MAKT;
        private DevExpress.XtraGrid.Columns.GridColumn TENKT;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYLAPHD;
        private DevExpress.XtraGrid.Columns.GridColumn NgayTra;
        private DevExpress.XtraGrid.Columns.GridColumn TIENCOC;
    }
}