using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpravljanjeProjektima;

namespace ProjektMvc.Controllers
{
  public class ProjektController : Controller
  {
    // default popis projekata
    // GET: /Projekt/
    public ActionResult Index()
    {
      return View(ProjektInfoList.Get());
    }

    // odabir projekta sa "Dodaj na projekt" u Osoba \ Details
    // GET: /Projekt/Select
    public ActionResult Select(int IdOsobe)
    {
      ViewData["IdOsobe"] = IdOsobe;
      Osoba osoba = Osoba.Get(IdOsobe);
      var projektiOsobe = osoba.ProjektiOsobe.Select(p => p.SifProjekta);
      ProjektInfoList sviProjekti = ProjektInfoList.Get();
      var preostaliProjekti = sviProjekti.Where(p => !projektiOsobe.Contains(p.SifProjekta));
      return View(preostaliProjekti);
    }

    // prikaži detalje (master-detail)
    public ActionResult Details(string SifProjekta)
    {
      return View(Projekt.Get(SifProjekta));
    }


    // započni unos novog
    public ActionResult Create()
    {
      return View(Projekt.New());
    }


    // pospremi novog
    [HttpPost]
    public ActionResult Create(string SifProjekta, string NazProjekta, DateTime? DatPocetka, DateTime? DatZavrsetka, string OpisProjekta)
    {
      Projekt projekt = Projekt.New();
      try
      {
        projekt.SifProjekta = SifProjekta;
        projekt.NazProjekta = NazProjekta;
        projekt.DatPocetka = DatPocetka;
        projekt.DatZavrsetka = DatZavrsetka;
        projekt.OpisProjekta = OpisProjekta;
        projekt.Save();
        return RedirectToAction("Details", new { SifProjekta = SifProjekta });
      }
      catch (Csla.Validation.ValidationException ex)
      {
        ViewBag.Pogreska = ex.Message;
        if (projekt.BrokenRulesCollection.Count > 0)
        {
          List<string> errors = new List<string>();
          foreach (Csla.Validation.BrokenRule rule in projekt.BrokenRulesCollection)
          {
            errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
            //označi polje stilom input-validation-error (site.css)
            ModelState.AddModelError(rule.Property, rule.Description);
          }
          ViewBag.ErrorsList = errors;
        }
        return View(projekt);
      }
      catch (Csla.DataPortalException ex)
      {
        ViewBag.Pogreska = ex.BusinessException.Message;
        return View(projekt);
      }
      catch (Exception ex)
      {
        ViewBag.Pogreska = ex.Message;
        return View(projekt);
      }

    }

    // "Ažuriraj" - prikaži obrazac za uređivanje
    public ActionResult Edit(string SifProjekta)
    {
      Projekt projekt = Projekt.Get(SifProjekta);
      return View(projekt);
    }


    // "Spremi" - postback uređivanja
    [HttpPost]
    public ActionResult Edit(string SifProjekta, string NazProjekta, DateTime? DatPocetka, DateTime? DatZavrsetka, string OpisProjekta)
    {
      Projekt projekt = null;
      try
      {
        projekt = Projekt.Get(SifProjekta); // dozovi iz BL
        projekt.NazProjekta = NazProjekta; // izmijeni
        projekt.DatPocetka = DatPocetka;
        projekt.DatZavrsetka = DatZavrsetka;
        projekt.OpisProjekta = OpisProjekta;
        projekt.Save(); // spremi (uz validaciju u BL)
        return RedirectToAction("Details", new { SifProjekta = SifProjekta });
      }
      catch (Csla.Validation.ValidationException ex)
      {
        ViewBag.Pogreska = ex.Message;
        if (projekt.BrokenRulesCollection.Count > 0)
        {
          List<string> errors = new List<string>();
          foreach (Csla.Validation.BrokenRule rule in projekt.BrokenRulesCollection)
          {
            errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
            // oboji textbox vezan za svojstvo nad koji se dogodila iznimka
            ModelState.AddModelError(rule.Property, rule.Description);
          }
          ViewBag.ErrorsList = errors;
        }
        return View(projekt);
      }
      catch (Csla.DataPortalException ex)
      {
        ViewBag.Pogreska = ex.BusinessException.Message;
        return View(projekt);
      }
      catch (Exception ex)
      {
        ViewBag.Pogreska = ex.Message;
        return View(projekt);
      }
    }

    // "Obriši" projekt (master)
    [HttpPost]
    public ActionResult Delete(string SifProjekta)
    {
      try
      {
        Projekt.Delete(SifProjekta);
      }
      catch (Exception ex)
      {
        TempData["Pogreska"] = ex.Message;
      }
      return RedirectToAction("Index");
    }


    // Select: @Html.ActionLink("Dodaj na ovaj projekt", "DodijeliProjekt", "Osoba", ...
    public ActionResult DodijeliOsobu(int IdOsobe, string SifProjekta)
    {
      try
      {
        Projekt projekt = Projekt.Get(SifProjekta);
        projekt.SudioniciProjekta.DodijeliOsobu(IdOsobe);
        projekt.Save();
      }
      catch (Exception ex)
      {
        TempData["Pogreska"] = ex.Message;
      }
      return RedirectToAction("Details", new { SifProjekta = SifProjekta });
    }

    // "Obriši" na sudioniku u Projekt \ Details
    [HttpPost]
    public ActionResult UkloniOsobu(int IdOsobe, string SifProjekta)
    {
      try
      {
        Projekt projekt = Projekt.Get(SifProjekta);
        projekt.SudioniciProjekta.UkloniOsobu(IdOsobe);
        projekt.Save();
      }
      catch (Exception ex)
      {
        TempData["Pogreska"] = ex.Message;
      }
      return RedirectToAction("Details", new { SifProjekta = SifProjekta });
    }

    // ajax postback po odabiru uloge u padajućoj listi (ddlist) Views \ Projekt \ Osobe
    [HttpPost]
    public string PromijeniUlogu(int IdOsobe, string SifProjekta, int IdUloge)
    {
      try
      {
        Projekt projekt = Projekt.Get(SifProjekta);
        SudionikProjekta projektOsobe = projekt.SudioniciProjekta.GetSudionikProjekta(IdOsobe);
        projektOsobe.IdUloge = IdUloge;
        projekt.Save();
        return "OK";
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

  }
}
