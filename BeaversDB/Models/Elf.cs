using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Elf
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DeerId { get; set; }

    public virtual Deer Deer { get; set; } = null!;
}
