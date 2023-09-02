# MediatR

### MediatR Request

MediatR Requests are very simple request-response style messages, where a single request is synchronously handled by a single handler (synchronous from the request point of view, not C# internal async/await). Good use cases here would be returning something from a database or updating a database.

There are two types of requests in MediatR. One that returns a value, and one that doesn’t. Often this corresponds to reads/queries (returning a value) and writes/commands (usually doesn’t return a value).

### MediatR Notifications

So we’ve only seen a single request being handled by a single handler. However, what if we want to handle a single request by multiple handlers?

That’s where notifications come in. In these situations, we usually have multiple independent operations that need to occur after some event.

Examples might be:

- Sending an email
- Invalidating a cache

### MediatR Behaviors

Often when we build applications, we have many cross-cutting concerns. These include authorization, validating, and logging.

Instead of repeating this logic throughout our handlers, we can make use of Behaviors. Behaviors are very similar to ASP.NET Core middleware, in that they accept a request, perform some action, then (optionally) pass along the request.

### MediatR Conclusion

In this article, we’ve gone over how MediatR can be used to implement both the CQRS and Mediator patterns in ASP.NET Core. We’ve been through requests and notifications, and how to handle cross-cutting concerns with behaviors.

MediatR provides a great starting point for an application that needs to evolve from a simple monolith into a more mature application, by allowing us to separate read and write concerns, and minimizing the dependencies between code.

This puts us in a great position to take several additional possible steps:

Use a different database for the reads (perhaps by extending our `ProductAddedNotification` to add a second handler to write to a new DB, then modifying `GetProductsQuery` to read from this DB)
Split out our reads/writes into separate apps (by modifying the `ProductAddedNotification` to publish to `Kafka/Service Bus`, then having a second app read from the message bus)
We now have our app in a great position to make the above steps if the need arises, without overcomplicating things in the short term.
