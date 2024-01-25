using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class ProCanyonScreen : ContentView
{
    private CannyonBasedViewModel viewModel;
	public ProCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
        SteupUI();
	}

    private void SteupUI()
    {
        scrolllayout.HeightRequest = Constans.DeviceHeight - 122;
        viewModel.LoadPerforssioanlList();
    }
}