using Hexbear.Lib.EFCore;

namespace Hexbear.Lib.Models
{
    public class UserResponse
    {
        public Person Person { get; set; }
        public List<ReportItem> ReportedItems { get; set; }
        public List<ReportItem> ReportsCreatedItems { get; set; }
        public List<Post> UpvotedRemovedPosts { get; set; }
        public List<Comment> UpvotedRemovedComments { get; set; }
    }
}