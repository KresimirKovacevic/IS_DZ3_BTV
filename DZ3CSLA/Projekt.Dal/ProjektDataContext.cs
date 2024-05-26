using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UpravljanjeProjektima.Dal
{
  public partial class ProjektDataContext
  {
    partial void OnCreated()
    {       
      //this.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["Projekt"].ConnectionString;    
    }
  }
}
