using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class CommentSaved
{
    public int Id { get; set; }

    public int CommentId { get; set; }

    public int PersonId { get; set; }

    public DateTime Published { get; set; }

    public virtual Comment Comment { get; set; }

    public virtual Person Person { get; set; }
}
