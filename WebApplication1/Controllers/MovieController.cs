using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class MovieController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("testing2");
    }
}