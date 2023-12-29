namespace MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;

public partial class AddDescriptionModal : ContentPage
{
	public AddDescriptionModal()
	{
		InitializeComponent();
	}

    private void SaveDescription(object sender, EventArgs e)
    {

    }

    private void BackBtnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

}