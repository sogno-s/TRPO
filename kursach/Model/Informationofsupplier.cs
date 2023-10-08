using System;
using System.Collections.Generic;

namespace kursach;

public partial class Informationofsupplier
{
    public int Idinformation { get; set; }

    public string? Fullnaming { get; set; }

    public DateOnly? Dateofcooperation { get; set; }

    public DateOnly? Dateendcooperation { get; set; }

    public decimal? Monthlypayment { get; set; }

    public string? Accountnumbers { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
