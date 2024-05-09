using System;
using System.Collections.Generic;

namespace acme_publishing_data;

public partial class Customer
{
    public string Id { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? CountryId { get; set; }
}
