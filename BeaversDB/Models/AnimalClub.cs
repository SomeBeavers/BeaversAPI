using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class AnimalClub
{
    public int AnimalId { get; set; }

    public int ClubId { get; set; }

    public DateTime PublicationDate { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual Club Club { get; set; } = null!;
}
