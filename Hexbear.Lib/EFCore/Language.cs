using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class Language
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Community> Communities { get; set; } = new List<Community>();

    public virtual ICollection<LocalUser> LocalUsers { get; set; } = new List<LocalUser>();

    public virtual ICollection<Site> Sites { get; set; } = new List<Site>();
}
