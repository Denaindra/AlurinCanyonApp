using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.AddNewItem;

public partial class ReglementationAddPage : Popup
{
    private CannyonBasedViewModel vm;

    public ReglementationAddPage(CannyonBasedViewModel vm)
	{
		InitializeComponent();
        popUpLayout.WidthRequest = Constans.DeviceWidth * 0.8;
        popUpLayout.HeightRequest = Constans.DeviceHeight * 0.8;
        BindingContext = this.vm = vm;
        SteupUI();
    }
    private void SteupUI()
    {
       
    }

    private void BackIconTapped(object sender, TappedEventArgs e)
    {
        this.Close();
    }
}