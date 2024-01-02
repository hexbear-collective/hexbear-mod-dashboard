using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class LocalSite
{
    public int Id { get; set; }

    public int SiteId { get; set; }

    public bool SiteSetup { get; set; }

    public bool EnableDownvotes { get; set; }

    public bool EnableNsfw { get; set; }

    public bool CommunityCreationAdminOnly { get; set; }

    public bool RequireEmailVerification { get; set; }

    public string ApplicationQuestion { get; set; }

    public bool PrivateInstance { get; set; }

    public string DefaultTheme { get; set; }

    public string LegalInformation { get; set; }

    public bool HideModlogModNames { get; set; }

    public bool ApplicationEmailAdmins { get; set; }

    public string SlurFilterRegex { get; set; }

    public int ActorNameMaxLength { get; set; }

    public bool FederationEnabled { get; set; }

    public bool CaptchaEnabled { get; set; }

    public string CaptchaDifficulty { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public bool ReportsEmailAdmins { get; set; }

    public bool FederationSignedFetch { get; set; }

    public virtual ICollection<CustomEmoji> CustomEmojis { get; set; } = new List<CustomEmoji>();

    public virtual LocalSiteRateLimit LocalSiteRateLimit { get; set; }

    public virtual Site Site { get; set; }

    public virtual ICollection<Tagline> Taglines { get; set; } = new List<Tagline>();
}
