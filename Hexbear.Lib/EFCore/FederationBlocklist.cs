using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class FederationBlocklist
{
    public int InstanceId { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Instance Instance { get; set; }
}
