using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.CanyoningPageScreens;

public partial class ResumeCanyonScreen : ContentView
{
    private readonly CannyonBasedViewModel vm;
    public ResumeCanyonScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        this.vm = viewModel;
        SetupUI();
    }

    private void SetupUI()
    {
        scrollView.HeightRequest = Constans.DeviceHeight-122;
        vm.LoadCannoynDetails();
        vm.GetCanyonList();
    }
}