using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class Site
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Sidebar { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public string Icon { get; set; }

    public string Banner { get; set; }

    public string Description { get; set; }

    public string ActorId { get; set; }

    public DateTime LastRefreshedAt { get; set; }

    public string InboxUrl { get; set; }

    public string PrivateKey { get; set; }

    public string PublicKey { get; set; }

    public int InstanceId { get; set; }

    public virtual Instance Instance { get; set; }

    public virtual LocalSite LocalSite { get; set; }

    public virtual ICollection<SiteAggregate> SiteAggregates { get; set; } = new List<SiteAggregate>();

    public virtual ICollection<SiteLanguage> SiteLanguages { get; set; } = new List<SiteLanguage>();
}
