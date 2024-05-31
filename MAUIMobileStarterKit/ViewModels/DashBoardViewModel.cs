using Auth0.OidcClient;
using MAUIMobileStarterKit.Constant;
using MAUIMobileStarterKit.Interface;
using MAUIMobileStarterKit.Interface.APIServices;
using MAUIMobileStarterKit.Models.Service;
using MAUIMobileStarterKit.Screens;
using MAUIMobileStarterKit.Screens.SettingsScreen;
using MAUIMobileStarterKit.Utilities;

namespace MAUIMobileStarterKit.ViewModels
{

    public class DashBoardViewModel : BaseViewModel
    {

        private readonly ContactUsPage contactUsPage;
        private readonly InfoPage infoPage;
        private readonly SecurityScreen securityScreen;
        private readonly MainSettingScreen mainSettingScreen;
        private readonly HomeScreen homeScreen;
        private readonly LogOutPage logOutpage;
        private Auth0Client authClient;


        private readonly ItokenProvider itokenProvider;
        private readonly ILocalStorage localStorage;

        public DashBoardViewModel(ILocalStorage localStorage,LogOutPage logOutpage, HomeScreen homeScreen, MainSettingScreen mainSettingScreen, ContactUsPage contactUsPage, InfoPage infoPage, SecurityScreen securityScreen, Auth0Client authClient)
        {
            this.contactUsPage = contactUsPage;
            this.infoPage = infoPage;
            this.securityScreen = securityScreen;
            this.mainSettingScreen = mainSettingScreen;
            this.homeScreen = homeScreen;
            this.authClient = authClient;
            this.logOutpage = logOutpage;
            this.localStorage = localStorage;
            itokenProvider = GetItokenProvider();
        }
        public async Task<bool> CheckUserLogin()
        {
            var oauthToken = await localStorage.GetAsync("access_token");
            if (!string.IsNullOrEmpty(oauthToken))
            {
                var result = await authClient.RefreshTokenAsync(oauthToken);
                return true;
            }
            else
            {
                var result = await authClient.LoginAsync();
                if (result.IsError)
                {
                    return false;
                }
                else
                {
                    localStorage.SetAsync("access_token", result.AccessToken);
                    localStorage.SetAsync("identity_token", result.IdentityToken);

                    var name = result.User.FindFirst(c => c.Type == "name")?.Value;
                    localStorage.SetAsync("Name", name);

                    var email = result.User.FindFirst(c => c.Type == "email")?.Value;
                    localStorage.SetAsync("Email", email);

                    var role = result.User.FindFirst(c => c.Type == "http://canyonAppdeouf.net/roles")?.Value;
                    if (string.IsNullOrEmpty(role))
                    {
                        role = "Free";
                        localStorage.SetAsync("role", role);
                    }
                    else
                    {
                        localStorage.SetAsync("role", role);
                    }

                    var nickName = result.User.FindFirst(c => c.Type == "nickname")?.Value;
                    localStorage.SetAsync("NickName", nickName);
                    var tokenRequest = new AccessTokenRequest()
                    {
                        client_id = "1MJwNXR7aPSnt3wzDKaEgMk3HThSBOMQ",
                        client_secret = "27C9JYTVixBHFI4jprZoPKgmLoOZ58ZmfhANaxMaLTtJ11PRDWe7lsEiVIYy4w0y",
                        audience = Constans.AccessTokenRequestAudence,
                        grant_type = "client_credentials"
                    };
                    var tokenResponse = await itokenProvider.GetToken(tokenRequest);
                    localStorage.SetAsync("apiToken", tokenResponse.access_token);


                    return true;
                }
            }
        }

        public async void LogOutTheUser()
        {
            var logoutResult = await authClient.LogoutAsync();
            SecureStorage.Default.RemoveAll();
        }

        public async Task<bool> IsUserLogOut()
        {
            string oauthToken = await localStorage.GetAsync("access_token");
            if (string.IsNullOrEmpty(oauthToken))
            {
                return true;
            }
            return false;
        }
        public Page PageNavigationSteup(int index)
        {
            if (index == 0)
            {
                return homeScreen;
            }
            else if (index == 1)
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
            else if (index == 4)
            {
                return infoPage;
            }
            else if (index == 5)
            {
                logOutpage.dashBoardView = this;
                return logOutpage;
            }
            return homeScreen;
        }
    }
}
