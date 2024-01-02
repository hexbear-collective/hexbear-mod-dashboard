using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class DieselSchemaMigration
{
    public string Version { get; set; }

    public DateTime RunOn { get; set; }
}
