using Hexbear.Lib.EFCore;
using Hexbear.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Hexbear.API.Services
{
    public class PostService
    {
        public async Task<PostResponse> GetPostDetails(int id, LemmyContext db)
        {
            var post = await db.Posts.Include(x => x.PostLikes).ThenInclude(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
            return new PostResponse()
            {
                Post = post
            };
        }

        public async Task<CommentResponse> GetCommentDetails(int id, LemmyContext db)
        {
            var comment = await db.Comments.Include(x => x.CommentLikes).ThenInclude(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
            return new CommentResponse()
            {
                Comment = comment
            };
        }
    }
}
