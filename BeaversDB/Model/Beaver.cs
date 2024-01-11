namespace BeaversDB.Model;

//[Table("Beaver")]
public class Beaver : Animal
{
	public FluffinessEnum Fluffiness { get; set; }
	public int Size { get; set; }
	public List<AnimalClub> AnimalClubs { get; set; }


	public override string ToString()
	{
		var animalClubs = new List<AnimalClub>();
		animalClubs.Add(new AnimalClub { AnimalId = this.Id, ClubId = 1, PublicationDate = DateTime.Now });
		animalClubs.Add(new AnimalClub { AnimalId = this.Id, ClubId = 2, PublicationDate = DateTime.Now });
		this.AnimalClubs = animalClubs;
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
	Fluffy,
	VeryFluffy
}