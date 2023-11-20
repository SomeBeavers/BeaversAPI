using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class AdditionalInfo
{
    public int Id { get; set; }

    public string? Comment { get; set; }

    public string DetailedSummary { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Club> Clubs { get; set; } = new List<Club>();
}
