# Personal-Expense-Tracker

## Table of Contents
- [Description](#description)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup and Installation](#setup-and-installation)
- [Usage](#usage)
- [Detailed Instructions](#detailed-instructions)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [Code of Conduct](#code-of-conduct)
- [License](#license)
- [Deployment](#deployment)
- [GitHub Codespaces Setup](#github-codespaces-setup)

## Description

The Personal Expense Tracker is a Windows Forms application designed to help users manage their personal finances efficiently. The application allows users to add, edit, and categorize expenses, as well as visualize their spending habits through various charts and graphs.

## Features

- Add, edit, and delete expenses
- Categorize expenses
- View expense summaries
- Visualize spending habits with charts and graphs
- Predict future expenses using AI-based expense prediction

## Technologies Used

- .NET 6.0
- Windows Forms
- System.Data.SqlClient
- System.Windows.Forms.DataVisualization
- MathNet.Numerics

## Setup and Installation

1. Clone the repository:
   ```
   git clone https://github.com/AbaSheger/Personal-Expense-Tracker.git
   ```
2. Open the solution file `PersonalExpenseTracker.sln` in Visual Studio.
3. Restore NuGet packages.
4. Build the solution.
5. Run the application.

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

## Detailed Instructions

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

## Deployment

### Building and Running the Docker Container

1. Build the Docker image:
   ```
   docker build -t personal-expense-tracker .
   ```
2. Run the Docker container:
   ```
   docker run -d -p 80:80 personal-expense-tracker
   ```

### Using the GitHub Actions Workflow

1. Ensure that you have set up the necessary secrets in your GitHub repository:
   - `DOCKER_USERNAME`: Your DockerHub username
   - `DOCKER_PASSWORD`: Your DockerHub password
   - `AZURE_WEBAPP_PUBLISH_PROFILE`: Your Azure Web App publish profile

2. The GitHub Actions workflow will automatically build and deploy the application when you push changes to the main branch.

### Using Environment Files for DockerHub Login

1. Ensure that you have set up the necessary secrets in your GitHub repository:
   - `DOCKER_USERNAME`: Your DockerHub username
   - `DOCKER_PASSWORD`: Your DockerHub password
   - `AZURE_WEBAPP_PUBLISH_PROFILE`: Your Azure Web App publish profile

2. Create a file named `DOCKERHUB_LOGIN.env` in the `.github/workflows` directory with the following content:
   ```
   DOCKER_USERNAME=<your-docker-username>
   DOCKER_PASSWORD=<your-docker-password>
   ```

3. Update the GitHub Actions workflow to use the Environment Files for DockerHub login.

4. The GitHub Actions workflow will automatically build and deploy the application when you push changes to the main branch.

## GitHub Codespaces Setup

### Setting up GitHub Codespaces

1. Open the repository in GitHub and click on the "Code" button.
2. Select "Open with Codespaces" and create a new Codespace.
3. The Codespace will automatically install Docker and Docker Compose.
4. The application will start using the `docker-compose.yml` file located in the project directory.
5. The application port `3003` will be exposed and made publicly accessible using the GitHub Codespaces `Ports` feature.
6. The environment variables will be loaded from the `.env` file in the project directory.

### Accessing the Application via Public URL

1. Once the Codespace is running, click on the "Ports" tab in the Codespaces interface.
2. Locate the port `3003` and click on the "Open in Browser" button.
3. The application will be accessible via the public URL provided by GitHub Codespaces.
