using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.SettingsScreen;

public partial class CreateCannyonScreen : ContentPage
{
    private readonly CreateCanyonViewModel vm;

    public CreateCannyonScreen(CreateCanyonViewModel viewModel)
	{
		InitializeComponent();
        this.vm = viewModel;
        this.vm.navigation = Navigation;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if(vm.CountryList == null)
        {
            vm.GetCountriesAsync();
        }
    }

    private void SaveCannyoonClicked(object sender, EventArgs e)
    {

    }

    private void AddDescriptionClicked(object sender, EventArgs e)
    {
        vm.PushModalAsync(vm.GetAddDescriptionModal());
    }

    private void AddCorrdinateClicked(object sender, EventArgs e)
    {
        vm.PushModalAsync(vm.GetAddCoordinatorModal());
    }

    private void CountryPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.LoadRegionList(countryPicker.SelectedItem.ToString());
    }

    private void RegionPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.LoadStateList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString());
    }

    private void StatePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.LoadMountains(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString());
    }
    private void MountainPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.LoadBassinList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString());
    }
    private void BasinPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.LoadCityList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString(), basinPicker.SelectedItem.ToString());
    }
    private void CityPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.LoadRiverList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString(), basinPicker.SelectedItem.ToString(),cityPicker.SelectedItem.ToString());
    }
    private void RiverPickerSelectedIndexChanged(object sender, EventArgs e)
    {

    }
}