using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravljanjeProjektima
{
    // Read-only informacije o osobi.
    [Serializable()]
    public class PersonInfo : ReadOnlyBase<PersonInfo>
    {
        #region Constructors
        internal PersonInfo(int id, string surname, string name)
        {
            PersonId = id;
            FullName = string.Format("{0}, {1}", surname, name);
        }
        #endregion

        #region Properties
        public int PersonId { get; private set; }
        public string FullName { get; private set; }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return FullName;
        }
        #endregion
    }
}
