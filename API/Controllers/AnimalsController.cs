using BeaversDB;
using BeaversDB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController(AnimalContext context) : ControllerBase
{
    public string MyProperty(string myCoolString)
    {
        string myString = MyProperty(myCoolString);
        string anotherString = myCoolString;
        return myString;
    }
}