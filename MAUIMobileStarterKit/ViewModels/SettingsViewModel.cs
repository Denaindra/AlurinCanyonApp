using MAUIMobileStarterKit.Screens.SettingsScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly CreateCannyonScreen cannyonScreen;
        public SettingsViewModel(CreateCannyonScreen cannyonScreen)
        {
            this.cannyonScreen = cannyonScreen;
        }

        public void NavigationCannyonCreatePage()
        {
            PushAsyncPage(cannyonScreen);
        }
    }
}
