using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class CommentAggregate
{
    public int CommentId { get; set; }

    public long Score { get; set; }

    public long Upvotes { get; set; }

    public long Downvotes { get; set; }

    public DateTime Published { get; set; }

    public int ChildCount { get; set; }

    public double HotRank { get; set; }

    public double ControversyRank { get; set; }

    public virtual Comment Comment { get; set; }
}
