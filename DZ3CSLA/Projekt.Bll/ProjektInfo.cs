using System;
using System.Reflection;
using Csla;
using Csla.Serialization;

namespace UpravljanjeProjektima
{
  // Read-only informacije o projektu.
  [Serializable()]
  public class ProjektInfo : ReadOnlyBase<ProjektInfo>
  {
    #region Constructors
    internal ProjektInfo()
    {
    }

    internal ProjektInfo(string sifProjekta, string nazProjekta)
    {
      SifProjekta = sifProjekta;
      NazProjekta = nazProjekta;
    }
    #endregion

    #region Properties
    public string SifProjekta { get; internal set; }
    public string NazProjekta { get; internal set; }
    #endregion

    #region Overrides
    protected override object GetIdValue()
    {
      return SifProjekta;
    }

    public override string ToString()
    {
      return NazProjekta;
    }
    #endregion
  }
}