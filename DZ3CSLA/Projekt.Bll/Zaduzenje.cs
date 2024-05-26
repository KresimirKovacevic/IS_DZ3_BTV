using System;
using System.Linq;
using Csla.Data;
using Csla.Validation;
using UpravljanjeProjektima.Properties;
//using System.Data.Entity;

namespace UpravljanjeProjektima
{
  internal static class Zaduzenje
  {
    #region  Business Methods
    public static DateTime GetDatumDodjele()
    {
      return DateTime.Today;
    }
    #endregion

    #region  Validation Rules
    public static bool IsUlogaValid<T>(T target, RuleArgs e)
      where T : ISadrziUloge
    {
      int role = target.IdUloge;

      if (UlogaList.Get().ContainsKey(role))
      {
        return true;
      }
      else
      {
        e.Description = Resources.UlogaNijeIspravna;
        return false;
      }
    }
    #endregion

    #region  Data Access
    public static void DodajZaduzenje(string sifProjekta, int idOsobe, DateTime datDodjele, int idUloge)
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Dal.UlogaOsobe u = new Dal.UlogaOsobe
        {
          SifProjekta = sifProjekta,
          IdUloge = idUloge,
          IdOsobe = idOsobe,
          DatDodjele = datDodjele
        };

        ctx.DataContext.UlogaOsobe.Add(u);
        ctx.DataContext.SaveChanges();
      }
    }

    public static void PromijeniZaduzenje(string sifProjekta, int idOsobe, DateTime datDodjele, int idNoveUloge)
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Dal.UlogaOsobe u = ctx.DataContext.UlogaOsobe.Where(x => x.SifProjekta == sifProjekta && x.IdOsobe == idOsobe).Single();
        
        u.IdUloge = idNoveUloge;
        u.DatDodjele = datDodjele;

        ctx.DataContext.SaveChanges();
      }
    }

    public static void UkloniZaduzenje(string sifProjekta, int idOsobe)
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        // Dal.UlogaOsobe u = ctx.DataContext.UlogaOsobe.Where(x => x.SifProjekta == sifProjekta && x.IdOsobe == idOsobe).Single();
        var u = ctx.DataContext.UlogaOsobe.Find(sifProjekta, idOsobe);
        if (u != null)
        {
          ctx.DataContext.UlogaOsobe.Remove(u);
          ctx.DataContext.SaveChanges();
        }
      }
    }
    #endregion
  }
}