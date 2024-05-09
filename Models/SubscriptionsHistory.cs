using System;
using System.Collections.Generic;

namespace acme_publishing_data;

public partial class SubscriptionsHistory
{
    public string? SubscriptionId { get; set; }

    public string? DistributorId { get; set; }

    public DateTime? TimeTriggered { get; set; }

    public uint Id { get; set; }

    public string? CountryId { get; set; }
}
