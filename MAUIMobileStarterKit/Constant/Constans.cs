using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Constant
{
    public static class Constans
    {
        public static double DeviceHeight;
        public static double DeviceWidth;
        public static FlyoutPage flyoutPage;

        public const string Domain = "canyonproject.eu.auth0.com";
        public static string ClientId = "dKayOCy49So27VtmIrJsjdfB3qfVLJWc";
        public static string RedirectUri = "com.companyname.canyonproject://canyonproject.eu.auth0.com/android/com.companyname.canyonproject/callback";
        public static string PostLogoutRedirectUri = "com.companyname.canyonproject://canyonproject.eu.auth0.com/android/com.companyname.canyonproject/callback";
        public static string Scope = "openid profile email";
        public const string LogoutTitle = "LogOut";
        public const string LogingTitle = "LogIn";

        public const string BASEDURL = "https://canyonapp.azurewebsites.net";
        public const string TOKENBASEDURL = "https://canyonproject.eu.auth0.com";
        public const string AccessTokenRequestAudence = "https://api.canyonproject.com";


    }
}
