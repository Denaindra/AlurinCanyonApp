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
        [Get("/api/Professionnal/canyon/")]
        Task <IList<Professionnal>> GetProsCanyon(int canyonId);

        [Post("/api/Professionnal")]
        Task<IList<Professionnal>> PostPro(int numcanyon, Professionnal professionnal);

        [Put("/api/Professionnal")]
        Task ModifyPro([AliasAs("id")] int id, Professionnal professionelModify);

        [Delete("/api/Professionnal")]
        Task DeletePro([AliasAs("id")] int id);




    }
}
