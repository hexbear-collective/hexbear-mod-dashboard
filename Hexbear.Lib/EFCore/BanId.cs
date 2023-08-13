using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class BanId
{
    public Guid Id { get; set; }

    public DateTime Created { get; set; }

    public Guid? AliasedTo { get; set; }

    public virtual BanId AliasedToNavigation { get; set; }

    public virtual ICollection<BanId> InverseAliasedToNavigation { get; set; } = new List<BanId>();

    public virtual ICollection<Person> Uids { get; set; } = new List<Person>();
}
