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
            Quit = new ReaLTaiizor.Controls.NightButton();
            nightHeaderLabel1 = new ReaLTaiizor.Controls.NightHeaderLabel();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.Transparent;
            PlayButton.DialogResult = DialogResult.None;
            PlayButton.Font = new Font("Papyrus", 27.75F, FontStyle.Bold);
            PlayButton.ForeColor = Color.AntiqueWhite;
            PlayButton.HoverBackColor = Color.FromArgb(50, 242, 93, 89);
            PlayButton.HoverForeColor = Color.White;
            PlayButton.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            PlayButton.Location = new Point(846, 418);
            PlayButton.MinimumSize = new Size(144, 47);
            PlayButton.Name = "PlayButton";
            PlayButton.NormalBackColor = Color.Linen;
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
            // Quit
            // 
            Quit.BackColor = Color.Transparent;
            Quit.DialogResult = DialogResult.None;
            Quit.Font = new Font("Papyrus", 27.75F, FontStyle.Bold);
            Quit.ForeColor = Color.AntiqueWhite;
            Quit.HoverBackColor = Color.FromArgb(50, 242, 93, 89);
            Quit.HoverForeColor = Color.White;
            Quit.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            Quit.Location = new Point(846, 525);
            Quit.MinimumSize = new Size(144, 47);
            Quit.Name = "Quit";
            Quit.NormalBackColor = Color.Linen;
            Quit.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            Quit.PressedBackColor = Color.FromArgb(100, 242, 93, 89);
            Quit.PressedForeColor = Color.White;
            Quit.Radius = 20;
            Quit.Size = new Size(393, 70);
            Quit.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Quit.TabIndex = 5;
            Quit.Text = "Quit";
            Quit.Click += Quit_Click;
            // 
            // nightHeaderLabel1
            // 
            nightHeaderLabel1.AutoSize = true;
            nightHeaderLabel1.BackColor = Color.Transparent;
            nightHeaderLabel1.FlatStyle = FlatStyle.Flat;
            nightHeaderLabel1.Font = new Font("Papyrus", 84.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nightHeaderLabel1.ForeColor = Color.White;
            nightHeaderLabel1.LeftSideForeColor = Color.White;
            nightHeaderLabel1.Location = new Point(106, 234);
            nightHeaderLabel1.Name = "nightHeaderLabel1";
            nightHeaderLabel1.RightSideForeColor = Color.White;
            nightHeaderLabel1.Side = ReaLTaiizor.Controls.NightHeaderLabel.PanelSide.LeftPanel;
            nightHeaderLabel1.Size = new Size(511, 195);
            nightHeaderLabel1.TabIndex = 6;
            nightHeaderLabel1.Text = "Questus";
            nightHeaderLabel1.TextAlign = ContentAlignment.MiddleCenter;
            nightHeaderLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            nightHeaderLabel1.UseCompatibleTextRendering = true;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            BackgroundImage = Properties.Resources.menu21;
            ClientSize = new Size(1264, 681);
            Controls.Add(nightHeaderLabel1);
            Controls.Add(Quit);
            Controls.Add(PlayButton);
            Name = "MainMenu";
            Text = "game";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.NightButton PlayButton;
        private ReaLTaiizor.Controls.NightButton Quit;
        private ReaLTaiizor.Controls.NightHeaderLabel nightHeaderLabel1;
    }
}