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
        vm.OpenAddTopoCanyonPopup(false);
    }

    private void SaveObstacleClicked(object sender, EventArgs e)
    {
        vm.SaveObstropyObsacle();
    }

    private async void TopoListViewItemTapped(object sender, ItemTappedEventArgs e)
    {
        vm.SeletedTOPOCanyon(e.Item);
        var action = await App.Current.MainPage.DisplayAlert(vm.GetSeletedTOPOCanyon().TypeObstacle + ", " + vm.GetSeletedTOPOCanyon().TypeDanger, vm.GetSeletedTOPOCanyon().TopoComment, "OK", "Modify");
        if (!action)
        {
            if (!vm.GetSeletedTOPOCanyon().IsValidTopo || Constans.UserRole == "Administrator" || Constans.UserRole == "Premium")
            {
                vm.OpenAddTopoCanyonPopup(true);
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Error !!!!", "You have to be administrator to do this operation !!", "OK");
            }
        }
    }

    private void CheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (Constans.UserRole == "Administrator")
        {
            saveButton.IsVisible = true;
        }
    }
}