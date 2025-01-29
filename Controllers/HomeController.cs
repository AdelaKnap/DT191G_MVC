using Microsoft.AspNetCore.Mvc;
using DT191G_MVC.Models;
using System.Text.Json;

namespace DT191G_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var jsonStr = System.IO.File.ReadAllText("dogs.json");
        var dogs = JsonSerializer.Deserialize<List<DogModel>>(jsonStr);
        return View(dogs);
    }

    [Route("/om")]
    public IActionResult About()
    {
        return View();
    }

    [Route("/raser")]
    public IActionResult Breeds()
    {
        return View();
    }
}