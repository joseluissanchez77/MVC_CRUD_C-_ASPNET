using System;
using System.Collections.Generic;

namespace MVC_CRUD_C__ASPNET.Models;

public partial class Position
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
