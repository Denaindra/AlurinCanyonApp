using Auth0.OidcClient;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class LogOutPage : ContentPage
{
    public DashBoardViewModel dashBoardView;
    
    public LogOutPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var isuserLogOut = await dashBoardView.IsUserLogOut();
        if (isuserLogOut)
        {
            loginLogoutbtn.Text = Constans.LogingTitle;
        }
        else
        {
            loginLogoutbtn.Text = Constans.LogoutTitle;
        }
    }
    protected override bool OnBackButtonPressed()
    {
        return false;
    }

    private async void LogoOutClicked(object sender, EventArgs e)
    {
       var isuserLogOut = await dashBoardView.IsUserLogOut();
        if (isuserLogOut)
        {
            var results = await dashBoardView.CheckUserLogin();
            if (results)
            {
                loginLogoutbtn.Text = Constans.LogoutTitle;
                dashBoardView.PopModalAsyncy();
            }
        }
        else
        {
            bool answer = await DisplayAlert("Logout", "Would you like to Logout from the App ?", "Yes", "No");
            if (answer)
            {
                dashBoardView.LogOutTheUser();
                loginLogoutbtn.Text = Constans.LogingTitle;
                dashBoardView.PopModalAsyncy();
            }
        }

    }
}