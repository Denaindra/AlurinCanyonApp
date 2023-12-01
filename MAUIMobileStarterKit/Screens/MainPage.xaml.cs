using Controls.UserDialogs.Maui;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class MainPage : ContentPage
{
	private readonly IUserDialogs userDialogs;
    private readonly MainPageViewModels viewModels;

    public MainPage(MainPageViewModels viewModel, IUserDialogs userDialogs)
	{
		InitializeComponent();
		this.userDialogs = userDialogs;
        this.viewModels = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

   async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        viewModels.StartLoading();
        await Task.Delay(3000);
        viewModels.EndLoading();
    }
}
