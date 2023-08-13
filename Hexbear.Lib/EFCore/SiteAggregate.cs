using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class SiteAggregate
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public long Users { get; set; }

    public long Posts { get; set; }

    public long Comments { get; set; }

    public long Communities { get; set; }

    public long UsersActiveDay { get; set; }

    public long UsersActiveWeek { get; set; }

    public long UsersActiveMonth { get; set; }

    public long UsersActiveHalfYear { get; set; }

    public virtual Site Site { get; set; }
}
