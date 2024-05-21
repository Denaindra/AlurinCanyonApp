using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class ReglementationCanyonScreen : ContentView
{
	private CannyonBasedViewModel vm;
	public ReglementationCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
		this.vm = viewModel;
        BindingContext = viewModel;
        SteupUI();

    }
    private void SteupUI()
    {
        stackLayout.HeightRequest = Constans.DeviceHeight - 122;
        vm.LoadReglementation();
    }

    private void AddRelementationClicked(object sender, EventArgs e)
    {
        vm.OpenReglementationAddPagePopup();
    }
}