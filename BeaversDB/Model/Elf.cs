namespace BeaversDB.Model;

public class Elf
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    // NOTE: property is not null. When elves are removed from deer (`elf.Deer.Elves = null;`) then Elf is removed from DB.
    public virtual Deer Deer { get; set; } = null!;

    public override string ToString()
    {
        return $"Elf : Id = {Id} Name = {Name}";
    }
}
