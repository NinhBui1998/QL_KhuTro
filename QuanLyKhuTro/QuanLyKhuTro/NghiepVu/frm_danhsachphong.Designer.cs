namespace QuanLyKhuTro
{
    partial class frm_test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_test));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_restart = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grv_phong = new DevExpress.XtraGrid.GridControl();
            this.gridView_Phong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MATANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MALOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOLUONG_HT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOLUONG_TD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv_phong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Phong)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.14622F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.93212F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(952, 383);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_restart
            // 
            this.btn_restart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_restart.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_restart.ImageOptions.SvgImage")));
            this.btn_restart.Location = new System.Drawing.Point(3, 3);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(124, 26);
            this.btn_restart.TabIndex = 0;
            this.btn_restart.Text = "Resfesh";
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.95137F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.04863F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.grv_phong, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(946, 254);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 248);
            this.panel1.TabIndex = 1;
            // 
            // grv_phong
            // 
            this.grv_phong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grv_phong.Location = new System.Drawing.Point(484, 3);
            this.grv_phong.MainView = this.gridView_Phong;
            this.grv_phong.Name = "grv_phong";
            this.grv_phong.Size = new System.Drawing.Size(425, 248);
            this.grv_phong.TabIndex = 2;
            this.grv_phong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Phong});
            // 
            // gridView_Phong
            // 
            this.gridView_Phong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MATANG,
            this.MALOAI,
            this.TENPHONG,
            this.SOLUONG_HT,
            this.SOLUONG_TD});
            this.gridView_Phong.GridControl = this.grv_phong;
            this.gridView_Phong.Name = "gridView_Phong";
            this.gridView_Phong.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_Phong_FocusedRowChanged);
            // 
            // MATANG
            // 
            this.MATANG.Caption = "Mã tầng";
            this.MATANG.FieldName = "MATANG";
            this.MATANG.Name = "MATANG";
            this.MATANG.Visible = true;
            this.MATANG.VisibleIndex = 0;
            // 
            // MALOAI
            // 
            this.MALOAI.Caption = "Mã loại";
            this.MALOAI.FieldName = "MALOAI";
            this.MALOAI.Name = "MALOAI";
            this.MALOAI.Visible = true;
            this.MALOAI.VisibleIndex = 1;
            // 
            // TENPHONG
            // 
            this.TENPHONG.Caption = "Tên phòng";
            this.TENPHONG.FieldName = "TENPHONG";
            this.TENPHONG.Name = "TENPHONG";
            this.TENPHONG.Visible = true;
            this.TENPHONG.VisibleIndex = 2;
            // 
            // SOLUONG_HT
            // 
            this.SOLUONG_HT.Caption = "Số lượng hiện tại";
            this.SOLUONG_HT.FieldName = "SOLUONG_HT";
            this.SOLUONG_HT.Name = "SOLUONG_HT";
            this.SOLUONG_HT.Visible = true;
            this.SOLUONG_HT.VisibleIndex = 3;
            // 
            // SOLUONG_TD
            // 
            this.SOLUONG_TD.Caption = "Số lượng tối đa";
            this.SOLUONG_TD.FieldName = "SOLUONG_TD";
            this.SOLUONG_TD.Name = "SOLUONG_TD";
            this.SOLUONG_TD.Visible = true;
            this.SOLUONG_TD.VisibleIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.6696F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.3304F));
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 301);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(227, 79);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.SeaGreen;
            this.textBox2.Location = new System.Drawing.Point(3, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(36, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Gray;
            this.textBox3.Location = new System.Drawing.Point(3, 55);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(36, 20);
            this.textBox3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Phòng trống";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Có khách";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Full khách";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.59498F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.40502F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel4.Controls.Add(this.btn_restart, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBox1, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBox2, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(946, 32);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tầng";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(282, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(506, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Loại phòng";
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(572, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(182, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // frm_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frm_test";
            this.Size = new System.Drawing.Size(952, 383);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grv_phong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Phong)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btn_restart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraGrid.GridControl grv_phong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Phong;
        private DevExpress.XtraGrid.Columns.GridColumn MATANG;
        private DevExpress.XtraGrid.Columns.GridColumn MALOAI;
        private DevExpress.XtraGrid.Columns.GridColumn TENPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn SOLUONG_HT;
        private DevExpress.XtraGrid.Columns.GridColumn SOLUONG_TD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}