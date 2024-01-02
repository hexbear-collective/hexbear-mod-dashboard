using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class FederationQueueState
{
    public int InstanceId { get; set; }

    public long? LastSuccessfulId { get; set; }

    public int FailCount { get; set; }

    public DateTime? LastRetry { get; set; }

    public DateTime? LastSuccessfulPublishedTime { get; set; }

    public virtual Instance Instance { get; set; }
}
