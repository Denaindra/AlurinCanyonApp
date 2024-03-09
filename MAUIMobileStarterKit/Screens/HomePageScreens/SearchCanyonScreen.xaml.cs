using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;
using Microsoft.Maui.Controls;

namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class SearchCanyonScreen : ContentView
{
    private readonly HomePageViewModel vm;
    private Entry countryEntry;

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

      countryEntry = (Entry)contryEntry.FindByName("EntryField");
      countryEntry.Focused += CountryEntryFocused;
    }

    private void CountryEntryFocused(object sender, FocusEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() => {
            countryEntry.Unfocus();
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

    private void CountryPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        countryEntry.Text = picker.SelectedItem.ToString();
    }
}