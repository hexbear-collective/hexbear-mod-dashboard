using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class CommunityAggregate
{
    public int Id { get; set; }

    public int CommunityId { get; set; }

    public long Subscribers { get; set; }

    public long Posts { get; set; }

    public long Comments { get; set; }

    public DateTime Published { get; set; }

    public long UsersActiveDay { get; set; }

    public long UsersActiveWeek { get; set; }

    public long UsersActiveMonth { get; set; }

    public long UsersActiveHalfYear { get; set; }

    public int HotRank { get; set; }

    public virtual Community Community { get; set; }
}
