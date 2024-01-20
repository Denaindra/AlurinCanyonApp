using MAUIMobileStarterKit.Screens.CanyoningPageScreens;
using MAUIMobileStarterKit.ViewModels;
using System;

namespace MAUIMobileStarterKit.Screens;

public partial class CanyonBaseScreen : ContentPage
{
    private readonly CannyonBasedViewModel viewModel;
    public CanyonBaseScreen(CannyonBasedViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SteupPage(0);
    }
    private void MenuBtnClicked(object sender, EventArgs e)
    {

    }

    private void OnMenuTapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
        ResetView();
        RemoveChildView();
        var tappedParameter = (TappedEventArgs)e;
        var parameter = Convert.ToInt32(tappedParameter.Parameter);
        SteupPage(parameter);
    }

    private void SteupPage(int parameter)
    {
        switch (parameter)
        {
            case 0:
                recannyonLabel.FontSize = 12;
                recannyonLabel.FontAttributes = FontAttributes.Bold;
                childLayout.Children.Add(new ResumeCanyonScreen(viewModel));
                break;
            case 1:
                mapLabel.FontSize = 12;
                mapLabel.FontAttributes = FontAttributes.Bold;
                childLayout.Children.Add(new CanyonMapScreen());
                break;
            case 2:
                tcannyonLabel.FontAttributes = FontAttributes.Bold;
                tcannyonLabel.FontSize = 12;
                childLayout.Children.Add(new TopoCanyonScreen(viewModel));
                break;
            case 3:
                reglementLabel.FontAttributes = FontAttributes.Bold;
                reglementLabel.FontSize = 12;
                childLayout.Children.Add(new ReglementationCanyonScreen(viewModel));
                break;
            case 4:
                chatLabel.FontAttributes = FontAttributes.Bold;
                chatLabel.FontSize = 12;
                childLayout.Children.Add(new CommentCanyonScreen(viewModel));
                break;
            case 5:
                ImageLabel.FontAttributes = FontAttributes.Bold;
                ImageLabel.FontSize = 12;
                childLayout.Children.Add(new TabbedPicturesCanyonScreen());
                break;
            case 6:
                proLabel.FontAttributes = FontAttributes.Bold;
                proLabel.FontSize = 17;
                childLayout.Children.Add(new ProCanyonScreen());
                break;
        }
    }
    private void ResetView()
    {
        ImageLabel.FontAttributes = FontAttributes.None;
        chatLabel.FontAttributes = FontAttributes.None;
        reglementLabel.FontAttributes = FontAttributes.None;
        tcannyonLabel.FontAttributes = FontAttributes.None;
        mapLabel.FontAttributes = FontAttributes.None;
        recannyonLabel.FontAttributes = FontAttributes.None;

        ImageLabel.FontSize = 10;
        chatLabel.FontSize = 10;
        reglementLabel.FontSize = 10;
        tcannyonLabel.FontSize = 10;
        mapLabel.FontSize = 10;
        recannyonLabel.FontSize = 10;
        proLabel.FontSize= 15;
    }
    private void RemoveChildView()
    {
        childLayout.Children.Clear();
    }
}