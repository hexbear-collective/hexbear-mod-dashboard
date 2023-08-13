using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class EmailVerification
{
    public int Id { get; set; }

    public int LocalUserId { get; set; }

    public string Email { get; set; }

    public string VerificationToken { get; set; }

    public DateTime Published { get; set; }

    public virtual LocalUser LocalUser { get; set; }
}
