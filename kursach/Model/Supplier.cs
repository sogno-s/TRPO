using System;
using System.Collections.Generic;

namespace kursach;

public partial class Supplier
{
    public int Idsupplier { get; set; }

    public string? Naming { get; set; }

    public string? Surnameresponsible { get; set; }

    public int? Idinformation { get; set; }

    public virtual Informationofsupplier? IdinformationNavigation { get; set; }

    public virtual ICollection<Supplierproduct> Supplierproducts { get; } = new List<Supplierproduct>();

    public virtual ICollection<Warehouse> Warehouses { get; } = new List<Warehouse>();
}
