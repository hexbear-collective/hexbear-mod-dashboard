using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ModFeaturePost
{
    public int Id { get; set; }

    public int ModPersonId { get; set; }

    public int PostId { get; set; }

    public bool Featured { get; set; }

    public DateTime When { get; set; }

    public bool IsFeaturedCommunity { get; set; }

    public virtual Person ModPerson { get; set; }

    public virtual Post Post { get; set; }
}
