using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class Secret
{
    public int Id { get; set; }

    public string JwtSecret { get; set; }
}
