using SceneControl;
using Scenes;

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

        private void InitializeAnimation()
        {
            if (currentScene != null && !string.IsNullOrEmpty(currentScene.SceneText))
            {
                textToAnimate = currentScene.SceneText;
                currentCharIndex = 0;

                animatedLabel = new Label();
                animatedLabel.AutoSize = true;
                animatedLabel.Location = new Point(10, 10); // Location
                animatedLabel.Font = new Font("Arial", 14); // Font/Size
                Controls.Add(animatedLabel);

                animationTimer = new System.Windows.Forms.Timer();
                animationTimer.Interval = 50; // Interval
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

        private void UpdateButtonTextAndHandlers()
        {
            Option1.Text = currentScene.SceneActions.Count > 0 ? currentScene.SceneActions[0] : string.Empty;
            Option1.Click -= Option_Click;
            Option1.Click += Option_Click;
            Option1.Enabled = currentScene.SceneActions.Count > 0;

            Option2.Text = currentScene.SceneActions.Count > 1 ? currentScene.SceneActions[1] : string.Empty;
            Option2.Click -= Option_Click;
            Option2.Click += Option_Click;
            Option2.Enabled = currentScene.SceneActions.Count > 1;

            Option3.Text = currentScene.SceneActions.Count > 2 ? currentScene.SceneActions[2] : string.Empty;
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

            UpdateButtonTextAndHandlers();
            ResetAnimation();
            InitializeAnimation();
        }

        private void StartAgainButton_Click(object? sender, EventArgs e)
        {
            Controls.Remove((Button)sender); // Удаляем кнопку "Start Again"
            Controls.Remove(Controls.OfType<Button>().FirstOrDefault(b => b.Text == "Quit Game")); // Удаляем кнопку "Quit Game"
            Controls.Remove(questionMark);

            InitializeComponent();
            InitializeGame();
            InitializeAnimation();
            history.Push(0);
        }

        private void QuitGameButton_Click(object? sender, EventArgs e)
        {
            Close();
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

        private void ShowEndGameButtons()
        {
            ClearAnimatedLabel();

            questionMark = new Label();
            questionMark.Text = "Wanna start again?";
            questionMark.Location = new Point(10, 10);
            questionMark.AutoSize = true;
            Controls.Add(questionMark);

            Button startAgainButton = new Button();
            startAgainButton.Text = "Start Again";
            startAgainButton.Location = new Point(Width / 2 - startAgainButton.Width - 20, Height / 2 - startAgainButton.Height / 2);
            startAgainButton.Click += StartAgainButton_Click;
            Controls.Add(startAgainButton);

            Button quitGameButton = new Button();
            quitGameButton.Text = "Quit Game";
            quitGameButton.Location = new Point(Width / 2 + 20, Height / 2 - quitGameButton.Height / 2);
            quitGameButton.Click += QuitGameButton_Click;
            Controls.Add(quitGameButton);
        }

        private void HideButtons()
        {
            Option1.Hide();
            Option2.Hide();
            Option3.Hide();
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
    }
}
