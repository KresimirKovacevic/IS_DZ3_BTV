using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
    // Read-only popis redova (cache).
    [Serializable()]
    public class OrderList : NameValueListBase<int, string>
    {
        #region Constructors
        private OrderList()
        {
        }
        #endregion

        #region  Business Methods
        public static int Default()
        {
            OrderList list = Get();
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
        private static OrderList list;

        public static OrderList Get()
        {
            if (list == null)
            {
                list = DataPortal.Fetch<OrderList>();
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
                foreach (var u in ctx.DataContext.Order_t.AsNoTracking().ToList())
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
