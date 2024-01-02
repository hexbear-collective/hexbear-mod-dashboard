using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class ImageUpload
{
    public int LocalUserId { get; set; }

    public string PictrsAlias { get; set; }

    public string PictrsDeleteToken { get; set; }

    public DateTime Published { get; set; }

    public virtual LocalUser LocalUser { get; set; }
}
