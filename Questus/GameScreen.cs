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
        private IAnimationController animationController;

        private Label questionMark;

        public GameScreen()
        {
            InitializeComponent();
            animationController = new AnimationController();
            animationController.AnimationCompleted += AnimationController_AnimationCompleted;
            LoadGame();
        }

        private void AnimationController_AnimationCompleted(object sender, EventArgs e)
        {
            if (sceneGetter.IsEndingScene(currentSceneIndex))
            {
                ShowEndGameButtons();
            }
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

        private void InitializeAnimation()
        {
            if (currentScene != null && !string.IsNullOrEmpty(currentScene.SceneText))
            {
                var label = new Label
                {
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    AutoSize = true,
                    Location = new Point(180, 465),
                    Font = new Font("Arial", 18),
                    BorderStyle = BorderStyle.None
                };
                Controls.Add(label);

                animationController.InitializeAnimation(label, currentScene.SceneText, 25);
                animationController.StartAnimation();
            }
        }

        private void ResetAnimation()
        {
            animationController.ResetAnimation();
        }

        private void ClearAnimatedLabel()
        {
            animationController.ClearAnimatedLabel();
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

            if (sceneGetter.IsEndingScene(currentSceneIndex))
            {
                currentScene.SceneText = sceneGetter.GetEndingSceneText(currentSceneIndex);
                HideButtons();
            }

            UpdateScene();
        }

        private void StartAgainButton_Click(object? sender, EventArgs e)
        {
            Controls.Remove((Button)sender);
            Controls.Remove(Controls.OfType<Button>().FirstOrDefault(b => b.Text == "Quit Game"));
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

            questionMark = new Label
            {
                Text = "Wanna start again?",
                Location = new Point(500, 220),
                Font = new Font("Tempus Sans ITC", 25),
                TextAlign = ContentAlignment.MiddleLeft,
                BorderStyle = BorderStyle.None,
                Image = Properties.Resources.buttonFon,
                AutoSize = true
            };
            Controls.Add(questionMark);

            Button startAgainButton = new Button
            {
                Text = "Start Again",
                Size = new Size(90, 50),
                Font = new Font("Tempus Sans ITC", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(350, 550),
                Image = Properties.Resources.buttonFon
            };
            startAgainButton.Click += StartAgainButton_Click;
            Controls.Add(startAgainButton);

            Button quitGameButton = new Button
            {
                Text = "Quit Game",
                Size = new Size(90, 50),
                Location = new Point(850, 550),
                Font = new Font("Tempus Sans ITC", 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Image = Properties.Resources.buttonFon
            };
            quitGameButton.Click += QuitGameButton_Click;
            Controls.Add(quitGameButton);
        }

        private void HideButtons()
        {
            Option1.Hide();
            Option2.Hide();
            Option3.Hide();
        }

        private void RestartGame()
        {
            InitializeComponent();
            InitializeGame();
            InitializeAnimation();
            history.Push(0);
        }

        private void UpdateScene()
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
            InitializeGame();
            InitializeAnimation();
            BackgroundImage = Properties.Resources.ResourceManager.GetObject(currentScene.BackgroundImageName) as Image;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }
    }
}