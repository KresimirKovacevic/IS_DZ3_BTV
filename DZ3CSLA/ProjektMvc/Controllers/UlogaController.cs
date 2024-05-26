using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpravljanjeProjektima.Admin;

namespace ProjektMvc.Controllers
{
  public class UlogaController : Controller
  {

    // popis uloga					
    // GET: /Uloga/
    public ActionResult Index()
    {
      return View(Uloge.Get());
    }

    // unos novog
    // GET: /Uloga/Create
    public ActionResult Create()
    {
      Uloga uloga = Uloge.Get().AddNew();
      return View(uloga);
    }

    // spremanje novog
    // POST: /Uloga/Create
    [HttpPost]
    public ActionResult Create(int IdUloge, string NazUloge)
    {
      Uloga uloga = null;
      try
      {
        Uloge uloge = Uloge.Get();
        uloga = uloge.AddNew();
        uloga.IdUloge = IdUloge;
        uloga.NazUloge = NazUloge;
        uloge.Save();
        return RedirectToAction("Index");
      }
      catch (Csla.Validation.ValidationException ex)
      {
        ViewBag.Pogreska = ex.Message;
        if (uloga.BrokenRulesCollection.Count > 0)
        {
          List<string> errors = new List<string>();
          foreach (Csla.Validation.BrokenRule rule in uloga.BrokenRulesCollection)
          {
            errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
            ModelState.AddModelError(rule.Property, rule.Description);
          }
          ViewBag.ErrorsList = errors;
        }
        return View(uloga);
      }
      catch (Csla.DataPortalException ex)
      {
        ViewBag.Pogreska = ex.BusinessException.Message;
        return View(uloga);
      }
      catch (Exception ex)
      {
        ViewBag.Pogreska = ex.Message;
        return View();
      }

    }

    // uređivanje postojećeg
    // GET: /Uloga/Edit/5
    public ActionResult Edit(int id)
    {
      Uloga uloga = Uloge.Get().GetUloga(id);
      return View(uloga);
    }

    // spremanje ažuriranog
    // POST: /Uloga/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, string NazUloge)
    {
      Uloga uloga = null;
      try
      {
        Uloge uloge = Uloge.Get();
        uloga = uloge.GetUloga(id);
        uloga.NazUloge = NazUloge;
        uloge.Save();
        return RedirectToAction("Index");
      }
      catch (Csla.Validation.ValidationException ex)
      {
        ViewBag.Pogreska = ex.Message;
        if (uloga.BrokenRulesCollection.Count > 0)
        {
          List<string> errors = new List<string>();
          foreach (Csla.Validation.BrokenRule rule in uloga.BrokenRulesCollection)
          {
            errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
            ModelState.AddModelError(rule.Property, rule.Description);
          }
          ViewBag.ErrorsList = errors;
        }
        return View(uloga);
      }
      catch (Csla.DataPortalException ex)
      {
        ViewBag.Pogreska = ex.BusinessException.Message;
        return View(uloga);
      }
      catch (Exception ex)
      {
        ViewBag.Pogreska = ex.Message;
        return View();
      }
    }

    // brisanje s "Obriši" u popisu
    [HttpPost]
    public ActionResult Delete(int id)
    {
      try
      {
        Uloge uloge = Uloge.Get();
        uloge.RemoveUloga(id);
        uloge.Save();
      }
      catch (Exception ex)
      {
        TempData["Pogreska"] = ex.Message;
      }
      return RedirectToAction("Index");
    }
  }
}
