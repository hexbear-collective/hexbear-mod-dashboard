using Hexbear.Lib.EFCore;
using Hexbear.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Hexbear.Lib.Services
{
    public class ReportService
    {
        public async Task<ReportsResponse> ListReports(LemmyContext db)
        {
            var commentReports = await db.CommentReports
                .Select(x => new ReportItem()
                {
                    CreatorName = x.Creator.Name,
                    Reason = x.Reason,
                    Resolved = x.Resolved,
                    ResolverName = x.Resolver.Name,
                    PosterName = x.Comment.Creator.Name,
                    ReportType = "Comment",
                    OriginalText = x.OriginalCommentText,
                    DateCreated = x.Published,
                })
                .ToListAsync();
            var postReports = await db.PostReports
            .Select(x => new ReportItem()
            {
                CreatorName = x.Creator.Name,
                Reason = x.Reason,
                Resolved = x.Resolved,
                ResolverName = x.Resolver.Name,
                PosterName = x.Post.Creator.Name,
                ReportType = "Post",
                OriginalText = x.OriginalPostBody,
                DateCreated = x.Published,
            })
            .ToListAsync();
            var dmReports = await db.PrivateMessageReports
            .Select(x => new ReportItem()
            {
                CreatorName = x.Creator.Name,
                Reason = x.Reason,
                Resolved = x.Resolved,
                ResolverName = x.Resolver.Name,
                PosterName = x.PrivateMessage.Creator.Name,
                ReportType = "Private Message",
                OriginalText = x.OriginalPmText,
                DateCreated = x.Published,
            })
            .ToListAsync();
            return new ReportsResponse()
            {
                ReportItems = commentReports.Concat(postReports).Concat(dmReports).OrderByDescending(x => x.DateCreated).ToList()
            };
        }
    }
}
