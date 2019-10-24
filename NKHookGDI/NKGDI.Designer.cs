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
            this.notifText = new System.Windows.Forms.Label();
            this.notifBox = new System.Windows.Forms.Panel();
            this.notifBox.SuspendLayout();
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
            // notifText
            // 
            this.notifText.AutoSize = true;
            this.notifText.BackColor = System.Drawing.Color.Transparent;
            this.notifText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notifText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notifText.Location = new System.Drawing.Point(0, 0);
            this.notifText.MinimumSize = new System.Drawing.Size(420, 180);
            this.notifText.Name = "notifText";
            this.notifText.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.notifText.Size = new System.Drawing.Size(420, 180);
            this.notifText.TabIndex = 2;
            this.notifText.Text = "text";
            this.notifText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifBox
            // 
            this.notifBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifBox.BackgroundImage = global::NKHook5.Properties.Resources.nk_hook_gdi_bg_1;
            this.notifBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.notifBox.Controls.Add(this.notifText);
            this.notifBox.Location = new System.Drawing.Point(1486, 12);
            this.notifBox.Name = "notifBox";
            this.notifBox.Size = new System.Drawing.Size(422, 179);
            this.notifBox.TabIndex = 3;
            // 
            // NKGDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.notifBox);
            this.Controls.Add(this.gdiTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NKGDI";
            this.Text = "NKGDI";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.NKGDI_Load);
            this.notifBox.ResumeLayout(false);
            this.notifBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label gdiTag;
        private System.Windows.Forms.Label notifText;
        private System.Windows.Forms.Panel notifBox;
    }
}