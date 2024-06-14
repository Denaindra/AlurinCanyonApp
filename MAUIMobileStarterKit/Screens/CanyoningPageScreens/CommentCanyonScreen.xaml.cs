using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Models.Service;
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

    private async void CommentListViewItemTapped(object sender, ItemTappedEventArgs e)
    {
        vm.SetSelectedComment(e.Item);
        var action = await App.Current.MainPage.DisplayAlert(vm.GetSelectedComment().CreationDate.ToShortDateString() + ", " + vm.GetSelectedComment().UserName, vm.GetSelectedComment().UserComment, "OK", "Modify");
        if (!action)
        {
            if (Constans.UserRole== "Administrator" || Constans.SelectedCanyon.Comments.Where(c => c.Id.ToString() == vm.GetSelectedComment().Id.ToString()).FirstOrDefault().Useremail == await vm.GetLocalStorageProeprties("Email"))
            {
                vm.OpenModifyCommentCanyonPopup();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error !!!!", "You have to be administrator to do this operation !!", "OK");
                CommentListView.SelectedItem = null;
            }
        }
    }
}