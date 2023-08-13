using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class PostReport
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public int PostId { get; set; }

    public string OriginalPostName { get; set; }

    public string OriginalPostUrl { get; set; }

    public string OriginalPostBody { get; set; }

    public string Reason { get; set; }

    public bool Resolved { get; set; }

    public int? ResolverId { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Person Creator { get; set; }

    public virtual Post Post { get; set; }

    public virtual Person Resolver { get; set; }
}
