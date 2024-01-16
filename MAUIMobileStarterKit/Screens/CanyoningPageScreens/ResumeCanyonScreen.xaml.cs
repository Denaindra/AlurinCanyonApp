using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class ResumeCanyonScreen : ContentView
{
    private readonly CannyonBasedViewModel viewModel;
    public ResumeCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
        SetupUI();
    }

    private void SetupUI()
    {
        //scrollView.HeightRequest = 18000;//Constans.DeviceHeight;
        viewModel.LoadCannoynDetails();
        viewModel.LoadUserCreators();
    }
}