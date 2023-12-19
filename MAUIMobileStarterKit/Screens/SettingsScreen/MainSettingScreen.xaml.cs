namespace MAUIMobileStarterKit.Screens.SettingsScreen;

public partial class MainSettingScreen : ContentPage
{
	public MainSettingScreen()
	{
		InitializeComponent();
	}

    protected override void OnSizeAllocated(double pageWidth, double pageHeight)
    {
        base.OnSizeAllocated(pageWidth, pageHeight);
        const double aspectRatio = 1600 / 1441.0; // Aspect ratio of the original image
        backgroundImage.WidthRequest = Math.Max(pageHeight * aspectRatio, pageWidth);
    }

    private void LanugaeSelectedIndexChanged(object sender, EventArgs e)
    {
   
    }

    private void LanuageTapped(object sender, TappedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            picker.Focus();
        });
    }
}