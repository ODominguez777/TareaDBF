using System;
using System.Collections.Generic;

namespace TrabajoDBF.Models;

public partial class User
{
    public int Id { get; set; }

    public int RolId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Rol Rol { get; set; } = null!;
}
