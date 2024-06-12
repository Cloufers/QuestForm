namespace Scenes
{
    public class SceneHolder
    {
        private string _sceneText = string.Empty;
        private string _backgroundImageName = string.Empty;

        public SceneHolder()
        {
        }

        private List<string> _actions = new List<string>();
        private List<int> _goToScene = new List<int>();

        public List<string> SceneActions
        {
            get { return _actions; }
            set { _actions = value; }
        }

        public List<int> SceneGoTo
        {
            get { return _goToScene; }
            set { _goToScene = value; }
        }

        public string SceneText
        {
            get { return _sceneText; }
            set { _sceneText = value; }
        }

        public string BackgroundImageName
        {
            get { return _backgroundImageName; }
            set { _backgroundImageName = value; }
        }
    }
}