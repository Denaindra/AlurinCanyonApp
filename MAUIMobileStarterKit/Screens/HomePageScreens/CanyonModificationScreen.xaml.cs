using MAUIMobileStarterKit.ViewModels;
using System.Reflection.Metadata;

namespace MAUIMobileStarterKit.Screens.HomePageScreens;

public partial class CanyonModificationScreen : ContentView
{
    private HomePageViewModel viewModel;
    private int parameter;
    public CanyonModificationScreen(HomePageViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
        viewModel.LoadCannoynDetails();
        viewModel.LoadCommentDetails();
        viewModel.TopographyDetails();
    }


    private void DataFileterTapped(object sender, TappedEventArgs e)
    {
        var tappedParameter = (TappedEventArgs)e;
        parameter = Convert.ToInt32(tappedParameter.Parameter);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            picker.Focus();
        });
    }

    private void DatePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        picker.Unfocus();
        if (parameter == 0)
        {
            commentsDays.Text = picker.SelectedItem.ToString();
        }
        else if (parameter == 1)
        {
            topographyDays.Text = picker.SelectedItem.ToString();
        }
        else if (parameter == 2)
        {
            modifyCannyonDays.Text = picker.SelectedItem.ToString();
        }
    }
}