using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ModLockPost
{
    public int Id { get; set; }

    public int ModPersonId { get; set; }

    public int PostId { get; set; }

    public bool Locked { get; set; }

    public DateTime When { get; set; }

    public virtual Person ModPerson { get; set; }

    public virtual Post Post { get; set; }
}
