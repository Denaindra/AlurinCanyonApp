using MAUIMobileStarterKit.Constant;
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
    private void LanugaeSelectedIndexChanged(object sender, EventArgs e)
    {
   
    }

    private async void SettingItemtapped(object sender, TappedEventArgs e)
    {
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);

        if (parameter == 0)
        {
            //MainThread.BeginInvokeOnMainThread(() =>
            //{
            //    //picker.IsVisible = true;
            //    picker.Focus();
            //});Lanugaes
            string action = await DisplayActionSheet("Select a Lanuage", "Cancel", null,"English (en)","French (fr)","Italian (It)","Spanish (es)");

        }
        else
        {
            viewModel.NavigationCannyonCreatePage();
        }
    }

    private void MenueClicked(object sender, EventArgs e)
    {
        if (!Constans.flyoutPage.IsPresented)
        {
            Constans.flyoutPage.IsPresented = true;
        }
    }
}