using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ModRemoveCommunity
{
    public int Id { get; set; }

    public int ModPersonId { get; set; }

    public int CommunityId { get; set; }

    public string Reason { get; set; }

    public bool Removed { get; set; }

    public DateTime When { get; set; }

    public virtual Community Community { get; set; }

    public virtual Person ModPerson { get; set; }
}
