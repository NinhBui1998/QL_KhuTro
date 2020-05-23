namespace QuanLyKhuTro.DuLieu
{
    partial class frm_Restore
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
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_links = new System.Windows.Forms.Button();
            this.txt_links = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_restore
            // 
            this.btn_restore.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_restore.Location = new System.Drawing.Point(412, 78);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(98, 33);
            this.btn_restore.TabIndex = 8;
            this.btn_restore.Text = "Restore";
            this.btn_restore.UseVisualStyleBackColor = false;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_links
            // 
            this.btn_links.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_links.Location = new System.Drawing.Point(412, 39);
            this.btn_links.Name = "btn_links";
            this.btn_links.Size = new System.Drawing.Size(98, 33);
            this.btn_links.TabIndex = 7;
            this.btn_links.Text = "Browse";
            this.btn_links.UseVisualStyleBackColor = false;
            this.btn_links.Click += new System.EventHandler(this.btn_links_Click);
            // 
            // txt_links
            // 
            this.txt_links.Location = new System.Drawing.Point(42, 40);
            this.txt_links.Name = "txt_links";
            this.txt_links.Size = new System.Drawing.Size(348, 32);
            this.txt_links.TabIndex = 6;
            this.txt_links.Text = "";
            // 
            // frm_Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.btn_links);
            this.Controls.Add(this.txt_links);
            this.Name = "frm_Restore";
            this.Size = new System.Drawing.Size(553, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Button btn_links;
        private System.Windows.Forms.RichTextBox txt_links;
    }
}
