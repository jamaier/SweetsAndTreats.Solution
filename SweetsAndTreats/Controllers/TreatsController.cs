using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SweetsAndTreats.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace SweetsAndTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly SweetsAndTreatsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(UserManager<ApplicationUser> userManager, SweetsAndTreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      return View(_db.Treats.ToList());
    }

    [Authorize]
    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View();
    }

    [Authorize]
    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisTreat);
    }

    [Authorize]
    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      ViewBag.Flavors = _db.Flavors.ToList();
      Treat thisTreat = _db.Treats
                            .Include(treat => treat.JoinEntities)
                            .ThenInclude(join => join.Flavor)
                            .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [Authorize]
    public ActionResult AddFlavor(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(thisTreat);
    }

    [Authorize]
    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
#nullable enable
      TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.FlavorId == FlavorId && join.TreatId == treat.TreatId));
#nullable disable
      if (joinEntity == null && FlavorId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    [Authorize]
    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [Authorize]
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      TreatFlavor joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
      _db.TreatFlavors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.TreatId });
    }
  }
}