using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class CommentReport
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public int CommentId { get; set; }

    public string OriginalCommentText { get; set; }

    public string Reason { get; set; }

    public bool Resolved { get; set; }

    public int? ResolverId { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Comment Comment { get; set; }

    public virtual Person Creator { get; set; }

    public virtual Person Resolver { get; set; }
}
