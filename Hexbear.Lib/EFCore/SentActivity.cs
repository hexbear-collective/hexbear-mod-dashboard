using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class SentActivity
{
    public long Id { get; set; }

    public string ApId { get; set; }

    public string Data { get; set; }

    public bool Sensitive { get; set; }

    public DateTime Published { get; set; }

    public List<string> SendInboxes { get; set; }

    public int? SendCommunityFollowersOf { get; set; }

    public bool SendAllInstances { get; set; }

    public string ActorApubId { get; set; }
}
