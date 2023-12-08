using MAUIMobileStarterKit.Screens;
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
        private readonly HomeScreen homeScreen;
        private readonly ContactUsPage contactUsPage;
        public DashBoardViewModel(HomeScreen homeScreen, ContactUsPage contactUsPage)
        {
            this.homeScreen = homeScreen;
            this.contactUsPage = contactUsPage;
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
                    PushAsyncPage(homeScreen);
                    break;
                case 2:
                   
                    break;
                case 3:
                    PushAsyncPage(contactUsPage);
                    break;
                default:
                    
                    break;
            }

        }
    }
}
