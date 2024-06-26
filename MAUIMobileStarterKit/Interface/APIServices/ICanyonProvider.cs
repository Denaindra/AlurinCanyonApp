﻿using MAUIMobileStarterKit.Models.Service;
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
        Task<List<CustomPin>> GetAllCoordinate([Authorize("Bearer")] string token);

        [Post("/api/Canyons")]
        Task PostCanyon(Canyon canyon, [Authorize("Bearer")] string token);

        [Get("/api/Canyons/{canyonNumber}")]
        Task<Canyon> GetCanyon([AliasAs("canyonNumber")] string canyonNumber, [Authorize("Bearer")] string token);

        [Get("/api/Canyons/{canyonId}")]
        Task<Canyon> GetCanyonwithId([AliasAs("canyonId")] int canyonNumber);

        [Put("/api/Canyons")]
        Task<Canyon> UpdateCanyon([Body] Canyon canyontoupdate, [Authorize("Bearer")] string token);

        [Get("/api/Canyons/searchbyCountryRegion")]
        Task<List<Canyon>> GetCanyonFromRegion(GetCanyonFromRegionParams parms, [Authorize("Bearer")] string token);

        [Get("/api/Canyons/searchNamecanyon")]
        Task<List<Canyon>> GetCanyonName([AliasAs("canyonName")] string canyonName, [Authorize("Bearer")] string token);

        [Get("/api/Canyons/UnValidatedCanyon")]
        Task<List<Canyon>> UnvalidatedCanyon([Authorize("Bearer")] string token);

        [Delete("/api/Canyons")]
        Task DeleteCanyon([AliasAs("id")] string id, [Authorize("Bearer")] string token);

        [Get("/api/Canyons/listCanyonDays")]
        Task<List<Canyon>> GetCanyonLastDays(int days, [Authorize("Bearer")] string token);
    }

}
