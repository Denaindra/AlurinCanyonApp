using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.SettingsScreen;

public partial class CreateCannyonScreen : ContentPage
{
    private readonly CreateCanyonViewModel vm;
    public bool IscanyonModify;
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

        if (Constans.UserRole == "Administrator")
        {
            //entryUseremail.IsVisible = true;
            //Labelemail.IsVisible = true;
            //buttonAddStates.IsVisible = true;
            //buttonAddCities.IsVisible = true;
            //buttonAddMountain.IsVisible = true;
            //buttonAddBassin.IsVisible = true;
            //buttonAddRiver.IsVisible = true;
            //DeleteCanyonButton.IsVisible = true;
            //switchvalidationcanyon.IsVisible = true;

        }
    }

    private async void SaveCannyoonClicked(object sender, EventArgs e)
    {
        var result = await vm.SaveCanyon();
        if (result)
        {
            await DisplayAlert("Message", "Thank you very much for your time in creation of canyon description, your canyon will be validated soon, you should receive an email for more information about this new canyon and when it will be validated. Thanks a lot !!!", "OK");
            vm.PopModalAsyncy();
        }
        else
        {
            await DisplayAlert("Message", "There is a mistake in canyon data you provide. Please correct it.", "OK");
        }
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
        vm.Country = countryPicker.SelectedItem.ToString();
        vm.LoadRegionList(countryPicker.SelectedItem.ToString());
    }

    private void RegionPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.Region = regionPicker.SelectedItem.ToString();
        vm.LoadStateList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString());
    }

    private void StatePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.State = statePicker.SelectedItem.ToString();
        vm.LoadMountains(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString());
    }
    private void MountainPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.Mountain = mountainPicker.SelectedItem.ToString();
        vm.LoadBassinList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString());
    }
    private void BasinPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.Basin = basinPicker.SelectedItem.ToString(); 
        vm.LoadCityList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString(), basinPicker.SelectedItem.ToString());
    }
    private void CityPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.City = cityPicker.SelectedItem.ToString();
        vm.LoadRiverList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString(), basinPicker.SelectedItem.ToString(),cityPicker.SelectedItem.ToString());
    }
    private void RiverPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        vm.River = riverPicker.SelectedItem.ToString(); 
    }

    private async void DeleteClicked(object sender, EventArgs e)
    {
        var results = await vm.DeleteCanyon(Constans.SelectedCanyon.Id);
        if (results)
        {
            var action = await DisplayAlert("Alert !!!!!!!", "Are you sure you want to delete the data ?", "OK","Delete");
        }
    }
}