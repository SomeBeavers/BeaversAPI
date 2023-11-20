using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Location
{
    public int ClubId { get; set; }

    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public virtual Club Club { get; set; } = null!;
}
