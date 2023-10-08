using System;
using System.Collections.Generic;

namespace kursach;

public partial class Address
{
    public int Idaddress { get; set; }

    public string? Region { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? Numberhouse { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
