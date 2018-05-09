# Overview
This is the complete code test conducted by Rebtel during hiring of new resources. 

### Requirements
 Requirements provided were as follows:
> Implement Web Api for creating user and his phone subscriptions. The logic for getting/writing data from/to DB should be in a separate WCF service. Database can be MS SQL Server or MS SQL Server Express. Client will POST/GET/PUT/DELETE data to Web Api, Web Api will connect to WCF service to write/read data from database.

Details of service API provided are given below:
#### User: 
Base-URI will be /users and API should do the following:
* Get all users (GET -> /users)
* Get current user (GET -> /users/some-url-friendly-identifier)
* Create user (POST -> /users)
* Add subscription to user (PUT -> /users/ some-url-friendly-identifier/subscriptionId)
* Delete user (DELETE -> /users/some-url-friendly-identifier)

JSON-structure for user resource:
```json
{
  "id":"some-url-friendly-identifier",
  "firstname":"First name",
  "lastname":"Last name",
  "email":"email",
  "subscriptions": [
      {
         "id":"2712e86a-d519-48af-b50b-194e9a2102de",
         "price":24.0,
         "priceIncVatAmount ":30.0,
         "callminutes":50
      },
      {
         "id":"4712e86a-d519-48af-b50b-194e9a2102dd",
         "price":14.0,
         "priceIncVatAmount":20.0,
         "callminutes":20
      },
   ],
   "totalPriceIncVatAmount":50.0,
   "totalcallminutes":70 
}
```

#### Subscription:
Base-URI will be /subscriptions and API should do the following:
* Get all subscriptions (GET -> /subscriptions)
* Get current subscription (GET -> /subscriptions/some-url-friendly-identifier)
* Create subscription (POST -> /subscriptions)
* Update subscription data such  (PUT -> /subscriptions/some-url-friendly-identifier)
* Delete subscription (DELETE -> /subscriptions/some-url-friendly-identifier)

JSON-structure for subscription resource:
```json
{
   "id":"2712e86a-d519-48af-b50b-194e9a2102de",
   "name":"50 min deal",
   "price":24.0,
   "priceIncVatAmount":30.0,
   "callminutes":50
}
```

------------

### Solution Architechture
I have divided the visual studio solution in multiple smaller projects but there are only three main categories.
1. **Business Layer**
Contains WCF services, service and data contracts and a WCF host app. There are three projects in this layer. 
	1. **Business.DTOs**
	Contains Data Contracts for WCF Service. I have separated out Service Data Contract classes from DB Model classes. And Each data contract class is sepecific to the service end point. E.g. CreateUserDTO is a data contract class which is only used in endpoint specific to user creation. 
	Mapster is used for mapping properties between these data contract and db model classes.
	2. **Business.Services**
	Contains actual service implementations. Services first recieve data from user and transform it to db model classes using Mapster. Then repositories are asked to perform database related operations. Exception handling is also provided here. Whenever an error occrs, WCF services will throw a strongly type FaultException which also contian a result code. 
	3. **Business.WCFHost**
	It is a simple service solution project which hosts services and provides all of their configurations. By separating out services from their host, I have made services host environment independent . This way we can host services in any way required. Both IIS/WAS hosting and self hosting are possible.
	This project uses SimpleInjector for implementing dependency injection and providing services dependencies.
2. **Client Layer**
Contains WebAPI services, data models, WCF client proxies and WCF service contracts. There are four projects in this layer.
	1. **Client.Entities**
	Contains Data Contracts for WCF services. These data contracts are used by client applications for communicating with WCF services.
	2. **Client.ServiceContracts**
	Contains service contracts of WCF services. These service contracts are used by client applications for communicating with WCF services.
	3. **Client.ServiceProxies**
	Contains WCF service proxies.
	4. **Client.WebAPI**
	Contains WebAPI controllers. These controllers using WCF Proxies to communicate with WCF services and act as client. This project also uses SimpleInjector for implementing dependency injection and providing WebAPI controller dependencies. I have configured service output JSON serializer to automatically format inbound and outbound property names in came case pattern. Any exception handling for client side is also being implemented here.
3. **Data Access Layer**
Contains Database model entites, respositories and database context infrastructure. It has two projects.
	1. **Business.DataEntities**
	Contains entity framework POCO models classes for database
	2. **Business.DAL**
	This project contains entity framework DbContext classes and repositories for working with database. For managing DbContext life-cycle I am using a different approach to conventional UnitOfWork pattern. Details of that approach can be found at [DbContextScope](https://github.com/mehdime/DbContextScope "DbContextScope") and [Managing DbContext the right way with Entity Framework 6](http://mehdi.me/ambient-dbcontext-in-ef6/ "Managing DbContext the right way with Entity Framework 6"). For this perticular project I have only implemented a very simplified solution for managing DbContext life-cycle.
4. **Test Layer**
Contains a single project for unit testing wcf services.
	1. **Tests**
	For a proper unit testing, usually we will need to mock Entity Framework DbContext and a lot of other classes, but due to this being a very simple and fake problem, I am not doing so. I have directly used actual DbContext in my test cases and only provided very few test cases for testing User WCF service.
5. **Common Layer**
Contains a single project which is shared between WCF and WebAPI layers. It provides common exception types and generic utility classes.
	1. **Core.Infrastructure**
	This contains some custom exceptions and an enum for Response Codes returned by WCF services when an error occurs.
