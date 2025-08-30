# Sample ASP.NET Core Project

A simple project showing how to build a clean and testable ASP.NET Core application.

## How It's Built

This project follows a few core ideas to keep the code clean and easy to maintain.

* **Tests First (TDD):** Tests are written before the code to guide development and ensure functionality.

* **Clean & Organized Architecture:** Uses **Clean Architecture** and **Domain-Driven Design (DDD)** to keep the core business logic separate from the UI and database. It also leverages the **CQRS pattern** with **MediatR** to decouple commands and queries, making the application easier to scale and maintain.

* **Clear Error Handling:** Returns an [**Either**](https://mikhail.io/2016/01/validation-with-either-data-type-in-csharp/) type for explicit success or error results, which prevents application crashes. A [**ControllerEitherExtension**](Shared/Types/ControllerEitherExtensions.cs) is used to simplify handling these results within the controllers.

  * [**Nothing**](Shared/Types/Nothing.cs) is used for success cases that don't return a value.
  * [**EitherExtensions**](Shared/Types/EitherExtensions.cs) are included to help with async operations.

* **Solid Validation:** A [**Guard**](Shared/Types/Guard.cs) pattern collects all [**validation**](Shared/Types/Validation.cs) errors at once, rather than failing on the first one.

* **Safe IDs:** Uses strongly-typed **ValueObjects** (like `BookmarkId`) instead of a plain `Guid` to improve type safety and prevent bugs.

## Key Features

* **Approach:** Test-Driven Development (TDD)

* **Architecture:** Clean Architecture + DDD

* **Pattern:** CQRS with MediatR

* **Error Handling:** `Either` type for clear success or failure, with `ControllerEitherExtension` for easy implementation.

* **Validation:** `Guard` pattern to collect all errors at once

* **IDs:** Specific, strongly-typed IDs for better safety

