using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Club
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<AnimalClub> AnimalClubs { get; set; } = new List<AnimalClub>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<MapToQuery> MapToQueries { get; set; } = new List<MapToQuery>();

    public virtual ICollection<AdditionalInfo> AdditionalInfos { get; set; } = new List<AdditionalInfo>();

    public virtual ICollection<Drawback> Drawbacks { get; set; } = new List<Drawback>();
}
