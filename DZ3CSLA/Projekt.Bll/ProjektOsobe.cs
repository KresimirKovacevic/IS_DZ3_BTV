using System;
using System.Reflection;
using Csla;

namespace UpravljanjeProjektima
{
  // Odreðuje zaduženje/ulogu osobe dodijeljene projektu.
  [Serializable()]
  public class ProjektOsobe : BusinessBase<ProjektOsobe>, ISadrziUloge
  {
    #region Constructors
    private ProjektOsobe()
    {
    }
    #endregion

    #region  Properties
    private static PropertyInfo<string> SifProjektaProperty =
      RegisterProperty(typeof(ProjektOsobe), new PropertyInfo<string>(Reflector.GetPropertyName<ProjektOsobe>(x => x.SifProjekta)));
    public string SifProjekta
    {
      get { return GetProperty(SifProjektaProperty); }
    }

    private static PropertyInfo<string> NazProjektaProperty = 
      RegisterProperty(typeof(ProjektOsobe), new PropertyInfo<string>(Reflector.GetPropertyName<ProjektOsobe>(x => x.NazProjekta)));
    public string NazProjekta
    {
      get { return GetProperty(NazProjektaProperty); }
    }

    private static PropertyInfo<DateTime> DatDodjeleUlogeProperty = 
      RegisterProperty(typeof(ProjektOsobe), new PropertyInfo<DateTime>(Reflector.GetPropertyName<ProjektOsobe>(x => x.DatDodjeleUloge)));
    public DateTime DatDodjeleUloge
    {
      get { return GetProperty<DateTime>(DatDodjeleUlogeProperty); }
    }

    private static PropertyInfo<int> IdUlogeProperty = 
      RegisterProperty(typeof(ProjektOsobe), new PropertyInfo<int>(Reflector.GetPropertyName<ProjektOsobe>(x => x.IdUloge)));
    public int IdUloge
    {
      get { return GetProperty(IdUlogeProperty); }
      set { SetProperty(IdUlogeProperty, value); }
    }
    #endregion

    #region Business Methods
    public Projekt GetProjekt()
    {
      return Projekt.Get(SifProjekta);
    }
    #endregion

    #region  Validation Rules
    protected override void AddBusinessRules()
    {
      ValidationRules.AddRule<ProjektOsobe>(Zaduzenje.IsUlogaValid, IdUlogeProperty);
    }
    #endregion

    #region Factory Methods
    internal static ProjektOsobe New(string sifProjekta)
    {
      return DataPortal.CreateChild<ProjektOsobe>(sifProjekta, UlogaList.Default());
    }

    internal static ProjektOsobe Load(Dal.UlogaOsobe data)
    {
      return DataPortal.FetchChild<ProjektOsobe>(data);
    }
    #endregion

    #region  Data Access
    private void Child_Create(string sifProjekta, int idUloge)
    {
      var data = Projekt.Get(sifProjekta);

      LoadProperty(SifProjektaProperty, data.SifProjekta);
      LoadProperty(NazProjektaProperty, data.NazProjekta);
      LoadProperty(DatDodjeleUlogeProperty, Zaduzenje.GetDatumDodjele());
      LoadProperty(IdUlogeProperty, idUloge);
    }

    private void Child_Fetch(Dal.UlogaOsobe data)
    {
      LoadProperty(SifProjektaProperty, data.SifProjekta);
      LoadProperty(NazProjektaProperty, data.Projekt.NazProjekta);
      LoadProperty(DatDodjeleUlogeProperty, data.DatDodjele);
      LoadProperty(IdUlogeProperty, data.IdUloge);
    }

    private void Child_Insert(Osoba resource)
    {
      Zaduzenje.DodajZaduzenje(SifProjekta, resource.IdOsobe, DatDodjeleUloge, IdUloge);
    }

    private void Child_Update(Osoba resource)
    {
      Zaduzenje.PromijeniZaduzenje(SifProjekta, resource.IdOsobe, DatDodjeleUloge, IdUloge);
    }

    private void Child_DeleteSelf(Osoba resource)
    {
      Zaduzenje.UkloniZaduzenje(SifProjekta, resource.IdOsobe);
    }
    #endregion

    #region Overrides
    public override string ToString()
    {
      return SifProjekta;
    }
    #endregion
  }
}