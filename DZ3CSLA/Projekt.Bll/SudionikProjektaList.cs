using System;
using System.Linq;
using Csla;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
  // Lista osoba dodijeljenih projektu.
  [Serializable()]
  public class SudionikProjektaList : BusinessListBase<SudionikProjektaList, SudionikProjekta>
  {
    #region Constructors
    private SudionikProjektaList()
    {
    }
    #endregion

    #region  Business Methods
  public SudionikProjekta GetSudionikProjekta(int idOsobe)
  {
    if (ContainsOsoba(idOsobe))
    {
      return this.Where(x => x.IdOsobe == idOsobe).Select(x => x).Single();
    }
    else
    {
      return null;
    }
  }

  public void DodijeliOsobu(int idOsobe)
  {
    if (!ContainsOsoba(idOsobe))
    {
      SudionikProjekta osoba = SudionikProjekta.New(idOsobe);
      this.Add(osoba);
    }
    else
    {
      throw new InvalidOperationException(Resources.OsobaVecRadiNaProjektu);
    }
  }

  public void UkloniOsobu(int idOsobe)
  {
    if (ContainsOsoba(idOsobe))
    {
      Remove(this.Where(x => x.IdOsobe == idOsobe).Select(x => x).Single());
    }
  }

  public bool ContainsOsoba(int idOsobe)
  {
    return this.Where(x => x.IdOsobe == idOsobe).Count() > 0;
  }

  internal bool ContainsDeleted(int idOsobe)
  {
    return DeletedList.Where(x => x.IdOsobe == idOsobe).Count() > 0;
  }
    #endregion

    #region  Factory Methods
    // stvaranje nove liste
    internal static SudionikProjektaList New()
    {
      return DataPortal.CreateChild<SudionikProjektaList>();
    }

    // punjenje postojeæim
    internal static SudionikProjektaList Load(Dal.UlogaOsobe[] data)
    {
      return DataPortal.FetchChild<SudionikProjektaList>(data);
    }
    #endregion

    #region  Data Access
    // dohvati detail iz Projekt.UlogaOsobe (vidi EF model)
    private void Child_Fetch(Dal.UlogaOsobe[] data)
    {
      this.RaiseListChangedEvents = false;
      foreach (var value in data)
        this.Add(SudionikProjekta.Load(value));
      this.RaiseListChangedEvents = true;
    }
    #endregion
  }
}