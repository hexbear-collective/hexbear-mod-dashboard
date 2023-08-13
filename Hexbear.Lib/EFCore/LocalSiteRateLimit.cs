using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class LocalSiteRateLimit
{
    public int Id { get; set; }

    public int LocalSiteId { get; set; }

    public int Message { get; set; }

    public int MessagePerSecond { get; set; }

    public int Post { get; set; }

    public int PostPerSecond { get; set; }

    public int Register { get; set; }

    public int RegisterPerSecond { get; set; }

    public int Image { get; set; }

    public int ImagePerSecond { get; set; }

    public int Comment { get; set; }

    public int CommentPerSecond { get; set; }

    public int Search { get; set; }

    public int SearchPerSecond { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public virtual LocalSite LocalSite { get; set; }
}
