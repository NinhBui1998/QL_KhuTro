namespace QuanLyKhuTro.user_thongkePhong
{
    partial class frm_thongkevipham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_thongkevipham));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grv_vipham = new DevExpress.XtraGrid.GridControl();
            this.gridView_ViPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Manoiquy11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Noidung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Socmnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ngayvipham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Solan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Hinhphat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ghichu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_xuathd = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_vipham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ViPham)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grv_vipham, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(891, 459);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grv_vipham
            // 
            this.grv_vipham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grv_vipham.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.grv_vipham.Location = new System.Drawing.Point(3, 94);
            this.grv_vipham.MainView = this.gridView_ViPham;
            this.grv_vipham.Name = "grv_vipham";
            this.grv_vipham.Size = new System.Drawing.Size(885, 362);
            this.grv_vipham.TabIndex = 9;
            this.grv_vipham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ViPham});
            this.grv_vipham.Click += new System.EventHandler(this.grv_vipham_Click);
            // 
            // gridView_ViPham
            // 
            this.gridView_ViPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5,
            this.Manoiquy11,
            this.Noidung,
            this.Socmnd,
            this.Ngayvipham,
            this.Solan,
            this.Hinhphat,
            this.Ghichu});
            this.gridView_ViPham.GridControl = this.grv_vipham;
            this.gridView_ViPham.Name = "gridView_ViPham";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mã vi phạm";
            this.gridColumn3.FieldName = "MAVIPHAM1";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 71;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã khách thuê";
            this.gridColumn2.FieldName = "Makt";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 71;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên khách thuê";
            this.gridColumn1.FieldName = "Tenkt";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 71;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mã phòng";
            this.gridColumn4.FieldName = "MAPHONG1";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 71;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên phòng";
            this.gridColumn5.FieldName = "TENPHONG1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 71;
            // 
            // Manoiquy11
            // 
            this.Manoiquy11.Caption = "Mã nội quy";
            this.Manoiquy11.FieldName = "Manoiquy";
            this.Manoiquy11.Name = "Manoiquy11";
            this.Manoiquy11.Visible = true;
            this.Manoiquy11.VisibleIndex = 5;
            this.Manoiquy11.Width = 64;
            // 
            // Noidung
            // 
            this.Noidung.Caption = "Vi phạm nội quy";
            this.Noidung.FieldName = "Noidung";
            this.Noidung.Name = "Noidung";
            this.Noidung.Visible = true;
            this.Noidung.VisibleIndex = 6;
            this.Noidung.Width = 63;
            // 
            // Socmnd
            // 
            this.Socmnd.Caption = "Số CMND";
            this.Socmnd.FieldName = "Socmnd";
            this.Socmnd.Name = "Socmnd";
            this.Socmnd.Visible = true;
            this.Socmnd.VisibleIndex = 7;
            this.Socmnd.Width = 71;
            // 
            // Ngayvipham
            // 
            this.Ngayvipham.Caption = "Ngày vi phạm";
            this.Ngayvipham.FieldName = "Ngayvipham";
            this.Ngayvipham.Name = "Ngayvipham";
            this.Ngayvipham.Visible = true;
            this.Ngayvipham.VisibleIndex = 8;
            this.Ngayvipham.Width = 71;
            // 
            // Solan
            // 
            this.Solan.Caption = "Số lần ";
            this.Solan.FieldName = "Solan";
            this.Solan.Name = "Solan";
            this.Solan.Visible = true;
            this.Solan.VisibleIndex = 9;
            this.Solan.Width = 71;
            // 
            // Hinhphat
            // 
            this.Hinhphat.Caption = "Tiền phạt";
            this.Hinhphat.DisplayFormat.FormatString = "#,###";
            this.Hinhphat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Hinhphat.FieldName = "TIENPHAT1";
            this.Hinhphat.Name = "Hinhphat";
            this.Hinhphat.Visible = true;
            this.Hinhphat.VisibleIndex = 10;
            this.Hinhphat.Width = 71;
            // 
            // Ghichu
            // 
            this.Ghichu.Caption = "Ghi chú";
            this.Ghichu.FieldName = "Ghichu";
            this.Ghichu.Name = "Ghichu";
            this.Ghichu.Visible = true;
            this.Ghichu.VisibleIndex = 11;
            this.Ghichu.Width = 94;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(289, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "DOANH THU VI PHẠM";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel2.Controls.Add(this.btn_xuathd, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 40);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(885, 48);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // btn_xuathd
            // 
            this.btn_xuathd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xuathd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_xuathd.ImageOptions.Image")));
            this.btn_xuathd.Location = new System.Drawing.Point(759, 4);
            this.btn_xuathd.Name = "btn_xuathd";
            this.btn_xuathd.Size = new System.Drawing.Size(123, 40);
            this.btn_xuathd.TabIndex = 14;
            this.btn_xuathd.Text = "Xuất vi phạm";
            this.btn_xuathd.Click += new System.EventHandler(this.btn_xuathd_Click);
            // 
            // frm_thongkevipham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 459);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_thongkevipham";
            this.Text = "Thống kê vi phạm";
            this.Load += new System.EventHandler(this.frm_thongkevipham_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_vipham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ViPham)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grv_vipham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ViPham;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn Manoiquy11;
        private DevExpress.XtraGrid.Columns.GridColumn Noidung;
        private DevExpress.XtraGrid.Columns.GridColumn Socmnd;
        private DevExpress.XtraGrid.Columns.GridColumn Ngayvipham;
        private DevExpress.XtraGrid.Columns.GridColumn Solan;
        private DevExpress.XtraGrid.Columns.GridColumn Hinhphat;
        private DevExpress.XtraGrid.Columns.GridColumn Ghichu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btn_xuathd;
    }
}