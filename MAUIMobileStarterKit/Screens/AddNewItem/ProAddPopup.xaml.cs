using CommunityToolkit.Maui.Views;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.AddNewItem;

public partial class ProAddPopup : Popup
{
    private CannyonBasedViewModel vm;
    private Professionnal professionnal;
    public int idprofessionnal;
    public ProAddPopup(CannyonBasedViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        popUpLayout.WidthRequest = Constans.DeviceWidth * 0.8;
        SteupUI();
    }
    public ProAddPopup(CannyonBasedViewModel vm, Professionnal professionnal)
	{
		InitializeComponent();
        this.vm = vm;
        popUpLayout.WidthRequest = Constans.DeviceWidth * 0.8;
        this.professionnal = professionnal;
        SteupUI();
    }

    private void SteupUI()
    {
        if (professionnal.Id != 0)
        {
            var entryLogoText = ((Entry)entryLogo.FindByName("EntryField")).Text;
            var entryNameText = ((Entry)entryName.FindByName("EntryField")).Text;
            var entryAdressText = ((Entry)entryAdress.FindByName("EntryField")).Text;
            var entryPhoneText = ((Entry)entryPhone.FindByName("EntryField")).Text;
            var entryEmailText = ((Entry)entryEmail.FindByName("EntryField")).Text;
            var entryUrlwebsiteproText = ((Entry)entryUrlwebsitepro.FindByName("EntryField")).Text;
            var entryDescriptionText = ((Entry)entryDescription.FindByName("EntryField")).Text;

            idprofessionnal = professionnal.Id;
            deleteButtonpro.IsVisible = true;
            entryLogoText = professionnal.Logo;
            entryNameText = professionnal.Name;
            entryAdressText = professionnal.Adress;
            entryPhoneText = professionnal.Phone;
            entryEmailText = professionnal.Email;
            entryUrlwebsiteproText = professionnal.Website;
            entryDescriptionText = professionnal.Description;
            entryDatePro.Date = professionnal.CreationDate;
        }
        else
        {
            entryDatePro.Date = DateTime.Now;
        }
    }

    private void DeleteBtnClicked(object sender, EventArgs e)
    {
        
    }

    private async void SaveBtnClicked(object sender, EventArgs e)
    {
        var entryLogoText = ((Entry)entryLogo.FindByName("EntryField")).Text;
        var entryNameText = ((Entry)entryName.FindByName("EntryField")).Text;
        var entryAdressText = ((Entry)entryAdress.FindByName("EntryField")).Text;
        var entryPhoneText = ((Entry)entryPhone.FindByName("EntryField")).Text;
        var entryEmailText = ((Entry)entryEmail.FindByName("EntryField")).Text;
        var entryUrlwebsiteproText = ((Entry)entryUrlwebsitepro.FindByName("EntryField")).Text;
        var entryDescriptionText = ((Entry)entryDescription.FindByName("EntryField")).Text;

        if (idprofessionnal != 0)
        {

        }
        else
        {
            var results = await vm.SavePro(entryLogoText, entryNameText, entryAdressText, entryPhoneText, entryEmailText, entryUrlwebsiteproText, entryDescriptionText, entryDatePro.Date);
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