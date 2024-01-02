using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class PostLike
{
    public int PostId { get; set; }

    public int PersonId { get; set; }

    public short Score { get; set; }

    public DateTime Published { get; set; }

    public virtual Person Person { get; set; }

    public virtual Post Post { get; set; }
}
