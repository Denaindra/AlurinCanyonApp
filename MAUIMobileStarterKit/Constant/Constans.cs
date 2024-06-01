using MAUIMobileStarterKit.Models.Service;
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
        public static string CanyonNumber = "1216";
        public static string UserRole = "Free";

        public static Canyon SelectedCanyon;

        public static List<Country> CountriesList;
        public static List<string> CountryList;
        public static List<string> RegionsList;
        public static List<string> StatesList;
        public static List<string> MoutainsList;
        public static List<string> BassinsList;
        public static List<string> CitiesList;
        public static List<string> RiversList;
    }
}
