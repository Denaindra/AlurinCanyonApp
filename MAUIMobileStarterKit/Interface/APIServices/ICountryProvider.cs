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
        Task LoadCanyonCountriesAsync();

        [Get("/api/Countries")]
        Task LoadCountriesAsync();
    }
}
