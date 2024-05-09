using System;
using System.Collections.Generic;

namespace acme_publishing_data;

public partial class Subscription
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }
}
