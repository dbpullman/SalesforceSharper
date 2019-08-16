using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Tests
{
    [TestClass]
    public class TypeExtensionTests
    {
        [TestMethod]
        public void GetObjectNameShouldReturnAttributeNameWhenAttributeIsPresent()
        {
            var name = typeof(CustomObjectWithAttribute).GetObjectName();

            Assert.AreEqual("CustomObject__c", name);
        }

        [TestMethod]
        public void GetObjectNameShouldReturnTypeNameWithNoAttribute()
        {
            var name = typeof(CustomObjectWithoutAttribute).GetObjectName();

            Assert.AreEqual("CustomObjectWithoutAttribute", name);
        }
    }
}
