namespace BeaversDB.Model;

public class Person
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [InverseProperty("LovedBy")]
    public virtual List<Animal> AnimalsLoved { get; set; }

    [InverseProperty("HatedBy")]
    public virtual List<Animal> AnimalsHated { get; set; }

    public override string ToString()
    {
        return $"Person : Id = {Id} Name = {Name}";
    }
}
