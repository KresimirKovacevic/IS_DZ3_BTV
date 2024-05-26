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
    public class DateGTTests
    {
        [Test]
        public void correctCase1()
        {
            var date1 = new DateTime(2000, 1, 1);
            var date2 = new DateTime(2001, 1, 1);
            bool corr = true;
            Assert.IsTrue(Worker.HireDateGTEndDate(date1, date2));
        }

        [Test]
        public void correctCase2()
        {
            var date1 = new DateTime(2000, 1, 1);
            var date2 = new DateTime(2000, 2, 1);
            bool corr = true;
            Assert.IsTrue(Worker.HireDateGTEndDate(date1, date2));
        }

        [Test]
        public void correctCase3()
        {
            var date1 = new DateTime(2000, 1, 1);
            var date2 = new DateTime(2000, 1, 2);
            bool corr = true;
            Assert.IsTrue(Worker.HireDateGTEndDate(date1, date2));
        }

        [Test]
        public void equalCase_true()
        {
            var date1 = new DateTime(2000, 1, 1);
            var date2 = new DateTime(2000, 1, 1);
            bool corr = true;
            Assert.IsTrue(Worker.HireDateGTEndDate(date1, date2));
        }

        [Test]
        public void falseCase1()
        {
            var date1 = new DateTime(2000, 1, 1);
            var date2 = new DateTime(1998, 1, 1);
            bool corr = true;
            Assert.IsFalse(Worker.HireDateGTEndDate(date1, date2));
        }

        [Test]
        public void falseCase2()
        {
            var date1 = new DateTime(2000, 12, 13);
            var date2 = new DateTime(2000, 12, 12);
            bool corr = true;
            Assert.IsFalse(Worker.HireDateGTEndDate(date1, date2));
        }
    }
}
