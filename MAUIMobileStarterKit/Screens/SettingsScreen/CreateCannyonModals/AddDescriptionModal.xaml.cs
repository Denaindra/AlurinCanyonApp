using MAUIMobileStarterKit.ViewModels;

namespace MAUIMobileStarterKit.Screens.SettingsScreen.CreateCannyonModals;

public partial class AddDescriptionModal : ContentPage
{
    public CreateCanyonViewModel vm;
    public bool isModifyAddDescriptionModal;

    public AddDescriptionModal()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = vm;

        if (isModifyAddDescriptionModal)
        {
            SetupModifyView();
        }
    }

    private void SetupModifyView()
    {
            var accesDescentrr = vm.GetTheSelectedAccessDescriptionModal();
            pickerLanguage.SelectedItem = accesDescentrr.Language;
            vm.Access = accesDescentrr.Acces;
            vm.Approach = accesDescentrr.Approche;
            vm.Decent = accesDescentrr.Descente;
            vm.ReturnTrip = accesDescentrr.Retour;
            vm.Engagement = accesDescentrr.Engagement;
            vm.History = accesDescentrr.Historique;
            vm.Comment = accesDescentrr.Remarque;
            vm.Geology = accesDescentrr.Geologie;
            vm.Period = accesDescentrr.Periode;

            savebtn.IsVisible = false;
            modifyBtn.IsVisible = true;
            deleteBtn.IsVisible = true;

            isModifyAddDescriptionModal = false;
    }
    private void SaveDescription(object sender, EventArgs e)
    {
        vm.Lanuage = pickerLanguage.SelectedItem as string;
        vm.SaveDescription();
    }

    private void BackBtnClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void ModifyBtnClicked(object sender, EventArgs e)
    {
        var modifyDescription = vm.GetTheSelectedAccessDescriptionModal();

        modifyDescription.Language = pickerLanguage.SelectedItem as string; ;
        modifyDescription.Acces = vm.Access;
        modifyDescription.Approche = vm.Approach;
        modifyDescription.Descente = vm.Decent;
        modifyDescription.Retour = vm.ReturnTrip;
        modifyDescription.Engagement = vm.Engagement;
        modifyDescription.Historique = vm.History;
        modifyDescription.Remarque = vm.Comment;
        modifyDescription.Geologie = vm.Geology;
        modifyDescription.Periode = vm.Period;

        vm.ModifyDescription(modifyDescription);
        vm.PopModalAsyncy();
    }

    private void DeleteBtnClicked(object sender, EventArgs e)
    {
        vm.DeleteDescription(vm.GetTheSelectedAccessDescriptionModal());
        vm.PopModalAsyncy();
    }
}