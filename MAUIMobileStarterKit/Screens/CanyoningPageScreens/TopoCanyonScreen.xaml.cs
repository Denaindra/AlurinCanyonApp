using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class TopoCanyonScreen : ContentView
{
	private readonly CannyonBasedViewModel vm;

    public TopoCanyonScreen(CannyonBasedViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
		BindingContext = vm;
		SteupUI();
    }

	private void SteupUI()
	{
        scrollView.HeightRequest = Constans.DeviceHeight-122;
        TopoListView.HeightRequest = Constans.DeviceHeight - 100;
        vm.LoadTopographies();
        if (Constans.SelectedCanyon.Topographies != null)
        {
            if (Constans.SelectedCanyon.Topographies.Any())
            {
                EmptyTopography.IsVisible = false;
            }
        }

    }

    private void AddObestacleClicked(object sender, EventArgs e)
    {
        vm.OpenPopup();
    }
}