using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class SearchCanyonScreen : ContentView
{
	public SearchCanyonScreen(HomePageViewModel viewModel)
	{
		InitializeComponent();
		SetupUI();
        BindingContext = viewModel;
        viewModel.LoadCannoynDetails();
    }

	private void SetupUI()
	{
        mapView.HeightRequest = Constans.DeviceHeight * 0.25;
        scrollView.HeightRequest = Constans.DeviceHeight * 0.75;
        mapView.UiSettings.MyLocationButtonEnabled = true;
    }

    private void SearchButtonPressed(object sender, EventArgs e)
    {

    }

}