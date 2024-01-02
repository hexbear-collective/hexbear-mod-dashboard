using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class InstanceBlock
{
    public int PersonId { get; set; }

    public int InstanceId { get; set; }

    public DateTime Published { get; set; }

    public virtual Instance Instance { get; set; }

    public virtual Person Person { get; set; }
}
