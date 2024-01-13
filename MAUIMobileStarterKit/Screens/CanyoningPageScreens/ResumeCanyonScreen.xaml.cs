using MAUIMobileStarterKit.Constant;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class ResumeCanyonScreen : ContentView
{
	public ResumeCanyonScreen()
	{
		InitializeComponent();
        SetupUI();

    }

    private void SetupUI()
    {
        scrollView.HeightRequest = 18000;//Constans.DeviceHeight;
    }
}