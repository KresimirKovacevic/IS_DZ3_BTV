using System;
using System.Linq;
using Csla;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
  // Lista projekata na kojima sudjeluje osoba.
  [Serializable()]
  public class ProjektOsobeList : BusinessListBase<ProjektOsobeList, ProjektOsobe>
  {
    #region Constructors
    private ProjektOsobeList()
    {
    }
    #endregion

    #region  Business Methods
    public ProjektOsobe GetProjektOsobe(string sifProjekta)
    {
      if (ContainsProjekt(sifProjekta))
      {
        return this.Where(x => x.SifProjekta == sifProjekta).Select(x => x).Single();
      }
      else
      {
        return null;
      }
    }

    public void DodijeliProjekt(string sifProjekta)
    {
      if (!ContainsProjekt(sifProjekta))
      {
        ProjektOsobe projekt = ProjektOsobe.New(sifProjekta);
        this.Add(projekt);
      }
      else
      {
        throw new InvalidOperationException(Resources.OsobaVecRadiNaProjektu);
      }
    }

    public void UkloniProjekt(string sifProjekta)
    {
      if (ContainsProjekt(sifProjekta))
      {
        Remove(this.Where(x => x.SifProjekta == sifProjekta).Select(x => x).Single());
      }
    }

    public bool ContainsProjekt(string sifProjekta)
    {
      return this.Where(x => x.SifProjekta == sifProjekta).Count() > 0;
    }

    internal bool ContainsDeleted(string sifProjekta)
    {
      return DeletedList.Where(x => x.SifProjekta == sifProjekta).Count() > 0;
    }
    #endregion

    #region  Factory Methods
    internal static ProjektOsobeList New()
    {
      return DataPortal.CreateChild<ProjektOsobeList>();
    }

    internal static ProjektOsobeList Load(Dal.UlogaOsobe[] data)
    {
      return DataPortal.FetchChild<ProjektOsobeList>(data);
    }
    #endregion

    #region Data Access
    private void Child_Fetch(Dal.UlogaOsobe[] data)
    {
      this.RaiseListChangedEvents = false;
      foreach (var child in data)
        Add(ProjektOsobe.Load(child));
      this.RaiseListChangedEvents = true;
    }
    #endregion
  }
}