using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Animal> AnimalHatedBies { get; set; } = new List<Animal>();

    public virtual ICollection<Animal> AnimalLovedBies { get; set; } = new List<Animal>();
}
