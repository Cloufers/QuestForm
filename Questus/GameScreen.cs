﻿using SceneControl;
using Scenes;
using System.Diagnostics.CodeAnalysis;

namespace Questus
{
    public partial class GameScreen : FixedSizeForm
    {
        // FIELDS
        private SceneManager sceneManager;
        private List<SceneHolder> listScenes;
        private int currentSceneIndex;
        private Stack<int> history;
        private SceneHolder currentScene;

        // ANIMATION FIELDS
        private Label animatedLabel;
        private string textToAnimate;
        private int currentCharIndex;
        private Label questionMark;
        private System.Windows.Forms.Timer animationTimer;

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
            InitializeAnimation();
        }

        private void InitializeGame()
        {
            sceneManager = new SceneManager();
            listScenes = sceneManager.GetScenes();
            currentSceneIndex = 0;
            history = new Stack<int>();
            history.Push(currentSceneIndex);
            currentScene = listScenes[currentSceneIndex];
            UpdateButtonTextAndHandlers();
        }


        // ANIMATION
        private void InitializeAnimation()
        {
            if (currentScene != null && !string.IsNullOrEmpty(currentScene.SceneText))
            {
                textToAnimate = currentScene.SceneText;
                currentCharIndex = 0;

                animatedLabel = new Label();
                animatedLabel.Image = Properties.Resources.label;
                animatedLabel.AutoSize = true;
                animatedLabel.Location = new Point(220, 420); // Location
                animatedLabel.Font = new Font("Arial", 18); // Font/Size
                animatedLabel.BorderStyle = BorderStyle.Fixed3D;
                Controls.Add(animatedLabel);
                animationTimer = new System.Windows.Forms.Timer();
                animationTimer.Interval = 30; // Interval
                animationTimer.Tick += async (sender, e) => await AnimationTimer_TickAsync();
                animationTimer.Start();
            }
        }
        private async Task AnimationTimer_TickAsync()
        {
            if (currentCharIndex < textToAnimate.Length)
            {
                animatedLabel.Text = textToAnimate.Substring(0, currentCharIndex + 1);
                currentCharIndex++;
            }
            else
            {
                animationTimer.Stop();
                if (sceneManager.IsEndingScene(currentSceneIndex))
                {
                    await Task.Delay(1000);
                    currentScene.SceneText = string.Empty;
                    ShowEndGameButtons();
                }
            }
        }
        private void ResetAnimation()
        {
            if (animationTimer != null)
            {
                animationTimer.Stop();
                animationTimer.Dispose();
                animationTimer = null;
            }

            if (animatedLabel != null)
            {
                Controls.Remove(animatedLabel);
                animatedLabel.Dispose();
                animatedLabel = null;
            }
        }
        private void ClearAnimatedLabel()
        {
            if (animatedLabel != null)
            {
                Controls.Remove(animatedLabel);
                animatedLabel.Dispose();
                animatedLabel = null;
            }
        }


        // BUTTONS

        private void UpdateButtonTextAndHandlers()
        {
            Option1.Text = currentScene.SceneActions.Count > 0 ? currentScene.SceneActions[0] : string.Empty;
            Option1.Image = Properties.Resources.buttonFon;
            Option1.Click -= Option_Click;
            Option1.Click += Option_Click;
            Option1.Enabled = currentScene.SceneActions.Count > 0;

            Option2.Text = currentScene.SceneActions.Count > 1 ? currentScene.SceneActions[1] : string.Empty;
            Option2.Image = Properties.Resources.buttonFon;
            Option2.Click -= Option_Click;
            Option2.Click += Option_Click;
            Option2.Enabled = currentScene.SceneActions.Count > 1;

            Option3.Text = currentScene.SceneActions.Count > 2 ? currentScene.SceneActions[2] : string.Empty;
            Option3.Image = Properties.Resources.buttonFon;
            Option3.Click -= Option_Click;
            Option3.Click += Option_Click;
            Option3.Enabled = currentScene.SceneActions.Count > 2;
        }
        private void Option_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int actionIndex = clickedButton.TabIndex;

            int nextSceneIndex = currentScene.SceneGoTo[actionIndex];

            history.Push(nextSceneIndex);
            currentSceneIndex = nextSceneIndex;
            currentScene = listScenes[currentSceneIndex];

            if (sceneManager.IsEndingScene(currentSceneIndex))
            {
                currentScene.SceneText = sceneManager.GetEndingSceneText(currentSceneIndex);
                HideButtons();
            }

            UpdtaeScene();
        }
        private void StartAgainButton_Click(object? sender, EventArgs e)
        {
            Controls.Remove((Button)sender); // Удаляем кнопку "Start Again"
            Controls.Remove(Controls.OfType<Button>().FirstOrDefault(b => b.Text == "Quit Game")); // Удаляем кнопку "Quit Game"
            Controls.Remove(questionMark);

            RestartGame();
        }
        private void QuitGameButton_Click(object? sender, EventArgs e)
        {
            Close();
        }
        private void ShowEndGameButtons()
        {
            ClearAnimatedLabel();


            this.BackgroundImage = Properties.Resources.scene0;

            questionMark = new Label();
            questionMark.Text = "Wanna start again?";
            questionMark.Location = new Point(540, 220);
            questionMark.Font = new Font("Tempus Sans ITC", 18); // Font/Size
            questionMark.TextAlign = ContentAlignment.MiddleLeft;
            questionMark.BorderStyle = BorderStyle.None;
            questionMark.Image = Properties.Resources.buttonFon;
            questionMark.AutoSize = true;
            Controls.Add(questionMark);

            Button startAgainButton = new Button();
            startAgainButton.Text = "Start Again";
            startAgainButton.Size = new Size(80, 40);
            startAgainButton.Font = new Font("Tempus Sans ITC", 18); // Font/Size
            startAgainButton.TextAlign = ContentAlignment.MiddleCenter;
            startAgainButton.Location = new Point(Width / 2 - startAgainButton.Width - 40, Height / 2 - startAgainButton.Height - 40);
            startAgainButton.Image = Properties.Resources.buttonFon;
            startAgainButton.Click += StartAgainButton_Click;
            Controls.Add(startAgainButton);

            Button quitGameButton = new Button();
            quitGameButton.Text = "Quit Game";
            quitGameButton.Size = new Size(80, 40);
            quitGameButton.Location = new Point(Width / 2 + 40, Height / 2 - quitGameButton.Height - 40);
            quitGameButton.Font = new Font("Tempus Sans ITC", 18); // Font/Size
            quitGameButton.TextAlign = ContentAlignment.MiddleCenter;
            quitGameButton.Image = Properties.Resources.buttonFon;
            quitGameButton.Click += QuitGameButton_Click;
            Controls.Add(quitGameButton);
        }
        private void HideButtons()
        {
            Option1.Hide();
            Option2.Hide();
            Option3.Hide();
        }




        // UPDATES
        private void RestartGame()
        {
            InitializeComponent();
            InitializeGame();
            InitializeAnimation();
            history.Push(0);
        }
        private void UpdtaeScene()
        {
            UpdateButtonTextAndHandlers();
            ResetAnimation();
            InitializeAnimation();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

    }

}
