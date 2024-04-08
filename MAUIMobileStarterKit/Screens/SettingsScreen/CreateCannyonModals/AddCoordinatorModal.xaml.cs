using Maui.GoogleMaps;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;

public partial class AddCoordinatorModal : ContentPage
{

    public CreateCoordinateViewModel vm;

    public AddCoordinatorModal()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = vm;
    }

    private void SaveCoordinate(object sender, EventArgs e)
    {
        vm.AddCordinateForCreateCanyon(pinPointpicker.SelectedIndex);
    }

    private void BackBtnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void GetCurrentGEOCoordinates(object sender, EventArgs e)
    {
        var result = await vm.GetCachedLocation();
        var latitude = result[0];
        var longotude = result[1];

        Pin pin = new Pin()
        {
            Type = PinType.Place,
            Label = "",
            Position = new Position(latitude, longotude)
        };

        mapView.Pins.Add(pin);
        mapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longotude), Distance.FromKilometers(5)));
    }
}