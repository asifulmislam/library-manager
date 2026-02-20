# Library Manager (.NET MVC)

A full-stack Book Management System built with **ASP.NET Core MVC**. This is a 1:1 port of my Library Manager React/Node.js application on [my website](https://librarymanager.asifulmislam.com/). This implements secure authentication, book ownership, and relationship management.

## Features

* **Authentication:** Secure Login and Registration using Cookie Authentication and BCrypt password hashing.
* **Authorization:** Role-based access control where users can only Edit or Delete books they personally created.
* **Data Management:** 
    * Create, Read, Update, and Delete (CRUD) for Books.
    * Create and Read for Authors.
    * Search functionality for filtering books by title.
* **Architecture:** MVC (Model-View-Controller) pattern using Entity Framework Core.

## Tech Stack

* **Framework:** ASP.NET Core 10.0 (MVC)
* **Database:** Entity Framework Core (In-Memory Database for testing)
* **Security:** `BCrypt.Net-Next` for password hashing.
* **Frontend:** Razor Views with Bootstrap styling.

## Getting Started

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) (Version 10.0 or later)

### Installation

1.  Clone the repository.

2.  Install dependencies:
    ```bash
    dotnet restore
    ```

3.  Build and run the application:
    ```bash
    dotnet build
    dotnet run
    ```

4.  Open your browser to the local host URL (typically `http://localhost:5xxx`).

## Usage Guide

### Default State
- The application starts with **no user logged in**.
- Two sample books ("1984" and "Animal Farm" by George Orwell) are pre-loaded in the system.
- These books belong to a default test user for demonstration purposes.

### Testing the Application

#### Option 1: Use the Default Test Account
To test the full functionality immediately:
1. **Login** with the pre-configured test account:
   - **Username:** `foo`
   - **Password:** `bar`.
2. You'll be able to **Edit** and **Delete** the two default books since they belong to this user
3. You can also create new books and authors.

#### Option 2: Create Your Own Account
1. **Register** a new account with your own credentials.
2. **Important:** You must **create Authors first** before adding books (Authors → Add Author).
3. **Add Books** linked to the authors you created.
4. You'll only see "Edit" and "Delete" buttons for books **you** created.
5. Books created by other users (including the default ones) will show "No actions".

### Key Workflow Notes
- **Authors must be created before books** - you cannot add a book without an existing author.
- **Book ownership is enforced** - you can only modify books you personally created.
- **Data resets on restart** - the app uses an In-Memory database, so all data (except defaults) is lost when you restart the server.

## Project Structure

* `Controllers/`: Handles incoming requests and logic (Account, Books, Authors).
* `Models/`: Database entities and constraints (User, Book, Author).
* `Views/`: Razor HTML templates for the UI.
* `Data/`: Database context and seed data configuration.