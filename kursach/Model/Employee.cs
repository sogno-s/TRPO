using System;
using System.Collections.Generic;

namespace kursach;

public partial class Employee
{
    public int Idemployee { get; set; }

    public string? Surname { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateOnly? Dateofbirthday { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public string? Idspecialization { get; set; }

    public int? Idpasport { get; set; }

    public string? Login { get; set; }

    public string? Passworde { get; set; }

    public virtual ICollection<Assembling> Assemblings { get; } = new List<Assembling>();

    public virtual Pasport? IdpasportNavigation { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
