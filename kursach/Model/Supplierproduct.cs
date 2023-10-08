using System;
using System.Collections.Generic;

namespace kursach;

public partial class Supplierproduct
{
    public int Idsupprod { get; set; }
    public int? Idsupplier { get; set; }

    public int? Idproduct { get; set; }

    public int? Quantity { get; set; }

    public virtual Product IdproductNavigation { get; set; } = null!;

    public virtual Supplier IdsupplierNavigation { get; set; } = null!;
}
