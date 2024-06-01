using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Interface;

namespace MAUIMobileStarterKit.ViewModels
{
    public class ContactUsViewModel:BaseViewModel
    {
        private readonly ILocalStorage localStorage;
        private readonly ILoading loading;
        public ContactUsViewModel(ILocalStorage localStorage, ILoading loading)
        {
            this.localStorage = localStorage;
            this.loading = loading;
        }
        public async Task<bool> SendMail(string selectedItem,string messageBody)
        {
            try
            {

                loading.StartIndicator();
                if (selectedItem != null && string.IsNullOrEmpty(messageBody))
                {
                    await Email.ComposeAsync(selectedItem, messageBody + "\n" + await localStorage.GetAsync("Name") + " - " + await localStorage.GetAsync("Email"), "canyon.project.world@gmail.com");
                }

                loading.EndIndiCator();
                return true;

            }catch(Exception ex)
            {
                loading.EndIndiCator();
                return false;
            }
        }
    }
}
