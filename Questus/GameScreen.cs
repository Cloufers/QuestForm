using SceneControl;
using Scenes;

namespace Questus
{
    public partial class GameScreen : FixedSizeForm
    {
        // FIELDS
        private SceneManager sceneManager;

        private string dbPath = "ScenesDATA.db";

        private List<SceneHolder> listScenes;
        private int currentSceneIndex;
        private Stack<int> history;
        private SceneHolder currentScene;
        private SceneGetter sceneGetter;

        // ANIMATION FIELDS
        private Label animatedLabel;

        private string textToAnimate;
        private int currentCharIndex;
        private Label questionMark;
        private System.Windows.Forms.Timer animationTimer;

        public GameScreen()
        {
            LoadGame();
        }

        private void InitializeGame()
        {
            sceneGetter = new SceneGetter(dbPath);
            listScenes = sceneGetter.GetScenes();
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
                animatedLabel.ForeColor = Color.Orange;
                animatedLabel.FlatStyle = FlatStyle.Flat;
                animatedLabel.BackColor = Color.Transparent;
                animatedLabel.AutoSize = true;
                animatedLabel.Location = new Point(180, 465); // Location
                animatedLabel.Font = new Font("Arial", 18); // Font/Size
                animatedLabel.BorderStyle = BorderStyle.None;
                Controls.Add(animatedLabel);
                animationTimer = new System.Windows.Forms.Timer();
                animationTimer.Interval = 25; // Interval
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
                if (sceneGetter.IsEndingScene(currentSceneIndex))
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

            if (sceneGetter.IsEndingScene(currentSceneIndex))
            {
                currentScene.SceneText = sceneGetter.GetEndingSceneText(currentSceneIndex);
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

            BackgroundImage = Properties.Resources.scene0;

            questionMark = new Label();
            questionMark.Text = "Wanna start again?";
            questionMark.Location = new Point(500, 220);
            questionMark.Font = new Font("Tempus Sans ITC", 25); // Font/Size
            questionMark.TextAlign = ContentAlignment.MiddleLeft;
            questionMark.BorderStyle = BorderStyle.None;
            questionMark.Image = Properties.Resources.buttonFon;
            questionMark.AutoSize = true;
            Controls.Add(questionMark);

            Button startAgainButton = new Button();
            startAgainButton.Text = "Start Again";
            startAgainButton.Size = new Size(90, 50);
            startAgainButton.Font = new Font("Tempus Sans ITC", 20); // Font/Size
            startAgainButton.TextAlign = ContentAlignment.MiddleCenter;
            startAgainButton.Location = new Point(350, 550);
            startAgainButton.Image = Properties.Resources.buttonFon;
            startAgainButton.Click += StartAgainButton_Click;
            Controls.Add(startAgainButton);

            Button quitGameButton = new Button();
            quitGameButton.Text = "Quit Game";
            quitGameButton.Size = new Size(90, 50);
            quitGameButton.Location = new Point(850, 550); //(Width / 2 + 40, Height / 2 - quitGameButton.Height - 40);
            quitGameButton.Font = new Font("Tempus Sans ITC", 20); // Font/Size
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
            if (!string.IsNullOrEmpty(currentScene.BackgroundImageName))
            {
                BackgroundImage = Properties.Resources.ResourceManager.GetObject(currentScene.BackgroundImageName) as Image;
            }

            UpdateButtonTextAndHandlers();
            ResetAnimation();
            InitializeAnimation();
        }

        private void LoadGame()
        {
            InitializeComponent();
            InitializeGame();
            InitializeAnimation();
            BackgroundImage = Properties.Resources.ResourceManager.GetObject(currentScene.BackgroundImageName) as Image;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }
    }
}