using System;
using System.Collections.Generic;

namespace kursach;

public partial class Paymentproduct
{
    public int Idpayment { get; set; }

    public int Idproduct { get; set; }

    public int? Quantity { get; set; }

    public virtual Payment IdpaymentNavigation { get; set; } = null!;

    public virtual Product IdproductNavigation { get; set; } = null!;
}
