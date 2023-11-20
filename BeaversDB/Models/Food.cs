using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Food
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? AnimalId { get; set; }

    public string Discriminator { get; set; } = null!;

    public int? Taste { get; set; }

    public int? Calories { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Drawback> Drawbacks { get; set; } = new List<Drawback>();
}
