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
    public class LocationParseTests
    {
        [Test]
        public void correctInput_ints()
        {
            bool result = Department.LocationValid("0:0");
            Assert.IsTrue(result);
        }

        [Test]
        public void correctInput_intANDfloat()
        {
            bool result = Department.LocationValid("1:2.1");
            Assert.IsTrue(result);
        }

        [Test]
        public void correctInput_floats()
        {
            bool result = Department.LocationValid("4.2:11.11");
            Assert.IsTrue(result);
        }

        [Test]
        public void falseInput_null()
        {
            bool result = Department.LocationValid(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void falseInput_empty()
        {
            bool result = Department.LocationValid("");
            Assert.IsFalse(result);
        }

        [Test]
        public void falseInput_oneValue()
        {
            bool result = Department.LocationValid("45");
            Assert.IsFalse(result);
        }

        [Test]
        public void falseInput_threeValues()
        {
            bool result = Department.LocationValid("44.4:-55:-1");
            Assert.IsFalse(result);
        }

        [Test]
        public void falseInput_strings()
        {
            bool result = Department.LocationValid("4d:a5");
            Assert.IsFalse(result);
        }

        [Test]
        public void falseInput_extraDecimals()
        {
            bool result = Department.LocationValid("-9.7:7.8.9");
            Assert.IsFalse(result);
        }
    }
}
