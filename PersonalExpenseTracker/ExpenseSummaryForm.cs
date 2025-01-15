using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

namespace PersonalExpenseTracker
{
    public partial class ExpenseSummaryForm : Form
    {
        private ExpenseManager expenseManager;
        private CategoryManager categoryManager;

        public ExpenseSummaryForm(ExpenseManager expenseManager, CategoryManager categoryManager)
        {
            InitializeComponent();
            this.expenseManager = expenseManager;
            this.categoryManager = categoryManager;
            LoadCategories();
        }

        private void InitializeComponent()
        {
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonGenerateSummary = new System.Windows.Forms.Button();
            this.chartExpenses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(200, 21);
            this.comboBoxCategory.TabIndex = 0;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(12, 39);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStart.TabIndex = 1;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(12, 65);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEnd.TabIndex = 2;
            // 
            // buttonGenerateSummary
            // 
            this.buttonGenerateSummary.Location = new System.Drawing.Point(12, 91);
            this.buttonGenerateSummary.Name = "buttonGenerateSummary";
            this.buttonGenerateSummary.Size = new System.Drawing.Size(200, 23);
            this.buttonGenerateSummary.TabIndex = 3;
            this.buttonGenerateSummary.Text = "Generate Summary";
            this.buttonGenerateSummary.UseVisualStyleBackColor = true;
            this.buttonGenerateSummary.Click += new System.EventHandler(this.ButtonGenerateSummary_Click);
            // 
            // chartExpenses
            // 
            ChartArea chartArea1 = new ChartArea("ChartArea1");
            this.chartExpenses.ChartAreas.Add(chartArea1);
            Legend legend1 = new Legend("Legend1");
            this.chartExpenses.Legends.Add(legend1);
            this.chartExpenses.Location = new System.Drawing.Point(12, 120);
            this.chartExpenses.Name = "chartExpenses";
            this.chartExpenses.Size = new System.Drawing.Size(776, 318);
            this.chartExpenses.TabIndex = 4;
            this.chartExpenses.Text = "chart1";
            // 
            // ExpenseSummaryForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartExpenses);
            this.Controls.Add(this.buttonGenerateSummary);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.comboBoxCategory);
            this.Name = "ExpenseSummaryForm";
            this.Text = "Expense Summary";
            ((System.ComponentModel.ISupportInitialize)(this.chartExpenses)).EndInit();
            this.ResumeLayout(false);

        }

        private void LoadCategories()
        {
            if (categoryManager.IsCategoryListEmpty())
            {
                MessageBox.Show("The category list is empty.");
            }

            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add("All Categories");
            foreach (var category in categoryManager.GetCategories())
            {
                comboBoxCategory.Items.Add(category.Name);
            }
            comboBoxCategory.SelectedIndex = 0;
        }

        private void ButtonGenerateSummary_Click(object sender, EventArgs e)
        {
            var selectedCategory = comboBoxCategory.SelectedItem.ToString();
            var startDate = dateTimePickerStart.Value.Date;
            var endDate = dateTimePickerEnd.Value.Date;

            var expenses = expenseManager.GetExpenses()
                .Where(expense => expense.Date >= startDate && expense.Date <= endDate);

            if (selectedCategory != "All Categories")
            {
                expenses = expenses.Where(expense => expense.Category == selectedCategory);
            }

            var expenseSummary = expenses
                .GroupBy(expense => expense.Date.Date)
                .Select(group => new { Date = group.Key, TotalAmount = group.Sum(expense => expense.Amount) })
                .ToList();

            chartExpenses.Series.Clear();
            var series = new Series("Expenses")
            {
                ChartType = SeriesChartType.Line
            };

            foreach (var summary in expenseSummary)
            {
                series.Points.AddXY(summary.Date, summary.TotalAmount);
            }

            chartExpenses.Series.Add(series);
        }

        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button buttonGenerateSummary;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExpenses;
    }
}
