using System;
using System.Collections.Generic;

namespace ATCP.IPS.MS.jhianpaolodolores.Model.Entity;

public partial class OrderByProductView
{
    public string? ProductName { get; set; }

    public string? CustomerFullName { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public int? ItemCountOrders { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? TotalAmountOrders { get; set; }
}
