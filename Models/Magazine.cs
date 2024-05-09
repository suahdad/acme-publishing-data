using System;
using System.Collections.Generic;

namespace acme_publishing_data;

public partial class Magazine
{
    public uint Id { get; set; }

    public ushort? IssueNumber { get; set; }

    public string? Name { get; set; }

    public DateTime? IssueDate { get; set; }
}
