using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projectdotnet.Models;
using projectdotnet.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using projectdotnet.Models.Tools;
using projectdotnet.Models.Context;
using Microsoft.AspNetCore.Authorization;
using projectdotnet.Models.Context;
using projectdotnet.Models.Data;
namespace projectdotnet.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly Application db;

    private readonly IWebHostEnvironment en;

    public UserController(ILogger<UserController> logger, Application _db, IWebHostEnvironment _en)
    {
        _logger = logger;
        db = _db;
        en = _en;
    }
    public IActionResult Show()
    {
        ViewBag.user = db.tbl_Users.ToList();
        return View();
    }
    public IActionResult GoToAdd()
    {
        return View();
    }
    public IActionResult Add(Vm_User vm)
    {
        Tbl_User user = new Tbl_User();
        user.UserName = vm.Vm_UserName;
        user.FullName = vm.Vm_FullName;
        user.Password = vm.Vm_Password;
        db.tbl_Users.Add(user);
        db.SaveChanges();
        return RedirectToAction("Show");
    }
    public IActionResult Delete(int id)
    {
        var find = db.tbl_Users.SingleOrDefault(p => p.Id == id);

        db.tbl_Users.Remove(find);
        db.SaveChanges();
        return RedirectToAction("Show");
    }
    public IActionResult gotoedit(int id)
    {
        var find = db.tbl_Users.SingleOrDefault(p => p.Id == id);
        Vm_User vm = new Vm_User();
        vm.Vm_Id = find.Id;
        vm.Vm_FullName = find.FullName;
        vm.Vm_UserName = find.UserName;
        vm.Vm_Password= find.Password;
        return View(vm);
    }
    public IActionResult edit(Vm_User vm)
    {
        var find = db.tbl_Users.SingleOrDefault(p => p.Id == vm.Vm_Id);
        find.Password = vm.Vm_Password;
        find.FullName = vm.Vm_FullName;
        find.UserName = vm.Vm_UserName;
        db.tbl_Users.Update(find);
        db.SaveChanges();
        return RedirectToAction("Show");
    }


}