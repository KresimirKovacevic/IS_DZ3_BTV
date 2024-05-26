using System;
using System.Reflection;
using Csla;

namespace UpravljanjeProjektima
{
  // Odreðuje zaduženje/ulogu osobe dodijeljene projektu.
  [Serializable()]
  public class SudionikProjekta : BusinessBase<SudionikProjekta>, ISadrziUloge
  {
    #region Constructors
    private SudionikProjekta()
    {
    }
    #endregion

    #region  Properties
    private static PropertyInfo<int> IdOsobeProperty = 
      RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<SudionikProjekta>(x => x.IdOsobe)));
    public int IdOsobe
    {
      get { return GetProperty(IdOsobeProperty); }
    }

    private static PropertyInfo<string> ImeOsobeProperty = 
      RegisterProperty(new PropertyInfo<string>(Reflector.GetPropertyName<SudionikProjekta>(x => x.ImeOsobe)));
    public string ImeOsobe
    {
      get { return GetProperty(ImeOsobeProperty); }
    }

    private static PropertyInfo<string> PrezimeOsobeProperty = 
      RegisterProperty(new PropertyInfo<string>(Reflector.GetPropertyName<SudionikProjekta>(x => x.PrezimeOsobe)));
    public string PrezimeOsobe
    {
      get { return GetProperty(PrezimeOsobeProperty); }
    }

    private static PropertyInfo<DateTime> DatDodjeleUlogeProperty = 
      RegisterProperty(new PropertyInfo<DateTime>(Reflector.GetPropertyName<SudionikProjekta>(x => x.DatDodjeleUloge)));
    public DateTime DatDodjeleUloge
    {
      get { return GetProperty<DateTime>(DatDodjeleUlogeProperty); }
    }

    private static PropertyInfo<int> IdUlogeProperty = 
      RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<SudionikProjekta>(x => x.IdUloge)));
    public int IdUloge
    {
      get { return GetProperty(IdUlogeProperty); }
      set { SetProperty(IdUlogeProperty, value); }
    }
    #endregion

    #region Calculated Properties
    public string PunoImeOsobe
    {
      get { return PrezimeOsobe + ", " + ImeOsobe; }
    }
    #endregion

    #region Business Methods
    public Osoba GetOsoba()
    {
      return Osoba.Get(GetProperty(IdOsobeProperty));
    }
    #endregion

    #region  Validation Rules
    protected override void AddBusinessRules()
    {
      ValidationRules.AddRule<SudionikProjekta>(Zaduzenje.IsUlogaValid, IdUlogeProperty);
    }
    #endregion

    #region  Factory Methods
    internal static SudionikProjekta New(int idOsobe)
    {
      return DataPortal.CreateChild<SudionikProjekta>(idOsobe, UlogaList.Default());
    }

    internal static SudionikProjekta Load(Dal.UlogaOsobe data)
    {
      return DataPortal.FetchChild<SudionikProjekta>(data);
    }
    #endregion

    #region  Data Access
    protected override void Child_Create()
    {
      LoadProperty(DatDodjeleUlogeProperty, DateTime.Now);
    }

    private void Child_Create(int idOsobe, int idUloge)
    {
      var o = Osoba.Get(idOsobe);
      LoadProperty(IdOsobeProperty, o.IdOsobe);
      LoadProperty(PrezimeOsobeProperty, o.PrezimeOsobe);
      LoadProperty(ImeOsobeProperty, o.ImeOsobe);
      LoadProperty(DatDodjeleUlogeProperty, Zaduzenje.GetDatumDodjele());
      LoadProperty(IdUlogeProperty, idUloge);
    }

    private void Child_Fetch(Dal.UlogaOsobe data)
    {
      LoadProperty(IdOsobeProperty, data.IdOsobe);
      LoadProperty(PrezimeOsobeProperty, data.Osoba.PrezimeOsobe);
      LoadProperty(ImeOsobeProperty, data.Osoba.ImeOsobe);
      LoadProperty(DatDodjeleUlogeProperty, data.DatDodjele);
      LoadProperty(IdUlogeProperty, data.IdUloge);
    }

    private void Child_Insert(Projekt projekt)
    {
      Zaduzenje.DodajZaduzenje(projekt.SifProjekta, ReadProperty(IdOsobeProperty), ReadProperty(DatDodjeleUlogeProperty), ReadProperty(IdUlogeProperty));
    }

    private void Child_Update(Projekt projekt)
    {
      Zaduzenje.PromijeniZaduzenje(projekt.SifProjekta, ReadProperty(IdOsobeProperty), ReadProperty(DatDodjeleUlogeProperty), ReadProperty(IdUlogeProperty));
    }

    private void Child_DeleteSelf(Projekt projekt)
    {
      Zaduzenje.UkloniZaduzenje(projekt.SifProjekta, ReadProperty(IdOsobeProperty));
    }
    #endregion

    #region Overrides
    public override string ToString()
    {
      return IdOsobe.ToString();
    }
    #endregion
  }
}