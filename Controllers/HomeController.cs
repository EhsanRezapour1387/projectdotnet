using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projectdotnet.Models;
using projectdotnet.Models.Context;

namespace projectdotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Application db;

    public HomeController(ILogger<HomeController> logger, Application _db)
    {
        _logger = logger;
        db = _db;
    }

    public IActionResult Index()
    {
        ViewBag.offer = db.tbl_Offers.ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
