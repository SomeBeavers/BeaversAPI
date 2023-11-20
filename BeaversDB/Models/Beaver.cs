using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Beaver
{
    public int Id { get; set; }

    public int Fluffiness { get; set; }

    public int Size { get; set; }

    public virtual Animal IdNavigation { get; set; } = null!;
}
