using MAUIMobileStarterKit.Models.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.APIServices
{
    public interface ItokenProvider
    {
        [Post("/oauth/token")]
        Task<AccessTokenRespond> GetToken([Body] AccessTokenRequest accessToken);
    }
}
