## Task Management API

This is the backend API for the Task Management application, built with **ASP.NET Core Web API**. It provides endpoints for user authentication, task management, and task assignments.

---

### Prerequisites

- **.NET 8 SDK**: [Download Link](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Entity Framework Core Tools**: Install with the command:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

### Getting Started

1. **Clone the Repository**
   ```bash
   git clone https://github.com/slymnGms/task-management-tekhnelogos-api.git
   cd task-management-api
   ```

2. **Configure the Database**

   - Open `appsettings.json`.
   - Replace the connection string with your own:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Your Database Connection String Here"
     },
     "JwtSettings": {
       "Secret": "YourSecretKey"
     }
     ```

3. **Apply Migrations**

   Run the following command to create the database and apply migrations:
   ```bash
   dotnet ef database update
   ```

---

### Running the Application

Start the API using the .NET CLI:
```bash
dotnet run
```

The API will be running at `http://localhost:5209` or `https://localhost:7072`.

---

### API Endpoints

- **User Authentication**
  - `POST /api/users/register` - Register a new user.
  - `POST /api/users/login` - Login and receive a JWT token.
  - `POST /api/users` - Get all users to assing tasks.

- **Tasks**
  - `GET /api/tasks` - Get all tasks.
  - `POST /api/tasks` - Create a new task.
  - `GET /api/tasks/mytasks` - Get tasks assigned to the authenticated user.
  - `GET /api/tasks/tasks-by-users` - List of tasks of grouped by users.
  - `GET /api/tasks/attended-tasks` - List of tasks of current user of daily tasks by due date.

- **Task Assignments**
  - `POST /api/tasks/assign` - Assign tasks to users.
  - `DELETE /api/tasks/assignments/{userId}/{taskId}` - Delete a task assignment.

---

### Project Structure

- **Controllers/** - API endpoint controllers.
- **Data/** - Database context and migrations.
- - **Models/** - Data models.
- - **Repositories/** - Data access layer.
- **Services/** - Business logic implementations.
- - **Dtos/** - Data transfer objects.

---

### Notes

- Ensure your `JwtSettings:Secret` is a strong, unique key.
- Use `dotnet ef migrations add MigrationName` to create new migrations after model changes.
- CORS is enabled to allow requests from the frontend application.
