using Csla.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpravljanjeProjektima.Dal;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
    internal static class WorkerHelper
    {
        #region  Business Methods
        public static DateTime GetToday()
        {
            return DateTime.Today;
        }
        #endregion

        #region  Validation Rules
        private static bool HireDateGTEndDate<T>(T target, RuleArgs e) where T : Worker
        {
            if (target.EndDate.HasValue && target.HireDate > target.EndDate)
            {
                e.Description = Resources.WorkerDatesError;
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool ConflictingWorkPeriod<T>(T target, RuleArgs e) where T : Worker
        {
            if (target.DepartmentID != null)
            {
                using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
                {
                    var data = ctx.DataContext.Workers.Where(x => x.ID_Person == target.PersonID && x.ID_Department == target.DepartmentID && x.ID != target.MainID);
                    foreach(var row in data)
                    {
                        if (row.End_date.HasValue)
                        {
                            if (target.HireDate >= row.Hire_date && target.HireDate <= row.End_date)
                            {
                                e.Description = Resources.WorkerJobError;
                                return false;
                            }
                            if (target.EndDate.HasValue && target.EndDate >= row.Hire_date && target.EndDate <= row.End_date)
                            {
                                e.Description = Resources.WorkerJobError;
                                return false;
                            }
                        }
                        else
                        {
                            if (target.HireDate >= row.Hire_date)
                            {
                                e.Description = Resources.WorkerJobError;
                                return false;
                            }
                            if (target.EndDate.HasValue && target.EndDate >= row.Hire_date)
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

        #region  Data Access
        public static void AddWorker(int personId, int departmentId, string role, DateTime? hireDate, DateTime? endDate)
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Dal.Worker w = new Dal.Worker
                {
                    //ID = MainID,
                    Role = role,
                    ID_Person = personId,
                    ID_Department = departmentId,
                    Hire_date = (DateTime)hireDate,
                    End_date = endDate
                };

                ctx.DataContext.Workers.Add(w);
                ctx.DataContext.SaveChanges();
            }
        }

        public static void UpdateWorker(int mainId, int personId, int departmentId, string role, DateTime? hireDate, DateTime? endDate)
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Dal.Worker w = ctx.DataContext.Workers.Where(x => x.ID == mainId).Single();

                w.ID_Department = departmentId;
                w.ID_Person = personId;
                w.Role = role;
                w.Hire_date = (DateTime)hireDate;
                w.End_date = endDate;

                ctx.DataContext.SaveChanges();
            }
        }

        public static void RemoveWorker(int mainID)
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                var w = ctx.DataContext.Workers.Find(mainID);
                if (w != null)
                {
                    ctx.DataContext.Workers.Remove(w);
                    ctx.DataContext.SaveChanges();
                }
            }
        }
        #endregion
    }
}
