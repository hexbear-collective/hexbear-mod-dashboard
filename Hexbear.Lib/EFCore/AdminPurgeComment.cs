using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class AdminPurgeComment
{
    public int Id { get; set; }

    public int AdminPersonId { get; set; }

    public int PostId { get; set; }

    public string Reason { get; set; }

    public DateTime When { get; set; }

    public virtual Person AdminPerson { get; set; }

    public virtual Post Post { get; set; }
}
