using SalesforceSharper.Attributes;

namespace SalesforceSharper.Tests
{
    public class Account
    {
        public string Id { get; set; }

       
        public string Name { get; set; }
    }

    public class CustomAccount
    {
        public string Id { get; set; }

        [SalesforceField("Name__c")]
        public string Name { get; set; }
    }
}
