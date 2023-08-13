using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class CommunityLanguage
{
    public int Id { get; set; }

    public int CommunityId { get; set; }

    public int LanguageId { get; set; }

    public virtual Community Community { get; set; }

    public virtual Language Language { get; set; }
}
