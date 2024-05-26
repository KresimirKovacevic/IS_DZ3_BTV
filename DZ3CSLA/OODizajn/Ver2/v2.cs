using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;

namespace OODDummy.Ver2
{
  public interface ISadrziUloge{}

  public class ProjektList : BusinessListBase<ProjektList, Projekt>
  {
  }

  public class Projekt : BusinessBase<Projekt>
  {
    public DateTime? DatPocetka { get; set; }
    public DateTime? DatZavrsetka { get; set; }
    public string NazProjekta { get; set; }
    public string OpisProjekta { get; set; }
    public string SifProjekta { get; set; }
    public SudionikProjektaList Sudionici { get; private set; } // da nema settera = readonly prop, ali auto (bez var)
  }

  public class SudionikProjekta : BusinessBase<SudionikProjekta>
  {
    public DateTime DatDodjeleUloge { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public int IdOsobe { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string ImeOsobe { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string PrezimeOsobe { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string PunoImeOsobe { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public int IdUloge { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
  }

  public class SudionikProjektaList : BusinessListBase<SudionikProjektaList, SudionikProjekta>
  {
    public void Dodijeli() { }
  }


  public class OsobaList : BusinessListBase<OsobaList, Osoba>
  {
  }
  
  public class Osoba : BusinessBase<Osoba>
  {
    public int IdOsobe { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string ImeOsobe { get; set; }
    public string PrezimeOsobe { get; set; }
    public string OIB { get; set; }
    public string PunoImeOsobe { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public ProjektOsobeList Projekti { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
  }

  public class ProjektOsobe : BusinessBase<ProjektOsobe>
  {
    public DateTime DatDodjeleUloge { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public int IdUloge { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string NazProjekta { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string SifProjekta { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
  }

  public class ProjektOsobeList : BusinessListBase<ProjektOsobeList, ProjektOsobe>
  {
    public void DodijeliProjekt() { }
  }


  public static class Zaduzenje
  {
    public static void DodajZaduzenje(string sifProjekta, int idOsobe, DateTime datDodjele, int idUloge) { }
    public static void PromijeniZaduzenje(string sifProjekta, int idOsobe, DateTime datDodjele, int idNoveUloge) { }
    public static void UkloniZaduzenje(string sifProjekta, int idOsobe) { }
    public static bool IsUlogaValid<T>(T target, Csla.Validation.RuleArgs e)
      where T : ISadrziUloge { return true; }

    public static DateTime GetDatumDodjele() { return DateTime.Today; }
  }


  public class Uloga : BusinessBase<Uloga>
  {
    public int IdUloge { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string NazUloge { get; set; }
  }

  public class UlogaList : NameValueListBase<int, string>
  {
  }


  public class UlogaEdit : BusinessBase<UlogaEdit>
  {
    public int IdUloge { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string NazUloge { get; set; }
  }

  public class UlogaEditList : BusinessListBase<UlogaEditList, UlogaEdit>
  {
  }
}
