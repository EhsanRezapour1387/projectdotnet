using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectdotnet.Models;
using projectdotnet.Models.Context;
using projectdotnet.Models.Models;

namespace projectdotnet.Areas.Admin.Controllers;
[Area("Admin")]
public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly Application db;

    public LoginController(ILogger<LoginController> logger, Application _db)
    {
        _logger = logger;
        db = _db;
    }
    public IActionResult Login()
    {

        return View();
    }
    public IActionResult Check(Vm_User vm)
    {
        var find = db.tbl_Users.SingleOrDefault
        (p => p.UserName == vm.Vm_UserName && p.Password == vm.Vm_Password);
        if (find == null)
        {
            return RedirectToAction("Login");
        }
        var claims = new List<Claim>()
        {
        new Claim (ClaimTypes.NameIdentifier, find.Id.ToString ()),
        new Claim (ClaimTypes.Name, find.FullName),
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties
        {
            IsPersistent = true
        };
        HttpContext.SignInAsync(principal, properties);
        return RedirectToAction("index", "Home", new { Area = "Admin" });
    }
    public IActionResult exit()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("index", "home");
    }

}
