using Csla;
using Csla.Data;
using Csla.Validation;
using NUnit.Framework;
using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UpravljanjeProjektima.Admin;
using UpravljanjeProjektima.Properties;
using static Csla.Security.MembershipIdentity;

namespace UpravljanjeProjektima
{
    [TestFixture]
    public class ConnectionTest
    {

        //private string connectionString = "metadata=res://*/BTVModel.csdl|res://*/BTVModel.ssdl|res://*/BTVModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-PC52VDS\\SQLEXPRESS;initial catalog=BTVdb;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        //private string connectionString = "metadata=res://*/Projekti.csdl|res://*/Projekti.ssdl|res://*/Projekti.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(local)\\SQLEXPRESS;initial catalog=Projekt;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

        [Test]
        public void basicConnectionTest()
        {
            Assert.DoesNotThrow(() => {
                //using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(connectionString))
                using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
                {
                    ctx.DataContext.Database.Exists();
                }
            });
        }

        [Test]
        public void basicTableTest()
        {
            Assert.DoesNotThrow(() =>
            {
                //using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(connectionString))
                using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
                {
                    ctx.DataContext.Kingdom_t.ToList().Count();
                    ctx.DataContext.Phylum_t.ToList().Count();
                    ctx.DataContext.Class_T.ToList().Count();
                    ctx.DataContext.Order_t.ToList().Count();
                    ctx.DataContext.Family_t.ToList().Count();
                    ctx.DataContext.Genus_t.ToList().Count();
                    ctx.DataContext.Species_t.ToList().Count();
                    ctx.DataContext.People.ToList().Count();
                    ctx.DataContext.Departments.ToList().Count();
                    ctx.DataContext.Workers.ToList().Count();
                    ctx.DataContext.Individuals.ToList().Count();
                    ctx.DataContext.Sensors.ToList().Count();
                    ctx.DataContext.Guests.ToList().Count();
                    ctx.DataContext.Assignments.ToList().Count();
                    ctx.DataContext.Locations.ToList().Count();
                }
            });
        }

        [Test]
        public void tableFillTest()
        {
            int i = 0, corr = 0;
            //using (var ctx = Dal.ContextManager<Dal.ProjektDataContext>.GetManager(connectionString))
            using (var ctx = Dal.ContextManager<Dal.BTVDataContext>.GetManager(Dal.Database.BTVConnectionString))
            {
                if(ctx.DataContext.Kingdom_t.ToList().Count == 0)i++;
                if(ctx.DataContext.Phylum_t.Count() == 0)i++;
                if(ctx.DataContext.Class_T.Count() == 0) i++;
                if(ctx.DataContext.Order_t.Count() == 0) i++;
                if(ctx.DataContext.Family_t.Count() == 0) i++;
                if(ctx.DataContext.Genus_t.Count() == 0) i++;
                if(ctx.DataContext.Species_t.Count() == 0) i++;
                if(ctx.DataContext.People.Count() == 0) i++;
                if(ctx.DataContext.Departments.Count() == 0) i++;
                if(ctx.DataContext.Workers.Count() == 0) i++;
                if(ctx.DataContext.Individuals.Count() == 0) i++;
                if(ctx.DataContext.Sensors.Count() == 0) i++;
                if(ctx.DataContext.Guests.Count() == 0) i++;
                if(ctx.DataContext.Assignments.Count() == 0) i++;
                if(ctx.DataContext.Locations.Count() == 0) i++;
            }
            Assert.AreEqual(i, corr);
        }
    }
}
