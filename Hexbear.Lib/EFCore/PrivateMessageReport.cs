using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class PrivateMessageReport
{
    public int Id { get; set; }

    public int CreatorId { get; set; }

    public int PrivateMessageId { get; set; }

    public string OriginalPmText { get; set; }

    public string Reason { get; set; }

    public bool Resolved { get; set; }

    public int? ResolverId { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Person Creator { get; set; }

    public virtual PrivateMessage PrivateMessage { get; set; }

    public virtual Person Resolver { get; set; }
}
