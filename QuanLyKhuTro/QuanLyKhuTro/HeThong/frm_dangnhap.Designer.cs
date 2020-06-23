namespace QuanLyKhuTro.HeThong
{
    partial class frm_dangnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_dangnhap));
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.btn_dangnhap = new DevExpress.XtraEditors.SimpleButton();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.txt_taikhoan = new System.Windows.Forms.TextBox();
            this.lbl_matkhau = new System.Windows.Forms.Label();
            this.lbl_taikhoan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(320, 156);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(107, 45);
            this.btn_huy.TabIndex = 4;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_dangnhap.Appearance.Options.UseForeColor = true;
            this.btn_dangnhap.Location = new System.Drawing.Point(145, 156);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(107, 45);
            this.btn_dangnhap.TabIndex = 3;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            this.btn_dangnhap.Enter += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Location = new System.Drawing.Point(145, 81);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Size = new System.Drawing.Size(282, 21);
            this.txt_matkhau.TabIndex = 2;
            this.txt_matkhau.Text = "123456789";
            // 
            // txt_taikhoan
            // 
            this.txt_taikhoan.Location = new System.Drawing.Point(145, 41);
            this.txt_taikhoan.Name = "txt_taikhoan";
            this.txt_taikhoan.Size = new System.Drawing.Size(282, 21);
            this.txt_taikhoan.TabIndex = 1;
            this.txt_taikhoan.Text = "NV001";
            // 
            // lbl_matkhau
            // 
            this.lbl_matkhau.AutoSize = true;
            this.lbl_matkhau.BackColor = System.Drawing.Color.Transparent;
            this.lbl_matkhau.Location = new System.Drawing.Point(58, 89);
            this.lbl_matkhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_matkhau.Name = "lbl_matkhau";
            this.lbl_matkhau.Size = new System.Drawing.Size(51, 13);
            this.lbl_matkhau.TabIndex = 3;
            this.lbl_matkhau.Text = "Mật khẩu";
            // 
            // lbl_taikhoan
            // 
            this.lbl_taikhoan.AutoSize = true;
            this.lbl_taikhoan.BackColor = System.Drawing.Color.Transparent;
            this.lbl_taikhoan.Location = new System.Drawing.Point(56, 49);
            this.lbl_taikhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_taikhoan.Name = "lbl_taikhoan";
            this.lbl_taikhoan.Size = new System.Drawing.Size(53, 13);
            this.lbl_taikhoan.TabIndex = 4;
            this.lbl_taikhoan.Text = "Tài khoản";
            // 
            // frm_dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(467, 218);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.txt_matkhau);
            this.Controls.Add(this.txt_taikhoan);
            this.Controls.Add(this.lbl_matkhau);
            this.Controls.Add(this.lbl_taikhoan);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frm_dangnhap.IconOptions.LargeImage")));
            this.Name = "frm_dangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_dn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private DevExpress.XtraEditors.SimpleButton btn_dangnhap;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.TextBox txt_taikhoan;
        private System.Windows.Forms.Label lbl_matkhau;
        private System.Windows.Forms.Label lbl_taikhoan;
    }
}