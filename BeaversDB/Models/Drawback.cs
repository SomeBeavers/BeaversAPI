using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Drawback
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string ConsequenceName { get; set; } = null!;

    public virtual ICollection<Club> Clubs { get; set; } = new List<Club>();

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
