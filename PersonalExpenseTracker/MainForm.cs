using System;
using System.Windows.Forms;

namespace PersonalExpenseTracker
{
    public partial class MainForm : Form
    {
        private ExpenseManager expenseManager;
        private CategoryManager categoryManager;

        public MainForm()
        {
            InitializeComponent();
            expenseManager = new ExpenseManager();
            categoryManager = new CategoryManager();
            LoadExpenses();
            LoadCategories();
        }

        private void InitializeComponent()
        {
            this.dataGridViewExpenses = new System.Windows.Forms.DataGridView();
            this.buttonAddExpense = new System.Windows.Forms.Button();
            this.buttonEditExpense = new System.Windows.Forms.Button();
            this.buttonDeleteExpense = new System.Windows.Forms.Button();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.buttonEditCategory = new System.Windows.Forms.Button();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.buttonViewSummary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewExpenses
            // 
            this.dataGridViewExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpenses.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewExpenses.Name = "dataGridViewExpenses";
            this.dataGridViewExpenses.Size = new System.Drawing.Size(776, 350);
            this.dataGridViewExpenses.TabIndex = 0;
            // 
            // buttonAddExpense
            // 
            this.buttonAddExpense.Location = new System.Drawing.Point(12, 368);
            this.buttonAddExpense.Name = "buttonAddExpense";
            this.buttonAddExpense.Size = new System.Drawing.Size(75, 23);
            this.buttonAddExpense.TabIndex = 1;
            this.buttonAddExpense.Text = "Add Expense";
            this.buttonAddExpense.UseVisualStyleBackColor = true;
            this.buttonAddExpense.Click += new System.EventHandler(this.ButtonAddExpense_Click);
            // 
            // buttonEditExpense
            // 
            this.buttonEditExpense.Location = new System.Drawing.Point(93, 368);
            this.buttonEditExpense.Name = "buttonEditExpense";
            this.buttonEditExpense.Size = new System.Drawing.Size(75, 23);
            this.buttonEditExpense.TabIndex = 2;
            this.buttonEditExpense.Text = "Edit Expense";
            this.buttonEditExpense.UseVisualStyleBackColor = true;
            this.buttonEditExpense.Click += new System.EventHandler(this.ButtonEditExpense_Click);
            // 
            // buttonDeleteExpense
            // 
            this.buttonDeleteExpense.Location = new System.Drawing.Point(174, 368);
            this.buttonDeleteExpense.Name = "buttonDeleteExpense";
            this.buttonDeleteExpense.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteExpense.TabIndex = 3;
            this.buttonDeleteExpense.Text = "Delete Expense";
            this.buttonDeleteExpense.UseVisualStyleBackColor = true;
            this.buttonDeleteExpense.Click += new System.EventHandler(this.ButtonDeleteExpense_Click);
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Location = new System.Drawing.Point(255, 368);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCategory.TabIndex = 4;
            this.buttonAddCategory.Text = "Add Category";
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.ButtonAddCategory_Click);
            // 
            // buttonEditCategory
            // 
            this.buttonEditCategory.Location = new System.Drawing.Point(336, 368);
            this.buttonEditCategory.Name = "buttonEditCategory";
            this.buttonEditCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonEditCategory.TabIndex = 5;
            this.buttonEditCategory.Text = "Edit Category";
            this.buttonEditCategory.UseVisualStyleBackColor = true;
            this.buttonEditCategory.Click += new System.EventHandler(this.ButtonEditCategory_Click);
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Location = new System.Drawing.Point(417, 368);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteCategory.TabIndex = 6;
            this.buttonDeleteCategory.Text = "Delete Category";
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.ButtonDeleteCategory_Click);
            // 
            // buttonViewSummary
            // 
            this.buttonViewSummary.Location = new System.Drawing.Point(498, 368);
            this.buttonViewSummary.Name = "buttonViewSummary";
            this.buttonViewSummary.Size = new System.Drawing.Size(100, 23);
            this.buttonViewSummary.TabIndex = 7;
            this.buttonViewSummary.Text = "View Summary";
            this.buttonViewSummary.UseVisualStyleBackColor = true;
            this.buttonViewSummary.Click += new System.EventHandler(this.ButtonViewSummary_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonViewSummary);
            this.Controls.Add(this.buttonDeleteCategory);
            this.Controls.Add(this.buttonEditCategory);
            this.Controls.Add(this.buttonAddCategory);
            this.Controls.Add(this.buttonDeleteExpense);
            this.Controls.Add(this.buttonEditExpense);
            this.Controls.Add(this.buttonAddExpense);
            this.Controls.Add(this.dataGridViewExpenses);
            this.Name = "MainForm";
            this.Text = "Personal Expense Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenses)).EndInit();
            this.ResumeLayout(false);

        }

        private void LoadExpenses()
        {
            dataGridViewExpenses.DataSource = expenseManager.GetExpenses();
        }

        private void LoadCategories()
        {
            // Load categories if needed
        }

        private void ButtonAddExpense_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm();
            if (expenseForm.ShowDialog() == DialogResult.OK)
            {
                expenseManager.AddExpense(expenseForm.Expense);
                LoadExpenses();
            }
        }

        private void ButtonEditExpense_Click(object sender, EventArgs e)
        {
            if (dataGridViewExpenses.SelectedRows.Count > 0)
            {
                Expense selectedExpense = (Expense)dataGridViewExpenses.SelectedRows[0].DataBoundItem;
                ExpenseForm expenseForm = new ExpenseForm(selectedExpense);
                if (expenseForm.ShowDialog() == DialogResult.OK)
                {
                    expenseManager.UpdateExpense(expenseForm.Expense);
                    LoadExpenses();
                }
            }
        }

        private void ButtonDeleteExpense_Click(object sender, EventArgs e)
        {
            if (dataGridViewExpenses.SelectedRows.Count > 0)
            {
                Expense selectedExpense = (Expense)dataGridViewExpenses.SelectedRows[0].DataBoundItem;
                expenseManager.RemoveExpense(selectedExpense);
                LoadExpenses();
            }
        }

        private void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm();
            if (categoryForm.ShowDialog() == DialogResult.OK)
            {
                categoryManager.AddCategory(categoryForm.Category);
                LoadCategories();
            }
        }

        private void ButtonEditCategory_Click(object sender, EventArgs e)
        {
            // Implement edit category functionality
        }

        private void ButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            // Implement delete category functionality
        }

        private void ButtonViewSummary_Click(object sender, EventArgs e)
        {
            ExpenseSummaryForm summaryForm = new ExpenseSummaryForm();
            summaryForm.ShowDialog();
        }

        private System.Windows.Forms.DataGridView dataGridViewExpenses;
        private System.Windows.Forms.Button buttonAddExpense;
        private System.Windows.Forms.Button buttonEditExpense;
        private System.Windows.Forms.Button buttonDeleteExpense;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.Button buttonEditCategory;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.Button buttonViewSummary;
    }
}
