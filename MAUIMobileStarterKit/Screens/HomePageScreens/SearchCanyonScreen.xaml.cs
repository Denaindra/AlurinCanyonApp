using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;
using Microsoft.Maui.Controls;

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
        viewModel.LoadCanyonCountriesAsync();
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
    private void CountryPickerSelectedIndexChanged(object sender, EventArgs e)
    {
       vm.LoadTheRegionBasedOnSelectedCountry(countryPicker.SelectedItem.ToString());
    }
    private void RegionSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.LoadTheStateBasedOnSelectedCountryAndRegion(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString());
    }
    private void StateSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        // regionEntry.Text = picker.SelectedItem.ToString();
    }
    private void SearchCannyonClicked(object sender, EventArgs e)
    {
        if(countryPicker.SelectedItem != null && statePicker.SelectedItem != null && regionPicker.SelectedItem != null)
        {
            vm.SearchCannyon(countryPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString());
        }
    }

    private void ValidatecanyonBtnClicked(object sender, EventArgs e)
    {
        vm.ValidateCanyon();
    }
}