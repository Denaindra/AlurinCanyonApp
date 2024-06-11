using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.AddNewItem;

public partial class AddTopoCanyon : Popup
{
    public CannyonBasedViewModel vm;
    public List<string> obstacles = new List<string>();
    public List<string> dangertypes = new List<string>();
    public List<int> numswithSize = new List<int> { 1, 2, 3, 10, 11, 13, 14 };
    public List<int> numswithRive = new List<int> { 4, 5, 11, 15, 16, 17 };
    private bool Ismodify;
    public int idtopotoModify;

    public AddTopoCanyon(CannyonBasedViewModel vm, bool isModify)
    {
        InitializeComponent();
        popUpLayout.WidthRequest = Constans.DeviceWidth * 0.8;
        popUpLayout.HeightRequest = Constans.DeviceHeight * 0.8;
        BindingContext = this.vm = vm;
        this.Ismodify = isModify;
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

        if (Ismodify)
        {
            var selestcted = vm.GetSeletedTOPOCanyon();
            idtopotoModify = selestcted.Id;
            Commentoftheuser.Text = selestcted.TopoComment;
            obstaclePicker.SelectedIndex = (int)selestcted.TypeObstacle;

            if(Constans.UserRole== "Adminitrator" && Constans.UserRole== "Premium" && !selestcted.IsValidTopo)
            {
                modify.IsVisible = true;
                delete.IsVisible = true;
                savetopo.IsVisible = false;
            }

            if (obstaclePicker.SelectedIndex == 0)
            {
                typeDangerPicker.IsVisible = true;
                typeDangerPicker.SelectedIndex = (int)selestcted.TypeDanger;
            }
            else
            {
                typeDangerPicker.IsVisible = false;
                obstaclePicker.SelectedIndex = (int)selestcted.TypeObstacle;
            }

            if (numswithSize.Contains(obstaclePicker.SelectedIndex))
            {
                obstaclePicker.IsVisible = true;
                obstacleSize.Text = selestcted.TailleObstacle;
            }
            else
            {
                obstaclePicker.IsVisible = false;
            }

            if (numswithRive.Contains(obstaclePicker.SelectedIndex))
            {
                stackSwitchRive.IsVisible = true;
            }
            else
            {
                stackSwitchRive.IsVisible = false;
            }

            if (selestcted.PositionPoint == PositionPoint.RiveDroite)
            {
                Postionpoint.IsToggled = true;
            }
        }
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
        var isTopoAdded = await vm.AddTopoCanyon(obstaclePicker.SelectedIndex, stackSwitchRive.IsVisible, Postionpoint.IsToggled, Commentoftheuser.Text, numswithSize, obstacleSize.Text, typeDangerPicker.SelectedIndex);
        if (isTopoAdded)
        {
            this.Close();
        }
    }

    private async void DeleteClicked(object sender, EventArgs e)
    {
            var action = await App.Current.MainPage.DisplayAlert("Alert !!!!!!!", "Are you sure you want to delete the data ?", "OK", "Delete");
            if (!action)
            {
                var result = vm.DeleteTopoCanyon(idtopotoModify);
                this.Close();
            }
    }

    private async void ModifyClicked(object sender, EventArgs e)
    {
        var isTopoModify = await vm.ModifyTopoGraphy(obstaclePicker.SelectedIndex, stackSwitchRive.IsVisible, Postionpoint.IsToggled, typeDangerPicker.SelectedIndex, numswithSize, obstacleSize.Text, Commentoftheuser.Text);

        if (isTopoModify)
        {
            this.Close();
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Error !!!!", "Please provide all data values. Thanks !", "OK");
        }
    }
}