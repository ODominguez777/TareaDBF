using System;
using System.Collections.Generic;

namespace TrabajoDBF.Models;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public double Price { get; set; }

    public int CountInStock { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int Rating { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
