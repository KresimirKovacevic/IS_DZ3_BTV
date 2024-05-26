using System;
using System.Reflection;
using Csla;
using Csla.Serialization;

namespace UpravljanjeProjektima
{
  // Read-only informacije o osobi.
  [Serializable()]
  public class OsobaInfo : ReadOnlyBase<OsobaInfo>
  {
    #region Constructors
    internal OsobaInfo(int id, string prezime, string ime)
    {
      IdOsobe = id;
      NazOsobe = string.Format("{0}, {1}", prezime, ime);
    }
    #endregion

    #region Properties
    public int IdOsobe { get; private set; }
    public string NazOsobe { get; private set; }
    #endregion

    #region Overrides
    public override string ToString()
    {
      return NazOsobe;
    }
    #endregion
  }
}