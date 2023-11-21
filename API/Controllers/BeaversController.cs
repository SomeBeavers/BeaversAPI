using API.Converters;
using API.Models;
using BeaversDB;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeaversController(AnimalContext context) : ControllerBase
{
	// GET: api/Beavers
	[HttpGet]
	public ActionResult<IEnumerable<BeaverModel>> GetBeavers()
	{
		return context.Beavers.Select(b => b.ToModel()).ToList();
	}
}