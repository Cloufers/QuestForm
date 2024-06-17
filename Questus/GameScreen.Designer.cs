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
            // Option1
            // 
            Option1.BackColor = Color.Transparent;
            Option1.FlatAppearance.BorderSize = 0;
            Option1.FlatStyle = FlatStyle.Flat;
            Option1.Font = new Font("Papyrus", 12.75F);
            Option1.ForeColor = Color.Orange;
            Option1.Location = new Point(197, 527);
            Option1.Margin = new Padding(2);
            Option1.Name = "Option1";
            Option1.Size = new Size(540, 45);
            Option1.TabIndex = 0;
            Option1.TextAlign = ContentAlignment.MiddleLeft;
            Option1.UseCompatibleTextRendering = true;
            Option1.UseVisualStyleBackColor = false;
            // 
            // Option2
            // 
            Option2.BackColor = Color.Transparent;
            Option2.FlatAppearance.BorderSize = 0;
            Option2.FlatStyle = FlatStyle.Flat;
            Option2.Font = new Font("Papyrus", 12.75F);
            Option2.ForeColor = Color.Orange;
            Option2.Location = new Point(197, 576);
            Option2.Margin = new Padding(2);
            Option2.Name = "Option2";
            Option2.Size = new Size(540, 45);
            Option2.TabIndex = 1;
            Option2.TextAlign = ContentAlignment.MiddleLeft;
            Option2.UseCompatibleTextRendering = true;
            Option2.UseVisualStyleBackColor = false;
            // 
            // Option3
            // 
            Option3.BackColor = Color.Transparent;
            Option3.FlatAppearance.BorderSize = 0;
            Option3.FlatStyle = FlatStyle.Flat;
            Option3.Font = new Font("Papyrus", 12.75F);
            Option3.ForeColor = Color.Orange;
            Option3.Location = new Point(196, 625);
            Option3.Margin = new Padding(2);
            Option3.Name = "Option3";
            Option3.Size = new Size(540, 45);
            Option3.TabIndex = 2;
            Option3.TextAlign = ContentAlignment.MiddleLeft;
            Option3.UseVisualStyleBackColor = false;
            // 
            // GameScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.scene0;
            ClientSize = new Size(1264, 681);
            Controls.Add(Option3);
            Controls.Add(Option2);
            Controls.Add(Option1);
            ForeColor = Color.Orange;
            Name = "GameScreen";
            Text = "Game";
            Load += GameScreen_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button Option1;
        private Button Option2;
        private Button Option3;
    }
}