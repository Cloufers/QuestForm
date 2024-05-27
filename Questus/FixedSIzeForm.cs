public class FixedSizeForm : Form
{
    public FixedSizeForm()
    {
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Width = 1280;
        Height = 720;
    }

    protected override void OnResize(EventArgs e)
    {
        Width = 1280;
        Height = 720;
        base.OnResize(e);   
    }


}
