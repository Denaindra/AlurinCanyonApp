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
        Task<List<Comment>> GetCommentCanyon([AliasAs("canyonId")] int canyonId);

        [Post("/api/Comment}")]
        Task<List<Comment>> PostComment([Body] Comment usercomment);

        [Put("/api/Comment")]
        Task DeleteComment(DeleteCommentParams comment);

        [Put("/api/Comment")]
        Task ModifyComment([Body] Comment commentModify, DeleteCommentParams comment);

        [Get("/api/Comment/listCommentdays")]
        Task<List<Comment>> GetCommentCanyonLastDays(DeleteCommentParams comment);

    }
}
