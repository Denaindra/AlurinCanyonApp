namespace MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;

public partial class AddCoordinatorModal : ContentPage
{
	public AddCoordinatorModal()
	{
		InitializeComponent();
	}

    private void SaveCoordinate(object sender, EventArgs e)
    {

    }

    private void BackBtnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}