using System;
using System.Collections.Generic;

namespace kursach;

public partial class Warehouse
{
    public int Idwarehouse { get; set; }

    public string? Inventorynumber { get; set; }

    public bool? Availability { get; set; }

    public DateOnly? Dateofreceipt { get; set; }

    public int? Idsupplier { get; set; }

    public virtual Supplier? IdsupplierNavigation { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
