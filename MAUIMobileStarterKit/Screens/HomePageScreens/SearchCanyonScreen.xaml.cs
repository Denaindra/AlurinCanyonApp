using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class SearchCanyonScreen : ContentView
{
    private readonly HomePageViewModel vm;
    private Entry CountryEntry;

    public SearchCanyonScreen(HomePageViewModel viewModel)
	{
		InitializeComponent();
		SetupUI();
        this.vm = viewModel;
        BindingContext = viewModel;
        viewModel.LoadCannoynDetails();
         viewModel.LoadCanyonCountriesAsync();
    }

	private void SetupUI()
	{
      scrollView.HeightRequest = Constans.DeviceHeight;
      mapView.UiSettings.MyLocationButtonEnabled = true;

      CountryEntry = (Entry)contryEntry.FindByName("EntryField");
      CountryEntry.Focused += CountryEntryFocused;
    }

    private void CountryEntryFocused(object sender, FocusEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() => {
            CountryEntry.Unfocus();
            countryPicker.Focus();
        });
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