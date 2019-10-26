namespace NKHook5
{
    partial class BootWindow
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
            this.launchButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.versionTag = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.discordButton = new System.Windows.Forms.Button();
            this.nkhLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.launchButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.launchButton.FlatAppearance.BorderSize = 0;
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.Location = new System.Drawing.Point(200, 364);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(100, 66);
            this.launchButton.TabIndex = 1;
            this.launchButton.Text = "Launch";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.BackgroundImage = global::NKHook5.Properties.Resources.Rainbow;
            this.pictureBox3.Image = global::NKHook5.Properties.Resources.Rainbow;
            this.pictureBox3.Location = new System.Drawing.Point(198, 362);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(104, 70);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.picturePaint);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Red;
            this.closeButton.Location = new System.Drawing.Point(438, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(50, 50);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "×";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // versionTag
            // 
            this.versionTag.AutoSize = true;
            this.versionTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionTag.Location = new System.Drawing.Point(7, 9);
            this.versionTag.Name = "versionTag";
            this.versionTag.Size = new System.Drawing.Size(138, 29);
            this.versionTag.TabIndex = 5;
            this.versionTag.Text = "VersionTag";
            this.versionTag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.doDrag);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BackgroundImage = global::NKHook5.Properties.Resources.Rainbow;
            this.pictureBox2.Image = global::NKHook5.Properties.Resources.Rainbow;
            this.pictureBox2.Location = new System.Drawing.Point(84, 362);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 70);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.picturePaint);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Location = new System.Drawing.Point(86, 364);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(100, 66);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.BackgroundImage = global::NKHook5.Properties.Resources.Rainbow;
            this.pictureBox4.Image = global::NKHook5.Properties.Resources.Rainbow;
            this.pictureBox4.Location = new System.Drawing.Point(312, 362);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(104, 70);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.picturePaint);
            // 
            // discordButton
            // 
            this.discordButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discordButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.discordButton.FlatAppearance.BorderSize = 0;
            this.discordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discordButton.Location = new System.Drawing.Point(314, 364);
            this.discordButton.Name = "discordButton";
            this.discordButton.Size = new System.Drawing.Size(100, 66);
            this.discordButton.TabIndex = 9;
            this.discordButton.Text = "Discord";
            this.discordButton.UseVisualStyleBackColor = true;
            this.discordButton.Click += new System.EventHandler(this.DiscordButton_Click);
            // 
            // nkhLabel
            // 
            this.nkhLabel.BackColor = System.Drawing.Color.Transparent;
            this.nkhLabel.Location = new System.Drawing.Point(0, 84);
            this.nkhLabel.Name = "nkhLabel";
            this.nkhLabel.Size = new System.Drawing.Size(500, 192);
            this.nkhLabel.TabIndex = 10;
            this.nkhLabel.Text = "NKH";
            this.nkhLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nkhLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.doDrag);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(3, 214);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(497, 117);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "Welcome!";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statusLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.doDrag);
            // 
            // BootWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.discordButton);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.versionTag);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.nkhLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BootWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BootWindow";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.splash_load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.doDrag);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label versionTag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button discordButton;
        private System.Windows.Forms.Label nkhLabel;
        private System.Windows.Forms.Label statusLabel;
        internal System.Windows.Forms.Button settingsButton;
    }
}