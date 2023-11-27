using BeaversDB.Model;

namespace API.Models;

public class BeaverModel
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public int Age { get; set; }
	public string Fluffiness { get; set; }
	public int Size { get; set; }
}