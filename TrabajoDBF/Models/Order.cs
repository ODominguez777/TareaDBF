using System;
using System.Collections.Generic;

namespace TrabajoDBF.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int StatusId { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string DateCreated { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
