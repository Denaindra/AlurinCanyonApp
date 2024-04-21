using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class TopoCanyonScreen : ContentView
{
	private readonly CannyonBasedViewModel viewModel;

    public TopoCanyonScreen(CannyonBasedViewModel vm)
	{
		InitializeComponent();
		this.viewModel = vm;
		BindingContext = vm;
		SteupUI();
    }

	private void SteupUI()
	{
        scrollView.HeightRequest = Constans.DeviceHeight-122;
        TopoListView.HeightRequest = Constans.DeviceHeight - 100;
        viewModel.LoadTopographies();
        if (Constans.SelectedCanyon.Topographies != null)
        {
            if (Constans.SelectedCanyon.Topographies.Any())
            {
                EmptyTopography.IsVisible = false;
            }
        }

    }
}