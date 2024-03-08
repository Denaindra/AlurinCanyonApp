using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class AccessTokenRequest
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string audience { get; set; }
        public string grant_type { get; set; }
    }
    public class AccessTokenRespond
    {
        public string access_token { get; set; }
        public long expires_in { get; set; }
        public string token_type { get; set; }
    }
}
