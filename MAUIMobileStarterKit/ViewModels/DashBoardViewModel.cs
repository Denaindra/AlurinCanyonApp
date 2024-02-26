using Auth0.OidcClient;
using IdentityModel.OidcClient;
using Java.Lang;
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
        private Auth0Client authClient;
        public DashBoardViewModel(HomeScreen homeScreen,MainSettingScreen mainSettingScreen, ContactUsPage contactUsPage, InfoPage infoPage, SecurityScreen securityScreen,Auth0Client authClient)
        {
            this.contactUsPage = contactUsPage;
            this.infoPage = infoPage;
            this.securityScreen = securityScreen;
            this.mainSettingScreen = mainSettingScreen;
            this.homeScreen = homeScreen;
            this.authClient = authClient;
        }
        public async Task<bool> CheckUserLogin()
        {
            var result = await authClient.LoginAsync();
            if (result.IsError)
            {
                return false;
            }
            else
            {
                await SecureStorage.Default.SetAsync("access_token", result.AccessToken);
                await SecureStorage.Default.SetAsync("identity_token", result.IdentityToken);

                var name = result.User.FindFirst(c => c.Type == "name")?.Value;
                await SecureStorage.SetAsync("Name", name);

                var email = result.User.FindFirst(c => c.Type == "email")?.Value;
                await SecureStorage.SetAsync("Email", email);

                var role = result.User.FindFirst(c => c.Type == "http://canyonAppdeouf.net/roles")?.Value;
                if (string.IsNullOrEmpty(role))
                {
                    role = "Free";
                    await SecureStorage.SetAsync("role", role);
                }
                else
                {
                    await SecureStorage.SetAsync("role", role);
                }

                var nickName = result.User.FindFirst(c => c.Type == "nickname")?.Value;
                await SecureStorage.SetAsync("NickName", nickName);

                return true;
            }
        }

        public async void LogOutTheUser()
        {
            var logoutResult =   await authClient.LogoutAsync();
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
