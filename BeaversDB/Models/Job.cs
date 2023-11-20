using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Salary { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual ICollection<Drawback> Drawbacks { get; set; } = new List<Drawback>();
}
