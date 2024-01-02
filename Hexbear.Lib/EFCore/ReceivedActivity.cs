using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ReceivedActivity
{
    public string ApId { get; set; }

    public DateTime Published { get; set; }
}
