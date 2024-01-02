using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class LoginToken
{
    public string Token { get; set; }

    public int UserId { get; set; }

    public DateTime Published { get; set; }

    public string Ip { get; set; }

    public string UserAgent { get; set; }

    public virtual LocalUser User { get; set; }
}
