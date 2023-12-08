
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class DashBoardScreen : ContentPage
{
	private DashBoardViewModel viewModel;
	public DashBoardScreen(DashBoardViewModel viewModel)
	{
		InitializeComponent();
		viewModel.navigation = Navigation;
		this.viewModel = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var results = await viewModel.CheckAndRequestLocationPermission();
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        Constans.DeviceHeight = height;
        base.OnSizeAllocated(width, height);
    }
    private void DashBoardItemTapped(object sender, TappedEventArgs e)
    {
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);
		viewModel.PageNavigationSteup(parameter);
    }
}