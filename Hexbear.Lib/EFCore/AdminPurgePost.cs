using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class AdminPurgePost
{
    public int Id { get; set; }

    public int AdminPersonId { get; set; }

    public int CommunityId { get; set; }

    public string Reason { get; set; }

    public DateTime When { get; set; }

    public virtual Person AdminPerson { get; set; }

    public virtual Community Community { get; set; }
}
