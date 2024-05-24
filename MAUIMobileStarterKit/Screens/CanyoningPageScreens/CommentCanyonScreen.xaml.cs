using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class CommentCanyonScreen : ContentView
{
    private readonly CannyonBasedViewModel vm;
	public CommentCanyonScreen(CannyonBasedViewModel vm)
	{
		InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
        SteupUI();
    }

    private void SteupUI()
    {
        stackLayout.HeightRequest = Constans.DeviceHeight - 122;
        //CommentListView.HeightRequest = Constans.DeviceHeight - 220;
        vm.LoadCommentList();
        if (vm.CommentsList.Any())
        {
            EmptyListComment.IsVisible = false;
        }
    }

    private void AddCommentBtnClicked(object sender, EventArgs e)
    {
        vm.OpenAddCommentCanyonPopup();
    }
}