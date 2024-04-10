using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;

public partial class AddDescriptionModal : ContentPage
{
    public CreateCanyonViewModel vm;
    public AddDescriptionModal()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = vm;
    }
    private void SaveDescription(object sender, EventArgs e)
    {
        vm.SaveDescription();
    }

    private void BackBtnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

}