using System;
using Csla;
using Csla.Core;
using Csla.Data;

namespace UpravljanjeProjektima.Admin
{
  // Odr�ava listu svih uloga u sustavu (�ifrarnik)
  [Serializable()]
  public class Uloge : BusinessListBase<Uloge, Uloga>
  {
    #region Constructors
    private Uloge()
    {
      // doga�aj pohrane
      this.Saved += new EventHandler<SavedEventArgs>(Uloge_Saved);
      // omogu�i dodavanje u �ifrarnik
      this.AllowNew = true;
    }
    #endregion

    #region  Business Methods
    // doddaj, ukloni, dobavi - memorija
    public void RemoveUloga(int idUloge)
    {
      foreach (Uloga item in this)
      {
        if (item.IdUloge == idUloge)
        {
          Remove(item);
          break;
        }
      }
    }

    public Uloga GetUloga(int idUloge)
    {
      foreach (Uloga item in this)
      {
        if (item.IdUloge == idUloge)
        {
          return item;
        }
      }
      return null;
    }
    #endregion

    #region Overrides
    // kad zatreba novi (zapo�ne dodavanje u grid)
    protected override object AddNewCore()
    {
      Uloga item = Uloga.New();
      this.Add(item);
      return item;
    }
    #endregion

    #region  Factory Methods
    public static Uloge Get()
    {
      return DataPortal.Fetch<Uloge>();
    }
    #endregion

    #region Deserialization
    protected override void OnDeserialized()
    {
      base.OnDeserialized();
      this.Saved += new EventHandler<SavedEventArgs>(Uloge_Saved);
    }
    #endregion

    #region Cache Invalidation
    // nakon spremanja �ifrarnika po�isti njegovu kopiju u memoriji (jer je nea�urna)
    private void Uloge_Saved(object sender, SavedEventArgs e)
    {
      UlogaList.InvalidateCache();
    }

    protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
    {
      if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server && e.Operation == DataPortalOperations.Update)
      {
        UlogaList.InvalidateCache();
      }
    }
    #endregion

    #region  Data Access
    #region DataPortal Methods
    private void DataPortal_Fetch()
    {
      this.RaiseListChangedEvents = false;
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        foreach (var u in ctx.DataContext.Uloga)
          this.Add(Uloga.Load(u)); // svaka se zasebno nato�i da bude BO
      }
      this.RaiseListChangedEvents = true;
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    protected override void DataPortal_Update()
    {
      this.RaiseListChangedEvents = false;
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Child_Update(); // Saves all items in the list, automatically performing insert, update or delete
      }
      this.RaiseListChangedEvents = true;
    }
    #endregion
    #endregion
  }
}