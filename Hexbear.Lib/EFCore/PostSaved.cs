using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class PostSaved
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int PersonId { get; set; }

    public DateTime Published { get; set; }

    public virtual Person Person { get; set; }

    public virtual Post Post { get; set; }
}
