using System;
using System.Collections.Generic;

namespace kursach;

public partial class Pasport
{
    public int Idpasport { get; set; }

    public string? Seria { get; set; }

    public string? Numberp { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
