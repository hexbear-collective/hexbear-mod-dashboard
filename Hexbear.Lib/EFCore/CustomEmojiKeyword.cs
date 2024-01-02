using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class CustomEmojiKeyword
{
    public int CustomEmojiId { get; set; }

    public string Keyword { get; set; }

    public virtual CustomEmoji CustomEmoji { get; set; }
}
