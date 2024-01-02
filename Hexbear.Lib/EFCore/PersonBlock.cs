using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class PersonBlock
{
    public int PersonId { get; set; }

    public int TargetId { get; set; }

    public DateTime Published { get; set; }

    public virtual Person Person { get; set; }

    public virtual Person Target { get; set; }
}
