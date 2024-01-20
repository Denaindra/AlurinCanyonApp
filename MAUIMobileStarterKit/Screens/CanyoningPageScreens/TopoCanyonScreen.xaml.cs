using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class TopoCanyonScreen : ContentView
{
	private readonly CannyonBasedViewModel viewModel;

    public TopoCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		BindingContext = viewModel;
		SteupUI();
    }

	private void SteupUI()
	{
        scrollView.HeightRequest = Constans.DeviceHeight-122;
        TopoListView.HeightRequest = Constans.DeviceHeight - 100;
        viewModel.LoadTopographies();

    }
}