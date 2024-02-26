using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.Content;

namespace MAUIMobileStarterKit.Platforms.Android
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
               Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
               DataScheme = CALLBACK_SCHEME)]
    public class WebAuthenticationCallbackActivity: Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
    {
        const string CALLBACK_SCHEME = "com.companyname.canyonproject";
    }
}
