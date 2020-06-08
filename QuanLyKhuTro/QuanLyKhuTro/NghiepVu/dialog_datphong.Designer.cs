namespace QuanLyKhuTro.NghiepVu
{
    partial class dialog_datphong
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
            this.btn_datphong = new DevExpress.XtraEditors.SimpleButton();
            this.btn_traphong = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btn_datphong
            // 
            this.btn_datphong.Location = new System.Drawing.Point(50, 58);
            this.btn_datphong.Name = "btn_datphong";
            this.btn_datphong.Size = new System.Drawing.Size(130, 52);
            this.btn_datphong.TabIndex = 0;
            this.btn_datphong.Text = "Đặt phòng";
            this.btn_datphong.Click += new System.EventHandler(this.btn_datphong_Click);
            // 
            // btn_traphong
            // 
            this.btn_traphong.Location = new System.Drawing.Point(249, 58);
            this.btn_traphong.Name = "btn_traphong";
            this.btn_traphong.Size = new System.Drawing.Size(130, 52);
            this.btn_traphong.TabIndex = 0;
            this.btn_traphong.Text = "Trả phòng";
            this.btn_traphong.Click += new System.EventHandler(this.btn_traphong_Click);
            // 
            // dialog_datphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 155);
            this.Controls.Add(this.btn_traphong);
            this.Controls.Add(this.btn_datphong);
            this.Name = "dialog_datphong";
            this.Text = "dialog_datphong";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_datphong;
        private DevExpress.XtraEditors.SimpleButton btn_traphong;
    }
}