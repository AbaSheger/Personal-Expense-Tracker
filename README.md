# Personal Expense Tracker

A comprehensive Windows Forms desktop application for tracking and analyzing personal expenses with built-in prediction capabilities.

## Table of Contents
- [Description](#description)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Setup and Installation](#setup-and-installation)
- [Usage](#usage)
- [Data Management](#data-management)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)

## Description

Personal Expense Tracker is a Windows Forms application built with .NET 6.0 that helps users manage their personal finances efficiently. The application provides an intuitive interface for tracking expenses, categorizing spending, visualizing financial data through charts, and predicting future expenses using linear regression analysis.

## Features

### Core Functionality
- **Expense Management**: Add, edit, and delete expense entries with detailed information
- **Predefined Categories**: Organize expenses into seven built-in categories:
  - Food
  - Transportation
  - Utilities
  - Entertainment
  - Healthcare
  - Education
  - Miscellaneous
- **Category Management**: Add, edit, and delete custom category definitions with names and descriptions
- **Data Grid View**: Display all expenses in an easy-to-read tabular format
- **Category Filtering**: Filter and view expenses by category using a dropdown selector

### Advanced Features
- **Expense Summaries**: View comprehensive summaries of spending by category and date range
- **Visual Charts**: Visualize spending patterns with charts and graphs
- **Expense Prediction**: Predict future expenses for the next 6 months using linear regression based on historical spending data
- **Data Persistence**: Automatic saving and loading of expenses and categories to/from JSON files

## Technologies Used

- **.NET 6.0** - Target framework
- **Windows Forms** - UI framework
- **C#** - Programming language
- **System.Text.Json** - JSON serialization for data persistence
- **System.Windows.Forms.DataVisualization** - Chart and graph visualization
- **MathNet.Numerics** - Mathematical library for linear regression and expense prediction
- **LINQ** - Data querying and manipulation

## Project Structure

```
PersonalExpenseTracker/
├── Program.cs                  # Application entry point
├── MainForm.cs                 # Main application window with expense grid and controls
├── ExpenseForm.cs              # Form for adding/editing expenses with prediction button
├── CategoryForm.cs             # Form for adding/editing categories
├── ExpenseSummaryForm.cs       # Form displaying expense summaries and charts
├── Expense.cs                  # Expense data model
├── ExpenseManager.cs           # Business logic for expense operations and predictions
├── Category.cs                 # Category data model
├── CategoryManager.cs          # Business logic for category operations
├── CategoryEnum.cs             # Enumeration of predefined expense categories
└── PersonalExpenseTracker.csproj  # Project configuration file
```

## Setup and Installation

### Prerequisites
- **Operating System**: Windows 10 or later
- **Development Environment**: Visual Studio 2019 or later (or Visual Studio Code with C# extension)
- **.NET SDK**: .NET 6.0 SDK or later

### Installation Steps

1. **Clone the repository**:
   ```bash
   git clone https://github.com/AbaSheger/Personal-Expense-Tracker.git
   cd Personal-Expense-Tracker
   ```

2. **Open the solution**:
   - Open `PersonalExpenseTracker.sln` in Visual Studio
   - Or open the folder in Visual Studio Code

3. **Restore NuGet packages**:
   - Visual Studio will automatically restore packages
   - Or run manually: `dotnet restore`

4. **Build the solution**:
   - Visual Studio: Press `Ctrl+Shift+B`
   - Command line: `dotnet build`

5. **Run the application**:
   - Visual Studio: Press `F5`
   - Command line: `dotnet run --project PersonalExpenseTracker`

## Usage

### Main Window
The main window displays all your expenses in a data grid and provides buttons for various operations.

### Managing Expenses

**Add an Expense:**
1. Click the **"Add Expense"** button
2. Enter the amount, select a category from the dropdown
3. Choose the date using the date picker
4. Enter a description
5. Click **"Save"** to add the expense

**Edit an Expense:**
1. Select an expense row in the data grid
2. Click the **"Edit Expense"** button
3. Modify the details in the form
4. Click **"Save"** to update

**Delete an Expense:**
1. Select an expense row in the data grid
2. Click the **"Delete Expense"** button
3. Confirm the deletion

### Managing Categories

**Add a Category:**
1. Click the **"Add Category"** button
2. Enter the category name and description
3. Click **"Save"**

**Edit a Category:**
1. Select a category from the list
2. Click the **"Edit Category"** button
3. Modify the details
4. Click **"Save"**

**Delete a Category:**
1. Select a category from the list
2. Click the **"Delete Category"** button
3. Confirm the deletion

### Viewing Summaries

1. Click the **"View Summary"** button
2. Select a category from the dropdown (or "All Categories")
3. Choose a date range if needed
4. View the generated chart showing your spending patterns

### Predicting Future Expenses

1. Open the Expense Form by clicking **"Add Expense"** or **"Edit Expense"**
2. Click the **"Predict"** button
3. A message box will display predicted expenses for the next 6 months based on your historical spending data
4. The prediction uses linear regression analysis to calculate trends

### Filtering by Category

Use the category dropdown at the bottom of the main window to filter expenses by specific categories or view all categories.

## Data Management

### Storage Format
- Expenses and categories are stored in JSON format
- Files can be manually saved/loaded using the ExpenseManager and CategoryManager classes
- Data includes: amount, category, date, and description for expenses; name and description for categories

### Data Location
By default, data is stored in memory during runtime. To persist data between sessions, the application uses:
- `SaveExpensesToFile(filePath)` - Save expenses to a JSON file
- `LoadExpensesFromFile(filePath)` - Load expenses from a JSON file
- `SaveCategoriesToFile(filePath)` - Save categories to a JSON file
- `LoadCategoriesFromFile(filePath)` - Load categories from a JSON file

### Prediction Algorithm
The expense prediction feature uses simple linear regression from the MathNet.Numerics library:
- Analyzes historical expense data grouped by date
- Fits a linear regression model to identify spending trends
- Projects expenses for the next 6 months based on the identified trend
- Results are displayed in currency format

## Screenshots

<!-- Add screenshots of your application here -->

## Contributing

Contributions are welcome! Please follow these guidelines:

1. **Fork the repository** on GitHub
2. **Create a feature branch**: `git checkout -b feature/your-feature-name`
3. **Commit your changes**: `git commit -am 'Add new feature'`
4. **Push to the branch**: `git push origin feature/your-feature-name`
5. **Create a Pull Request** to the main repository

### Code Standards
- Follow C# coding conventions
- Include XML documentation comments for public methods
- Test your changes thoroughly before submitting
- Update the README if you add new features

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Future Enhancements

Consider these improvements for production use:
- **Database Backend**: Implement SQL Server or SQLite for better data management
- **Export Features**: Add ability to export data to CSV/Excel
- **Budget Tracking**: Set and monitor monthly budgets per category
- **Recurring Expenses**: Support for recurring expense entries
- **Multi-currency**: Support for different currencies
- **Receipt Attachments**: Ability to attach receipt images to expenses
- **Authentication**: User login and multiple user profiles
- **Cloud Sync**: Synchronize data across devices
