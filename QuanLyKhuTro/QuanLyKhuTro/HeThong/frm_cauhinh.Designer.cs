namespace QuanLyKhuTro
{
    partial class frm_cauhinh
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
            this.lbl_servername = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_database = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.cbb_servername = new System.Windows.Forms.ComboBox();
            this.cbb_database = new System.Windows.Forms.ComboBox();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lbl_servername
            // 
            this.lbl_servername.AutoSize = true;
            this.lbl_servername.Location = new System.Drawing.Point(39, 35);
            this.lbl_servername.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_servername.Name = "lbl_servername";
            this.lbl_servername.Size = new System.Drawing.Size(93, 19);
            this.lbl_servername.TabIndex = 0;
            this.lbl_servername.Text = "Server name";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(39, 90);
            this.lbl_username.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(82, 19);
            this.lbl_username.TabIndex = 0;
            this.lbl_username.Text = "User name";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(39, 141);
            this.lbl_password.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(74, 19);
            this.lbl_password.TabIndex = 0;
            this.lbl_password.Text = "Password";
            // 
            // lbl_database
            // 
            this.lbl_database.AutoSize = true;
            this.lbl_database.Location = new System.Drawing.Point(39, 196);
            this.lbl_database.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_database.Name = "lbl_database";
            this.lbl_database.Size = new System.Drawing.Size(70, 19);
            this.lbl_database.TabIndex = 0;
            this.lbl_database.Text = "Database";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(171, 133);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(265, 27);
            this.txt_password.TabIndex = 1;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(171, 82);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(265, 27);
            this.txt_username.TabIndex = 1;
            // 
            // cbb_servername
            // 
            this.cbb_servername.FormattingEnabled = true;
            this.cbb_servername.Location = new System.Drawing.Point(171, 32);
            this.cbb_servername.Name = "cbb_servername";
            this.cbb_servername.Size = new System.Drawing.Size(265, 27);
            this.cbb_servername.TabIndex = 2;
            // 
            // cbb_database
            // 
            this.cbb_database.FormattingEnabled = true;
            this.cbb_database.Location = new System.Drawing.Point(171, 193);
            this.cbb_database.Name = "cbb_database";
            this.cbb_database.Size = new System.Drawing.Size(265, 27);
            this.cbb_database.TabIndex = 2;
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(102, 251);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(97, 40);
            this.btn_luu.TabIndex = 3;
            this.btn_luu.Text = "Lưu lại";
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(284, 251);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(96, 40);
            this.btn_huy.TabIndex = 3;
            this.btn_huy.Text = "Hủy bỏ";
            // 
            // frm_cauhinh
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 320);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.cbb_database);
            this.Controls.Add(this.cbb_servername);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lbl_database);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.lbl_servername);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frm_cauhinh";
            this.Text = "frm_cauhinh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_servername;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_database;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.ComboBox cbb_servername;
        private System.Windows.Forms.ComboBox cbb_database;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
    }
}