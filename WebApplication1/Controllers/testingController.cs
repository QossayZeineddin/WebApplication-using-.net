using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class testingController : Controller
{
    // GET
    
    
    public IActionResult Index()
    {
        return View("testing");
    }

    public String hello()
    {
        return "pubplic method that return a string ";
    }

    public String parameter(String name, double id)
    {
        //Uses HtmlEncoder.Default.Encode to protect the app from malicious input, such as through JavaScript.
        return HtmlEncoder.Default.Encode($"my name is: {name} and my id number is : {id}");

        //return ($"my name is: {name} and my id number is : {id}");
        //the url is
        //https://localhost:7134/testing/parameter?name=Qossay&id=1180235
    }
    public string parameter2(string name, int ID = 3)
    {
        //Console.WriteLine(DateTime.Now - TimeSpan.FromDays(7));
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        
    }
    
}