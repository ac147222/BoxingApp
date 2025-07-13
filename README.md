# BoxingApp

## Overview

BoxingApp is a comprehensive C# console application designed to manage all aspects of a boxing management system. The software supports full CRUD operations (Create, Read, Update, Delete) for entities such as Fighters, Gyms, Regions, Weightclasses, Matches, Outcome Types, Fighter-and-Gym records, and Match Outcomes. It also provides robust user authentication (login and registration), user role management (admin and standard user), and a comprehensive reporting suite for performance, statistics, and organizational insights.

---

## Features

- **User Authentication:** Secure login and registration for all users.
- **Role-based Access:** Distinction between admin and standard users, with admins having access to management menus.
- **Region, Gym, Weightclass, and Fighter Management:** Add, edit, delete, and view all core entities.
- **Match Management:** Schedule, update, and delete boxing matches with full outcome tracking.
- **Outcome Type and Match Outcome Management:** Define and manage possible match outcomes.
- **Fighter-Gym Associations:** Track which fighters train at which gyms and their records.
- **Comprehensive Reports:** Generate reports such as Fighters by Wins, Gym Fight Stats, Matches per Year, and much more.
- **Data Validation:** Extensive input validation to ensure data integrity and user guidance.
- **User-Friendly Console Menus:** Clear, navigable menus for all operations.
- **Extensive Error Handling:** Clear, actionable error messages for all invalid operations and edge cases.

---

## Key Requirements

- **.NET Core / .NET 6.0 SDK or newer**
- **SQL Server (local or remote)**
- **Basic familiarity with the command line / terminal**
- **Connection string/configuration set in the appsettings or configuration file**
- **No external dependencies beyond standard .NET libraries**

---

## Getting Started

### 1. Clone the Repository

```
git clone https://github.com/ac147222/BoxingApp.git
cd BoxingApp
```

### 2. Setup the Database

- Open the provided SQL scripts or use the built-in database setup functions to create all necessary tables.
- Ensure your SQL Server instance is running and accessible.
- Update your connection string in the configuration file (if required).

### 3. Build and Run

- Open the project in Visual Studio or use the CLI:
    ```
    dotnet build
    dotnet run
    ```

### 4. First-Time Setup

- On first launch, register an admin user.
- Log in as the admin to access all management menus.

---

## How to Use

### **Login and Registration**

- Upon launch, you will be prompted to log in or register.
- Registration requires a unique username and password.
- After logging in, you are presented with menus based on your role (admin or user).

### **Main Menu Navigation**

- Use numeric options to navigate between management menus (Regions, Gyms, Weightclasses, Fighters, Matches, Outcomes, Reports, etc.).
- Admins have full access; standard users have read/report access only.

### **Entity Management (CRUD)**

- **Add:** Enter details as prompted. All fields are validated.
- **Update:** Enter the ID of the record to update. Non-existing IDs are handled with error messages.
- **Delete:** Enter the ID to delete. Non-existing IDs prompt for correction.
- **View:** Lists all records for that entity.

### **Reports**

- Navigate to the Reports menu for insights such as:
    - Fighters sorted by name or wins
    - Gym and region breakdowns
    - Match outcomes and statistics
    - Yearly and weightclass-based summaries

### **Input Validation & Error Messages**

- The program guides you with clear prompts.
- Invalid or out-of-bound inputs are met with actionable error messages; you will not lose progress or data.
- All user input (IDs, names, numbers) is thoroughly validated.

---

## Example Workflow

1. Register and log in as an admin.
2. Add Regions, Weightclasses, and Gyms.
3. Add Fighters and assign them to Gyms.
4. Schedule Matches and record Outcomes.
5. Use Reports to analyze performance and statistics.
6. Manage users and roles as needed.

---

## Troubleshooting

- **Cannot connect to database:** Check your SQL Server is running and the connection string is correct.
- **Validation errors:** Read error messages carefully; correct data as prompted.
- **Unhandled exceptions:** Ensure all required tables are created and up to date.

---

## Support

For issues, suggestions, or contributions, please open an issue or pull request on the [GitHub repository](https://github.com/ac147222/BoxingApp).

---

## License

This software is provided for educational and demonstration purposes.
