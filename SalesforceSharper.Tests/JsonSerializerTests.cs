using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharp.Tests
{
    [TestClass]
    public class JsonSerializerTests
    {
        [TestMethod]
        public void SerializeShouldReturnStringOfObject()
        {
            var ser = new JsonSerializer();

            var acct = new Account() { Id = "1234", Name = "Test Account" };

            var str = ser.Serialize(acct);

            Assert.AreEqual("{\r\n  \"Id\": \"1234\",\r\n  \"Name\": \"Test Account\"\r\n}", str);
        }

        [TestMethod]
        public void DeserializeShouldReturnObjectFromString()
        {
            var ser = new JsonSerializer();

            var str = "{\"Id\": \"1234\",\"Name\": \"Test Account\"}";

            var acct = ser.Deserialize<Account>(str);

            Assert.AreEqual("1234", acct.Id);
            Assert.AreEqual("Test Account", acct.Name);
        }

        [TestMethod]
        public void SerializeWithFieldAttributeShouldGenerateFieldNameAsJsonProperty()
        {
            var ser = new JsonSerializer();

            var acct = new CustomAccount() { Id = "1234", Name = "Test Account" };

            var str = ser.Serialize(acct);

            Assert.AreEqual("{\r\n  \"Id\": \"1234\",\r\n  \"Name__c\": \"Test Account\"\r\n}", str);
        }
    }
}
