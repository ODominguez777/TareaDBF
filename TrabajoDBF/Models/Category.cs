using System;
using System.Collections.Generic;

namespace TrabajoDBF.Models;

public partial class Category
{
    public int Id { get; set; }

    public string NameCategory { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
