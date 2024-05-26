using System;
using System.Linq;
using System.Reflection;
using Csla;
using Csla.Data;
using Csla.Validation;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima.Admin
{
    // Dodaje i mijenja odjel.
    [Serializable()]
    public class Department : BusinessBase<Department>
    {
        #region Constructors
        private Department()
        {
        }
        #endregion

        #region  Properties
        private bool idSet;
        private static PropertyInfo<int> DepartmentIdProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Department>(x => x.DepartmentId)));
        public int DepartmentId
        {
            get
            {
                if (!idSet)
                {
                    idSet = true;
                    SetProperty(DepartmentIdProperty, GetMax() + 1);
                }
                return GetProperty(DepartmentIdProperty);
            }
            set
            {
                idSet = true;
                SetProperty(DepartmentIdProperty, value);
            }
        }

        private static PropertyInfo<string> DepartmentNameProperty =
          RegisterProperty(typeof(Department), new PropertyInfo<string>(Reflector.GetPropertyName<Department>(x => x.DepartmentName)));
        public string DepartmentName
        {
            get { return GetProperty(DepartmentNameProperty); }
            set { SetProperty(DepartmentNameProperty, value); }
        }

        private static PropertyInfo<string> DepartmentLocationProperty =
          RegisterProperty(typeof(Department), new PropertyInfo<string>(Reflector.GetPropertyName<Department>(x => x.DepartmentLocation)));
        public string DepartmentLocation
        {
            get { return GetProperty(DepartmentLocationProperty); }
            set { SetProperty(DepartmentLocationProperty, value); }
        }
        #endregion

        #region Business Methods
        private int GetMax()
        {
            Departments parent = (Departments)this.Parent;
            int max = parent.Max(x => x.DepartmentId);
            if (max > 0)
            {
                return max;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule<Department>(NoDuplicates, DepartmentIdProperty);

            ValidationRules.AddRule(CommonRules.StringRequired, DepartmentLocationProperty);
            ValidationRules.AddRule<Department>(LocationValid, DepartmentLocationProperty);

            ValidationRules.AddRule(CommonRules.StringRequired, DepartmentNameProperty);
            ValidationRules.AddRule<Department>(NoDuplicatesDepartmentName, DepartmentNameProperty);
        }

        private static bool NoDuplicates<T>(T target, RuleArgs e) where T : Department
        {
            Departments parent = (Departments)target.Parent;
            if (parent != null)
            {
                foreach (Department item in parent)
                {
                    if (item.DepartmentId == target.ReadProperty(DepartmentIdProperty) && !(ReferenceEquals(item, target)))
                    {
                        e.Description = Resources.NoDuplicates;
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool LocationValid<T>(T target, RuleArgs e) where T : Department
        {
            return LocationValid(target.ReadProperty(DepartmentLocationProperty));
            if (string.IsNullOrEmpty(target.ReadProperty(DepartmentLocationProperty)))return false;
            string[] components = target.ReadProperty(DepartmentLocationProperty).Split(':');
            if(components.Length != 2 ) return false;
            float tmpA, tmpB;
            if (float.TryParse(components[0], out tmpA) && float.TryParse(components[1], out tmpB)) return true;
            return false;
        }

        public static bool LocationValid(string location)
        {
            if (string.IsNullOrEmpty(location)) return false;
            string[] components = location.Split(':');
            if (components.Length != 2) return false;
            float tmpA, tmpB;
            if (float.TryParse(components[0], out tmpA) && float.TryParse(components[1], out tmpB)) return true;
            return false;
        }

        private static bool NoDuplicatesDepartmentName<T>(T target, RuleArgs e) where T : Department
        {
            if (string.IsNullOrEmpty(target.DepartmentName))
                return true;

            e.Description = Resources.NoDuplicates;

            Departments parent = (Departments)target.Parent;
            if (parent != null)
            {
                foreach (Department item in parent)
                {
                    if (item.DepartmentName == target.ReadProperty(DepartmentNameProperty) && !(ReferenceEquals(item, target)))
                    {
                        return false;
                    }
                }
            }

            return string.IsNullOrEmpty(target.DepartmentName) || !Department.Exists(target.DepartmentName);
        }
        #endregion

        #region  Factory Methods

        internal static Department New()
        {
            return DataPortal.CreateChild<Department>();
        }

        internal static Department Load(Dal.Department data)
        {
            return DataPortal.FetchChild<Department>(data);
        }
        public static Department Get(int departmentId)
        {
            return DataPortal.Fetch<Department>(new SingleCriteria<Department, int>(departmentId));
        }

        public static void Delete(int departmentId)
        {
            DataPortal.Delete(new SingleCriteria<Department, int>(departmentId));
        }
        #endregion

        #region  Data Access
        private void Child_Fetch(Dal.Department data)
        {
            LoadProperty(DepartmentIdProperty, data.ID);
            LoadProperty(DepartmentNameProperty, data.Name);
            LoadProperty(DepartmentLocationProperty, data.Location);
            idSet = true;
        }

        private void Child_Insert()
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Dal.Department d = new Dal.Department
                {
                    //ID = DepartmentId,
                    Name = DepartmentName,
                    Location = DepartmentLocation
                };
                //var transaction = ctx.DataContext.Database.BeginTransaction();
                //ctx.DataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Department] ON");
                ctx.DataContext.Departments.Add(d);
                ctx.DataContext.SaveChanges();
                //ctx.DataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Department] OFF");
                //transaction.Commit();
            }
        }

        private void Child_Update()
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Dal.Department d = ctx.DataContext.Departments.Find(this.DepartmentId);

                d.Name = DepartmentName;
                d.Location = DepartmentLocation;

                ctx.DataContext.SaveChanges();
            }
        }

        private void Child_DeleteSelf()
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                var d = ctx.DataContext.Departments.Find(this.DepartmentId);
                if (d != null)
                {
                    ctx.DataContext.Departments.Remove(d);
                    ctx.DataContext.SaveChanges();
                }
            }
        }
        #endregion

        #region  Exists
        public static bool Exists(string nazUloge)
        {
            return ExistsCommand.Exists(nazUloge);
        }

        #region ExisitsCommand
        [Serializable()]
        private class ExistsCommand : CommandBase
        {
            #region Execute
            public static bool Exists(string departmentName)
            {
                return DataPortal.Execute<ExistsCommand>(new ExistsCommand(departmentName)).DepartmentExists;
            }
            #endregion

            #region Constructors
            private ExistsCommand(string departmentName)
            {
                this.DepartmentName = departmentName;
            }
            #endregion

            #region Properties
            public string DepartmentName { get; private set; }
            public bool DepartmentExists { get; private set; }
            #endregion

            #region Data Access
            #region DataPortal Methods
            protected override void DataPortal_Execute()
            {
                using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
                {
                    DepartmentExists = ctx.DataContext.Departments.Where(u => u.Name == DepartmentName).Count() > 0;
                }
            }
            #endregion
            #endregion
        }
        #endregion
        #endregion
    }
}
