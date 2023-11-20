using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Crow
{
    public int Id { get; set; }

    public string Color { get; set; } = null!;

    public virtual Animal IdNavigation { get; set; } = null!;
}
