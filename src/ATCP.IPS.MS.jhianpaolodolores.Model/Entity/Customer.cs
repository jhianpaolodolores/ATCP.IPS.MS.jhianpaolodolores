using System;
using System.Collections.Generic;

namespace ATCP.IPS.MS.jhianpaolodolores.Model.Entity;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Address { get; set; } = null!;

    public int Age { get; set; }

    public string? Gender { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDttm { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDttm { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
