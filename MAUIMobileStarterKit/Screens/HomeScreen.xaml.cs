using MAUIMobileStarterKit.Constant;
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
    }
    protected override async void OnSizeAllocated(double width, double height)
    {
        Constans.DeviceHeight = height;
        base.OnSizeAllocated(width, height);
        var results = await viewModel.CheckAndRequestLocationPermission();
        if (results)
        {
            SteupPage(0);
        }
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
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);
        SteupPage(parameter);
    }

    private void SteupPage(int parameter)
    {
        switch (parameter)
        {
            case 0:
                search.HeightRequest = 30;
                searchLabel.FontSize = 17;
                searchLabel.FontAttributes = FontAttributes.Bold;
                childLayout.Children.Add(new SearchCanyonScreen(viewModel));
                break;
            case 1:
                map.HeightRequest = 30;
                mapLabel.FontSize = 17;
                mapLabel.FontAttributes = FontAttributes.Bold;
                childLayout.Children.Add(new GoogleMapScreen(viewModel));
                break;
            case 2:
                clock.HeightRequest = 30;
                clockLabel.FontAttributes = FontAttributes.Bold;
                clockLabel.FontSize = 17;
                childLayout.Children.Add(new CanyonModificationScreen(viewModel));

                break;
        }
    }

    private void ResetView()
    {
        search.HeightRequest = 20;
        map.HeightRequest = 20;
        clock.HeightRequest = 20;

        searchLabel.FontAttributes = FontAttributes.None;
        mapLabel.FontAttributes = FontAttributes.None;
        clockLabel.FontAttributes = FontAttributes.None;

        searchLabel.FontSize = 10;
        mapLabel.FontSize = 10;
        clockLabel.FontSize = 10;
    }
    private void RemoveChildView()
    {
        childLayout.Children.Clear();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (!Constans.flyoutPage.IsPresented)
        {
            Constans.flyoutPage.IsPresented = true;
        }
    }
}