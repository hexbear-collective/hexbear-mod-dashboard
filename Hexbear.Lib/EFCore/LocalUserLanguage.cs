using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class LocalUserLanguage
{
    public int Id { get; set; }

    public int LocalUserId { get; set; }

    public int LanguageId { get; set; }

    public virtual Language Language { get; set; }

    public virtual LocalUser LocalUser { get; set; }
}
