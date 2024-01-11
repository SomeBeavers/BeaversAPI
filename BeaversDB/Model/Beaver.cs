namespace BeaversDB.Model;

//[Table("Beaver")]
public class Beaver : Animal
{
	public FluffinessEnum Fluffiness { get; set; }
	public int Size { get; set; }
	public List<AnimalClub> AnimalClubs { get; set; }


	public override string ToString()
	{
	
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