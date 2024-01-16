using MAUIMobileStarterKit.Constant;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class CanyonMapScreen : ContentView
{
	public CanyonMapScreen()
	{
		InitializeComponent();
		SteupUI();

    }

	private void SteupUI()
	{
		mapView.HeightRequest = Constans.DeviceHeight;
    }
}