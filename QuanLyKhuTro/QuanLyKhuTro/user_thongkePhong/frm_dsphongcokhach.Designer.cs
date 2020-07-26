namespace QuanLyKhuTro.user_thongkePhong
{
    partial class frm_dsphongcokhach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_dsphongcokhach));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_tongphongdacoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.pnl_tkphong = new System.Windows.Forms.Panel();
            this.grv_khachthue = new DevExpress.XtraGrid.GridControl();
            this.gridView_khachthue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MAKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GIOITINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUEQUAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYSINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRUONGPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.pnl_tkphong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_khachthue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_khachthue)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.tableLayoutPanel7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 450);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phòng đã có khách thuê";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.pnl_tkphong, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel7.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.21378F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.78622F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(794, 421);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.03553F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.502538F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.79188F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.53317F));
            this.tableLayoutPanel6.Controls.Add(this.txt_tongphongdacoc, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.simpleButton3, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(788, 36);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // txt_tongphongdacoc
            // 
            this.txt_tongphongdacoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tongphongdacoc.Enabled = false;
            this.txt_tongphongdacoc.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tongphongdacoc.Location = new System.Drawing.Point(153, 4);
            this.txt_tongphongdacoc.Name = "txt_tongphongdacoc";
            this.txt_tongphongdacoc.Size = new System.Drawing.Size(61, 27);
            this.txt_tongphongdacoc.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 36);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tổng số phòng có khách thuê";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(636, 3);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(149, 30);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "Xuất danh sách phòng";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // pnl_tkphong
            // 
            this.pnl_tkphong.Controls.Add(this.grv_khachthue);
            this.pnl_tkphong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_tkphong.Location = new System.Drawing.Point(3, 45);
            this.pnl_tkphong.Name = "pnl_tkphong";
            this.pnl_tkphong.Size = new System.Drawing.Size(788, 373);
            this.pnl_tkphong.TabIndex = 2;
            // 
            // grv_khachthue
            // 
            this.grv_khachthue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grv_khachthue.Location = new System.Drawing.Point(0, 0);
            this.grv_khachthue.MainView = this.gridView_khachthue;
            this.grv_khachthue.Name = "grv_khachthue";
            this.grv_khachthue.Size = new System.Drawing.Size(788, 373);
            this.grv_khachthue.TabIndex = 4;
            this.grv_khachthue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_khachthue});
            // 
            // gridView_khachthue
            // 
            this.gridView_khachthue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MAKT,
            this.TENKT,
            this.GIOITINH,
            this.SDT,
            this.QUEQUAN,
            this.SOCMND,
            this.NGAYSINH,
            this.TRUONGPHONG,
            this.MAPHONG});
            this.gridView_khachthue.GridControl = this.grv_khachthue;
            this.gridView_khachthue.Name = "gridView_khachthue";
            // 
            // MAKT
            // 
            this.MAKT.Caption = "Mã khách thuê";
            this.MAKT.FieldName = "MAKT1";
            this.MAKT.Name = "MAKT";
            this.MAKT.Visible = true;
            this.MAKT.VisibleIndex = 0;
            // 
            // TENKT
            // 
            this.TENKT.Caption = "Tên khách thuê";
            this.TENKT.FieldName = "TENKT1";
            this.TENKT.Name = "TENKT";
            this.TENKT.Visible = true;
            this.TENKT.VisibleIndex = 1;
            // 
            // GIOITINH
            // 
            this.GIOITINH.Caption = "Giới tính";
            this.GIOITINH.FieldName = "GIOITINH1";
            this.GIOITINH.Name = "GIOITINH";
            this.GIOITINH.Visible = true;
            this.GIOITINH.VisibleIndex = 2;
            // 
            // SDT
            // 
            this.SDT.Caption = "Số điện thoại";
            this.SDT.FieldName = "SDT1";
            this.SDT.Name = "SDT";
            this.SDT.Visible = true;
            this.SDT.VisibleIndex = 3;
            // 
            // QUEQUAN
            // 
            this.QUEQUAN.Caption = "Quê quán";
            this.QUEQUAN.FieldName = "QUEQUAN1";
            this.QUEQUAN.Name = "QUEQUAN";
            this.QUEQUAN.Visible = true;
            this.QUEQUAN.VisibleIndex = 4;
            // 
            // SOCMND
            // 
            this.SOCMND.Caption = "Số CMND";
            this.SOCMND.FieldName = "SOCMND1";
            this.SOCMND.Name = "SOCMND";
            this.SOCMND.Visible = true;
            this.SOCMND.VisibleIndex = 5;
            // 
            // NGAYSINH
            // 
            this.NGAYSINH.Caption = "Ngày sinh";
            this.NGAYSINH.DisplayFormat.FormatString = "d";
            this.NGAYSINH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.NGAYSINH.FieldName = "NGAYSINH1";
            this.NGAYSINH.Name = "NGAYSINH";
            this.NGAYSINH.Visible = true;
            this.NGAYSINH.VisibleIndex = 6;
            // 
            // TRUONGPHONG
            // 
            this.TRUONGPHONG.Caption = "Trưởng phòng";
            this.TRUONGPHONG.FieldName = "TRUONGPHONG1";
            this.TRUONGPHONG.Name = "TRUONGPHONG";
            this.TRUONGPHONG.Visible = true;
            this.TRUONGPHONG.VisibleIndex = 7;
            // 
            // MAPHONG
            // 
            this.MAPHONG.Caption = "Mã phòng";
            this.MAPHONG.FieldName = "MAPHONG1";
            this.MAPHONG.Name = "MAPHONG";
            this.MAPHONG.Visible = true;
            this.MAPHONG.VisibleIndex = 8;
            // 
            // frm_dsphongcokhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Name = "frm_dsphongcokhach";
            this.Text = "frm_dsphongcokhach";
            this.Load += new System.EventHandler(this.frm_dsphongcokhach_Load);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.pnl_tkphong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grv_khachthue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_khachthue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox txt_tongphongdacoc;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.Panel pnl_tkphong;
        private DevExpress.XtraGrid.GridControl grv_khachthue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_khachthue;
        private DevExpress.XtraGrid.Columns.GridColumn MAKT;
        private DevExpress.XtraGrid.Columns.GridColumn TENKT;
        private DevExpress.XtraGrid.Columns.GridColumn GIOITINH;
        private DevExpress.XtraGrid.Columns.GridColumn SDT;
        private DevExpress.XtraGrid.Columns.GridColumn QUEQUAN;
        private DevExpress.XtraGrid.Columns.GridColumn SOCMND;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYSINH;
        private DevExpress.XtraGrid.Columns.GridColumn TRUONGPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn MAPHONG;
    }
}