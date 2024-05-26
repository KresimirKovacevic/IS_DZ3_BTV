using System;
using System.Linq;
using System.Reflection;
using Csla;
using Csla.Data;
using Csla.Validation;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
  // Dodaje i mijenja osobu.
  [Serializable()]
  public class Osoba : BusinessBase<Osoba>
  {
    #region Constructors
    private Osoba()
    {
    }
    #endregion

    #region  Properties
    private static PropertyInfo<int> IdOsobeProperty = 
      RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Osoba>(x => x.IdOsobe)));
    public int IdOsobe
    {
      get { return GetProperty(IdOsobeProperty); }
    }

    private static PropertyInfo<string> PrezimeOsobeProperty = 
      RegisterProperty(typeof(Osoba), new PropertyInfo<string>(Reflector.GetPropertyName<Osoba>(x => x.PrezimeOsobe)));
    public string PrezimeOsobe
    {
      get { return GetProperty(PrezimeOsobeProperty); }
      set { SetProperty(PrezimeOsobeProperty, value); }
    }

    private static PropertyInfo<string> ImeOsobeProperty = 
      RegisterProperty(new PropertyInfo<string>(Reflector.GetPropertyName<Osoba>(x => x.ImeOsobe)));
    public string ImeOsobe
    {
      get { return GetProperty(ImeOsobeProperty); }
      set { SetProperty(ImeOsobeProperty, value); }
    }

    private static PropertyInfo<string> OIBProperty = 
      RegisterProperty(new PropertyInfo<string>(Reflector.GetPropertyName<Osoba>(x => x.OIB)));
    public string OIB
    {
      get { return GetProperty(OIBProperty); }
      set { SetProperty(OIBProperty, value); }
    }

    private static PropertyInfo<ProjektOsobeList> ProjektiOsobeProperty =
      RegisterProperty(typeof(Osoba), new PropertyInfo<ProjektOsobeList>(Reflector.GetPropertyName<Osoba>(x => x.ProjektiOsobe)));
    public ProjektOsobeList ProjektiOsobe
    {
      get
      {
        if (!(FieldManager.FieldExists(ProjektiOsobeProperty)))
        {
          LoadProperty(ProjektiOsobeProperty, ProjektOsobeList.New());
        }
        return GetProperty(ProjektiOsobeProperty);
      }
    }
    #endregion

    #region Calculated Properties
    public string PunoImeOsobe
    {
      get { return PrezimeOsobe + ", " + ImeOsobe; }
    }
    #endregion

    #region  Validation Rules
    protected override void AddBusinessRules()
    {
      ValidationRules.AddRule(CommonRules.StringRequired, ImeOsobeProperty);
      ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(ImeOsobeProperty, 25));

      ValidationRules.AddRule(CommonRules.StringRequired, PrezimeOsobeProperty);
      ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(PrezimeOsobeProperty, 25));

      ValidationRules.AddRule(CommonRules.StringRequired, OIBProperty);
      ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(OIBProperty, 11));
      ValidationRules.AddRule<Osoba>(IsOIBValid, OIBProperty);
      ValidationRules.AddRule<Osoba>(IsOIBUnique, OIBProperty);
    }

    private static bool IsOIBValid<T>(T target, RuleArgs e) where T : Osoba
    {
      if (string.IsNullOrEmpty(target.OIB))
        return true;

      try
      {
        Convert.ToInt64(target.OIB);
      }
      catch (FormatException)
      {
        e.Description = Resources.NeispravanUnos;
        return false;
      }

      return true;
    }

    private static bool IsOIBUnique<T>(T target, RuleArgs e) where T : Osoba
    {
      if (string.IsNullOrEmpty(target.OIB))
        return true;

      e.Description = Resources.NoDuplicates;

      return !Osoba.Exists(target.OIB);
    }
    #endregion

    #region Factory Methods
    public static Osoba New()
    {
      return DataPortal.Create<Osoba>();
    }

    public static void Delete(int idOsobe)
    {
      DataPortal.Delete<Osoba>(new SingleCriteria<Osoba, int>(idOsobe));
    }

    public static Osoba Get(int idOsobe)
    {
      return DataPortal.Fetch<Osoba>(new SingleCriteria<Osoba, int>(idOsobe));
    }
    #endregion

    #region Data Access
    #region DataPortal Methods
    private void DataPortal_Fetch(SingleCriteria<Osoba, int> criteria)
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        // var data = (from o in ctx.DataContext.Osoba where o.IdOsobe == criteria.Value select o).Single();
        var data = ctx.DataContext.Osoba.Find(criteria.Value);

        LoadProperty(IdOsobeProperty, data.IdOsobe);
        LoadProperty(ImeOsobeProperty, data.ImeOsobe);
        LoadProperty(PrezimeOsobeProperty, data.PrezimeOsobe);
        LoadProperty(OIBProperty, data.OIB);

        LoadProperty(ProjektiOsobeProperty, ProjektOsobeList.Load(data.UlogaOsobe.ToArray()));
      }
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    protected override void DataPortal_Insert()
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Dal.Osoba o = new Dal.Osoba
        {
          ImeOsobe = ImeOsobe,
          PrezimeOsobe = PrezimeOsobe,
          OIB = OIB
        };

        ctx.DataContext.Osoba.Add(o);
        ctx.DataContext.SaveChanges();

        LoadProperty(IdOsobeProperty, o.IdOsobe);

        FieldManager.UpdateChildren(this);
      }
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    protected override void DataPortal_Update()
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Dal.Osoba o = ctx.DataContext.Osoba.Find(this.IdOsobe);
        
        o.ImeOsobe = ImeOsobe;
        o.PrezimeOsobe = PrezimeOsobe;
        o.OIB = OIB;
        
        FieldManager.UpdateChildren(this);
        
        ctx.DataContext.SaveChanges();
      }
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    protected override void DataPortal_DeleteSelf()
    {
      DataPortal_Delete(new SingleCriteria<Osoba, int>(IdOsobe));
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    private void DataPortal_Delete(SingleCriteria<Osoba, int> criteria)
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        var o = ctx.DataContext.Osoba.Find(criteria.Value);
        if (o != null)
        {
          ctx.DataContext.Osoba.Remove(o);
          ctx.DataContext.SaveChanges();
        }
      }
    }
    #endregion
    #endregion

    #region  Exists
    public static bool Exists(int idOsobe)
    {
      return ExistsCommand.Exists(idOsobe);
    }

    public static bool Exists(string oib)
    {
      return ExistsCommand.Exists(oib);
    }

    #region Exists Command
    [Serializable()]
    private class ExistsCommand : CommandBase
    {
      #region Execute
      public static bool Exists(int id)
      {
        return DataPortal.Execute<ExistsCommand>(new ExistsCommand(id)).OsobaExists;
      }

      public static bool Exists(string oib)
      {
        return DataPortal.Execute<ExistsCommand>(new ExistsCommand(oib)).OsobaExists;
      }
      #endregion

      #region Constructors
      private ExistsCommand(int idOsobe)
      {
        this.IdOsobe = idOsobe;
      }

      private ExistsCommand(string oib)
      {
        this.OIB = oib;
      }
      #endregion

      #region Properties
      public int IdOsobe { get; private set; }
      public string OIB { get; private set; }
      public bool OsobaExists { get; private set; }
      #endregion

      #region Data Access
      #region DataPortal Methods
      protected override void DataPortal_Execute()
      {
        using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
        {
          if (string.IsNullOrEmpty(OIB))
          {
            //OsobaExists = (from x in ctx.DataContext.Osoba
            //               where x.IdOsobe == IdOsobe
            //               select x).Count() > 0; 
            OsobaExists = ctx.DataContext.Osoba.
              Where(x => x.IdOsobe == IdOsobe).Count() > 0;

          }
          else
          {
            OsobaExists = ctx.DataContext.Osoba.
              Where(x => x.OIB == OIB).Count() > 0;
          }
        }
      }
      #endregion
      #endregion
    }
    #endregion
    #endregion

    #region Overrides
    public override string ToString()
    {
      return GetProperty(IdOsobeProperty).ToString();
    }
    #endregion
  }
}