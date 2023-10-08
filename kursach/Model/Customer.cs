using System;
using System.Collections.Generic;

namespace kursach;

public partial class Customer
{
    public int Idcustomer { get; set; }

    public string? Surname { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Phonenumber { get; set; }

    public int? Idaddress { get; set; }

    public int? Idpasport { get; set; }

    public virtual Address? IdaddressNavigation { get; set; }

    public virtual Pasport? IdpasportNavigation { get; set; }
}
