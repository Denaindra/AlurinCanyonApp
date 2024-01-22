using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class TabbedPicturesCanyonScreen : ContentView
{
    private readonly CannyonBasedViewModel viewModel;

    public TabbedPicturesCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
	}

    private void CameraBtnClicked(object sender, EventArgs e)
    {
        viewModel.TakePhoto();
    }
}