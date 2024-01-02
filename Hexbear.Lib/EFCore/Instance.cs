using System;
using System.Collections.Generic;

namespace Hexbear.Lib.EFCore;

public partial class Instance
{
    public int Id { get; set; }

    public string Domain { get; set; }

    public DateTime Published { get; set; }

    public DateTime? Updated { get; set; }

    public string Software { get; set; }

    public string Version { get; set; }

    public virtual ICollection<Community> Communities { get; set; } = new List<Community>();

    public virtual FederationAllowlist FederationAllowlist { get; set; }

    public virtual FederationBlocklist FederationBlocklist { get; set; }

    public virtual FederationQueueState FederationQueueState { get; set; }

    public virtual ICollection<InstanceBlock> InstanceBlocks { get; set; } = new List<InstanceBlock>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<PostAggregate> PostAggregates { get; set; } = new List<PostAggregate>();

    public virtual Site Site { get; set; }
}
