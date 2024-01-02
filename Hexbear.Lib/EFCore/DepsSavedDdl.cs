using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class DepsSavedDdl
{
    public int Id { get; set; }

    public string ViewSchema { get; set; }

    public string ViewName { get; set; }

    public string DdlToRun { get; set; }
}
