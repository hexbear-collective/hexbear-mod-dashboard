using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ModRemoveComment
{
    public int Id { get; set; }

    public int ModPersonId { get; set; }

    public int CommentId { get; set; }

    public string Reason { get; set; }

    public bool Removed { get; set; }

    public DateTime When { get; set; }

    public virtual Comment Comment { get; set; }

    public virtual Person ModPerson { get; set; }
}
