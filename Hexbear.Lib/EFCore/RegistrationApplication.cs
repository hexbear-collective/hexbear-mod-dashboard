using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class RegistrationApplication
{
    public int Id { get; set; }

    public int LocalUserId { get; set; }

    public string Answer { get; set; }

    public int? AdminId { get; set; }

    public string DenyReason { get; set; }

    public DateTime Published { get; set; }

    public virtual Person Admin { get; set; }

    public virtual LocalUser LocalUser { get; set; }
}
