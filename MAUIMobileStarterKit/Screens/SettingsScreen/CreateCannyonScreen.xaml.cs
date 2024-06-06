using CommunityToolkit.Maui.Core.Extensions;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;
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

    protected override async void OnAppearing()
    {
        base.OnAppearing();
           
        
        if (Constans.UserRole == "Administrator")
        {
            entryUseremail.IsVisible = true;
            DeleteCanyonButton.IsVisible = true;
            switchvalidationcanyon.IsVisible = true;
        }

        if (vm.CountryList == null)
        {
           var results = await vm.GetCountriesAsync();
            if (results)
            {
                SetupModifyData();
            }
        }
        else
        {
            SetupModifyData();
        }
    }
    public void SetupModifyData()
    {
        if (IscanyonModify)
        {
                countryPicker.SelectedIndex = vm.GetIndexValue(Constans.SelectedCanyon.PaysFr, vm.CountryList);

                if (!string.Equals(Constans.SelectedCanyon.RegionString, "undefined"))
                {
                    vm.LoadRegionList(countryPicker.SelectedItem.ToString());
                    regionPicker.SelectedIndex = vm.GetIndexValue(Constans.SelectedCanyon.RegionString, vm.RegionList);
                }

                if (!string.Equals(Constans.SelectedCanyon.Departement, "undefined"))
                {
                    vm.LoadStateList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString());
                    statePicker.SelectedIndex = vm.GetIndexValue(Constans.SelectedCanyon.Departement, vm.StateList);
                }

                if (!string.Equals(Constans.SelectedCanyon.Massif, "undefined"))
                {
                    vm.LoadMountains(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString());
                    mountainPicker.SelectedIndex = vm.GetIndexValue(Constans.SelectedCanyon.Massif, vm.MountainList);
                }

                if (!string.Equals(Constans.SelectedCanyon.BassinString, "undefined"))
                {
                    vm.LoadBassinList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString());
                    basinPicker.SelectedIndex = vm.GetIndexValue(Constans.SelectedCanyon.BassinString, vm.BassinList);
                }

                if (!string.Equals(Constans.SelectedCanyon.Commune, "undefined"))
                {
                    vm.LoadCityList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString(), basinPicker.SelectedItem.ToString());
                    cityPicker.SelectedIndex = vm.GetIndexValue(Constans.SelectedCanyon.Commune, vm.CityList);
                }

                if (!string.Equals(Constans.SelectedCanyon.Courseau, "undefined"))
                {
                    vm.LoadRiverList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString(), basinPicker.SelectedItem.ToString(), cityPicker.SelectedItem.ToString());
                    riverPicker.SelectedIndex = vm.GetIndexValue(Constans.SelectedCanyon.Courseau, vm.RiverList);
                }



            entryName.Text = Constans.SelectedCanyon.Name;
            entryDcNote.Text = Constans.SelectedCanyon.DcNote.ToString();
            entryAltDepart.Text = Constans.SelectedCanyon.AltDepart.ToString();
            entryDeniv.Text = Constans.SelectedCanyon.Deniv.ToString();
            entryLongueur.Text = Constans.SelectedCanyon.Longueur.ToString();
            entryCasMax.Text = Constans.SelectedCanyon.CasMax.ToString();
            entryCotation.Text = Constans.SelectedCanyon.Cotation.ToString();
            entryCorde.Text = Constans.SelectedCanyon.Corde.ToString();
            Approchetemps.Time = Constans.SelectedCanyon.ApprocheTime;
            Descentetemps.Time = Constans.SelectedCanyon.DescenteTime;
            Retourtemps.Time = Constans.SelectedCanyon.BackTime;
            NavetteDistance.Text = Constans.SelectedCanyon.NavetteDistance.ToString();
            entrySource.Text = Constans.SelectedCanyon.Source;
            entryUserCreatorName.Text = Constans.SelectedCanyon.UserCreatorName;
            entryUseremail.Text = Constans.SelectedCanyon.Useremail;
            swithIsValidated.IsToggled = Constans.SelectedCanyon.IsValid;

            vm.AccessDescription = Constans.SelectedCanyon.AccesDescents?.ToObservableCollection();
            vm.Coorddinates = Constans.SelectedCanyon.Coordonnees?.ToObservableCollection();
            IscanyonModify = false;
        }
    }

    private async void SaveCannyoonClicked(object sender, EventArgs e)
    {
            var result = await vm.SaveCanyon(IscanyonModify);
            if (result)
            {
                IscanyonModify = false;
                await DisplayAlert("Message", "Thank you very much for your time in creation of canyon description, your canyon will be validated soon, you should receive an email for more information about this new canyon and when it will be validated. Thanks a lot !!!", "OK");
                vm.PopModalAsyncy();
            }
            else
            {
                await DisplayAlert("Message", "There is a mistake in canyon data you provide. Please correct it.", "OK");
                vm.PopModalAsyncy();
            }
    }

    private void AddDescriptionClicked(object sender, EventArgs e)
    {
        vm.PushModalAsync(vm.GetAddDescriptionModal(false));
    }

    private void AddCorrdinateClicked(object sender, EventArgs e)
    {
        vm.PushModalAsync(vm.GetAddCoordinatorModal(false));
    }

    private void CountryPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IscanyonModify)
        {
            vm.Country = countryPicker.SelectedItem.ToString();
            vm.LoadRegionList(countryPicker.SelectedItem.ToString());
        }
    }
    private void RegionPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IscanyonModify)
        {
            vm.Region = regionPicker.SelectedItem.ToString();
            vm.LoadStateList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString());
        }
    }
    private void StatePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IscanyonModify)
        {
            vm.State = statePicker.SelectedItem.ToString();
            vm.LoadMountains(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString());
        }
    }
    private void MountainPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IscanyonModify)
        {
            vm.Mountain = mountainPicker.SelectedItem.ToString();
            vm.LoadBassinList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString());
        }
    }
    private void BasinPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IscanyonModify)
        {
            vm.Basin = basinPicker.SelectedItem.ToString();
            vm.LoadCityList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString(), basinPicker.SelectedItem.ToString());
        }
    }
    private void CityPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IscanyonModify)
        {
            vm.City = cityPicker.SelectedItem.ToString();
            vm.LoadRiverList(countryPicker.SelectedItem.ToString(), regionPicker.SelectedItem.ToString(), statePicker.SelectedItem.ToString(), mountainPicker.SelectedItem.ToString(), basinPicker.SelectedItem.ToString(), cityPicker.SelectedItem.ToString());
        }
    }
    private void RiverPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IscanyonModify)
        {
            vm.River = riverPicker.SelectedItem.ToString();
        }
    }
    private async void DeleteClicked(object sender, EventArgs e)
    {
        var results = await vm.DeleteCanyon(Constans.SelectedCanyon.Id);
        if (results)
        {
            var action = await DisplayAlert("Alert !!!!!!!", "Are you sure you want to delete the data ?", "OK", "Delete");
        }
    }

    private async void CoordinatesItemTapped(object sender, ItemTappedEventArgs e)
    {
        vm.SetTheSelecteCoordonnedModal(e.Item);
        var action = await DisplayAlert("Coordinates", vm.GetTheSelecteCoordonnedModal().PointType + ", Long: " + vm.GetTheSelecteCoordonnedModal().Long + ", Lat: " + vm.GetTheSelecteCoordonnedModal().Lat, "OK", "Modify");
        if (!action)
        {
            if (Constans.UserRole == "Administrator" || Constans.UserRole == "Premium")
            {
                vm.PushModalAsync(vm.GetAddCoordinatorModal(true));
            }
            else
            {
                await DisplayAlert("Error !!!!", "You have to be administrator to do this operation !!", "OK");
            }
        }
    }

    private async void AccessDescriptionItemTapped(object sender, ItemTappedEventArgs e)
    {
        vm.SetTheSelecteAccessDescriptioModal(e.Item);
        var action = await DisplayAlert("Description", vm.GetTheSelectedAccessDescriptionModal().Acces + "... ", "OK", "Modify");
        if (!action)
        {
            if (Constans.UserRole == "Administrator" || Constans.UserRole == "Premium")
            {
                  vm.PushModalAsync(vm.GetAddDescriptionModal(true));
            }
            else
            {
                await DisplayAlert("Error !!!!", "You have to be administrator to do this operation !!", "OK");
            }
        }
    }
}