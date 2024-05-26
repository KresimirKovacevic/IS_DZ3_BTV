using System;
using System.Linq;
using Csla;
using Csla.Data;

namespace UpravljanjeProjektima
{
  // Dohvaæa read-only listu projekata (za odabir projekta).
  [Serializable()]
  public class ProjektInfoList : ReadOnlyListBase<ProjektInfoList, ProjektInfo>
  {
    #region Constructors
    private ProjektInfoList()
    {
    }
    #endregion

    #region  Factory Methods
    public static ProjektInfoList Get()
    {
      return DataPortal.Fetch<ProjektInfoList>();
    }

    public static ProjektInfoList Get(string name)
    {
      return DataPortal.Fetch<ProjektInfoList>(new SingleCriteria<ProjektInfoList, string>(name));
    }
    #endregion

    #region  Data Access
    #region DataPortal Methods
    private void DataPortal_Fetch()
    {
      Fetch(string.Empty);
    }

    private void DataPortal_Fetch(SingleCriteria<ProjektInfoList, string> criteria)
    {
      Fetch(criteria.Value);
    }
    #endregion

    #region Helper Methods
    private void Fetch(string nameFilter)
    {
      RaiseListChangedEvents = false;
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        var data = from p in ctx.DataContext.Projekt
                   select new ProjektInfo { SifProjekta = p.SifProjekta, NazProjekta = p.NazProjekta };
        if (!string.IsNullOrEmpty(nameFilter))
        {
          data = data.Where(p => p.NazProjekta.Contains(nameFilter));
        }
        IsReadOnly = false;
        this.AddRange(data);
        IsReadOnly = true;
      }
      RaiseListChangedEvents = true;
    }
    #endregion
    #endregion
  }
}