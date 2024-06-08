using MAUIMobileStarterKit.Models.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.APIServices
{
    public interface IProfessionalProvider
    {
        [Get("/api/Professionnal/canyon/{canyonId}")]
        Task <IList<Professionnal>> GetProsCanyon([Authorize("Bearer")] string token, [AliasAs("canyonId")] int canyonId);

        [Post("/api/Professionnal")]
        Task PostPro([Authorize("Bearer")] string token, Professionnal professionnal);

        [Put("/api/Professionnal")]
        Task ModifyPro([Authorize("Bearer")] string token, [AliasAs("id")] int id, Professionnal professionelModify);

        [Delete("/api/Professionnal")]
        Task DeletePro([AliasAs("id")] int id);




    }
}
