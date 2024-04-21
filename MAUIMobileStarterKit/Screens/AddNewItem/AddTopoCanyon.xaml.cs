using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.AddNewItem;

public partial class AddTopoCanyon : Popup
{
    public CannyonBasedViewModel vm;

    public AddTopoCanyon(CannyonBasedViewModel vm)
	{
		InitializeComponent();
		popUpLayout.WidthRequest = Constans.DeviceWidth * 0.8;
        popUpLayout.HeightRequest = Constans.DeviceHeight * 0.8;
        BindingContext = vm;
    }

    private void BackIconTapped(object sender, TappedEventArgs e)
    {
        Close();
    }
}