# RestAPIBasics - Country Information API

## Overview

RestAPIBasics is an API built with **ASP.NET Core** that provides two endopoint. The first endpoint accepts an array of integers to return the **second largest number**. The second endpoint retrieves data from the **third-party API** (https://restcountries.com), stores the data in a **SQL Server database**, and caches it in **MemoryCache** for optimal performance. The API supports retrieving country details such as name, capitals, and borders.

---

## Features

- **GET** `/api/v1/numbers`: Accepts an array of integers and returns the second largest number from the array.
- **GET** `/api/countries`: Retrieves a list of countries, their name, capitals, and borders.
- Data fetched from the **third-party API** is saved to a **SQL Server** database and cached using **MemoryCache**.
- **Swagger** for easy exploration and testing of the API endpoints.

---
## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/pkyriakou23/RestAPIBasics.git
```

### 2. Set up SQL Server Database
Create a new database called CountriesDB in your SQL Server instance (either local or remote).

Update the current connection string (if needed) in the Program.cs to point to your database.
```
builder.Services.AddDbContext<CountryContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=CountriesDB;Trusted_Connection=True;TrustServerCertificate=True;");
});
```

### 3. Import the solution into Visual Studio
Open the solution using Visual Studio

### 4. Apply Migrations
Migrations are used to create and update the database schema based on your Entity Framework Core models. Run the following command in **Package Manager Console**
```
Update-Database
```

### 5. Run the Application
You are now ready to run the application.

Press F5 or Ctrl + F5 in Visual Studio to start the application.
The Swagger UI will open in your browser to test the API.

#### API Documentation
For additional details on the API documentation, you can refer to the Swagger YAML file (Swagger/RestAPIBasicsSwagger.yaml) which contains the OpenAPI specification. This file can be used with a [Swagger editor](https://editor.swagger.io/) to visualize the API endpoints, data models, and request/response structures.

#### Additional Implementation
For more complex use cases or future scalability, it’s better to consider breaking the current CountryData table into separate tables for:
- CountryName: Store the common and official names.
- Capitals: Store the capitals.
- Borders: Store the borders (country codes).

These among other details that may be needed, can be connected through foreign keys to maintain a clear relationship between the data.

#### Known Limitations
- Not production-ready: The application is designed for development and testing purposes and lacks certain authorizations and security features needed for production use.
- Configuration: The current configuration assumes a development environment with local database access.
