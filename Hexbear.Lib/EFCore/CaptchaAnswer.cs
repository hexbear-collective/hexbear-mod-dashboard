﻿using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class CaptchaAnswer
{
    public Guid Uuid { get; set; }

    public string Answer { get; set; }

    public DateTime Published { get; set; }
}
