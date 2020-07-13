namespace QuanLyKhuTro.NghiepVu
{
    partial class frm_dialog
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
            this.btn_traphong = new DevExpress.XtraEditors.SimpleButton();
            this.btn_datphong = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btn_traphong
            // 
            this.btn_traphong.Location = new System.Drawing.Point(177, 6);
            this.btn_traphong.Name = "btn_traphong";
            this.btn_traphong.Size = new System.Drawing.Size(130, 52);
            this.btn_traphong.TabIndex = 1;
            this.btn_traphong.Text = "Trả phòng";
            this.btn_traphong.Click += new System.EventHandler(this.btn_traphong_Click);
            // 
            // btn_datphong
            // 
            this.btn_datphong.Location = new System.Drawing.Point(9, 6);
            this.btn_datphong.Name = "btn_datphong";
            this.btn_datphong.Size = new System.Drawing.Size(130, 52);
            this.btn_datphong.TabIndex = 2;
            this.btn_datphong.Text = "Đặt phòng";
            this.btn_datphong.Click += new System.EventHandler(this.btn_datphong_Click);
            // 
            // frm_dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 74);
            this.Controls.Add(this.btn_traphong);
            this.Controls.Add(this.btn_datphong);
            this.Name = "frm_dialog";
            this.Text = "frm_dialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_dialog_FormClosing);
            this.Load += new System.EventHandler(this.frm_dialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_traphong;
        private DevExpress.XtraEditors.SimpleButton btn_datphong;
    }
}