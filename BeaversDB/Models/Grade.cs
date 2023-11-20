using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Grade
{
    public int Id { get; set; }

    public decimal? TheGrade { get; set; }

    public int ClubId { get; set; }

    public int AnimalId { get; set; }

    public int? AdditionalInfoId { get; set; }

    public virtual AdditionalInfo? AdditionalInfo { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual Club Club { get; set; } = null!;
}
