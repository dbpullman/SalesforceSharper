# SalesforceSharp

SalesforceSharp is a light-weight, easy to use asynchronous REST client for Salesforce written in .NET.

## Usage

To use SalesforceSharp, you must authenticate before making any other method calls:

```csharp
var auth = new UsernamePasswordAuthenticator("<ConsumerKey>",
                "<ConsumerSecret>",
                "<Username>",
                "<Password>");

var authInfo = await auth.Authenticate();

var client = new SalesforceClient(authInfo.InstanceUrl, authInfo.AccessToken);
```

After authenticated, you can begin to use the client:

### Query

The query method will return 2000 records matching a query. To query more than 2000 records, us the QueryAll<>() method (example below)

```csharp
var accounts = await client.Query<Account>("SELECT Id, Name FROM Account");
```

### Query All

The query all functionality will query all records (or the specified records in the LIMIT clause) and return more than 2000 records.

```csharp
var accounts = await client.QueryAll<Account>("SELECT Id, Name FROM Account");
```

### Create

To create a record:

```csharp
var acct = new Account()
{
  Name = "Test Account"
};

var createdAccount = await client.Create<Account>(acct);
```
or
```csharp
var createdAccount = await client.Create("Account", acct);
```

### Update

To update a record:

```csharp
var updatedAccount = new Account()
{
  Name = "Updated Test Account"
};

var updated = await client.Update<Account>("<recordId>", updatedAccount);
```
or
```csharp
var updated = await client.Update("Account", "<recordId>", updatedAccount);
```

### Delete

To delete a record:

```csharp
var deleted = await client.Delete<Account>("<recordId>");
```
or
```csharp
var deleted = await client.Delete("Account", "<recordId>");
```

### Attribute Usage

There is a SalesforceObjectAttribute that can be used to name a class to match the object name in Salesforce. This is used in the Update, Create, and Delete methods to determine the object name and URL:

```csharp
[SalesforceObject("Custom_Object__c")]
public class CustomObject
{
  public string Id { get; set; }
  public string Name { get; set; }
}

var customObj = new CustomeObject()
{
  Id = "1234567891011",
  Name = "Custom Object Name"
};

var created = await client.Create<CustomObject>(customObj);
```

The above method call would result in the following URL being used to make the API call ```/services/data/v45.0/Custom_Object__c```

This allows you to name your objects what you want on the client side and helps keep the client side code cleaner and more readable.
