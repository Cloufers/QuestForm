using Scenes;

namespace Questus
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
           GameScreen gameScreen = new GameScreen();

            gameScreen.Show();

            this.Hide();
        }
    }
}