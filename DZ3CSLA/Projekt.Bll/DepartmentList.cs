using System;
using System.Linq;
using Csla;
using Csla.Data;
using UpravljanjeProjektima.Properties;
using System.Collections.Generic;

namespace UpravljanjeProjektima
{
    // Read-only popis odjela (cache).
    [Serializable()]
    public class DepartmentList : NameValueListBase<int, string>
    {
        #region Constructors
        private DepartmentList()
        {
        }
        #endregion

        #region  Business Methods
        public static int Default()
        {
            DepartmentList list = Get();
            if (list.Count > 0)
            {
                return list.Items[0].Key;
            }
            else
            {
                throw new NullReferenceException(Resources.NoDataFound);
            }
        }
        #endregion

        #region  Factory Methods
        private static DepartmentList list;

        public static DepartmentList Get()
        {
            if (list == null)
            {
                list = DataPortal.Fetch<DepartmentList>();
            }
            return list;
        }

        public static void InvalidateCache()
        {
            list = null;
        }
        #endregion

        #region Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch()
        {
            this.RaiseListChangedEvents = false;
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                List<NameValuePair> data = new List<NameValuePair>();
                foreach (var u in ctx.DataContext.Departments.AsNoTracking().ToList())
                {
                    data.Add(new NameValuePair(u.ID, u.Name));
                }

                IsReadOnly = false;
                this.AddRange(data);
                IsReadOnly = true;
            }
            this.RaiseListChangedEvents = true;
        }
        #endregion
        #endregion
    }
}