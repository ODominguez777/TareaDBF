using System;
using System.Collections.Generic;

namespace TrabajoDBF.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string RolName { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
