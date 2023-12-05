using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.Screens.HomePageScreens;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class HomeScreen : ContentPage
{
    
    public HomeScreen()
    {
        InitializeComponent();
    }
  
    protected override void OnAppearing()
    {
        base.OnAppearing();
        childLayout.Add(new SearchCanyonScreen());
    }
    private void OnTapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);

    }
}