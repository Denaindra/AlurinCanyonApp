using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.AddNewItem;

public partial class ProAddPopup : Popup
{
    private CannyonBasedViewModel vm;
    private Professionnal SeletetdProfessionnal;
    public int idprofessionnal;
    private bool ismodify;
    public ProAddPopup(CannyonBasedViewModel vm,bool ismodify)
    {
        InitializeComponent();
        this.vm = vm;
        popUpLayout.WidthRequest = Constans.DeviceWidth * 0.8;
        this.ismodify = ismodify;
        SteupUI();
    }

    private void SteupUI()
    {
        if (ismodify)
        {
            SeletetdProfessionnal = vm.GetSelectedProfessionnalItem();

            idprofessionnal = SeletetdProfessionnal.Id;
            deleteButtonpro.IsVisible = true;
            entryLogo.Text = SeletetdProfessionnal.Logo;
            entryName.Text = SeletetdProfessionnal.Name;
            entryAdress.Text = SeletetdProfessionnal.Adress;
            entryPhone.Text = SeletetdProfessionnal.Phone;
            entryEmail.Text = SeletetdProfessionnal.Email;
            entryUrlwebsitepro.Text = SeletetdProfessionnal.Website;
            entryDescription.Text = SeletetdProfessionnal.Description;
            entryDatePro.Date = SeletetdProfessionnal.CreationDate;
        }
        else
        {
            entryDatePro.Date = DateTime.Now;
        }
    }

    private async void DeleteBtnClicked(object sender, EventArgs e)
    {
        var results = await vm.DeletePro(SeletetdProfessionnal);
        if (results)
        {
            vm.GetPro();
        }
        this.Close();
    }

    private async void SaveBtnClicked(object sender, EventArgs e)
    {
        if (ismodify)
        {
            SeletetdProfessionnal.Logo = entryLogo.Text;
            SeletetdProfessionnal.Name = entryName.Text;
            SeletetdProfessionnal.Adress = entryAdress.Text;
            SeletetdProfessionnal.Phone = entryPhone.Text;
            SeletetdProfessionnal.Email = entryEmail.Text;
            SeletetdProfessionnal.Website = entryUrlwebsitepro.Text;
            SeletetdProfessionnal.Description = entryDescription.Text;
            SeletetdProfessionnal.CreationDate = entryDatePro.Date;

            var results = await vm.ModifyPro(SeletetdProfessionnal);
            if (results)
            {
                vm.GetPro();
            }
            this.Close();
        }
        else
        {
            var results = await vm.SavePro(entryLogo.Text, entryName.Text, entryAdress.Text, entryPhone.Text, entryEmail.Text, entryUrlwebsitepro.Text, entryDescription.Text, entryDatePro.Date);
            if (results)
            {
              vm.GetPro();
            }
            this.Close();
        }

    }

    private void BackTapped(object sender, TappedEventArgs e)
    {
        this.Close();
    }
}