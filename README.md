# FunBooksAndVideos e-Commerce shop

This is fun implmenentation of FunBooksAndVideos e-Commerce shop
This solution introduce clean architecture approach combining CQRS with DDD.

There are two 'Aggregate Roots' existing within this project - `PurchaseOrder` and `Customer`.

In order to communicate between 'Aggregates' event-driven technique is used.
To sum it up - event is triggered according to business / domain rules and when `SavingChanges` in Infrastructure layer occurs it is published using `IMediator Publish()` method.

- For a <strong>Business Rule 1</strong> (regarding membership) Event handler is redirecting logic to `UpdateCustomerMembershipCommandHandler`
- For a <strong>Business Rule 1</strong> (regarding ordering physical product) - `PhysicalProductPurchasedHandler` Event handler consumes event and publish according message to queue message bus

<br>

## Tests
------
This solution introduced two types of tests, unit and integrations tests.

Integration tests are testing what is saved in database and if proper message was published to the queue message bus using `MassTransit.GetTestHarness()`.


## Introduction
------
FunBooksAndVideos is an e-commerce shop where customers can purchase books and videos. Users can have memberships for the book club, the video club or for both clubs (premium).

<br>

## Purchase Order 
------
A purchase order can contain products or membership requests. A purchase order has an PO ID, a customer ID and total price. There is an item

line in the purchase order per product purchased (product, membership type). One example of a purchase order is the following:

```
Purchase Order: 3344656

Total: 48.50

Customer: 4567890

Item lines:

-	Video "Comprehensive First Aid Training"

-	Book "The Girl on the train"

-	Book Club Membership
```

<br>

## Business Rules
------

Several business rules are applied when a purchase order is processed. Some of the business rules are shown in this list:

-	BR1. If the purchase order contains a membership, it has to be activated in the customer account immediately.

-	BR2. If the purchase order contains a physical product a shipping slip has to be generated.
