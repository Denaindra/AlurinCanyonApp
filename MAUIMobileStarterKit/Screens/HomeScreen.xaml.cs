using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.Screens.HomePageScreens;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class HomeScreen : ContentPage
{
    private HomePageViewModel viewModel;
    public HomeScreen(HomePageViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }
  
    protected override void OnAppearing()
    {
        base.OnAppearing();
        childLayout.Children.Add(new SearchCanyonScreen(viewModel));
        search.HeightRequest = 30;
    }
    protected override bool OnBackButtonPressed()
    {
        RemoveChildView();
        ResetView();
        return base.OnBackButtonPressed();

    }
    private void OnTapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
        ResetView();
        RemoveChildView();
        var iconobj = (Image)sender;
        iconobj.HeightRequest = 30;
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);

        switch (parameter)
        {
            case 0:
                backgroundInmage.Source = ImageSource.FromFile("backgroundvector2.png");
                childLayout.Children.Add(new SearchCanyonScreen(viewModel));
                break;
            case 1:
                childLayout.Children.Add(new GoogleMapScreen(viewModel));
                break;
            case 2:
                childLayout.Children.Add(new CanyonModificationScreen(viewModel));
                backgroundInmage.Source = ImageSource.FromFile("backgroundvector7.png");
                break;
        }
    }

    private void ResetView()
    {
        search.HeightRequest = 20;
        map.HeightRequest = 20;
        clock.HeightRequest = 20;
    }
    private void RemoveChildView()
    {
        childLayout.Children.Clear();
    }
}