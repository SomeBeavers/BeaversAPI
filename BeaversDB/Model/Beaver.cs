namespace BeaversDB.Model;

//[Table("Beaver")]

public class Beaver : Animal
{
	public FluffinessEnum Fluffiness { get; set; }
	public int Size { get; set; }
	public List<AnimalClub> AnimalClubs { get; set; }

	/// <summary>
	/// Overrides the base ToString method to include additional information about the Beaver object.
	/// </summary>
	/// <returns>A string representation of the Beaver object.</returns>
	public override string ToString()
	{
		List<AnimalClub> animalClubs =
        [
            new AnimalClub { AnimalId = Id, ClubId = 1, PublicationDate = DateTime.Now },
            new AnimalClub { AnimalId = Id, ClubId = 2, PublicationDate = DateTime.Now },
            
            
        ];

        AnimalClubs = animalClubs;
		return @$"{base.ToString()} Beaver: Fluffiness = {this.Fluffiness} Size = {this.Size}";
	}


	public void DoSomething()
	{
		AnimalClub animalClub = new AnimalClub();
		animalClub.AnimalId = this.Id;
		animalClub.ClubId = 1;
		animalClub.PublicationDate = DateTime.Now;
	}
}

public enum FluffinessEnum
{
	NotFluffy,
    MediumFluffy,
    Fluffy,
	VeryFluffy
}