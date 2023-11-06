using System;
using System.Collections.Generic;

namespace ATCP.IPS.MS.jhianpaolodolores.Model.Entity;

public partial class Account
{
    public long AccountNumber { get; set; }

    public string AccountType { get; set; } = null!;

    public decimal Balance { get; set; }
}
