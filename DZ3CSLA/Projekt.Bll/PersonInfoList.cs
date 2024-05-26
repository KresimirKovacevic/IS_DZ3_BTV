using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpravljanjeProjektima
{
    // Dohvaca read-only listu osoba (za odabir osobe).
    [Serializable()]
    public class PersonInfoList : ReadOnlyListBase<PersonInfoList, PersonInfo>
    {
        #region Constructors
        private PersonInfoList()
        {
        }
        #endregion

        #region  Factory Methods
        public static PersonInfoList Get()
        {
            return DataPortal.Fetch<PersonInfoList>();
        }
        #endregion

        #region  Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                List<PersonInfo> data = new List<PersonInfo>();
                foreach (var o in ctx.DataContext.People.AsNoTracking().ToList())
                {
                    data.Add(new PersonInfo(o.ID, o.Surname, o.Name));
                }

                IsReadOnly = false;
                this.AddRange(data);
                IsReadOnly = true;
            }
            RaiseListChangedEvents = true;
        }
        #endregion
        #endregion
    }
}