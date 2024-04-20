using Maui.GoogleMaps;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class CanyonMapScreen : ContentView
{
	private CannyonBasedViewModel vm;

    public CanyonMapScreen(CannyonBasedViewModel vm)
	{
		InitializeComponent();
        this.vm = vm;
        SteupUI();
    }

	private void SteupUI()
	{
		mapView.HeightRequest = Constans.DeviceHeight;
		if (Constans.SelectedCanyon.Coordonnees.Any())
		{
            vm.SetUpCoordinateDetails();
            foreach (var elt in Constans.SelectedCanyon.Coordonnees)
            {
                var pin = new Pin()
                {
                    Type = PinType.Place,
                    Label = Convert.ToString(elt.PointType),
                    Position = new Position(elt.Lat, elt.Long),
                    Tag = Convert.ToString(elt.PointType)
                };
                mapView.Pins.Add(pin);
            }
            mapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(vm.GetMeanlat(), vm.GetMeanLong()), Distance.FromKilometers(vm.GetPointDistance())));
        }
    }
}