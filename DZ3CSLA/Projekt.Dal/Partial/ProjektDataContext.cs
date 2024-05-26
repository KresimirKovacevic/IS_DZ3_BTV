using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpravljanjeProjektima.Dal
{
  public partial class ProjektDataContext
  {
    // instanciramo nazivom ključa za DAL config
    public ProjektDataContext(string ConnectionStringName)
      : base("name=" + ConnectionStringName)
    {
    }
  }
}
