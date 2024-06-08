using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class ProCanyonScreen : ContentView
{
    private CannyonBasedViewModel vm;
	public ProCanyonScreen(CannyonBasedViewModel vm)
	{
		InitializeComponent();
        this.vm = vm;
        BindingContext = vm;
        SteupUI();
	}

    private void SteupUI()
    {
        if (Constans.UserRole == "Administrator")
        {
            AddProButton.IsVisible = true;
        }
        scrolllayout.HeightRequest = Constans.DeviceHeight - 122;
        vm.LoadPerforssioanlList();
    }

    private void AddProButtonClicked(object sender, EventArgs e)
    {
        vm.OpenProPopup(false);
    }

    private void BrowsUrlClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string Urlwebsitepro = button.Text;
        Browser.OpenAsync(new Uri(Urlwebsitepro), BrowserLaunchMode.SystemPreferred);
    }

    private async void ProListViewItemTapped(object sender, ItemTappedEventArgs e)
    {
        vm.SetSelectedProfessionnalItem(e.Item);
        var action = await App.Current.MainPage.DisplayAlert(vm.GetSelectedProfessionnalItem().Name, vm.GetSelectedProfessionnalItem().Description, "OK", "Modify");
        if (!action)
        {
            if (Constans.UserRole == "Administrator")
            {
                vm.OpenProPopup(true);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error !!!!", "You have to be administrator to do this operation !!", "OK");
            }
        }
    }
}