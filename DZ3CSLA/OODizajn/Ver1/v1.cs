using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;

namespace OODDummy.Ver1
{
  public class Projekt : BusinessBase<Projekt>
  {
    public DateTime? DatPocetka { get; set; }
    public DateTime? DatZavrsetka { get; set; }
    public string NazProjekta { get; set; }
    public string OpisProjekta { get; set; }
    public string SifProjekta { get; set; }
    public SudionikProjektaList Sudionici { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
  }

  public class ProjektList : BusinessListBase<ProjektList, Projekt>
  {
  }

  public class SudionikProjektaList : BusinessListBase<SudionikProjektaList, Osoba>
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

  public class OsobaList : BusinessListBase<OsobaList, Osoba>
  {
  }

  public class ProjektOsobeList : BusinessListBase<ProjektOsobeList, Projekt>
  {
  }


  public class Zaposlenik : BusinessBase<Zaposlenik>
  {
    public int IdOsobe { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string ImeOsobe { get; set; }
    public string PrezimeOsobe { get; set; }
    public string OIB { get; set; }
    public string PunoImeOsobe { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
  }


  public class Uloga : BusinessBase<Uloga>
  {
    public int IdUloge { get; private set;} // da nema settera = readonly prop, ali auto (bez var)
    public string NazUloge { get; set; }
  }

  public class UlogaList : BusinessListBase<UlogaList, Uloga>
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
