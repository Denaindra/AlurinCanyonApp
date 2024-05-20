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

    private async void SteupUI()
    {
        var istopoLoaded = await vm.LoadTopographies();
        if (istopoLoaded)
        {
            if (Constans.SelectedCanyon.Topographies != null)
            {
                if (Constans.SelectedCanyon.Topographies.Any())
                {
                    EmptyTopography.IsVisible = false;
                    scrollView.HeightRequest = Constans.DeviceHeight - 122;
                    TopoListView.HeightRequest = Constans.DeviceHeight - 100;
                }
            }
        }

    }

    private void AddObestacleClicked(object sender, EventArgs e)
    {
        vm.OpenAddTopoCanyonPopup();
    }

    private void SaveObstacleClicked(object sender, EventArgs e)
    {

    }
}