namespace QuanLyKhuTro
{
    partial class frm_doimatkhau
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
            this.lbl_matkhaumoi = new System.Windows.Forms.Label();
            this.lbl_xacnhanmk = new System.Windows.Forms.Label();
            this.txt_xacnhanmk = new System.Windows.Forms.TextBox();
            this.txt_matkhaumoi = new System.Windows.Forms.TextBox();
            this.btn_xacnhan = new DevExpress.XtraEditors.SimpleButton();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lbl_matkhaumoi
            // 
            this.lbl_matkhaumoi.AutoSize = true;
            this.lbl_matkhaumoi.Location = new System.Drawing.Point(33, 30);
            this.lbl_matkhaumoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_matkhaumoi.Name = "lbl_matkhaumoi";
            this.lbl_matkhaumoi.Size = new System.Drawing.Size(102, 19);
            this.lbl_matkhaumoi.TabIndex = 0;
            this.lbl_matkhaumoi.Text = "Mật khẩu mới";
            // 
            // lbl_xacnhanmk
            // 
            this.lbl_xacnhanmk.AutoSize = true;
            this.lbl_xacnhanmk.Location = new System.Drawing.Point(33, 96);
            this.lbl_xacnhanmk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_xacnhanmk.Name = "lbl_xacnhanmk";
            this.lbl_xacnhanmk.Size = new System.Drawing.Size(135, 19);
            this.lbl_xacnhanmk.TabIndex = 0;
            this.lbl_xacnhanmk.Text = "Xác nhận mật khẩu";
            // 
            // txt_xacnhanmk
            // 
            this.txt_xacnhanmk.Location = new System.Drawing.Point(197, 88);
            this.txt_xacnhanmk.Name = "txt_xacnhanmk";
            this.txt_xacnhanmk.Size = new System.Drawing.Size(248, 27);
            this.txt_xacnhanmk.TabIndex = 1;
            // 
            // txt_matkhaumoi
            // 
            this.txt_matkhaumoi.Location = new System.Drawing.Point(197, 22);
            this.txt_matkhaumoi.Name = "txt_matkhaumoi";
            this.txt_matkhaumoi.Size = new System.Drawing.Size(248, 27);
            this.txt_matkhaumoi.TabIndex = 1;
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.Location = new System.Drawing.Point(120, 141);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(85, 41);
            this.btn_xacnhan.TabIndex = 2;
            this.btn_xacnhan.Text = "Xác nhận";
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(272, 141);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(85, 41);
            this.btn_huy.TabIndex = 2;
            this.btn_huy.Text = "Hủy bỏ";
            // 
            // frm_doimatkhau
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 205);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.txt_matkhaumoi);
            this.Controls.Add(this.txt_xacnhanmk);
            this.Controls.Add(this.lbl_xacnhanmk);
            this.Controls.Add(this.lbl_matkhaumoi);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_doimatkhau";
            this.Text = "frm_doimatkhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_matkhaumoi;
        private System.Windows.Forms.Label lbl_xacnhanmk;
        private System.Windows.Forms.TextBox txt_xacnhanmk;
        private System.Windows.Forms.TextBox txt_matkhaumoi;
        private DevExpress.XtraEditors.SimpleButton btn_xacnhan;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
    }
}