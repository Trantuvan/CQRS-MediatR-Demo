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
