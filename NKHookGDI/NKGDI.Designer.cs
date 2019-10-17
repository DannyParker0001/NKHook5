namespace NKHook5.NKHookGDI
{
    internal partial class NKGDI
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
            this.gdiTag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gdiTag
            // 
            this.gdiTag.AutoSize = true;
            this.gdiTag.BackColor = System.Drawing.Color.Black;
            this.gdiTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdiTag.ForeColor = System.Drawing.Color.White;
            this.gdiTag.Location = new System.Drawing.Point(0, 0);
            this.gdiTag.Name = "gdiTag";
            this.gdiTag.Size = new System.Drawing.Size(369, 42);
            this.gdiTag.TabIndex = 0;
            this.gdiTag.Text = "NKHook GDI Loaded";
            // 
            // NKGDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.gdiTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NKGDI";
            this.Text = "NKGDI";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.NKGDI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label gdiTag;
    }
}