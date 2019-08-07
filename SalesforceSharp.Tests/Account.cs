using SalesforceSharp.Attributes;

namespace SalesforceSharp.Tests
{
    public class Account
    {
        public string Id { get; set; }

        [SalesforceField("Name__c")]
        public string Name { get; set; }
    }
}
