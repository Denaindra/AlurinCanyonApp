using MAUIMobileStarterKit.Constant;

namespace MAUIMobileStarterKit.Screens;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
	}

    private void MenuBtnClicked(object sender, EventArgs e)
    {
        if (!Constans.flyoutPage.IsPresented)
        {
            Constans.flyoutPage.IsPresented = true;
        }
    }
}