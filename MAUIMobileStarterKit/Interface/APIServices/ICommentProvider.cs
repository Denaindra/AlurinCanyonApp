using MAUIMobileStarterKit.Models.Service;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface.APIServices
{
    public interface ICommentProvider
    {
        [Get("/api/Comment/canyon/{canyonId}")]
        Task<List<Comment>> GetCommentCanyon([AliasAs("canyonId")] int canyonId, [Authorize("Bearer")] string token);

        [Post("/api/Comment")]
        Task PostComment([Body] Comment usercomment,[Authorize("Bearer")] string token);

        [Delete("/api/Comment")]
        Task DeleteComment([Authorize("Bearer")] string token,[AliasAs("id")] int id);

        [Put("/api/Comment")]
        Task ModifyComment([Authorize("Bearer")] string token, [Body] Comment commentModify, [AliasAs("id")] int canyonId);

        [Get("/api/Comment/listCommentdays")]
        Task<List<Comment>> GetCommentCanyonLastDays([AliasAs("days")] int days, [Authorize("Bearer")] string token);
    }
}
