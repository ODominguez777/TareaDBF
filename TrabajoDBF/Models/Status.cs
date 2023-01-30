using System;
using System.Collections.Generic;

namespace TrabajoDBF.Models;

public partial class Status
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
