
using BeaversDB;
using BeaversDB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BeaversController(AnimalContext context) : ControllerBase
{
    // GET: api/Beavers
    [HttpGet]
    public ActionResult<IEnumerable<BeaverModel>> GetBeavers()
    {
        return context.Beavers.Include(beaver => beaver.Id).ToList();
    }
}