﻿using Scenes;
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
            splitter1 = new Splitter();
            Option1 = new Button();
            Option2 = new Button();
            Option3 = new Button();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 681);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // Option1
            // 
            Option1.BackgroundImage = Properties.Resources.buttonFon;
            Option1.Font = new Font("Segoe UI", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 204);
            Option1.Location = new Point(232, 530);
            Option1.Name = "Option1";
            Option1.Size = new Size(190, 60);
            Option1.TabIndex = 0;
            Option1.Text = "HELP";
            Option1.UseVisualStyleBackColor = true;
            // 
            // Option2
            // 
            Option2.BackgroundImage = Properties.Resources.buttonFon;
            Option2.Font = new Font("Segoe UI", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 204);
            Option2.Location = new Point(557, 530);
            Option2.Name = "Option2";
            Option2.Size = new Size(190, 60);
            Option2.TabIndex = 1;
            Option2.Text = "button2";
            Option2.UseVisualStyleBackColor = true;
            // 
            // Option3
            // 
            Option3.BackgroundImage = Properties.Resources.buttonFon;
            Option3.Font = new Font("Segoe UI", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 204);
            Option3.Location = new Point(864, 530);
            Option3.Name = "Option3";
            Option3.Size = new Size(190, 60);
            Option3.TabIndex = 2;
            Option3.Text = "button3";
            Option3.UseVisualStyleBackColor = true;
            // 
            // GameScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(Option3);
            Controls.Add(Option2);
            Controls.Add(Option1);
            Controls.Add(splitter1);
            Name = "GameScreen";
            Text = "Game";
            Load += GameScreen_Load;
            ResumeLayout(false);
        }

        #endregion
        private Splitter splitter1;
        private Button Option1;
        private Button Option2;
        private Button Option3;
    
    }
}