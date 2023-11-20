using System;
using System.Collections.Generic;

namespace BeaversDB.Models;

public partial class Category
{
    public int Id { get; set; }

    public int? FoodId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Food? Food { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
