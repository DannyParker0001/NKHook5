namespace NKHook5
{
    partial class SettingsWindow
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
            this.themeListBox = new System.Windows.Forms.ListBox();
            this.selectThemeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // themeListBox
            // 
            this.themeListBox.FormattingEnabled = true;
            this.themeListBox.Location = new System.Drawing.Point(13, 39);
            this.themeListBox.Name = "themeListBox";
            this.themeListBox.Size = new System.Drawing.Size(120, 394);
            this.themeListBox.TabIndex = 0;
            this.themeListBox.SelectedIndexChanged += new System.EventHandler(this.ThemeListBox_SelectedIndexChanged);
            // 
            // selectThemeLabel
            // 
            this.selectThemeLabel.AutoSize = true;
            this.selectThemeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectThemeLabel.Location = new System.Drawing.Point(8, 9);
            this.selectThemeLabel.Name = "selectThemeLabel";
            this.selectThemeLabel.Size = new System.Drawing.Size(78, 25);
            this.selectThemeLabel.TabIndex = 1;
            this.selectThemeLabel.Text = "Theme";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.selectThemeLabel);
            this.Controls.Add(this.themeListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsWindow";
            this.Text = "SettingsWindow";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.doDrag);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox themeListBox;
        private System.Windows.Forms.Label selectThemeLabel;
    }
}