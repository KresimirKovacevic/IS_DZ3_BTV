using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Reflection;
using Csla;
using Csla.Data;
using Csla.Validation;
using UpravljanjeProjektima.Properties;
using static Csla.Security.MembershipIdentity;

namespace UpravljanjeProjektima
{
    // Dodaje i mijenja radnika.
    [Serializable()]
    public class Worker : BusinessBase<Worker>
    {
        #region Constructors
        private Worker()
        {
        }
        #endregion

        #region  Properties
        private static PropertyInfo<int> MainIdProperty =
          RegisterProperty(typeof(Worker), new PropertyInfo<int>(Reflector.GetPropertyName<Worker>(x => x.MainID)));
        public int MainID
        {
            get { return GetProperty(MainIdProperty); }
            set { SetProperty(MainIdProperty, value); }
        }

        private static PropertyInfo<string> RoleProperty =
          RegisterProperty(typeof(Worker), new PropertyInfo<string>(Reflector.GetPropertyName<Worker>(x => x.Role)));
        public string Role
        {
            get { return GetProperty(RoleProperty); }
            set { SetProperty(RoleProperty, value); }
        }

        private static PropertyInfo<DateTime> HireDateProperty =
          RegisterProperty(typeof(Worker), new PropertyInfo<DateTime>(Reflector.GetPropertyName<Worker>(x => x.HireDate)));
        public DateTime HireDate
        {
            get { return GetProperty(HireDateProperty); }
            set { SetProperty(HireDateProperty, value); }
        }

        private static PropertyInfo<DateTime?> EndDateProperty =
          RegisterProperty(typeof(Worker), new PropertyInfo<DateTime?>(Reflector.GetPropertyName<Worker>(x => x.EndDate)));
        public DateTime? EndDate
        {
            get { return GetProperty(EndDateProperty); }
            set { SetProperty(EndDateProperty, value); }
        }

        private static PropertyInfo<int> PersonIdProperty =
          RegisterProperty(typeof(Worker), new PropertyInfo<int>(Reflector.GetPropertyName<Worker>(x => x.PersonID)));
        public int PersonID
        {
            get { return GetProperty(PersonIdProperty); }
            set { SetProperty(PersonIdProperty, value); }
        }

