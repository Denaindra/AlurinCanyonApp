using Maui.GoogleMaps;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Models.Service;
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
        UpdateMapList();
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

    private async void UpdateMapList()
    {
        List<Coordonnee> CoordList = new List<Coordonnee>();
        var canyonList = await vm.UnvalidatedCanyon();
        foreach (var canyon in canyonList)
        {
            if (canyon.Coordonnees.Any())
            {
                CoordList.Add(canyon.Coordonnees.FirstOrDefault());
                var mapping = new Pin()
                {
                    Type = PinType.Place,
                    Label = canyon.Name,
                    Position = new Position(canyon.Coordonnees.FirstOrDefault().Lat, canyon.Coordonnees.FirstOrDefault().Long),
                    Address = "Note :" + canyon.DcNote.ToString() + "/4",
                };
                mapView.Pins.Add(mapping);
            }
        }
        if (canyonList.Any())
        {
            double meanLat = CoordList.Average(c => c.Lat);
            double LatMax = CoordList.Max(c => c.Lat);
            double LatMin = CoordList.Min(c => c.Lat);
            double meanLong = CoordList.Average(c => c.Long);
            double LongMax = CoordList.Max(c => c.Long);
            double LongMin = CoordList.Min(c => c.Long);
            double PointDistance = Location.CalculateDistance(LatMin, LongMin, LatMax, LongMax, 0) + 0.5;
            mapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(meanLat, meanLong), Distance.FromKilometers(PointDistance)));
        }
        else
        {
           await App.Current.MainPage.DisplayActionSheet("Message", "No coordinates found !!!", "OK");
        }
    }
    private void CreateCanyonBtnClicked(object sender, EventArgs e)
    {
        vm.NavigateCreateCanyonScreen();
    }
}