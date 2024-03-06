using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class ServiceQueryParams
    {
    }
    public class GetCanyonFromRegionParams
    {
        public string country { get; set; }
        public string region { get; set; }
        public string state { get; set; }
    }

    public class DeleteCommentParams
    {
        public string id { get; set; }
        public string days { get; set; }
    }
}
