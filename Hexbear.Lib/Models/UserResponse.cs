using Hexbear.Lib.EFCore;

namespace Hexbear.Lib.Models
{
    public class UserResponse
    {
        public Person Person { get; set; }
        public List<ReportItem> ReportedItems { get; set; }
        public List<ReportItem> ReportsCreatedItems { get; set; }
        public int UpvotedRemovedPosts { get; set; }
        public int UpvotedRemovedComments { get; set; }
    }
}