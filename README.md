# ExpenseTracking
# ExpenseTracking_WebApp

Welcome to the ExpenseTracking Web Application! This is a comprehensive web application developed using ASP.NET Core MVC to help users manage their expenses and income effectively.

## Features

- **User Authentication**: Secure user registration and login.
- **Expense and Income Tracking**: Add, view, and manage expenses and income categories.
- **Dynamic Budgeting**: Track and manage your budget with real-time updates.
- **Responsive Design**: User-friendly and accessible interface optimized for both desktop and mobile devices.
- **Dynamic Category Management**: Add new categories or select from existing ones based on the type of expense or income.
- **Visual Styling**: Modern CSS styling for a clean and engaging user experience.

## Technologies Used

- **ASP.NET Core MVC**: Framework for building the web application.
- **C#**: Programming language used for the backend logic.
- **Bootstrap**: Frontend framework for responsive design.
- **CSS**: Custom styling to enhance the look and feel of the application.
- **Entity Framework Core**: ORM for database interactions.

## Getting Started

To get started with the ExpenseTracking Web Application, follow these steps:

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a compatible database system
- [Visual Studio](https://visualstudio.microsoft.com/) or another IDE of your choice

### Installation

1. Clone the repository:

   git clone https://github.com/NimsaraC/ExpenseTracking_WebApp.git


2. Navigate to the project directory:


   cd ExpenseTracking_WebApp


3. Restore the dependencies:


   dotnet restore


4. Update the connection string in `appsettings.json` to match your database configuration.

5. Apply the database migrations:


   dotnet ef database update


6. Run the application:

   ```bash
   dotnet run
   ```

   The application will be available at `https://localhost:5001` by default.

## Usage

1. **Register an Account**: Create a new user account by navigating to the registration page.
2. **Login**: Use your credentials to log in to the application.
3. **Add Expenses and Income**: Use the dashboard to manage your expenses and income categories.
4. **View Budget**: Check your current budget and remaining balance on the home page.

## Contributing

Contributions are welcome! Please follow these guidelines if you wish to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or issues, please reach out to [NimsaraC](https://github.com/NimsaraC) on GitHub.

---

Thank you for checking out the ExpenseTracking Web Application!

```

Feel free to tweak any sections to better match your project details or add additional information if needed!
