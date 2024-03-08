using MAUIMobileStarterKit.Models.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.APIServices
{
    public interface ITopographyProvider
    {
        [Get("api/Topography/canyon/{canyonId}")]
        Task<IList<Topography>> GetTopoCanyon([AliasAs("canyonId")] int canyonId);

        [Get("api/Topography/listTopodays")]
        Task<IList<Topography>> GetTopoCanyonLastDays([AliasAs("days")] int days);

        [Post("api/Topography/listTopodays")]
        Task<IList<Topography>> PostTopo(Topography topography);

        [Put("/api/Topography")]
        Task<IList<Topography>> ModifyTopo([AliasAs("id")] int id);

        [Put("api/Topography/list")]
        Task ModifyListTopo(IList<Topography> topographiestoModify);

        [Delete("api/Topography")]
        Task DeleteTopo([AliasAs("id")] int id);

    }
}