        private static PropertyInfo<int> DepartmentIdProperty =
          RegisterProperty(typeof(Worker), new PropertyInfo<int>(Reflector.GetPropertyName<Worker>(x => x.DepartmentID)));
        public int DepartmentID
        {
            get { return GetProperty(DepartmentIdProperty); }
            set { SetProperty(DepartmentIdProperty, value); }
        }
        #endregion


        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs(RoleProperty));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(RoleProperty, 100));

            ValidationRules.AddRule<Worker>(HireDateGTEndDate<Worker>, HireDateProperty);
            ValidationRules.AddRule<Worker>(HireDateGTEndDate<Worker>, EndDateProperty);

            ValidationRules.AddDependentProperty(HireDateProperty, EndDateProperty, true);

            ValidationRules.AddRule<Worker>(ConflictingWorkPeriod<Worker>, HireDateProperty);
            ValidationRules.AddRule<Worker>(ConflictingWorkPeriod<Worker>, EndDateProperty);
            ValidationRules.AddRule<Worker>(ConflictingWorkPeriod<Worker>, DepartmentIdProperty);

            ValidationRules.AddDependentProperty(HireDateProperty, DepartmentIdProperty, true);
            ValidationRules.AddDependentProperty(DepartmentIdProperty, EndDateProperty, true);
        }

        private static bool HireDateGTEndDate<T>(T target, RuleArgs e) where T : Worker
        {
            if(HireDateGTEndDate(target.ReadProperty(HireDateProperty), target.ReadProperty(EndDateProperty)))
            {
                return true;
            }
            else
            {
                e.Description = Resources.WorkerDatesError;
                return false;
            }
            if (target.ReadProperty(EndDateProperty).HasValue && target.ReadProperty(HireDateProperty) > target.ReadProperty(EndDateProperty))
            {
                e.Description = Resources.WorkerDatesError;
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool HireDateGTEndDate(DateTime hireDate, DateTime? endDate)
        {
            if (endDate.HasValue && hireDate > endDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ConflictingWorkPeriod<T>(T target, RuleArgs e) where T : Worker
        {
            if (target.ReadProperty(DepartmentIdProperty)!=null && target.ReadProperty(DepartmentIdProperty) <= 0)
            {
                using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
                {
                    var data = ctx.DataContext.Workers.Where(x => x.ID_Person == target.ReadProperty(PersonIdProperty) && x.ID_Department == target.ReadProperty(DepartmentIdProperty) && x.ID != target.ReadProperty(MainIdProperty));
                    foreach(var row in data)
                    {
                        if (row.End_date.HasValue)
                        {
                            if (target.ReadProperty(HireDateProperty) >= row.Hire_date && target.ReadProperty(HireDateProperty) <= row.End_date)
                            {
                                e.Description = Resources.WorkerJobError;
                                return false;
                            }
                            if (target.ReadProperty(EndDateProperty).HasValue && target.ReadProperty(EndDateProperty) >= row.Hire_date && target.ReadProperty(EndDateProperty) <= row.End_date)
                            {
                                e.Description = Resources.WorkerJobError;
                                return false;
                            }
                        }
                        else
                        {
                            if (target.ReadProperty(HireDateProperty) >= row.Hire_date)
                            {
                                e.Description = Resources.WorkerJobError;
                                return false;
                            }
                            if (target.ReadProperty(EndDateProperty).HasValue && target.ReadProperty(EndDateProperty) >= row.Hire_date)
                            {
                                e.Description = Resources.WorkerJobError;
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region  Factory Methods
        public static Worker New()
        {
            return DataPortal.Create<Worker>();
        }

        public static Worker Get(int mainID)
        {
            return DataPortal.Fetch<Worker>(new SingleCriteria<Worker, int>(mainID));
        }

        public static void Delete(int mainID)
        {
            DataPortal.Delete(new SingleCriteria<Projekt, int>(mainID));
        }
        #endregion


        #region Data Access
        #region DataPortal Methods
        [RunLocal()]
        protected override void DataPortal_Create()
        {
            LoadProperty(HireDateProperty, DateTime.Today);
            this.ValidationRules.CheckRules();
        }

        private void DataPortal_Fetch(SingleCriteria<Worker, int> criteria)
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                var data = ctx.DataContext.Workers.Find(criteria.Value);

                LoadProperty(MainIdProperty, data.ID); 
                LoadProperty(RoleProperty, data.Role);
                LoadProperty(PersonIdProperty, data.ID_Person);
                LoadProperty(DepartmentIdProperty, data.ID_Department);
                LoadProperty(HireDateProperty, data.Hire_date);
                LoadProperty(EndDateProperty, data.End_date);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Dal.Worker w = new Dal.Worker
                {
                    //ID = MainID,
                    Role = Role,
                    ID_Person = PersonID,
                    ID_Department = DepartmentID,
                    Hire_date = (DateTime)HireDate,
                    End_date = EndDate
                };

                ctx.DataContext.Workers.Add(w);
                ctx.DataContext.SaveChanges();

                FieldManager.UpdateChildren(this);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Dal.Worker w = ctx.DataContext.Workers.Find(this.MainID);

                //w.ID = MainID;
                w.Role = Role;
                w.ID_Person = PersonID;
                w.ID_Department = DepartmentID;
                w.Hire_date = (DateTime)HireDate;
                w.End_date = EndDate;

                ctx.DataContext.SaveChanges();

                FieldManager.UpdateChildren(this);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<Worker, int>(ReadProperty(MainIdProperty)));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SingleCriteria<Worker, int> criteria)
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                var worker = ctx.DataContext.Workers.Find(criteria.Value);
                if (worker != null)
                {
                    ctx.DataContext.Workers.Remove(worker);
                    ctx.DataContext.SaveChanges();
                }
            }
        }
        #endregion
        #endregion

        #region  Exists
        // metoda za provjeru duplikata
        public static bool Exists(int mainID)
        {
            return ExistsCommand.Exists(mainID);
        }

        #region ExisitsCommand
        [Serializable()]
        private class ExistsCommand : CommandBase
        {
            #region Execute
            public static bool Exists(int mainID)
            {
                return DataPortal.Execute<ExistsCommand>(new ExistsCommand(mainID)).WorkerExists;
            }
            #endregion

            #region Constructors
            private ExistsCommand(int mainID)
            {
                this.mainID = mainID;
            }
            #endregion

            #region Properties
            public int mainID { get; private set; }
            public bool WorkerExists { get; private set; }
            #endregion

            #region Data Access
            #region DataPortal Methods
            // metoda provjere koju aktivira portal
            protected override void DataPortal_Execute()
            {
                using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
                {
                    WorkerExists = ctx.DataContext.Workers.
                      Where(w => w.ID == mainID).Count() > 0;
                }
            }
            #endregion
            #endregion
        }
        #endregion
        #endregion

        #region Overrides
        public override string ToString()
        {
            String result = "";
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                result += ctx.DataContext.People.Where(x => x.ID == PersonID).Single().Surname + ", ";
                result += ctx.DataContext.People.Where(x => x.ID == PersonID).Single().Name + " - ";
                result += ctx.DataContext.Departments.Where(x => x.ID == DepartmentID).Single().Name + " (";
            }
            if(EndDate.HasValue) {
                result += HireDate.ToString() + " - " + EndDate.ToString() + ")";
            }
            else
            {
                result += HireDate.ToString() + ")";
            }
            return result;
        }
        #endregion
    }
}
