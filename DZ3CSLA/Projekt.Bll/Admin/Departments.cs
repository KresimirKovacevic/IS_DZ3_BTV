using System;
using Csla;
using Csla.Core;
using Csla.Data;

namespace UpravljanjeProjektima.Admin
{
    [Serializable()]
    public class Departments : BusinessListBase<Departments, Department>
    {
        #region Constructors
        private Departments()
        {
            // događaj pohrane
            this.Saved += new EventHandler<SavedEventArgs>(Departments_Saved);
            // omoguci dodavanje u sifrarnik
            this.AllowNew = true;
        }
        #endregion

        #region  Business Methods
        // dodaj, ukloni, dobavi - memorija
        public void RemoveDepartment(int departmentId)
        {
            foreach (Department item in this)
            {
                if (item.DepartmentId == departmentId)
                {
                    Remove(item);
                    break;
                }
            }
        }

        public Department GetDepartment(int departmentId)
        {
            foreach (Department item in this)
            {
                if (item.DepartmentId == departmentId)
                {
                    return item;
                }
            }
            return null;
        }
        #endregion

        #region Overrides
        // kad zatreba novi (zapocne dodavanje u grid)
        protected override object AddNewCore()
        {
            Department item = Department.New();
            this.Add(item);
            return item;
        }
        #endregion

        #region  Factory Methods
        public static Departments Get()
        {
            return DataPortal.Fetch<Departments>();
        }
        #endregion

        #region Deserialization
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            this.Saved += new EventHandler<SavedEventArgs>(Departments_Saved);
        }
        #endregion

        #region Cache Invalidation
        private void Departments_Saved(object sender, SavedEventArgs e)
        {
            DepartmentList.InvalidateCache();
        }

        protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server && e.Operation == DataPortalOperations.Update)
            {
                DepartmentList.InvalidateCache();
            }
        }
        #endregion

        #region  Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch()
        {
            this.RaiseListChangedEvents = false;
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                foreach (var d in ctx.DataContext.Departments)
                    this.Add(Department.Load(d)); 
            }
            this.RaiseListChangedEvents = true;
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Child_Update(); 
            }
            this.RaiseListChangedEvents = true;
        }
        #endregion
        #endregion
    }
}
