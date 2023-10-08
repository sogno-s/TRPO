using System;
using System.Collections.Generic;

namespace kursach;

public partial class Categoryproduct
{
    public int Idcategory { get; set; }

    public string? Namingcategory { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
