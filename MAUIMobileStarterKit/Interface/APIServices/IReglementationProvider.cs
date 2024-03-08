using MAUIMobileStarterKit.Models.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.APIServices
{
    public interface IReglementationProvider
    {
        [Get("/api/Reglementation/canyon/{canyonId}")]
        Task<IList<Reglementation>> GetProsCanyon([AliasAs("canyonId")] int canyonId);

        [Post("/api/Professionnal")]
        Task <IList<Reglementation>> PostPro(Reglementation reglementation);

        [Put("/api/Reglementation")]
        Task<IList<Reglementation>> ModifyPro(string commentId,Reglementation reglementation);

        [Delete("/api/Reglementation")]
        Task DeletePro([AliasAs("id")] int id);

    }
}
