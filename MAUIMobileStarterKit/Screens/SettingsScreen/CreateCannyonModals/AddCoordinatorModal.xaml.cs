using Maui.GoogleMaps;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.ViewModels;
using Microsoft.Maui.ApplicationModel;

namespace MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;

public partial class AddCoordinatorModal : ContentPage
{
    public CreateCanyonViewModel vm;
    public bool isModifyAddCoordinatiorModal;
    
    public AddCoordinatorModal()
    {
        InitializeComponent();
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = vm;
        if (isModifyAddCoordinatiorModal)
        {
            SetupDeleteAndModifyUI();
        }
    }
    private void SetupDeleteAndModifyUI()
    {
        var selectedCannore = vm.GetTheSelecteCoordonnedModal();
        savebtn.IsVisible = false;
        deleteBtn.IsVisible = true;
        modifyBtn.IsVisible = true;

        int pointtypepickerIndex = (int)selectedCannore.PointType;
        pinPointpicker.SelectedIndex = pointtypepickerIndex;

        longitude.Text = selectedCannore.Long.ToString();
        latitude.Text = selectedCannore.Lat.ToString();

        MapSetup(selectedCannore.Lat, selectedCannore.Long,false);
    }
    private void SaveCoordinate(object sender, EventArgs e)
    {
        vm.AddCordinateForCreateCanyon(pinPointpicker.SelectedIndex);
    }
    private void BackBtnClicked(object sender, EventArgs e)
    {
        vm.PopModalAsyncy();
    }
    private async void GetCurrentGEOCoordinates(object sender, EventArgs e)
    {
        var result = await vm.GetCachedLocation();
        var latitude = result[0];
        var longotude = result[1];
        MapSetup(latitude, longotude,true);
    }
    private void MapSetup(double latitude, double longotude, bool isAdd)
    {
        Pin pin = new CustomPin()
        {
            Type = PinType.Place,
            Label = "",
            Position = new Position(latitude, longotude),
            Icon = BitmapDescriptorFactory.FromBundle(isAdd ? vm.GetMapPins("InternalPoint") : vm.GetMapPins(vm.GetTheSelecteCoordonnedModal().PointType.ToString())),
        };

        mapView.Pins.Add(pin);
        mapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(latitude, longotude), Distance.FromKilometers(5)));
    }
    private void ModifyBtnClicked(object sender, EventArgs e)
    { 
        var selectedModal = vm.GetTheSelecteCoordonnedModal();
        selectedModal.PointType = vm.GetSelectedPointTypeIndex(pinPointpicker.SelectedIndex);
        vm.ModifyCordinateForCreateCanyon(selectedModal);
        vm.PopModalAsyncy();
    }
    private void DeleteBtnClicked(object sender, EventArgs e)
    {
        vm.DeleteCordinateForCreateCanyon(vm.GetTheSelecteCoordonnedModal());
        vm.PopModalAsyncy();
    }
}