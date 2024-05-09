using System;
using System.Collections.Generic;

namespace acme_publishing_data;

public partial class MagazineSubscription
{
    public string? SubscriptionId { get; set; }

    public uint? MagazineId { get; set; }

    public DateTime? AddedDate { get; set; }

    public bool? IsActive { get; set; }
}
