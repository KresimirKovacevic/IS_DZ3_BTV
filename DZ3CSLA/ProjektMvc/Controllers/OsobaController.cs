using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpravljanjeProjektima;

namespace ProjektMvc.Controllers
{
  public class OsobaController : Controller
  {
    //
    // GET: /Osoba/
    public ActionResult Index()
    {
      return View(OsobaInfoList.Get());
    }

    // odabir osobe sa "Dodaj sudionik+a" u Projekt \ Details
    public ActionResult Select(string SifProjekta)
    {
      ViewData["SifProjekta"] = SifProjekta;
      Projekt projekt = Projekt.Get(SifProjekta);
      var sudioniciProjekta = projekt.SudioniciProjekta.Select(o => o.IdOsobe);
      OsobaInfoList sveOsobe = OsobaInfoList.Get();
      var preostaleOsobe = sveOsobe.Where(o => !sudioniciProjekta.Contains(o.IdOsobe));
      return View(preostaleOsobe);
    }

    public ActionResult Details(int IdOsobe)
    {
      return View(Osoba.Get(IdOsobe));
    }

    //
    // GET: /Osoba/Create
    public ActionResult Create()
    {
      return View(Osoba.New());
    }

    //
    // POST: /Osoba/Create
    [HttpPost]
    public ActionResult Create(string ImeOsobe, string PrezimeOsobe, string OIB)
    {
      Osoba osoba = Osoba.New();
      try
      {
        osoba.ImeOsobe = ImeOsobe;
        osoba.PrezimeOsobe = PrezimeOsobe;
        osoba.OIB = OIB;
        osoba = osoba.Save();
        return RedirectToAction("Details", new { id = osoba.IdOsobe });
      }
      catch (Csla.Validation.ValidationException ex)
      {
        ViewBag.Pogreska = ex.Message;
        if (osoba.BrokenRulesCollection.Count > 0)
        {
          List<string> errors = new List<string>();
          foreach (Csla.Validation.BrokenRule rule in osoba.BrokenRulesCollection)
          {
            errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
            ModelState.AddModelError(rule.Property, rule.Description);
          }
          ViewBag.ErrorsList = errors;
        }
        return View(osoba);
      }
      catch (Csla.DataPortalException ex)
      {
        ViewBag.Pogreska = ex.BusinessException.Message;
        return View(osoba);
      }
      catch (Exception ex)
      {
        ViewBag.Pogreska = ex.Message;
        return View(osoba);
      }

    }

    //
    // GET: /Osoba/Edit/5
    public ActionResult Edit(int id)
    {
      Osoba osoba = Osoba.Get(id);
      return View(osoba);
    }

    //
    // POST: /Osoba/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, string ImeOsobe, string PrezimeOsobe, string OIB)
    {
      Osoba osoba = null;
      try
      {
        osoba = Osoba.Get(id);
        osoba.ImeOsobe = ImeOsobe;
        osoba.PrezimeOsobe = PrezimeOsobe;
        osoba.OIB = OIB;
        osoba.Save();
        return RedirectToAction("Details", new { id = osoba.IdOsobe });
      }
      catch (Csla.Validation.ValidationException ex)
      {
        ViewBag.Pogreska = ex.Message;
        if (osoba.BrokenRulesCollection.Count > 0)
        {
          List<string> errors = new List<string>();
          foreach (Csla.Validation.BrokenRule rule in osoba.BrokenRulesCollection)
          {
            errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
            ModelState.AddModelError(rule.Property, rule.Description);
          }
          ViewBag.ErrorsList = errors;
        }
        return View(osoba);
      }
      catch (Csla.DataPortalException ex)
      {
        ViewBag.Pogreska = ex.BusinessException.Message;
        return View(osoba);
      }
      catch (Exception ex)
      {
        ViewBag.Pogreska = ex.Message;
        return View(osoba);
      }
    }

    [HttpPost]
    public ActionResult Delete(int IdOsobe)
    {
      try
      {
        Osoba.Delete(IdOsobe);
      }
      catch (Exception ex)
      {
        TempData["Pogreska"] = ex.Message;
      }
      return RedirectToAction("Index");
    }

    public ActionResult DodijeliProjekt(int IdOsobe, string SifProjekta)
    {
      try
      {
        Osoba osoba = Osoba.Get(IdOsobe);
        osoba.ProjektiOsobe.DodijeliProjekt(SifProjekta);
        osoba.Save();
      }
      catch (Exception ex)
      {
        TempData["Pogreska"] = ex.Message;
      }
      return RedirectToAction("Details", new { IdOsobe = IdOsobe });
    }

    [HttpPost]
    public ActionResult UkloniProjekt(int IdOsobe, string SifProjekta)
    {
      try
      {
        Osoba osoba = Osoba.Get(IdOsobe);
        osoba.ProjektiOsobe.UkloniProjekt(SifProjekta);
        osoba.Save();
      }
      catch (Exception ex)
      {
        TempData["Pogreska"] = ex.Message;
      }
      return RedirectToAction("Details", new { IdOsobe = IdOsobe });
    }

    [HttpPost]
    public string PromijeniUlogu(int IdOsobe, string SifProjekta, int IdUloge)
    {
      try
      {
        Osoba osoba = Osoba.Get(IdOsobe);
        ProjektOsobe projektOsobe = osoba.ProjektiOsobe.GetProjektOsobe(SifProjekta);
        projektOsobe.IdUloge = IdUloge;
        osoba.Save();
        return "OK";
      }
      catch (Exception ex)
      {
        return ex.Message;
      }

    }
  }
}
