using System;
using System.Linq;
using Csla;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
    public class PersonDepartmentList : BusinessListBase<PersonDepartmentList, PersonDepartment>
    {
        #region Constructors
        private PersonDepartmentList()
        {
        }
        #endregion

        #region  Business Methods
        public PersonDepartment GetPersonDepartment(int mainId)
        {
            if (ContainsJob(mainId))
            {
                return this.Where(x => x.MainID == mainId).Select(x => x).Single();
            }
            else
            {
                return null;
            }
        }

        public void NewPersonDepartment()
        {
            {
                PersonDepartment perDep = PersonDepartment.New();
                this.Add(perDep);
            }
        }

        public void NewPersonDepartment(int departmentId)
        {
            {
                PersonDepartment perDep = PersonDepartment.New(departmentId);
                this.Add(perDep);
            }
        }

        public void RemovePersonDepartment(int mainId)
        {
            if (ContainsJob(mainId))
            {
                Remove(this.Where(x => x.MainID == mainId).Select(x => x).Single());
            }
        }

        public bool ContainsJob(int mainId)
        {
            return this.Where(x => x.MainID == mainId).Count() > 0;
        }

        internal bool ContainsDeleted(int mainId)
        {
            return DeletedList.Where(x => x.MainID == mainId).Count() > 0;
        }
        #endregion

        #region  Factory Methods
        internal static PersonDepartmentList New()
        {
            return DataPortal.CreateChild<PersonDepartmentList>();
        }

        internal static ProjektOsobeList Load(Dal.Worker[] data)
        {
            return DataPortal.FetchChild<ProjektOsobeList>(data);
        }
        #endregion

        #region Data Access
        private void Child_Fetch(Dal.Worker[] data)
        {
            this.RaiseListChangedEvents = false;
            foreach (var child in data)
                Add(PersonDepartment.Load(child));
            this.RaiseListChangedEvents = true;
        }
        #endregion
    }
}
