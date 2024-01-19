using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class ReglementationCanyonScreen : ContentView
{
	private CannyonBasedViewModel viewModel;
	public ReglementationCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
        BindingContext = viewModel;
        SteupUI();

    }
    private void SteupUI()
    {
        stackLayout.HeightRequest = Constans.DeviceHeight - 122;
        viewModel.LoadReglementation();
    }
}