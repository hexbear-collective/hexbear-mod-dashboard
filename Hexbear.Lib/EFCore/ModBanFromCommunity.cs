using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ModBanFromCommunity
{
    public int Id { get; set; }

    public int ModPersonId { get; set; }

    public int OtherPersonId { get; set; }

    public int CommunityId { get; set; }

    public string Reason { get; set; }

    public bool Banned { get; set; }

    public DateTime? Expires { get; set; }

    public DateTime When { get; set; }

    public virtual Community Community { get; set; }

    public virtual Person ModPerson { get; set; }

    public virtual Person OtherPerson { get; set; }
}
