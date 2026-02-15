# Library Manager (.NET MVC)

A full-stack Book Management System built with **ASP.NET Core MVC**. This is a 1:1 port of my Library Manager React/Node.js application on [my website](https://librarymanager.asifulmislam.com/). This implements secure authentication, book ownership, and relationship management.

## Features

* **Authentication:** Secure Login and Registration using Cookie Authentication and BCrypt password hashing.
* **Authorization:** Role-based access control where users can only Edit or Delete books they personally created.
* **Data Management:** * Create, Read, Update, and Delete (CRUD) for Books.
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

1.  Clone the repository:
    ```bash
    git clone [https://github.com/yourusername/library-manager.git](https://github.com/yourusername/library-manager.git)
    cd library-manager
    ```

2.  Install dependencies:
    ```bash
    dotnet restore
    ```

3.  Run the application:
    ```bash
    dotnet run
    ```

4.  Open your browser to the local host URL (typically `http://localhost:5xxx`).

## Usage Guide

1.  **Register:** Create a new account. The app uses an In-Memory database, so data resets every time you restart the server.
2.  **Add Author:** You must create an Author (e.g., "J.R.R. Tolkien") before you can create a book.
3.  **Add Book:** Create a book linked to that author.
4.  **Manage:** You will see "Edit" and "Delete" buttons only for books you created. Books created by others will show "No actions".

## Project Structure

* `Controllers/`: Handles incoming requests and logic (Account, Books, Authors).
* `Models/`: Database entities and constraints (User, Book, Author).
* `Views/`: Razor HTML templates for the UI.
* `Data/`: Database context and seed data configuration.