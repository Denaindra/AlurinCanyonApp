using MAUIMobileStarterKit.Constant;

namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class SearchCanyonScreen : ContentView
{
	public SearchCanyonScreen()
	{
		InitializeComponent();
		SetupUI();
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