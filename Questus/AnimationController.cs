public class AnimationController : IAnimationController
{
    private Label? _animatedLabel;
    private string? _textToAnimate;
    private int _currentCharIndex;
    private System.Windows.Forms.Timer? _animationTimer;

    public event EventHandler? AnimationCompleted;

    public void InitializeAnimation(Label label, string textToAnimate, int interval)
    {
        _animatedLabel = label;
        _textToAnimate = textToAnimate;
        _currentCharIndex = 0;

        _animationTimer = new System.Windows.Forms.Timer { Interval = interval };
        _animationTimer.Tick += AnimationTimer_Tick;
    }

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        if (_currentCharIndex < _textToAnimate.Length)
        {
            _animatedLabel.Text = _textToAnimate.Substring(0, _currentCharIndex + 1);
            _currentCharIndex++;
        }
        else
        {
            StopAnimation();
            AnimationCompleted?.Invoke(this, EventArgs.Empty);
        }
    }

    public void StartAnimation()
    {
        _animationTimer.Start();
    }

    public void StopAnimation()
    {
        _animationTimer.Stop();
    }

    public void ResetAnimation()
    {
        StopAnimation();
        _currentCharIndex = 0;
        _animatedLabel.Text = string.Empty;
    }

    public void ClearAnimatedLabel()
    {
        if (_animatedLabel != null)
        {
            _animatedLabel.Dispose();
            _animatedLabel = null;
        }
    }
}