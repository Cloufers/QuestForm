using Scenes;
using SceneControl;

namespace Questus
{
    partial class GameScreen
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
            Option1 = new Button();
            Option2 = new Button();
            Option3 = new Button();
            SuspendLayout();
            // 
            // 
            // 
            // Option1
            // 
            Option1.Font = new Font("Segoe UI", 18F);
            Option1.ForeColor = Color.Orange;
            Option1.Location = new Point(197, 485);
            Option1.Name = "Option1";
            Option1.Size = new Size(538, 54);
            Option1.TabIndex = 0;
            Option1.UseVisualStyleBackColor = true;
            // 
            // Option2
            // 
            Option2.Font = new Font("Segoe UI", 18F);
            Option2.ForeColor = Color.Orange;
            Option2.Location = new Point(196, 545);
            Option2.Name = "Option2";
            Option2.Size = new Size(538, 54);
            Option2.TabIndex = 1;
            Option2.UseVisualStyleBackColor = true;
            // 
            // Option3
            // 
            Option3.Font = new Font("Segoe UI", 18F);
            Option3.ForeColor = Color.Orange;
            Option3.Location = new Point(195, 605);
            Option3.Name = "Option3";
            Option3.Size = new Size(539, 54);
            Option3.TabIndex = 2;
            Option3.UseVisualStyleBackColor = true;
            // 
            // GameScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.scene0;
            Controls.Add(Option3);
            Controls.Add(Option2);
            Controls.Add(Option1);
            ForeColor = Color.Orange;
            Name = "GameScreen";
            Text = "Game";
            ResumeLayout(false);
        }

        #endregion
        private Button Option1;
        private Button Option2;
        private Button Option3;
    }
}