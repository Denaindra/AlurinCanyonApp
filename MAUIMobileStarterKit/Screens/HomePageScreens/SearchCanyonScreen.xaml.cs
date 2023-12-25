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
      scrollView.HeightRequest = Constans.DeviceHeight;
      mapView.UiSettings.MyLocationButtonEnabled = true;
    }

 

    private void SearchButtonPressed(object sender, EventArgs e)
    {

    }

}