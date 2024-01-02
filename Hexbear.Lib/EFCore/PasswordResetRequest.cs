using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class PasswordResetRequest
{
    public int Id { get; set; }

    public string Token { get; set; }

    public DateTime Published { get; set; }

    public int LocalUserId { get; set; }

    public virtual LocalUser LocalUser { get; set; }
}
