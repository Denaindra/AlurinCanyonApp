using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class DashBoardScreen : ContentPage
{
	private DashBoardViewModel viewModel;
	public DashBoardScreen(DashBoardViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
	}

    private void DashBoardItemTapped(object sender, TappedEventArgs e)
    {

    }
}