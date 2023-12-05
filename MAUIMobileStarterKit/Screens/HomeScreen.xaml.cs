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
    protected override void OnSizeAllocated(double pageWidth, double pageHeight)
    {
        //base.OnSizeAllocated(pageWidth, pageHeight);
        //const double aspectRatio = 1600 / 1441.0; // Aspect ratio of the original image
        //backgroundImage.WidthRequest = Math.Max(pageHeight * aspectRatio, pageWidth);
    }
    private void OnTapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);

    }
}