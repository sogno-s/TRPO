using System;
using System.Collections.Generic;

namespace kursach;

public partial class Product
{
    public int Idproduct { get; set; }

    public string? Naming { get; set; }

    public string? Manufacturer { get; set; }

    public int? Idcategory { get; set; }

    public decimal? Price { get; set; }

    public int? Idwarehouse { get; set; }

    public string? Description { get; set; }

    public int? Stockquantity { get; set; }

    public virtual Categoryproduct? IdcategoryNavigation { get; set; }

    public virtual Warehouse? IdwarehouseNavigation { get; set; }

    public virtual ICollection<Paymentproduct> Paymentproducts { get; } = new List<Paymentproduct>();

    public virtual ICollection<Supplierproduct> Supplierproducts { get; } = new List<Supplierproduct>();
}
