namespace QuanLyKhuTro.DuLieu
{
    partial class frm_backup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_links = new System.Windows.Forms.Button();
            this.txt_links = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_backup
            // 
            this.btn_backup.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_backup.Location = new System.Drawing.Point(472, 88);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(98, 33);
            this.btn_backup.TabIndex = 5;
            this.btn_backup.Text = "Backup";
            this.btn_backup.UseVisualStyleBackColor = false;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // btn_links
            // 
            this.btn_links.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_links.Location = new System.Drawing.Point(472, 32);
            this.btn_links.Name = "btn_links";
            this.btn_links.Size = new System.Drawing.Size(98, 33);
            this.btn_links.TabIndex = 4;
            this.btn_links.Text = "Browse";
            this.btn_links.UseVisualStyleBackColor = false;
            this.btn_links.Click += new System.EventHandler(this.btn_links_Click);
            // 
            // txt_links
            // 
            this.txt_links.Location = new System.Drawing.Point(12, 33);
            this.txt_links.Name = "txt_links";
            this.txt_links.Size = new System.Drawing.Size(434, 32);
            this.txt_links.TabIndex = 3;
            this.txt_links.Text = "";
            // 
            // frm_backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.btn_links);
            this.Controls.Add(this.txt_links);
            this.Name = "frm_backup";
            this.Size = new System.Drawing.Size(597, 147);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_links;
        private System.Windows.Forms.RichTextBox txt_links;
    }
}
