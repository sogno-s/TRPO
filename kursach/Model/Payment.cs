using System;
using System.Collections.Generic;

namespace kursach;

public partial class Payment
{
    public int Idpayment { get; set; }

    public int? Idemployee { get; set; }

    public decimal? Totalsumm { get; set; }

    public int? Idstatus { get; set; }

    public DateOnly? Dateofpay { get; set; }

    public string? Typeofpay { get; set; }

    public virtual ICollection<Assembling> Assemblings { get; } = new List<Assembling>();

    public virtual Employee? IdemployeeNavigation { get; set; }

    public virtual Status? IdstatusNavigation { get; set; }

    public virtual ICollection<Paymentproduct> Paymentproducts { get; } = new List<Paymentproduct>();
}
