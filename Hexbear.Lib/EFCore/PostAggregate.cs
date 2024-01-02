using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class PostAggregate
{
    public int PostId { get; set; }

    public long Comments { get; set; }

    public long Score { get; set; }

    public long Upvotes { get; set; }

    public long Downvotes { get; set; }

    public DateTime Published { get; set; }

    public DateTime NewestCommentTimeNecro { get; set; }

    public DateTime NewestCommentTime { get; set; }

    public bool FeaturedCommunity { get; set; }

    public bool FeaturedLocal { get; set; }

    public double HotRank { get; set; }

    public double HotRankActive { get; set; }

    public int CommunityId { get; set; }

    public int CreatorId { get; set; }

    public double ControversyRank { get; set; }

    public int InstanceId { get; set; }

    public double ScaledRank { get; set; }

    public virtual Community Community { get; set; }

    public virtual Person Creator { get; set; }

    public virtual Instance Instance { get; set; }

    public virtual Post Post { get; set; }
}
