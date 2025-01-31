using Microsoft.AspNetCore.Mvc;
using DT191G_MVC.Models;
using System.Text.Json;

namespace DT191G_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        // Läsa in JSON-fil och deserialisera
        var jsonStr = System.IO.File.ReadAllText("dogs.json");
        var dogs = JsonSerializer.Deserialize<List<DogModel>>(jsonStr);

        // Hämta namnet från session och skicka med ViewBag
        ViewBag.UserName = HttpContext.Session.GetString("UserName");

        return View(dogs);  // Skicka med listan till vyn
    }

    // Formuläret för att fylla i namn
    [HttpPost]
    public IActionResult SaveName(string userName)
    {
        if (!string.IsNullOrWhiteSpace(userName))
        {
            // Spara namnet i session
            HttpContext.Session.SetString("UserName", userName);
        }

        return RedirectToAction("Index");
    }


    [Route("/om")]
    public IActionResult About()
    {
        ViewBag.UserName = HttpContext.Session.GetString("UserName"); // Skicka med namnet
        return View();
    }


    [Route("/hundar")]
    public IActionResult Breeds()
    {
        ViewBag.UserName = HttpContext.Session.GetString("UserName"); // Skicka med namnet
        
        // Läs in form.json och deserialisera
        string jsonStr = System.IO.File.ReadAllText("form.json");
        var form = JsonSerializer.Deserialize<List<FormModel>>(jsonStr);

        return View(form);  // Skicka med listan till vyn
    }

    [HttpPost]
    [Route("/om")]
    public IActionResult About(FormModel model)
    {
        // Validera data
        if (ModelState.IsValid)
        {

            // Läs in form.json och deserialisera
            string jsonStr = System.IO.File.ReadAllText("form.json");
            var form = JsonSerializer.Deserialize<List<FormModel>>(jsonStr);

            // Lägg till i form.json
            if (form != null)
            {
                form.Add(model);
                //Serialisera och spara till form.json
                jsonStr = JsonSerializer.Serialize(form);
                System.IO.File.WriteAllText("form.json", jsonStr);
            }

            ModelState.Clear();                     // rensa formuläret

            return RedirectToAction("Breeds", "Home");    // Redirect till underisdan hundar
        }

        return View();
    }

}