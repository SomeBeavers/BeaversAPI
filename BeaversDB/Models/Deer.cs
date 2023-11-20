using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Deer
{
    public int Id { get; set; }

    public bool Horns { get; set; }

    public virtual ICollection<Elf> Elves { get; set; } = new List<Elf>();

    public virtual Animal IdNavigation { get; set; } = null!;
}
