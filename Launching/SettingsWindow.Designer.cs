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
            this.pluginLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.pluginList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // themeListBox
            // 
            this.themeListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.themeListBox.FormattingEnabled = true;
            this.themeListBox.Location = new System.Drawing.Point(13, 39);
            this.themeListBox.Name = "themeListBox";
            this.themeListBox.Size = new System.Drawing.Size(220, 394);
            this.themeListBox.TabIndex = 0;
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
            // pluginLabel
            // 
            this.pluginLabel.AutoSize = true;
            this.pluginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pluginLabel.Location = new System.Drawing.Point(249, 9);
            this.pluginLabel.Name = "pluginLabel";
            this.pluginLabel.Size = new System.Drawing.Size(83, 25);
            this.pluginLabel.TabIndex = 3;
            this.pluginLabel.Text = "Plugins";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Red;
            this.closeButton.Location = new System.Drawing.Point(643, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(50, 50);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "×";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // pluginList
            // 
            this.pluginList.CheckBoxes = true;
            this.pluginList.HideSelection = false;
            this.pluginList.Location = new System.Drawing.Point(254, 39);
            this.pluginList.Name = "pluginList";
            this.pluginList.Size = new System.Drawing.Size(383, 394);
            this.pluginList.TabIndex = 6;
            this.pluginList.UseCompatibleStateImageBehavior = false;
            this.pluginList.View = System.Windows.Forms.View.List;
            this.pluginList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.PluginList_ItemCheck);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.pluginList);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.pluginLabel);
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
        private System.Windows.Forms.Label pluginLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ListView pluginList;
    }
}