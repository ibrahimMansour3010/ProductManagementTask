# Product Management Task

This repository contains a full-stack implementation of a Product Management Task. The project is divided into two parts:
- Backend API built with ASP.NET Core.
- Frontend application built with Angular.

## Prerequisites
Ensure you have the following installed on your system:
- **SQL Server**
- **.NET 8 SDK** or higher
- **Node.js** and **npm**
- **Angular CLI** 19

---

## Instructions to Set Up the Project

### 1. Create the Database
1. Open SQL Server Management Studio (SSMS).
2. Create a new database with the name: `ProductManagementTaskDB`.

### 2. Run SQL Scripts
1. Locate the `schema.sql` and `data.sql` files in the repository.
2. Execute `schema.sql` to create the database schema.
3. Execute `data.sql` to populate the database with initial data.

### 3. Run the API Project
1. Navigate to the `API` project folder using a terminal:
   ```bash
   cd path/to/api/project
   ```
2. Restore dependencies and build the project:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Start the API:
   ```bash
   dotnet run
   ```
4. The API will be accessible at `https://localhost:51208` (check the terminal output for the exact port).

### 4. Run the Angular Project
1. Navigate to the `Angular` project folder using a terminal:
   ```bash
   cd path/ProductManagementTask.clientApp
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Start the Angular project:
   ```bash
   ng serve
   ```
4. The application will be accessible at `http://localhost:4200`.

---

## Features
- Add, edit, and delete products.
- Search and sort products using a dynamic table.
- Pagination and filtering.

---

## Troubleshooting
- Ensure SQL Server is running and the database is created before starting the API.
- Use compatible versions of Node.js and Angular CLI as per the project dependencies.
- Check for any CORS issues and configure the API project accordingly if needed.

---

## Contribution
Feel free to fork the repository and submit pull requests. For major changes, please open an issue first to discuss what you would like to change.



