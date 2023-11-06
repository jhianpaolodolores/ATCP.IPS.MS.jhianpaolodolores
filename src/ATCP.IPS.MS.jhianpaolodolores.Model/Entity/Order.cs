using System;
using System.Collections.Generic;

namespace ATCP.IPS.MS.jhianpaolodolores.Model.Entity;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public int ItemCount { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalAmount { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDttm { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDttm { get; set; }

    public bool IsActive { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
