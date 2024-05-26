using System;
using System.Linq;
using System.Reflection;
using Csla;
using Csla.Data;
using Csla.Validation;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima.Admin
{
  // Dodaje i mijenja ulogu.
  [Serializable()]
  public class Uloga : BusinessBase<Uloga>
  {
    #region Constructors
    private Uloga()
    {
    }
    #endregion

    #region  Properties
    private bool idSet;
    private static PropertyInfo<int> IdUlogeProperty = 
      RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Uloga>(x => x.IdUloge)));
    public int IdUloge
    {
      get
      {
        if (!idSet)
        {
          idSet = true;
          SetProperty(IdUlogeProperty, GetMax() + 1);
        }
        return GetProperty(IdUlogeProperty);
      }
      set
      {
        idSet = true;
        SetProperty(IdUlogeProperty, value);
      }
    }

    private static PropertyInfo<string> NazUlogeProperty = 
      RegisterProperty(typeof(Uloga), new PropertyInfo<string>(Reflector.GetPropertyName<Uloga>(x => x.NazUloge)));
    public string NazUloge
    {
      get { return GetProperty(NazUlogeProperty); }
      set { SetProperty(NazUlogeProperty, value); }
    }
    #endregion

    #region Business Methods
    private int GetMax()
    {
      Uloge parent = (Uloge)this.Parent;
      int max = parent.Max(x => x.IdUloge);
      if (max > 0)
      {
        return max;
      }
      else
      {
        return 0;
      }
    }
    #endregion

    #region  Validation Rules
    protected override void AddBusinessRules()
    {
      ValidationRules.AddRule<Uloga>(NoDuplicates, IdUlogeProperty);

      ValidationRules.AddRule(CommonRules.StringRequired, NazUlogeProperty);
      ValidationRules.AddRule<Uloga>(NoDuplicatesNazUloge, NazUlogeProperty);
    }

    private static bool NoDuplicates<T>(T target, RuleArgs e) where T : Uloga
    {
      Uloge parent = (Uloge)target.Parent;
      if (parent != null)
      {
        foreach (Uloga item in parent)
        {
          if (item.IdUloge == target.ReadProperty(IdUlogeProperty) && !(ReferenceEquals(item, target)))
          {
            e.Description = Resources.NoDuplicates;
            return false;
          }
        }
      }
      return true;
    }

    private static bool NoDuplicatesNazUloge<T>(T target, RuleArgs e) where T : Uloga
    {
      if (string.IsNullOrEmpty(target.NazUloge))
        return true;

      e.Description = Resources.NoDuplicates;

      Uloge parent = (Uloge)target.Parent;
      if (parent != null)
      {
        foreach (Uloga item in parent)
        {
          if (item.NazUloge == target.ReadProperty(NazUlogeProperty) && !(ReferenceEquals(item, target)))
          {
            return false;
          }
        }
      }

      return string.IsNullOrEmpty(target.NazUloge) || !Uloga.Exists(target.NazUloge);
    }
    #endregion

    #region  Factory Methods

    // rukovanje elementom šifrarnika (iz šifrarnika Uloge)

    internal static Uloga New()
    {
      return DataPortal.CreateChild<Uloga>();
    }

    internal static Uloga Load(Dal.Uloga data)
    {
      return DataPortal.FetchChild<Uloga>(data);
    }
    #endregion

    #region  Data Access
    private void Child_Fetch(Dal.Uloga data)
    {
      LoadProperty(IdUlogeProperty, data.IdUloge);
      LoadProperty(NazUlogeProperty, data.NazUloge);
      idSet = true;
    }

    private void Child_Insert()
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Dal.Uloga u = new Dal.Uloga
        {
          IdUloge = IdUloge,
          NazUloge = NazUloge
        };

        ctx.DataContext.Uloga.Add(u);
        ctx.DataContext.SaveChanges();
      }
    }

    private void Child_Update()
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Dal.Uloga u = ctx.DataContext.Uloga.Find(this.IdUloge);

        u.NazUloge = NazUloge;
        
        ctx.DataContext.SaveChanges();
      }
    }

    private void Child_DeleteSelf()
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        var u = ctx.DataContext.Uloga.Find(this.IdUloge); 
        if (u != null)
        {
          ctx.DataContext.Uloga.Remove(u);
          ctx.DataContext.SaveChanges();
        }
      }
    }
    #endregion

    #region  Exists
    public static bool Exists(string nazUloge)
    {
      return ExistsCommand.Exists(nazUloge);
    }

    #region ExisitsCommand
    [Serializable()]
    private class ExistsCommand : CommandBase
    {
      #region Execute
      public static bool Exists(string nazUloge)
      {
        return DataPortal.Execute<ExistsCommand>(new ExistsCommand(nazUloge)).UlogaExists;
      }
      #endregion

      #region Constructors
      private ExistsCommand(string nazUloge)
      {
        this.NazUloge = nazUloge;
      }
      #endregion

      #region Properties
      public string NazUloge { get; private set; }
      public bool UlogaExists { get; private set; }
      #endregion

      #region Data Access
      #region DataPortal MEthods
      protected override void DataPortal_Execute()
      {
        using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
        {
          //// stvar stila
          //UlogaExists = ((from u in ctx.DataContext.Uloga
          //                where u.NazUloge == NazUloge
          //                select u).Count() > 0);
          UlogaExists = ctx.DataContext.Uloga.
            Where(u => u.NazUloge == NazUloge).Count() > 0;
        }
      }
      #endregion
      #endregion
    }
    #endregion
    #endregion
  }
}