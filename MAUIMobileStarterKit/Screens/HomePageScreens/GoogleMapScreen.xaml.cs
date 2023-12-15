using MAUIMobileStarterKit.Constant;

namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class GoogleMapScreen : ContentView
{
	public GoogleMapScreen(ViewModels.HomePageViewModel viewModel)
	{
		InitializeComponent();
		InitiateMapView();

    }

	private void InitiateMapView()
	{
        mapview.HeightRequest =  Constans.DeviceHeight;
        mapview.UiSettings.MyLocationButtonEnabled = true;
    }
}