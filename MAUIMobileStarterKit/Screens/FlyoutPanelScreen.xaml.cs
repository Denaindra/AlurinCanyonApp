
using Auth0.OidcClient;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class FlyoutPanelScreen : FlyoutPage
{
    private DashBoardViewModel dashBoardvm;
    private Page homescreen;
    public FlyoutPanelScreen(DashBoardViewModel dashBoardvm)
    {
        InitializeComponent();
        this.dashBoardvm = dashBoardvm;
        this.homescreen = dashBoardvm.PageNavigationSteup(0);
        dashBoardvm.navigation = Navigation;
        Constans.flyoutPage = this;
        LoadInitialPage();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var results = await dashBoardvm.CheckUserLogin();
        if (results)
        {
            flyoutContentPage.IsVisible = true;
        }
    }
    private void DashBoardItemTapped(object sender, TappedEventArgs e)
    {
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);

            if(dashBoardvm.PageNavigationSteup(parameter) is LogOutPage)
            {
                dashBoardvm.PushModalAsync(dashBoardvm.PageNavigationSteup(parameter));
            }
            else
            {
                Detail = new NavigationPage(dashBoardvm.PageNavigationSteup(parameter));
            }
    }
    private void LoadInitialPage()
    {
        Detail = homescreen;
        IsPresented = false;
    }
}