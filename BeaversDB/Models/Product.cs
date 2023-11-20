using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Category? Category { get; set; }
}
