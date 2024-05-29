using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens;

public partial class ContactUsPage : ContentPage
{
    private ContactUsViewModel vm;
    public ContactUsPage(ContactUsViewModel vm)
	{
		InitializeComponent();
        this.vm = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        purposeRequest.Items.Clear();
        purposeRequest.Items.Add("Questions");
        purposeRequest.Items.Add("Business");
        purposeRequest.Items.Add("Help");
        purposeRequest.Items.Add("App Problem");
        purposeRequest.Items.Add("Canyon Problem");

        //if (Namecanyon != "")
        //{
        //    purposeRequest.SelectedItem = AppResources.AppResources.CanyonProblem;
        //    bodyuserMessage.Text = AppResources.AppResources.CanyonProblemMessageStart + Namecanyon + AppResources.AppResources.CanyonProblemMessageEnd;
        //}
    }
    private void MenuBtnClicked(object sender, EventArgs e)
    {
        if (!Constans.flyoutPage.IsPresented)
        {
            Constans.flyoutPage.IsPresented = true;
        }
    }

    private async void SendMsgClicked(object sender, EventArgs e)
    {
        var mesagebody = ((Entry)message.FindByName("EntryField")).Text;
        var results = await vm.SendMail(purposeRequest.SelectedItem.ToString(), mesagebody);
        if (results)
        {
            await DisplayAlert("Error !!!!", "Please provide all data values. Thanks !", "OK");
        }

    }
}