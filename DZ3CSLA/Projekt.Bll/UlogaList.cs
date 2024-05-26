using System;
using System.Linq;
using Csla;
using Csla.Data;
using UpravljanjeProjektima.Properties;
using System.Collections.Generic; 

namespace UpravljanjeProjektima
{
  // Read-only popis uloga (cache).
  [Serializable()]
  public class UlogaList : NameValueListBase<int, string>
  {
    #region Constructors
    private UlogaList()
    {
    }
    #endregion

    #region  Business Methods
    public static int Default()
    {
      UlogaList list = Get();
      if (list.Count > 0)
      {
        return list.Items[0].Key;
      }
      else
      {
        throw new NullReferenceException(Resources.NoDataFound);
      }
    }
    #endregion

    #region  Factory Methods
    private static UlogaList list;

    public static UlogaList Get()
    {
      if (list == null)
      {
        list = DataPortal.Fetch<UlogaList>();
      }
      return list;
    }

    public static void InvalidateCache()
    {
      list = null;
    }
    #endregion

    #region Data Access
    #region DataPortal Methods
    private void DataPortal_Fetch()
    {
      this.RaiseListChangedEvents = false;
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      { 
        // uobièajeno bi bilo
        // var data = from u in ctx.DataContext.Uloga select new NameValuePair(u.IdUloge, u.NazUloge);
        // var data = ctx.DataContext.Uloga.Select(u => new NameValuePair(u.IdUloge, u.NazUloge));
        // var data = ctx.DataContext.Uloga.Select(u => new NameValuePair { Key = u.IdUloge, Value = u.NazUloge });

        // ali zbog {"Only parameterless constructors and initializers are supported in LINQ to Entities."}
        List<NameValuePair> data = new List<NameValuePair>();
        foreach (var u in ctx.DataContext.Uloga.AsNoTracking().ToList()) 
        {
          data.Add(new NameValuePair(u.IdUloge, u.NazUloge));
        }

        IsReadOnly = false;
        this.AddRange(data);
        IsReadOnly = true;
      }
      this.RaiseListChangedEvents = true;
    }
    #endregion
    #endregion
  }
}