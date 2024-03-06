using MAUIMobileStarterKit.Models.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.APIServices
{
    public interface ICanyonProvider
    {
        [Get("/api/Canyons/allCoordinates")]
        Task<List<CustomPin>> GetAllCoordinate();

        [Post("/api/Canyons/")]
        Task<Canyon> PostCanyon([Body] Canyon newcanyon);

        [Get("/api/Canyons/{canyonNumber}")]
        Task<Canyon> GetCanyon([AliasAs("canyonNumber")] int canyonNumber);

        [Get("/api/Canyons/{canyonId}")]
        Task<Canyon> GetCanyonwithId([AliasAs("canyonId")] int canyonNumber);

        [Put("/api/Canyons/")]
        Task<Canyon> UpdateCanyon([Body] Canyon canyontoupdate);

        [Get("/api/Canyons/searchbyCountryRegion")]
        Task<List<Canyon>> GetCanyonFromRegion(GetCanyonFromRegionParams parms);

        [Get("api/Canyons/searchNamecanyon")]
        Task<List<Canyon>> GetCanyonName(string canyonName);

        [Get("/api/Canyons/UnValidatedCanyon")]
        Task<List<Canyon>> UnvalidatedCanyon();

        [Get("https://canyonproject.eu.auth0.com/oauth/token")]
        Task<List<Canyon>> GetToken();

        [Delete("/api/Canyons")]
        Task<List<Canyon>> GetToken(string id);

        [Get("/api/Canyons/listCanyonDays")]
        Task<List<Canyon>> GetCanyonLastDays(int days);
    }

}
