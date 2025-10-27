# Todo API

A RESTful API built with ASP.NET Core using the MVC pattern to manage todo items. The API supports CRUD operations, with an in-memory database for development.

## Features
- **CRUD Operations**: Create, read, update, and delete todo items via endpoints like `GET api/Todo`, `POST api/Todo`, `PUT api/Todo/{id}`, and `DELETE api/Todo/{id}`.
- **Default Values**: `IsCompleted` defaults to `false` if not provided in POST requests.
- **Dependency Injection**: Uses DI to inject `TodoDbContext` and `ITodoService` for modularity.
- **Swagger UI**: Interactive API documentation and testing at `/swagger`.

## Tech Stack
- **ASP.NET Core**: Web API framework.
- **Entity Framework Core**: ORM with in-memory database for development.
- **C# Records and Classes**: `TodoModel` for data structure.
- **Swashbuckle.AspNetCore**: Swagger for API documentation.

## Setup Instructions
1. **Prerequisites**:
   - .NET 9 SDK
   - Postman or Swagger for testing
2. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd TodoApi
   ```
3. **Install Dependencies**:
   ```bash
   dotnet restore
   ```
4. **Run the API**:
   ```bash
   dotnet run
   ```
   - Access the API at `https://localhost:5248/api/todo`.
   - Use Swagger at `https://localhost:5248/swagger`.
5. **Test Endpoints**:
   - **Create Todo**: `POST api/todo` with JSON:
     ```json
     { "title": "Buy groceries" }
     ```
     - Response includes auto-generated `Id` and `IsCompleted: false`.
   - **Get All Todos**: `GET api/todo`
   - **Get Todo by ID**: `GET api/todo/{id}`
   - **Update Todo**: `PUT api/todo/{id}`
   - **Delete Todo**: `DELETE api/todo/{id}`

## Project Structure
- **Models**: `TodoModel` (class with auto-generated GUID `Id`, required `Title`, default `IsCompleted`) and `CreateTodoDto` for input validation.
- **Services**: `ITodoService` and `TodoService` handle business logic and database operations.
- **Controllers**: `TodoController` manages HTTP requests with routes like `api/todo`.
- **Data**: `TodoDbContext` manages database access using EF Core.

## Future Improvements
- Transition to PostgreSQL for persistent storage.
- Add filtering (e.g., `GET api/todo/incomplete`) and pagination.
- Implement JWT authentication and role-based authorization.
- Enhance error handling with custom middleware.

## Notes
- In-memory database used for development; will switch to PostgreSQL for production.
