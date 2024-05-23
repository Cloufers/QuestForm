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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            PlayButton = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.FlatAppearance.MouseDownBackColor = Color.White;
            PlayButton.FlatStyle = FlatStyle.Flat;
            PlayButton.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PlayButton.Location = new Point(63, 115);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(250, 43);
            PlayButton.TabIndex = 0;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += PlayButton_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(63, 185);
            button2.Name = "button2";
            button2.Size = new Size(250, 45);
            button2.TabIndex = 1;
            button2.Text = "Continue\r\n";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(63, 332);
            button3.Name = "button3";
            button3.Size = new Size(250, 39);
            button3.TabIndex = 2;
            button3.Text = "Settings";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(63, 259);
            button4.Name = "button4";
            button4.Size = new Size(250, 45);
            button4.TabIndex = 3;
            button4.Text = "Credits";
            button4.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1006, 520);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(PlayButton);
            Name = "MainMenu";
            Text = "game";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button PlayButton;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}