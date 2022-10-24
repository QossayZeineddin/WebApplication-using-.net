using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class MovieController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("testing2");
    }
    public IActionResult welcome(string name, int ID = 3)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = ID;

        return View("testing2");

    }
}