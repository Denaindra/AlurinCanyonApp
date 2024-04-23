using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.AddNewItem;

public partial class AddTopoCanyon : Popup
{
    public CannyonBasedViewModel vm;
    public List<string> obstacles = new List<string>();
    public List<string> dangertypes = new List<string>();
    public List<int> numswithSize = new List<int> { 1, 2, 3, 10, 11, 13, 14 };
    public List<int> numswithRive = new List<int> { 4, 5, 11, 15, 16, 17 };
    public AddTopoCanyon(CannyonBasedViewModel vm)
	{
		InitializeComponent();
		popUpLayout.WidthRequest = Constans.DeviceWidth * 0.8;
        popUpLayout.HeightRequest = Constans.DeviceHeight * 0.8;
        BindingContext = this.vm = vm;
        SteupUI();
    }

    private void SteupUI()
    {
        nameCanyon.Text = Constans.SelectedCanyon.Name.ToString();
        obstacles.Add("Danger");
        obstacles.Add("Waterfall");
        obstacles.Add("Toboggan");
        obstacles.Add("Walking");
        obstacles.Add("Escape");
        obstacles.Add("Tributary");
        obstacles.Add("Siphon");
        obstacles.Add("Tunnel");
        obstacles.Add("Road");
        obstacles.Add("Trees");
        obstacles.Add("RocksChaos");
        obstacles.Add("RunningHand");
        obstacles.Add("Barrage");
        obstacles.Add("swimming");
        obstacles.Add("jump");
        obstacles.Add("relais");
        obstacles.Add("monopoint");
        obstacles.Add("Exit");
        obstacles.Add("Bridge");
        dangertypes.Add("RopeFriction");
        dangertypes.Add("RopeBlocking");
        dangertypes.Add("Syphon");
        dangertypes.Add("Drossage");
        dangertypes.Add("Slippery");
        dangertypes.Add("RockFall");

        obstaclePicker.ItemsSource = obstacles;
        typeDangerPicker.ItemsSource = dangertypes;
    }
    private void BackIconTapped(object sender, TappedEventArgs e)
    {
        Close();
    }

    private void ObstaclePickerSelectedIndexChanged(object sender, EventArgs e)
    {

        if (obstaclePicker.SelectedIndex == 0)
        {
            typeDangerPicker.IsVisible = true;
        }
        else
        {
            typeDangerPicker.IsVisible = false;
        }
        if (numswithSize.Contains(obstaclePicker.SelectedIndex))
        {
            obstacleSize.IsVisible = true;
        }
        else
        {
            obstacleSize.IsVisible = false;
        }
        if (numswithRive.Contains(obstaclePicker.SelectedIndex))
        {
            stackSwitchRive.IsVisible = true;
        }
        else
        {
            stackSwitchRive.IsVisible = false;
        }
    }

    private async void AddTopoBtnClicked(object sender, EventArgs e)
    {
     var rsult =  await vm.AddTopoCanyon(obstaclePicker.SelectedIndex, stackSwitchRive.IsVisible, Postionpoint.IsToggled, Commentoftheuser.Text, numswithSize, obstacleSize.Text, typeDangerPicker.SelectedIndex);
    }
}