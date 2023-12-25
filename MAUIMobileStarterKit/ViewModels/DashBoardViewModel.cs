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
        public DashBoardViewModel(MainSettingScreen mainSettingScreen, ContactUsPage contactUsPage, InfoPage infoPage, SecurityScreen securityScreen)
        {
        
            this.contactUsPage = contactUsPage;
            this.infoPage = infoPage;
            this.securityScreen = securityScreen;
            this.mainSettingScreen = mainSettingScreen;
        }

        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return status;
        }
        public void PageNavigationSteup(int index)
        {
            switch (index)
            {
                case 0:
                   // PushAsyncPage(homeScreen);
                    break;
                case 1:
                    PushAsyncPage(mainSettingScreen);
                    break;
                case 2:
                    PushAsyncPage(securityScreen);
                    break;
                case 3:
                    PushAsyncPage(contactUsPage);
                    break;
                case 4:
                    PushAsyncPage(infoPage);
                    break;
                default:
                    
                    break;
            }

        }
    }
}
