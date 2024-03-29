ToDo App
This project is a simple ToDo application built using .NET MAUI for the frontend and Minimal Web API for the backend. It utilizes SQLite as the database to store ToDo items.

Features
Get all ToDo items
Create a new ToDo item
Update an existing ToDo item
Delete a ToDo item
Prerequisites
.NET 6 SDK
Visual Studio 2022 or Visual Studio Code with appropriate extensions
SQLite database engine
Getting Started
Clone the repository:
bash
Copy code
git clone <repository_url>
Open the solution in your preferred IDE.

Ensure that the necessary dependencies are installed.

Build and run the application.

Database Setup
The application uses SQLite as the database. The database file (todo.db) is automatically created when the application runs for the first time.

Usage
The application exposes the following APIs:

GET /api/todo: Retrieves all ToDo items.
POST /api/todo: Creates a new ToDo item.
PUT /api/todo/{id}: Updates an existing ToDo item by ID.
DELETE /api/todo/{id}: Deletes a ToDo item by ID.
Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.
