using API.Models;
using BeaversDB.Model;

namespace API.Converters;

public static class BeaverExtensions
{
	public static BeaverModel ToModel(this Beaver beaver)
	{
		return new BeaverModel
		{
			Id = beaver.Id,
			Name = beaver.Name,
			Fluffiness = beaver.Fluffiness,
			Size = beaver.Size,
			Age = beaver.Age,
			
		};
	}

	public static Beaver ToEntity(this BeaverModel beaver)
	{
		return new Beaver
		{
			Id = beaver.Id,
			Name = beaver.Name,
			Fluffiness = beaver.Fluffiness,
			Size = beaver.Size
		};
	}
}