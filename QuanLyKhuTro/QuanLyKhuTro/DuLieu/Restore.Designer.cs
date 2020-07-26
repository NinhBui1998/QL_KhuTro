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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_restore
            // 
            this.btn_restore.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_restore.Location = new System.Drawing.Point(411, 116);
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
            this.btn_links.Location = new System.Drawing.Point(411, 77);
            this.btn_links.Name = "btn_links";
            this.btn_links.Size = new System.Drawing.Size(98, 33);
            this.btn_links.TabIndex = 7;
            this.btn_links.Text = "Browse";
            this.btn_links.UseVisualStyleBackColor = false;
            this.btn_links.Click += new System.EventHandler(this.btn_links_Click);
            // 
            // txt_links
            // 
            this.txt_links.Location = new System.Drawing.Point(41, 78);
            this.txt_links.Name = "txt_links";
            this.txt_links.Size = new System.Drawing.Size(348, 32);
            this.txt_links.TabIndex = 6;
            this.txt_links.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(188, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "PHỤC HỒI DỮ LIỆU";
            // 
            // frm_Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.btn_links);
            this.Controls.Add(this.txt_links);
            this.Name = "frm_Restore";
            this.Size = new System.Drawing.Size(566, 167);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Button btn_links;
        private System.Windows.Forms.RichTextBox txt_links;
        private System.Windows.Forms.Label label1;
    }
}
