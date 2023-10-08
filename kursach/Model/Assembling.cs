using System;
using System.Collections.Generic;

namespace kursach;

public partial class Assembling
{
    public int Idassembling { get; set; }

    public int? Idpayment { get; set; }

    public DateOnly? Dateofadmission { get; set; }

    public int? Idemployee { get; set; }

    public virtual Employee? IdemployeeNavigation { get; set; }

    public virtual Payment? IdpaymentNavigation { get; set; }
}
