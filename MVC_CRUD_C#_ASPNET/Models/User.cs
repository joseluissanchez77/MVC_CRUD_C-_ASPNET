using System;
using System.Collections.Generic;

namespace MVC_CRUD_C__ASPNET.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? IdCargo { get; set; }

    public virtual Position? oPosition { get; set; }

    //public virtual Position? IdCargoNavigation { get; set; }
}
