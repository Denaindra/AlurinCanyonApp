using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class SearchCanyonScreen : ContentView
{
    private readonly HomePageViewModel vm;

    public SearchCanyonScreen(HomePageViewModel viewModel)
	{
		InitializeComponent();
		SetupUI();
        this.vm = viewModel;
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
        var searchBar = (SearchBar)sender;
        if (!string.IsNullOrEmpty(searchBar.Text))
        {
            vm.GetCannyonNamesList(searchBar.Text);
        }
    }

    private void CannyonItemTapped(object sender, ItemTappedEventArgs e)
    {
        vm.NavigateToCannyonBasePage();
    }
}