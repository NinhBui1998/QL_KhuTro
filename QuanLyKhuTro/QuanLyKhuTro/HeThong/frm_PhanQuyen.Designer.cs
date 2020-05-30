namespace QuanLyKhuTro.HeThong
{
    partial class frm_phanquyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_phanquyen));
            this.tab_ND_NhomND = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_xoa_nd = new DevExpress.XtraEditors.SimpleButton();
            this.btn_them = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grv_qlnd_nnd = new DevExpress.XtraGrid.GridControl();
            this.gridView_qlnd_nhomnd = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TENDANGNHAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MANHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbo_quanlynhomnd = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grv_qlnd = new DevExpress.XtraGrid.GridControl();
            this.gridView_qlnguoidung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TENDN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOATDONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckb_hoatdong = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_sua = new DevExpress.XtraEditors.SimpleButton();
            this.btn_xoa = new DevExpress.XtraEditors.SimpleButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tab_ND_NhomND.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_qlnd_nnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_qlnd_nhomnd)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_qlnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_qlnguoidung)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_ND_NhomND
            // 
            this.tab_ND_NhomND.Controls.Add(this.tabPage1);
            this.tab_ND_NhomND.Controls.Add(this.tabPage2);
            this.tab_ND_NhomND.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_ND_NhomND.Location = new System.Drawing.Point(0, 0);
            this.tab_ND_NhomND.Name = "tab_ND_NhomND";
            this.tab_ND_NhomND.SelectedIndex = 0;
            this.tab_ND_NhomND.Size = new System.Drawing.Size(671, 417);
            this.tab_ND_NhomND.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.btn_xoa_nd);
            this.tabPage1.Controls.Add(this.btn_them);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Người dùng_ nhóm người dùng";
            // 
            // btn_xoa_nd
            // 
            this.btn_xoa_nd.Appearance.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa_nd.Appearance.Options.UseFont = true;
            this.btn_xoa_nd.Location = new System.Drawing.Point(274, 201);
            this.btn_xoa_nd.Name = "btn_xoa_nd";
            this.btn_xoa_nd.Size = new System.Drawing.Size(93, 38);
            this.btn_xoa_nd.TabIndex = 13;
            this.btn_xoa_nd.Text = "<<";
            this.btn_xoa_nd.Click += new System.EventHandler(this.btn_xoa_nd_Click);
            // 
            // btn_them
            // 
            this.btn_them.Appearance.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Appearance.Options.UseFont = true;
            this.btn_them.Location = new System.Drawing.Point(274, 124);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(93, 38);
            this.btn_them.TabIndex = 14;
            this.btn_them.Text = ">>";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grv_qlnd_nnd);
            this.groupBox2.Controls.Add(this.cbo_quanlynhomnd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(382, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 385);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quản lý người dùng nhóm người dùng";
            // 
            // grv_qlnd_nnd
            // 
            this.grv_qlnd_nnd.Location = new System.Drawing.Point(11, 69);
            this.grv_qlnd_nnd.MainView = this.gridView_qlnd_nhomnd;
            this.grv_qlnd_nnd.Name = "grv_qlnd_nnd";
            this.grv_qlnd_nnd.Size = new System.Drawing.Size(253, 286);
            this.grv_qlnd_nnd.TabIndex = 5;
            this.grv_qlnd_nnd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_qlnd_nhomnd});
            // 
            // gridView_qlnd_nhomnd
            // 
            this.gridView_qlnd_nhomnd.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TENDANGNHAP,
            this.MANHOM});
            this.gridView_qlnd_nhomnd.GridControl = this.grv_qlnd_nnd;
            this.gridView_qlnd_nhomnd.Name = "gridView_qlnd_nhomnd";
            this.gridView_qlnd_nhomnd.OptionsBehavior.ReadOnly = true;
            // 
            // TENDANGNHAP
            // 
            this.TENDANGNHAP.Caption = "Tên đăng nhập";
            this.TENDANGNHAP.FieldName = "TENDN";
            this.TENDANGNHAP.Name = "TENDANGNHAP";
            this.TENDANGNHAP.Visible = true;
            this.TENDANGNHAP.VisibleIndex = 0;
            // 
            // MANHOM
            // 
            this.MANHOM.Caption = "Mã nhóm";
            this.MANHOM.FieldName = "MANHOM";
            this.MANHOM.Name = "MANHOM";
            this.MANHOM.Visible = true;
            this.MANHOM.VisibleIndex = 1;
            // 
            // cbo_quanlynhomnd
            // 
            this.cbo_quanlynhomnd.FormattingEnabled = true;
            this.cbo_quanlynhomnd.Location = new System.Drawing.Point(11, 36);
            this.cbo_quanlynhomnd.Name = "cbo_quanlynhomnd";
            this.cbo_quanlynhomnd.Size = new System.Drawing.Size(253, 27);
            this.cbo_quanlynhomnd.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grv_qlnd);
            this.groupBox1.Controls.Add(this.ckb_hoatdong);
            this.groupBox1.Controls.Add(this.tableLayoutPanel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 385);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Người dùng";
            // 
            // grv_qlnd
            // 
            this.grv_qlnd.Location = new System.Drawing.Point(6, 53);
            this.grv_qlnd.MainView = this.gridView_qlnguoidung;
            this.grv_qlnd.Name = "grv_qlnd";
            this.grv_qlnd.Size = new System.Drawing.Size(236, 239);
            this.grv_qlnd.TabIndex = 0;
            this.grv_qlnd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_qlnguoidung});
            // 
            // gridView_qlnguoidung
            // 
            this.gridView_qlnguoidung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TENDN,
            this.HOATDONG});
            this.gridView_qlnguoidung.GridControl = this.grv_qlnd;
            this.gridView_qlnguoidung.Name = "gridView_qlnguoidung";
            this.gridView_qlnguoidung.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_qlnguoidung_FocusedRowChanged);
            // 
            // TENDN
            // 
            this.TENDN.Caption = "Tên đăng nhập";
            this.TENDN.FieldName = "TENDN";
            this.TENDN.Name = "TENDN";
            this.TENDN.Visible = true;
            this.TENDN.VisibleIndex = 0;
            // 
            // HOATDONG
            // 
            this.HOATDONG.Caption = "Hoạt động";
            this.HOATDONG.FieldName = "HOATDONG";
            this.HOATDONG.Name = "HOATDONG";
            this.HOATDONG.Visible = true;
            this.HOATDONG.VisibleIndex = 1;
            // 
            // ckb_hoatdong
            // 
            this.ckb_hoatdong.AutoSize = true;
            this.ckb_hoatdong.ForeColor = System.Drawing.Color.Black;
            this.ckb_hoatdong.Location = new System.Drawing.Point(6, 24);
            this.ckb_hoatdong.Name = "ckb_hoatdong";
            this.ckb_hoatdong.Size = new System.Drawing.Size(99, 23);
            this.ckb_hoatdong.TabIndex = 5;
            this.ckb_hoatdong.Text = "Hoạt động";
            this.ckb_hoatdong.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btn_sua, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_xoa, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 310);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(236, 55);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // btn_sua
            // 
            this.btn_sua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sua.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.Appearance.Options.UseFont = true;
            this.btn_sua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_sua.ImageOptions.SvgImage")));
            this.btn_sua.Location = new System.Drawing.Point(121, 7);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(112, 40);
            this.btn_sua.TabIndex = 1;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xoa.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Appearance.Options.UseFont = true;
            this.btn_xoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_xoa.ImageOptions.SvgImage")));
            this.btn_xoa.Location = new System.Drawing.Point(3, 7);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(112, 40);
            this.btn_xoa.TabIndex = 0;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(663, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Phân quyền";
            // 
            // frm_phanquyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tab_ND_NhomND);
            this.Name = "frm_phanquyen";
            this.Size = new System.Drawing.Size(671, 417);
            this.Load += new System.EventHandler(this.frm_PhanQuyen_Load);
            this.tab_ND_NhomND.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grv_qlnd_nnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_qlnd_nhomnd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_qlnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_qlnguoidung)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_ND_NhomND;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraEditors.SimpleButton btn_xoa_nd;
        private DevExpress.XtraEditors.SimpleButton btn_them;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl grv_qlnd_nnd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_qlnd_nhomnd;
        private DevExpress.XtraGrid.Columns.GridColumn TENDANGNHAP;
        private DevExpress.XtraGrid.Columns.GridColumn MANHOM;
        private System.Windows.Forms.ComboBox cbo_quanlynhomnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl grv_qlnd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_qlnguoidung;
        private DevExpress.XtraGrid.Columns.GridColumn TENDN;
        private DevExpress.XtraGrid.Columns.GridColumn HOATDONG;
        private System.Windows.Forms.CheckBox ckb_hoatdong;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.SimpleButton btn_sua;
        private DevExpress.XtraEditors.SimpleButton btn_xoa;
        private System.Windows.Forms.TabPage tabPage2;
    }
}