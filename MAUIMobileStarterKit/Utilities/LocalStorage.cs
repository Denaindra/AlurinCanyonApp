using IdentityModel.OidcClient;
using MAUIMobileStarterKit.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Utilities
{
    public class LocalStorage: ILocalStorage
    {
        public async void SetAsync(string key,string value)
        {
            await SecureStorage.Default.SetAsync(key, value);
        }
        public async Task<string> GetAsync(string key)
        {
           var reasult =  await SecureStorage.Default.GetAsync(key);
           return reasult;
        }
    }
}
