using System;
using System.Collections.Generic;

namespace acme_publishing_data;

public partial class CustomerSubscription
{
    public string? CustomerId { get; set; }

    public string? SubscriptionId { get; set; }

    public string? Address { get; set; }

    public string? CountryId { get; set; }

    public uint Id { get; set; }
}
