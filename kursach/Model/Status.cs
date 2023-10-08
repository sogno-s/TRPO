using System;
using System.Collections.Generic;

namespace kursach;

public partial class Status
{
    public int Idstatus { get; set; }

    public string? Naming { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
