using Csla;
using Csla.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UpravljanjeProjektima.Admin;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
    [Serializable()]
    public class PersonDepartment : BusinessBase<PersonDepartment>
    {
        #region Constructors
        private PersonDepartment()
        {
        }
        #endregion

        #region  Properties
        private static PropertyInfo<int> MainIdProperty =
          RegisterProperty(typeof(PersonDepartment), new PropertyInfo<int>(Reflector.GetPropertyName<PersonDepartment>(x => x.MainID)));
        public int MainID
        {
            get { return GetProperty(MainIdProperty); }
        }

        private static PropertyInfo<int> DepartmentIdProperty =
            RegisterProperty(typeof(PersonDepartment), new PropertyInfo<int>(Reflector.GetPropertyName<PersonDepartment>(x => x.DepartmentId)));
        public int DepartmentId
        {
            get { return GetProperty(DepartmentIdProperty); }
            set { SetProperty(DepartmentIdProperty, value); }
        }

        private static PropertyInfo<string> DepartmnetNameProperty =
            RegisterProperty(typeof(PersonDepartment), new PropertyInfo<string>(Reflector.GetPropertyName<PersonDepartment>(x => x.DepartmentName)));
        public string DepartmentName
        {
            get { return GetProperty(DepartmnetNameProperty); }
        }

        private static PropertyInfo<string> RoleProperty =
            RegisterProperty(typeof(PersonDepartment), new PropertyInfo<string>(Reflector.GetPropertyName<PersonDepartment>(x => x.Role)));
        public string Role
        {
            get { return GetProperty(RoleProperty); }
            set { SetProperty(RoleProperty, value); }
        }

        private static PropertyInfo<DateTime?> HireDateProperty =
            RegisterProperty(typeof(PersonDepartment), new PropertyInfo<DateTime?>(Reflector.GetPropertyName<PersonDepartment>(x => x.HireDate)));
        public DateTime? HireDate
        {
            get { return GetProperty<DateTime?>(HireDateProperty); }
            set { SetProperty<DateTime?>(HireDateProperty, value); }
        }

        private static PropertyInfo<DateTime?> EndDateProperty =
            RegisterProperty(typeof(PersonDepartment), new PropertyInfo<DateTime?>(Reflector.GetPropertyName<PersonDepartment>(x => x.EndDate)));
        public DateTime? EndDate
        {
            get { return GetProperty<DateTime?>(EndDateProperty); }
            set { SetProperty<DateTime?>(EndDateProperty, value); }
        }
        #endregion

        #region Business Methods
        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.StringRequired, new RuleArgs(RoleProperty));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(RoleProperty, 100));

            ValidationRules.AddRule<PersonDepartment>(HireDateExists<PersonDepartment>, HireDateProperty);
            ValidationRules.AddRule<PersonDepartment>(HireDateGTEndDate<PersonDepartment>, HireDateProperty);
            ValidationRules.AddRule<PersonDepartment>(HireDateGTEndDate<PersonDepartment>, EndDateProperty);

            ValidationRules.AddDependentProperty(HireDateProperty, EndDateProperty, true);
        }

        private static bool HireDateExists<T>(T target, RuleArgs e) where T : PersonDepartment
        {
            return target.ReadProperty(HireDateProperty).HasValue;
        }

            private static bool HireDateGTEndDate<T>(T target, RuleArgs e) where T : PersonDepartment
        {
            if (target.ReadProperty(HireDateProperty).HasValue && target.ReadProperty(EndDateProperty).HasValue && target.ReadProperty(HireDateProperty) > target.ReadProperty(EndDateProperty))
            {
                e.Description = Resources.WorkerDatesError;
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Factory Methods
        internal static PersonDepartment New()
        {
            return DataPortal.CreateChild<PersonDepartment>(DepartmentList.Default());
        }

        internal static PersonDepartment New(int departmentId)
        {
            return DataPortal.CreateChild<PersonDepartment>(departmentId);
        }

        internal static PersonDepartment Load(Dal.Worker data)
        {
            return DataPortal.FetchChild<PersonDepartment>(data);
        }
        #endregion

        #region  Data Access
        private void Child_Create(int departmentId)
        {
            var data = Department.Get(departmentId);

            LoadProperty(DepartmentIdProperty, data.DepartmentId);
            LoadProperty(DepartmnetNameProperty, data.DepartmentName);
            LoadProperty(HireDateProperty, WorkerHelper.GetToday());
            LoadProperty(EndDateProperty, WorkerHelper.GetToday());
        }

        private void Child_Fetch(Dal.Worker data)
        {
            LoadProperty(MainIdProperty, data.ID);
            LoadProperty(DepartmentIdProperty, data.ID_Department);
            LoadProperty(DepartmnetNameProperty, data.Department.Name);
            LoadProperty(HireDateProperty, data.Hire_date);
            LoadProperty(EndDateProperty, data.End_date);
            LoadProperty(RoleProperty, data.Role);
        }

        private void Child_Insert(Person resource)
        {
            WorkerHelper.AddWorker(resource.PersonId, DepartmentId, Role, HireDate, EndDate);
        }

        private void Child_Update(Person resource)
        {
            WorkerHelper.UpdateWorker(MainID, resource.PersonId, DepartmentId, Role, HireDate, EndDate);
        }

        private void Child_DeleteSelf(Person resource)
        {
            WorkerHelper.RemoveWorker(MainID);
        }
        #endregion

    }
}
