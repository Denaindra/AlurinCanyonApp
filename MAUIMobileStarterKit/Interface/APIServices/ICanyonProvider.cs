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
        Task<List<Canyon>> GetCanyonFromRegion(GetCanyonFromRegionParams parms, [Authorize("Bearer")] string token);

        [Get("/api/Canyons/searchNamecanyon")]
        Task<List<Canyon>> GetCanyonName([AliasAs("canyonName")] string canyonName, [Authorize("Bearer")] string token);

        [Get("/api/Canyons/UnValidatedCanyon")]
        Task<List<Canyon>> UnvalidatedCanyon([Authorize("Bearer")] string token);

        [Delete("/api/Canyons")]
        Task<List<Canyon>> DeleteCanyon(string id);

        [Get("/api/Canyons/listCanyonDays")]
        Task<List<Canyon>> GetCanyonLastDays(int days, [Authorize("Bearer")] string token);
    }

}
