using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Csla;
using Csla.Data;
using Csla.Validation;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
    // Dodaje i mijenja osobu.
    [Serializable()]
    public class Person : BusinessBase<Person>
    {
        #region Constructors
        private Person()
        {
        }
        #endregion

        #region  Properties
        private static PropertyInfo<int> PersonIdProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Person>(x => x.PersonId)));
        public int PersonId
        {
            get { return GetProperty(PersonIdProperty); }
        }

        private static PropertyInfo<string> PersonSurnameProperty =
          RegisterProperty(typeof(Person), new PropertyInfo<string>(Reflector.GetPropertyName<Person>(x => x.PersonSurname)));
        public string PersonSurname
        {
            get { return GetProperty(PersonSurnameProperty); }
            set { SetProperty(PersonSurnameProperty, value); }
        }

        private static PropertyInfo<string> PersonNameProperty =
          RegisterProperty(new PropertyInfo<string>(Reflector.GetPropertyName<Person>(x => x.PersonName)));
        public string PersonName
        {
            get { return GetProperty(PersonNameProperty); }
            set { SetProperty(PersonNameProperty, value); }
        }
        #endregion

        #region Calculated Properties
        public string PersonFullName
        {
            get { return PersonSurname + ", " + PersonName; }
        }
        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.StringRequired, PersonName);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(PersonNameProperty, 20));

            ValidationRules.AddRule(CommonRules.StringRequired, PersonSurname);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(PersonSurnameProperty, 20));
        }
        #endregion

        #region Factory Methods
        public static Person New()
        {
            return DataPortal.Create<Person>();
        }

        public static void Delete(int personId)
        {
            DataPortal.Delete<Person>(new SingleCriteria<Person, int>(personId));
        }

        public static Person Get(int personId)
        {
            return DataPortal.Fetch<Person>(new SingleCriteria<Person, int>(personId));
        }
        #endregion

        #region Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch(SingleCriteria<Person, int> criteria)
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                var data = ctx.DataContext.People.Find(criteria.Value);

                LoadProperty(PersonIdProperty, data.ID);
                LoadProperty(PersonNameProperty, data.Name);
                LoadProperty(PersonSurnameProperty, data.Surname);

                //LoadProperty(ProjektiOsobeProperty, ProjektOsobeList.Load(data.UlogaOsobe.ToArray()));
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Dal.Person o = new Dal.Person
                {
                    Name = PersonName,
                    Surname = PersonSurname
                };

                ctx.DataContext.People.Add(o);
                ctx.DataContext.SaveChanges();

                LoadProperty(PersonIdProperty, o.ID);

                FieldManager.UpdateChildren(this);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                Dal.Person o = ctx.DataContext.People.Find(this.PersonId);

                o.Name = PersonName;
                o.Surname = PersonSurname;

                FieldManager.UpdateChildren(this);

                ctx.DataContext.SaveChanges();
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<Person, int>(PersonId));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SingleCriteria<Person, int> criteria)
        {
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                var o = ctx.DataContext.People.Find(criteria.Value);
                if (o != null)
                {
                    ctx.DataContext.People.Remove(o);
                    ctx.DataContext.SaveChanges();
                }
            }
        }
        #endregion
        #endregion

        #region  Exists
        public static bool Exists(int personId)
        {
            return ExistsCommand.Exists(personId);
        }

        #region Exists Command
        [Serializable()]
        private class ExistsCommand : CommandBase
        {
            #region Execute
            public static bool Exists(int id)
            {
                return DataPortal.Execute<ExistsCommand>(new ExistsCommand(id)).personExists;
            }
            #endregion

            #region Constructors
            private ExistsCommand(int personId)
            {
                this.personId = personId;
            }
            #endregion

            #region Properties
            public int personId { get; private set; }
            public bool personExists { get; private set; }
            #endregion

            #region Data Access
            #region DataPortal Methods
            protected override void DataPortal_Execute()
            {
                using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
                {
                    personExists = ctx.DataContext.People.Where(x => x.ID == personId).Count() > 0;
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
            return GetProperty(PersonIdProperty).ToString();
        }
        #endregion
    }
}
