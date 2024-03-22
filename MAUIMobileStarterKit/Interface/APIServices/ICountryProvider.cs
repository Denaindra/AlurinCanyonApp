using MAUIMobileStarterKit.Models.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.APIServices
{
    public interface ICountryProvider
    {
        [Get("/api/Canyons/CanyonCountry")]
        Task <List<CanyonCountry>> LoadCanyonCountriesAsync([Authorize("Bearer")] string token);

        [Get("/api/Countries")]
        Task<List<Country>> LoadCountriesAsync([Authorize("Bearer")] string token);
    }
}
