using ReaLTaiizor.Forms;

namespace Questus
{
    public partial class MainMenu : FixedSizeForm
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            GameScreen gameScreen = new GameScreen();
            gameScreen.Show();
            Hide();
        }
    }
}
