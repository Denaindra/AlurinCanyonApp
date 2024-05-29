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
        scrolllayout.HeightRequest = Constans.DeviceHeight - 122;
        vm.LoadPerforssioanlList();
    }

    private void AddProButtonClicked(object sender, EventArgs e)
    {
        vm.OpenProPopup();
    }

    private void BrowsUrlClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string Urlwebsitepro = button.Text;
        Browser.OpenAsync(new Uri(Urlwebsitepro), BrowserLaunchMode.SystemPreferred);
    }
}