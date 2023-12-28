using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.SettingsScreen;

public partial class CreateCannyonScreen : ContentPage
{
    private readonly CreateCoordinateViewModel viewModel;
    public CreateCannyonScreen(CreateCoordinateViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        this.viewModel.navigation = Navigation;
	}

    private void SaveCannyoonClicked(object sender, EventArgs e)
    {

    }

    private void AddDescriptionClicked(object sender, EventArgs e)
    {
        viewModel.PushModalAsync(viewModel.GetAddDescriptionModal());
    }

    private void AddCorrdinateClicked(object sender, EventArgs e)
    {
        viewModel.PushModalAsync(viewModel.GetAddCoordinatorModal());
    }
}