using Maui.GoogleMaps;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.ViewModels;
using System.Linq;
namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class GoogleMapScreen : ContentView
{
	private HomePageViewModel vm;
	public GoogleMapScreen(HomePageViewModel viewModel)
	{
		InitializeComponent();
        this.vm = viewModel;
        InitiateMapView();
    }
	private async void InitiateMapView()
	{
        mapview.HeightRequest =  Constans.DeviceHeight;
        mapview.UiSettings.MyLocationButtonEnabled = true;
		var resultsOfCustomPings = await vm.GetAllCoordinates();
        if (resultsOfCustomPings.Any())
        {
            foreach (var map in resultsOfCustomPings.Where(x => x.Coordonnee != null))
            {
                Pin pin = new Pin()
                {
                    Type = PinType.Place,
                    Label = map.Name,
                    Position = new Position(map.Coordonnee.Lat, map.Coordonnee.Long),
                    Address = map.DcNoteText
                };
                mapview.Pins.Add(pin);
            }
        }
    }
}