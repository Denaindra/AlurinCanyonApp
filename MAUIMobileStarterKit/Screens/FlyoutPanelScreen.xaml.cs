
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class FlyoutPanelScreen : FlyoutPage
{
    private DashBoardViewModel dashBoard;
    private HomeScreen homescreen;
	public FlyoutPanelScreen(DashBoardViewModel dashBoard, HomeScreen homescreen)
	{
		InitializeComponent();
        this.dashBoard = dashBoard;
        this.homescreen = homescreen;
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
            dashBoard.PageNavigationSteup(parameter);
        }

    }
    private void LoadInitialPage()
    {
        Detail = homescreen;
        IsPresented = false;
    }
}