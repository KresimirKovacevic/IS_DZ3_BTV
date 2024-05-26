using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpravljanjeProjektima.Dal
{
    public partial class BTVDataContext
    {
        // instanciramo nazivom ključa za DAL config
        public BTVDataContext(string ConnectionStringName)
          : base("name=" + ConnectionStringName)
        {
        }
    }
}
