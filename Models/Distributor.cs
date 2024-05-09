using System;
using System.Collections.Generic;

namespace acme_publishing_data;

public partial class Distributor
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? CountryId { get; set; }
}
