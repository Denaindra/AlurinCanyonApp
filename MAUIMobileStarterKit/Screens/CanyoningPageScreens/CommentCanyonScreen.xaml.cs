using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class CommentCanyonScreen : ContentView
{
    private readonly CannyonBasedViewModel viewModel;
	public CommentCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
        SteupUI();
    }

    private void SteupUI()
    {
        stackLayout.HeightRequest = Constans.DeviceHeight - 122;
        CommentListView.HeightRequest = Constans.DeviceHeight - 220;
        viewModel.LoadCommentList();
    }
}