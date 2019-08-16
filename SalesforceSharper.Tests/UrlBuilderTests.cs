using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharper.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Tests
{
    [TestClass]
    public class UrlBuilderTests
    {
        [TestMethod]
        public void QueryBuilderShouldReturnPathWithApiVersionAndQuery()
        {
            var url = new QueryUrlBuilder("v45.0")
                .WithQuery("SELECT Id FROM Account")
                .ToString();

            Assert.AreEqual("/services/data/v45.0/query/?q=SELECT Id FROM Account", url);
        }

        [TestMethod]
        public void SObjectUrlBuilderShouldReturnSObjectUrlWithNoId()
        {
            var url = new SObjectUrlBuilder("v45.0")
                .ForSObject("Account")
                .ToString();

            Assert.AreEqual("/services/data/v45.0/sobjects/Account", url);
        }

        [TestMethod]
        public void SObjectUrlBuilderShouldReturnSObjectUrlWithId()
        {
            var url = new SObjectUrlBuilder("v45.0")
                .ForSObject("Account")
                .WithId("1234567812345678")
                .ToString();

            Assert.AreEqual("/services/data/v45.0/sobjects/Account/1234567812345678", url);
        }
    }
}
