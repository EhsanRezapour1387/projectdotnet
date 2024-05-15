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
public class OfferController : Controller
{
    private readonly ILogger<OfferController> _logger;
    private readonly Application db;

    private readonly IWebHostEnvironment en;

    public OfferController(ILogger<OfferController> logger, Application _db, IWebHostEnvironment _en)
    {
        _logger = logger;
        db = _db;
        en = _en;
    }
    public IActionResult Show()
    {
        ViewBag.Offer = db.tbl_Offers.ToList();
        return View();
    }
    public IActionResult GoToAdd()
    {
        return View();
    }
    public IActionResult Add(Vm_Offer vm)
    {
        Tbl_Offer offer = new Tbl_Offer();
        offer.Title = vm.Vm_Title;
        offer.Detail = vm.Vm_Detail;
        offer.Link = vm.Vm_Link;
        if (vm.Vm_Img != null)
        {
            Upload pl = new Upload(en);
            offer.Image  = pl.Upload_Webp_Thumb(vm.Vm_Img, "admin/offer", 350).Result;
        }
        db.tbl_Offers.Add(offer);
        db.SaveChanges();
        return RedirectToAction("Show");
    }
    public IActionResult Delete(int id)
    {
        var find = db.tbl_Offers.SingleOrDefault(p => p.Id == id);
        Delete de = new Delete(en);
        de.Delete_Image(find.Image);
        db.tbl_Offers.Remove(find);
        db.SaveChanges();
        return RedirectToAction("Show");
    }
    public IActionResult gotoedit(int id)
    {
        var find = db.tbl_Offers.SingleOrDefault(p => p.Id == id);
        Vm_Offer vm = new Vm_Offer();
        vm.Vm_Id = find.Id;
        vm.Vm_Image = find.Image;
        vm.Vm_Link = find.Link;
        vm.Vm_Title = find.Title;
        vm.Vm_Detail = find.Detail;
        return View(vm);
    }
    public IActionResult edit(Vm_Offer vm)
    {
        var find = db.tbl_Offers.SingleOrDefault(p => p.Id == vm.Vm_Id);
        find.Title = vm.Vm_Title;
        find.Detail = vm.Vm_Detail;
        find.Link = vm.Vm_Link;
        if (vm.Vm_Img != null)
        {
            Delete de = new Delete(en);
            de.Delete_Image(find.Image);
            Upload pl = new Upload(en);
            find.Image = pl.Upload_Webp_Thumb(vm.Vm_Img, "admin/offer", 350).Result;
        }
        db.tbl_Offers.Update(find);
        db.SaveChanges();
        return RedirectToAction("Show");
    }


}