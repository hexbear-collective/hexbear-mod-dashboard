using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class SiteLanguage
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

    public virtual Site Site { get; set; }
}
