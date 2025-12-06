# Personal-Expense-Tracker

## Table of Contents
- [Description](#description)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup and Installation](#setup-and-installation)
- [Usage](#usage)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [Code of Conduct](#code-of-conduct)
- [License](#license)
- [Notes](#notes)

## Description

The Personal Expense Tracker is a Windows Forms application designed to help users manage their personal finances efficiently. The application allows users to add, edit, and categorize expenses, as well as visualize their spending habits through various charts and graphs.

## Features

- Add, edit, and delete expenses
- Categorize expenses using predefined categories (Food, Transportation, Utilities, Entertainment, Healthcare, Education, Miscellaneous)
- Manage categories (add, edit, delete)
- View expense summaries with charts
- Filter expenses by category and date range
- Expense prediction using linear regression
- Persistent data storage using JSON files

## Technologies Used

- .NET 6.0
- Windows Forms
- System.Text.Json (for data persistence)
- System.Windows.Forms.DataVisualization (for charts and graphs)
- MathNet.Numerics (for linear regression and expense prediction)

## Setup and Installation

### Prerequisites
- Windows operating system
- Visual Studio 2019 or later (or Visual Studio Code with C# extension)
- .NET 6.0 SDK

### Installation Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/AbaSheger/Personal-Expense-Tracker.git
   ```
2. Open the solution file `PersonalExpenseTracker.sln` in Visual Studio.
3. Restore NuGet packages (Visual Studio will do this automatically, or run `dotnet restore`).
4. Build the solution (Ctrl+Shift+B or `dotnet build`).
5. Run the application (F5 or `dotnet run`).

## Usage

### Adding an Expense

1. Click on the "Add Expense" button.
2. Fill in the details of the expense in the form that appears.
3. Click "Save" to add the expense.

### Editing an Expense

1. Select the expense you want to edit from the list.
2. Click on the "Edit Expense" button.
3. Modify the details in the form that appears.
4. Click "Save" to update the expense.

### Deleting an Expense

1. Select the expense you want to delete from the list.
2. Click on the "Delete Expense" button.
3. Confirm the deletion in the prompt that appears.

### Adding a Category

1. Click on the "Add Category" button.
2. Fill in the details of the category in the form that appears.
3. Click "Save" to add the category.

### Editing a Category

1. Select the category you want to edit from the list.
2. Click on the "Edit Category" button.
3. Modify the details in the form that appears.
4. Click "Save" to update the category.

### Deleting a Category

1. Select the category you want to delete from the list.
2. Click on the "Delete Category" button.
3. Confirm the deletion in the prompt that appears.

### Viewing Expense Summary

1. Click on the "View Summary" button.
2. Select the category and date range for the summary.
3. Click "Generate Summary" to view the summary chart.

### Predicting Future Expenses

1. Click on the "Predict" button in the Expense Form.
2. The predicted expenses for the next 6 months will be displayed in a message box.

## Screenshots

<!-- Add screenshots here -->

## Contributing

We welcome contributions to the Personal Expense Tracker project. Please follow these guidelines when contributing:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Commit your changes with a clear message.
4. Push your branch to your forked repository.
5. Create a pull request to the main repository.

## Code of Conduct

We expect all contributors to adhere to the [Code of Conduct](CODE_OF_CONDUCT.md). Please read it to understand the expectations for behavior when contributing to this project.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Notes

This is a Windows Forms desktop application designed to run on Windows operating systems. It uses JSON file storage to persist expenses and categories data. The application includes expense prediction functionality using linear regression analysis from the MathNet.Numerics library. For production use with larger datasets, consider implementing a proper database backend (SQL Server, SQLite, etc.).
