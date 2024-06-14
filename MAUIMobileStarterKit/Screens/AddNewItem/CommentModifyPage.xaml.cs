using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.AddNewItem;

public partial class CommentModifyPage : Popup
{
    private CannyonBasedViewModel vm;
    public List<string> flow = new List<string>();
    public List<string> waterFeeling = new List<string>();
    public List<string> airFeeling = new List<string>();
    public List<string> doneorviewlist = new List<string>();
    public int idCommentToModify;
    private Comment commentToModify;

    public CommentModifyPage(CannyonBasedViewModel vm, string commentid)
	{
        this.vm = vm;
        commentToModify = new Comment();
        commentToModify = Constans.SelectedCanyon.Comments.Where(c => c.Id.ToString() == commentid).FirstOrDefault();
        idCommentToModify = int.Parse(commentid);
        InitializeComponent();
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

        idCanyon.Text = commentToModify.CanyonId.ToString();
        idComment.Text = commentToModify.Id.ToString();
        FlowPicker.SelectedIndex = (int)commentToModify.Debit;
        WaterTempPicker.SelectedIndex = (int)commentToModify.WaterFeeling;
        AirTempPicker.SelectedIndex = (int)commentToModify.AirFeeling;
        Commentoftheuser.Text = commentToModify.UserComment;
        DatePicker.Date = commentToModify.CreationDate;

    }
    private void BackTapped(object sender, TappedEventArgs e)
    {
        this.Close();
    }

    private async void ModifyClicked(object sender, EventArgs e)
    {
        try
        {
            Comment usercomment = new Comment();
            usercomment.Id = idCommentToModify;
            if (DatePicker.Date.Date <= DateTime.Today)
            {
                usercomment.CreationDate = DatePicker.Date;
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Error !!!!", "You can't be in the futur !!!", "OK");
                return;
            }
            if (FlowPicker.SelectedIndex >= 0 && AirTempPicker.SelectedIndex >= 0 && WaterTempPicker.SelectedIndex >= 0 && !string.IsNullOrEmpty(Commentoftheuser.Text))
            {
                if (NickNameswith.IsToggled)
                {
                    usercomment.UserName = await vm.GetLocalStorageProeprties("NickName");
                }
                else
                {
                    usercomment.UserName = await vm.GetLocalStorageProeprties("Name"); 
                }
                usercomment.Useremail = await vm.GetLocalStorageProeprties("Email");
                usercomment.CanyonId = Constans.SelectedCanyon.Id;
                if (SeeorDone.IsToggled)
                {
                    usercomment.DoneOrView = "Done";
                }
                else
                {
                    usercomment.DoneOrView = "View";
                }
                usercomment.Debit = (DebitEnum)FlowPicker.SelectedIndex;
                usercomment.AirFeeling = (AirFeeling)AirTempPicker.SelectedIndex;
                usercomment.WaterFeeling = (WaterFeeling)WaterTempPicker.SelectedIndex;
                usercomment.UserComment = Commentoftheuser.Text;
                vm.CommentModify(usercomment, usercomment.Id);
                await App.Current.MainPage.DisplayAlert("Message", "Thank you , your comment has been add to this canyon !!", "OK");
               this.Close();    

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error !!!!", "Please provide all data values. Thanks !", "OK");
                return;
            }
        }
        finally
        {
            
        }
    }

    private async void DeleteClicked(object sender, EventArgs e)
    {
        try
        {
            var action = await App.Current.MainPage.DisplayAlert("Alert !!!!!!!", "Are you sure you want to delete the data ?", "OK", "Delete");
            if (!action)
            {
                vm.CommentDelete(idCommentToModify);
            }
        }
        finally
        {
            
        }
    }
}