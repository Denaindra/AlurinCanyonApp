using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.SettingsScreen;

public partial class MainSettingScreen : ContentPage
{
    private readonly SettingsViewModel viewModel;
    public MainSettingScreen(SettingsViewModel viewModel)
	{
		InitializeComponent();
        viewModel.navigation = Navigation;
        this.viewModel = viewModel;
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

    private void SettingItemtapped(object sender, TappedEventArgs e)
    {
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);

        if (parameter == 0)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                picker.Focus();
            });
        }
        else
        {
            viewModel.NavigationCannyonCreatePage();
        }
    }
}