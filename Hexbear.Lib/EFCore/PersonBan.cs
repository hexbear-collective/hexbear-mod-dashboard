using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class PersonBan
{
    public int PersonId { get; set; }

    public DateTime Published { get; set; }

    public virtual Person Person { get; set; }
}
