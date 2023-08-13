using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ModAdd
{
    public int Id { get; set; }

    public int ModPersonId { get; set; }

    public int OtherPersonId { get; set; }

    public bool Removed { get; set; }

    public DateTime When { get; set; }

    public virtual Person ModPerson { get; set; }

    public virtual Person OtherPerson { get; set; }
}
