using NAudio.Wave;

namespace Questus
{
    public partial class MainMenu : FixedSizeForm
    {
        private WaveOutEvent waveOut;

        public MainMenu()
        {
            InitializeComponent();
            BackgroundMusic();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            GameScreen gameScreen = new GameScreen();
            gameScreen.Show();
            Hide();
        }

        private void BackgroundMusic()
        {
            var musicFilePath = "back.mp3";
                waveOut = new WaveOutEvent();

                using (var reader = new Mp3FileReader(musicFilePath))
                {
                    waveOut.Init(reader);
                    waveOut.Play();
                }
     
        }

 
    }
}