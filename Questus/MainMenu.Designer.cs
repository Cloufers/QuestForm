namespace Questus
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PlayButton = new ReaLTaiizor.Controls.NightButton();
            nightButton2 = new ReaLTaiizor.Controls.NightButton();
            nightButton3 = new ReaLTaiizor.Controls.NightButton();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.Transparent;
            PlayButton.DialogResult = DialogResult.None;
            PlayButton.Font = new Font("Papyrus", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayButton.ForeColor = Color.Orange;
            PlayButton.HoverBackColor = Color.FromArgb(50, 242, 93, 89);
            PlayButton.HoverForeColor = Color.White;
            PlayButton.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            PlayButton.Location = new Point(70, 148);
            PlayButton.MinimumSize = new Size(144, 47);
            PlayButton.Name = "PlayButton";
            PlayButton.NormalBackColor = Color.Orange;
            PlayButton.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            PlayButton.PressedBackColor = Color.FromArgb(100, 242, 93, 89);
            PlayButton.PressedForeColor = Color.White;
            PlayButton.Radius = 20;
            PlayButton.Size = new Size(393, 70);
            PlayButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            PlayButton.TabIndex = 4;
            PlayButton.Text = "Play";
            PlayButton.Click += PlayButton_Click;
            // 
            // nightButton2
            // 
            nightButton2.BackColor = Color.Transparent;
            nightButton2.DialogResult = DialogResult.None;
            nightButton2.Font = new Font("Papyrus", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nightButton2.ForeColor = Color.Orange;
            nightButton2.HoverBackColor = Color.FromArgb(50, 242, 93, 89);
            nightButton2.HoverForeColor = Color.White;
            nightButton2.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            nightButton2.Location = new Point(70, 250);
            nightButton2.MinimumSize = new Size(144, 47);
            nightButton2.Name = "nightButton2";
            nightButton2.NormalBackColor = Color.Orange;
            nightButton2.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            nightButton2.PressedBackColor = Color.FromArgb(100, 242, 93, 89);
            nightButton2.PressedForeColor = Color.White;
            nightButton2.Radius = 20;
            nightButton2.Size = new Size(393, 70);
            nightButton2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            nightButton2.TabIndex = 5;
            nightButton2.Text = "Settings";
            // 
            // nightButton3
            // 
            nightButton3.BackColor = Color.Transparent;
            nightButton3.DialogResult = DialogResult.None;
            nightButton3.Font = new Font("Papyrus", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nightButton3.ForeColor = Color.Orange;
            nightButton3.HoverBackColor = Color.FromArgb(50, 242, 93, 89);
            nightButton3.HoverForeColor = Color.White;
            nightButton3.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            nightButton3.Location = new Point(70, 352);
            nightButton3.MinimumSize = new Size(144, 47);
            nightButton3.Name = "nightButton3";
            nightButton3.NormalBackColor = Color.Orange;
            nightButton3.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            nightButton3.PressedBackColor = Color.FromArgb(100, 242, 93, 89);
            nightButton3.PressedForeColor = Color.White;
            nightButton3.Radius = 20;
            nightButton3.Size = new Size(393, 70);
            nightButton3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            nightButton3.TabIndex = 6;
            nightButton3.Text = "Credits";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            BackgroundImage = Properties.Resources.mainFon;
            ClientSize = new Size(1264, 681);
            Controls.Add(nightButton3);
            Controls.Add(nightButton2);
            Controls.Add(PlayButton);
            Name = "MainMenu";
            Text = "game";
            Load += MainMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.NightButton PlayButton;
        private ReaLTaiizor.Controls.NightButton nightButton2;
        private ReaLTaiizor.Controls.NightButton nightButton3;
    }
}