using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Tests
{
    [TestClass]
    public class HttpMethodExtensionTests
    {
        [TestMethod]
        public void IsOneOfShouldReturnTrueWhenHttpMethodIsInProvidedParams()
        {
            HttpMethod m = HttpMethod.Get;
            var isOneOf = m.IsOneOf(HttpMethod.Get, HttpMethod.Post);

            Assert.AreEqual(true, isOneOf);
        }

        [TestMethod]
        public void IsOneOfShouldReturnFalseWhenHttpMethodIsNotInProvidedParams()
        {
            HttpMethod m = HttpMethod.Get;
            var isOneOf = m.IsOneOf(HttpMethod.Post, HttpMethod.Put);

            Assert.AreEqual(false, isOneOf);
        }
    }
}
