using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class SearchCanyonScreen : ContentView
{
    private readonly HomePageViewModel viewModel;

    public SearchCanyonScreen(HomePageViewModel viewModel)
	{
		InitializeComponent();
		SetupUI();
        this.viewModel = viewModel;
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

    private void CannyonItemTapped(object sender, ItemTappedEventArgs e)
    {
        viewModel.NavigateToCannyonBasePage();
    }
}