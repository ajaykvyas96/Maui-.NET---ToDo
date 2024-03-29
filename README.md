## ToDo App
This project is a simple ToDo application built using .NET MAUI for the frontend and Minimal Web API for the backend. It utilizes SQLite as the database to store ToDo items.

# Features
Get all ToDo items
Create a new ToDo item
Update an existing ToDo item
Delete a ToDo item

# Prerequisites
.NET 6 SDK
Visual Studio 2022 or Visual Studio Code with appropriate extensions
SQLite database engine

# Getting Started
Clone the repository: git clone https://github.com/ajaykvyas96/Maui-.NET---ToDo.git
There are two sulutions. 
1. ToDoWebApi - Web api
2. ToDoMauiClient - Maui Client
Open the solution in Visual Studio.
Ensure that the necessary dependencies are installed.
Run database migration in web api solution.
Build and run the application.

# Database Setup
The application uses SQLite as the database. The database file (todo.db) is automatically created when the application runs for the first time. If it does not create, please run migration command as below
update-database in package manager console.

# Usage
The web api exposes the following APIs:

GET /api/todo: Retrieves all ToDo items.
POST /api/todo: Creates a new ToDo item.
PUT /api/todo/{id}: Updates an existing ToDo item by ID.
DELETE /api/todo/{id}: Deletes a ToDo item by ID.

