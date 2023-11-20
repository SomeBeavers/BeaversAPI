using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class MapToQuery
{
    public int Id { get; set; }

    public int Fluffiness { get; set; }

    public int Size { get; set; }

    public int ClubId { get; set; }

    public virtual Club Club { get; set; } = null!;
}
