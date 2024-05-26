using System;
using System.Linq;
using System.Reflection;
using Csla;
using Csla.Data;
using Csla.Validation;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
  // Dodaje i mijenja projekt.
  [Serializable()]
  public class Projekt : BusinessBase<Projekt>
  {
    #region Constructors
    private Projekt()
    {
    }
    #endregion

    #region  Properties
    private static PropertyInfo<string> SifProjektaProperty = 
      RegisterProperty(typeof(Projekt), new PropertyInfo<string>(Reflector.GetPropertyName<Projekt>(x => x.SifProjekta)));
    public string SifProjekta
    {
      get { return GetProperty(SifProjektaProperty); }
      set { SetProperty(SifProjektaProperty, value); }
    }

    private static PropertyInfo<string> NazProjektaProperty = 
      RegisterProperty(typeof(Projekt), new PropertyInfo<string>(Reflector.GetPropertyName<Projekt>(x=>x.NazProjekta)));
    public string NazProjekta
    {
      get { return GetProperty(NazProjektaProperty); }
      set { SetProperty(NazProjektaProperty, value); }
    }

    private static PropertyInfo<string> OpisProjektaProperty = 
      RegisterProperty(typeof(Projekt), new PropertyInfo<string>(Reflector.GetPropertyName<Projekt>(x => x.OpisProjekta)));
    public string OpisProjekta
    {
      get { return GetProperty(OpisProjektaProperty); }
      set { SetProperty(OpisProjektaProperty, value); }
    }

    private static PropertyInfo<DateTime?> DatPocetkaProperty = 
      RegisterProperty(typeof(Projekt), new PropertyInfo<DateTime?>(Reflector.GetPropertyName<Projekt>(x => x.DatPocetka)));
    public DateTime? DatPocetka
    {
      get { return GetProperty(DatPocetkaProperty); }
      set { SetProperty(DatPocetkaProperty, value); }
    }

    private static PropertyInfo<DateTime?> DatZavrsetkaProperty = 
      RegisterProperty(typeof(Projekt), new PropertyInfo<DateTime?>(Reflector.GetPropertyName<Projekt>(x => x.DatZavrsetka)));
    public DateTime? DatZavrsetka
    {
      get { return GetProperty(DatZavrsetkaProperty); }
      set { SetProperty(DatZavrsetkaProperty, value); }
    }

    private static PropertyInfo<SudionikProjektaList> SudioniciProjektaProperty =
      RegisterProperty(typeof(Projekt), new PropertyInfo<SudionikProjektaList>(Reflector.GetPropertyName<Projekt>(x => x.SudioniciProjekta)));
    public SudionikProjektaList SudioniciProjekta
    {
      get
      {
        if (!(FieldManager.FieldExists(SudioniciProjektaProperty)))
        {
          LoadProperty(SudioniciProjektaProperty, SudionikProjektaList.New());
        }
        return GetProperty(SudioniciProjektaProperty);
      }
    }
    #endregion

    #region  Validation Rules
    protected override void AddBusinessRules()
    {
      ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs(SifProjektaProperty));
      ValidationRules.AddRule<Projekt>(SifProjektaUnique, new RuleArgs(SifProjektaProperty));

      ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs(NazProjektaProperty));
      ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(NazProjektaProperty, 50));

      ValidationRules.AddRule<Projekt>(StartDateGTEndDate<Projekt>, DatPocetkaProperty);
      ValidationRules.AddRule<Projekt>(StartDateGTEndDate<Projekt>, DatZavrsetkaProperty);

      ValidationRules.AddDependentProperty(DatPocetkaProperty, DatZavrsetkaProperty, true);
    }

    private static bool SifProjektaUnique<T>(T target, RuleArgs e) where T : Projekt
    {
      if (Projekt.Exists(target.ReadProperty<string>(SifProjektaProperty)))
      {
        e.Description = Resources.NoDuplicates;
        return false;
      }
      else
      {
        return true;
      }
    }

    private static bool StartDateGTEndDate<T>(T target, RuleArgs e) where T : Projekt
    {
      if (target.ReadProperty(DatPocetkaProperty).HasValue && target.ReadProperty(DatZavrsetkaProperty).HasValue && target.ReadProperty(DatPocetkaProperty) > target.ReadProperty(DatZavrsetkaProperty))
      {
        e.Description = Resources.DatumProjektaError;
        return false;
      }
      else
      {
        return true;
      }
    }
    #endregion

    #region  Factory Methods
    public static Projekt New()
    {
      return DataPortal.Create<Projekt>();
    }

    public static Projekt Get(string sifProjekta)
    {
      return DataPortal.Fetch<Projekt>(new SingleCriteria<Projekt, string>(sifProjekta));
    }

    public static void Delete(string sifProjekta)
    {
      DataPortal.Delete(new SingleCriteria<Projekt, string>(sifProjekta));
    }
    #endregion

    #region Data Access
    #region DataPortal Methods
    [RunLocal()]
    protected override void DataPortal_Create()
    {
      LoadProperty(DatPocetkaProperty, DateTime.Today);
      this.ValidationRules.CheckRules();
    }

    private void DataPortal_Fetch(SingleCriteria<Projekt, string> criteria)
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        var data = ctx.DataContext.Projekt.Find(criteria.Value);

        LoadProperty(SifProjektaProperty, data.SifProjekta); // napuni polje uz PropertyHasChanged
        LoadProperty(NazProjektaProperty, data.NazProjekta);
        LoadProperty(DatPocetkaProperty, data.DatPocetka);
        LoadProperty(DatZavrsetkaProperty, data.DatZavrsetka);
        LoadProperty(OpisProjektaProperty, data.OpisProjekta);

        LoadProperty(SudioniciProjektaProperty, SudionikProjektaList.Load(data.UlogaOsobe.ToArray()));
      }
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    protected override void DataPortal_Insert()
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Dal.Projekt p = new Dal.Projekt
        {
          SifProjekta = SifProjekta,
          DatPocetka = DatPocetka,
          DatZavrsetka = DatZavrsetka,
          NazProjekta = NazProjekta,
          OpisProjekta = OpisProjekta
        };

        ctx.DataContext.Projekt.Add(p);
        ctx.DataContext.SaveChanges();

        FieldManager.UpdateChildren(this);
      }
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    protected override void DataPortal_Update()
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        Dal.Projekt p = ctx.DataContext.Projekt.Find(this.SifProjekta);

        p.DatPocetka = DatPocetka;
        p.DatZavrsetka = DatZavrsetka;
        p.OpisProjekta = OpisProjekta;
        p.NazProjekta = NazProjekta;
        
        ctx.DataContext.SaveChanges();

        FieldManager.UpdateChildren(this);
      }
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    protected override void DataPortal_DeleteSelf()
    {
      DataPortal_Delete(new SingleCriteria<Projekt, string>(ReadProperty(SifProjektaProperty)));
    }

    [Transactional(TransactionalTypes.TransactionScope)]
    private void DataPortal_Delete(SingleCriteria<Projekt, string> criteria)
    {
      using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
      {
        var projekt = ctx.DataContext.Projekt.Find(criteria.Value);
        if (projekt != null)
        {
          ctx.DataContext.Projekt.Remove(projekt);
          ctx.DataContext.SaveChanges();
        }

        LoadProperty(SudioniciProjektaProperty, SudionikProjektaList.New());
      }
    }
    #endregion
    #endregion

    #region  Exists
    // metoda za provjeru duplikata
    public static bool Exists(string sifProjekta)
    {
      // pozove komandu s vrijednošæu PK
      return ExistsCommand.Exists(sifProjekta);
    }

    #region ExisitsCommand
    [Serializable()]
    private class ExistsCommand : CommandBase
    {
      #region Execute
      public static bool Exists(string sifProjekta)
      {
        // provjerea u komandi vrati vrijednost svojstva ProjectExists 
        // koje bude napunjeno pozivom portalske Execute
        return DataPortal.Execute<ExistsCommand>(new ExistsCommand(sifProjekta)).ProjectExists;
      }
      #endregion

      #region Constructors
      private ExistsCommand(string sifProjekta)
      {
        this.SifProjekta = sifProjekta;
      }
      #endregion

      #region Properties
      public string SifProjekta { get; private set; }
      public bool ProjectExists { get; private set; }
      #endregion

      #region Data Access
      #region DataPortal Methods
      // metoda provjere koju aktivira portal
      protected override void DataPortal_Execute()
      {
        using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(Dal.Database.ProjektConnectionString))
        {
          ProjectExists = ctx.DataContext.Projekt.
            Where(p => p.SifProjekta == SifProjekta).Count() > 0;
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
      return SifProjekta.ToString();
    }
    #endregion
  }
}