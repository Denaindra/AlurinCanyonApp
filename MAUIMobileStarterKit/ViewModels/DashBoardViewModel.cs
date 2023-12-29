using MAUIMobileStarterKit.Screens;
using MAUIMobileStarterKit.Screens.SettingsScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.ViewModels
{

    public class DashBoardViewModel:BaseViewModel
    {
  
        private readonly ContactUsPage contactUsPage;
        private readonly InfoPage infoPage;
        private readonly SecurityScreen securityScreen;
        private readonly MainSettingScreen mainSettingScreen;
        private readonly HomeScreen homeScreen;
        public DashBoardViewModel(HomeScreen homeScreen,MainSettingScreen mainSettingScreen, ContactUsPage contactUsPage, InfoPage infoPage, SecurityScreen securityScreen)
        {
            this.contactUsPage = contactUsPage;
            this.infoPage = infoPage;
            this.securityScreen = securityScreen;
            this.mainSettingScreen = mainSettingScreen;
            this.homeScreen = homeScreen;
        }
        public Page PageNavigationSteup(int index)
        {
            if(index == 0)
            {
                return homeScreen;
            }
            else if(index == 1)
            {
                return mainSettingScreen;
            }
            else if (index == 2)
            {
                return securityScreen;
            }
            else if (index == 3) 
            {
                return contactUsPage;
            }
            else if(index==4)
            {
                return infoPage;
            }
            return homeScreen;
        }
    }
}
