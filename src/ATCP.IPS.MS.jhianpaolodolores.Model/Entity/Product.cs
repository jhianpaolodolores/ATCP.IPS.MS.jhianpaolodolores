using System;
using System.Collections.Generic;

namespace ATCP.IPS.MS.jhianpaolodolores.Model.Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDttm { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDttm { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
