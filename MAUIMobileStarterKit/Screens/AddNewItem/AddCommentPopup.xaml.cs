using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;
using System;

namespace MAUIMobileStarterKit.Screens.AddNewItem;

public partial class AddCommentPopup : Popup
{
	private CannyonBasedViewModel vm;
    public List<string> flow = new List<string>();
    public List<string> waterFeeling = new List<string>();
    public List<string> airFeeling = new List<string>();
    public List<string> doneorviewlist = new List<string>();
    public AddCommentPopup(CannyonBasedViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
        popUpLayout.WidthRequest = Constans.DeviceWidth * 0.8;
        popUpLayout.HeightRequest = Constans.DeviceHeight * 0.8;
        SteupUI();
    }

    private async void SteupUI()
    {
        nameCanyon.Text = Constans.SelectedCanyon.Name;
        userNameText.Text = await vm.GetLocalStorageProeprties("UserName");
        userNickNameText.Text = await vm.GetLocalStorageProeprties("NickName");

        flow.Add("Too much water danger");
        flow.Add("Very big flow");
        flow.Add("Big flow");
        flow.Add("Good flow");
        flow.Add("Few water");
        flow.Add("No water");

        waterFeeling.Add("Hot");
        waterFeeling.Add("Good");
        waterFeeling.Add("Cold");
        waterFeeling.Add("VeryCold");
        waterFeeling.Add("Ice");

        airFeeling.Add("Very hot");
        airFeeling.Add("Hot");
        airFeeling.Add("Good");
        airFeeling.Add("Cold");
        airFeeling.Add("Very Cold");

        doneorviewlist.Add("Done");
        doneorviewlist.Add("View");

        FlowPicker.ItemsSource = flow;
        WaterTempPicker.ItemsSource = waterFeeling;
        AirTempPicker.ItemsSource = airFeeling;
    }

    private async void SaveBtnClicked(object sender, EventArgs e)
    {
        var results = await vm.SendComments(FlowPicker.SelectedIndex, AirTempPicker.SelectedIndex, WaterTempPicker.SelectedIndex, Commentoftheuser.Text, NickNameswith.IsToggled, SeeorDone.IsToggled, DatePicker.Date);
        if (results)
        {
            vm.LoadCommentList();
            this.Close();
        }
    }

    private void BackTapped(object sender, TappedEventArgs e)
    {
        this.Close();
    }
}