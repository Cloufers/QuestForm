public interface IAnimationController
{
    void InitializeAnimation(Label label, string textToAnimate, int interval);

    void StartAnimation();

    void StopAnimation();

    void ResetAnimation();

    void ClearAnimatedLabel();

    event EventHandler AnimationCompleted;
}