using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ModRemovePost
{
    public int Id { get; set; }

    public int ModPersonId { get; set; }

    public int PostId { get; set; }

    public string Reason { get; set; }

    public bool Removed { get; set; }

    public DateTime When { get; set; }

    public virtual Person ModPerson { get; set; }

    public virtual Post Post { get; set; }
}
