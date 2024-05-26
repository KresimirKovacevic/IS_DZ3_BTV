using System;
using System.Linq;
using Csla;
using Csla.Data;
using System.Collections.Generic;

namespace UpravljanjeProjektima
{
  // Dohvaca read-only listu osoba (za odabir osobe).
  [Serializable()]
  public class OsobaInfoList : ReadOnlyListBase<OsobaInfoList, OsobaInfo>
  {
    #region Constructors
    private OsobaInfoList()
    {
    }
    #endregion

    #region  Factory Methods
    public static OsobaInfoList Get()
    {
      return DataPortal.Fetch<OsobaInfoList>();
    }
    #endregion

    #region  Data Access
    #region DataPortal Methods
    private void DataPortal_Fetch()
    {
      RaiseListChangedEvents = false;
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        //var data = from o in ctx.DataContext.Osoba
        //           select new OsobaInfo(o.IdOsobe, o.PrezimeOsobe, o.ImeOsobe);
        // gornje ne ide zbog {"Only parameterless constructors and initializers are supported in LINQ to Entities."}
        // osim toga, "the property or indexer cannot be used..."
        // jer OsobaInfo ima 2 parametra u konstruktoru (Id, Ime, Prez) a dva svojstva (Id, Naz)

        List<OsobaInfo> data = new List<OsobaInfo>();
        foreach (var o in ctx.DataContext.Osoba.AsNoTracking().ToList()) 
        {
          data.Add(new OsobaInfo(o.IdOsobe, o.PrezimeOsobe, o.ImeOsobe));
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