using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class Language
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<CommunityLanguage> CommunityLanguages { get; set; } = new List<CommunityLanguage>();

    public virtual ICollection<LocalUserLanguage> LocalUserLanguages { get; set; } = new List<LocalUserLanguage>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<SiteLanguage> SiteLanguages { get; set; } = new List<SiteLanguage>();
}
