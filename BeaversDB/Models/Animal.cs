using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Animal
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public int? JobId { get; set; }

    public int? LovedById { get; set; }

    public int? HatedById { get; set; }

    public string IpAddress { get; set; } = null!;

    public virtual ICollection<AnimalClub> AnimalClubs { get; set; } = new List<AnimalClub>();

    public virtual Beaver? Beaver { get; set; }

    public virtual Crow? Crow { get; set; }

    public virtual Deer? Deer { get; set; }

    public virtual Food? Food { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Person? HatedBy { get; set; }

    public virtual Job? Job { get; set; }

    public virtual Person? LovedBy { get; set; }
}
