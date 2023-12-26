
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class FlyoutPanelScreen : FlyoutPage
{
    private DashBoardViewModel dashBoard;
    private Page homescreen;
	public FlyoutPanelScreen(DashBoardViewModel dashBoard)
	{
		InitializeComponent();
        this.dashBoard = dashBoard;
        this.homescreen = dashBoard.PageNavigationSteup(0);
        dashBoard.navigation = Navigation;
        Constans.flyoutPage = this;
        LoadInitialPage();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var results = await dashBoard.CheckAndRequestLocationPermission();
    }
    private async void DashBoardItemTapped(object sender, TappedEventArgs e)
    {
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);
        if (parameter == 5)
        {
            bool answer = await DisplayAlert("Logout", "Would you like to Logout from the App ?", "Yes", "No");
        }
        else
        {
            Detail = new NavigationPage(dashBoard.PageNavigationSteup(parameter));
        }

    }
    private void LoadInitialPage()
    {
        Detail = homescreen;
        IsPresented = false;
    }
}