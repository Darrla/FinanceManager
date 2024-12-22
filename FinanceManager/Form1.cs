using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LiveCharts.WinForms;
using LiveCharts.Definitions.Charts;
using OfficeOpenXml;

namespace FinanceManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            InitializeBudgetTable();
            InitializeRemindersTable();
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadTransactions();
            LoadBudgetCategories(); // Загрузка категорий бюджета при загрузке формы
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Transactions (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Amount REAL,
                        Category TEXT,
                        Date TEXT,
                        Type TEXT
                    )";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InitializeBudgetTable()
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string createBudgetTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Budget (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Category TEXT,
                        Amount REAL
                    )";
                using (var command = new SQLiteCommand(createBudgetTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InitializeRemindersTable()
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string createRemindersTableQuery = @"
            CREATE TABLE IF NOT EXISTS Reminders (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Description TEXT,
                DueDate TEXT
            )";
                using (var command = new SQLiteCommand(createRemindersTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadCategories()
        {
            categoryComboBox.Items.AddRange(new string[]
            {
                "Зарплата",
                "Еда",
                "Транспорт",
                "Развлечения",
                "Коммунальные услуги"
            });
        }

        private void LoadTransactions()
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Transactions";
                using (var adapter = new SQLiteDataAdapter(selectQuery, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    transactionsDataGridView.DataSource = table;
                }
            }
        }

        private void LoadBudgetCategories()
        {
            budgetCategoryComboBox.Items.AddRange(new string[]
            {
                "Зарплата",
                "Еда",
                "Транспорт",
                "Развлечения",
                "Коммунальные услуги"
            });
        }

        private void AddTransaction(string type)
        {
            if (double.TryParse(amountTextBox.Text, out double amount) && categoryComboBox.SelectedItem != null)
            {
                string category = categoryComboBox.SelectedItem.ToString();
                string date = dateTimePicker.Value.ToString("yyyy-MM-dd");

                using (var connection = new SQLiteConnection("Data Source=finance.db"))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Transactions (Amount, Category, Date, Type) VALUES (@amount, @category, @date, @type)";
                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@category", category);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@type", type);
                        command.ExecuteNonQuery();
                    }
                }

                LoadTransactions(); // Обновляем таблицу после добавления
                CheckBudget(category, amount); // Проверяем бюджет после добавления расхода
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму и выберите категорию.");
            }
        }

        private void addIncomeButton_Click(object sender, EventArgs e)
        {
            AddTransaction("Income");
        }

        private void addExpenseButton_Click(object sender, EventArgs e)
        {
            AddTransaction("Expense");
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            LoadExpenseAnalysis(); // Генерация отчета по расходам
        }

        private void saveBudgetButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(budgetAmountTextBox.Text, out double budgetAmount) && budgetCategoryComboBox.SelectedItem != null)
            {
                string category = budgetCategoryComboBox.SelectedItem.ToString();
                SaveBudget(category, budgetAmount);
                MessageBox.Show($"Бюджет в размере {budgetAmount} установлен для категории {category}.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму и выберите категорию.");
            }
        }

        private void SaveBudget(string category, double amount)
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string insertBudgetQuery = "INSERT INTO Budget (Category, Amount) VALUES (@category, @amount)";
                using (var command = new SQLiteCommand(insertBudgetQuery, connection))
                {
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@amount", amount);
                    command.ExecuteNonQuery();
                }
            }
        }

        private double GetBudgetForCategory(string category)
        {
            double budgetAmount = 0;
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string selectBudgetQuery = "SELECT Amount FROM Budget WHERE Category = @category";
                using (var command = new SQLiteCommand(selectBudgetQuery, connection))
                {
                    command.Parameters.AddWithValue("@category", category);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        budgetAmount = Convert.ToDouble(result);
                    }
                }
            }
            return budgetAmount;
        }

        private void CheckBudget(string category, double expenseAmount)
        {
            double budgetAmount = GetBudgetForCategory(category);
            if (expenseAmount > budgetAmount && budgetAmount > 0)
            {
                MessageBox.Show($"Вы превысили бюджет по категории {category}!");
            }
        }

        private List<ExpenseByCategory> GetExpensesGroupedByCategory()
        {
            var expensesByCategory = new List<ExpenseByCategory>();

            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string query = @"
                   SELECT Category, SUM(Amount) AS Total
                   FROM Transactions
                   WHERE Type = 'Expense'
                   GROUP BY Category";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var expense = new ExpenseByCategory
                        {
                            Category = reader["Category"].ToString(),
                            Total = Convert.ToDouble(reader["Total"])
                        };
                        expensesByCategory.Add(expense);
                    }
                }
            }

            return expensesByCategory;
        }

        private void clearExpensesButton_Click(object sender, EventArgs e)
        {
            ClearAllExpenses(); // Вызов метода очистки
        }
        private void ClearAllExpenses()
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Transactions";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            LoadTransactions(); // Обновляем таблицу после очистки
            MessageBox.Show("Все расходы были успешно очищены.");
        }

        private void LoadExpenseAnalysis()
        {
            var expensesGrouped = GetExpensesGroupedByCategory();
            var values = new ChartValues<double>();
            var labels = new List<string>();

            foreach (var item in expensesGrouped)
            {
                values.Add(item.Total);
                labels.Add(item.Category);
            }

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();

            cartesianChart1.Series.Add(new ColumnSeries { Values = values });
            cartesianChart1.AxisX.Add(new Axis { Title = "Категории", Labels = labels });
        }

        private void addReminderButton_Click(object sender, EventArgs e)
        {
            string description = reminderDescriptionTextBox.Text;
            string dueDate = reminderDatePicker.Value.ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(description))
            {
                SaveReminder(description, dueDate);
                MessageBox.Show("Напоминание успешно добавлено.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите описание напоминания.");
            }
        }

        private void SaveReminder(string description, string dueDate)
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string insertReminderQuery = "INSERT INTO Reminders (Description, DueDate) VALUES (@description, @dueDate)";
                using (var command = new SQLiteCommand(insertReminderQuery, connection))
                {
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@dueDate", dueDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void checkRemindersButton_Click(object sender, EventArgs e)
        {
            CheckReminders();
        }

        private void CheckReminders()
        {
            var reminders = GetReminders();
            foreach (var reminder in reminders)
            {
                if (DateTime.Parse(reminder.DueDate) <= DateTime.Now)
                {
                    MessageBox.Show($"Напоминание: {reminder.Description}");
                }
            }
        }

        private List<Reminder> GetReminders()
        {
            var reminders = new List<Reminder>();

            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string query = "SELECT * FROM Reminders";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reminder = new Reminder
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            DueDate = reader.GetString(2)
                        };
                        reminders.Add(reminder);
                    }
                }
            }

            return reminders;
        }

        public class ExpenseByCategory
        {
            public string Category { get; set; }
            public double Total { get; set; }
        }

        public class Reminder
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string DueDate { get; set; }
        }

        private void exportCsvButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Сохранить файл CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(saveFileDialog.FileName);
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string query = "SELECT * FROM Transactions";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Id,Amount,Category,Date,Type"); // Заголовки столбцов
                    while (reader.Read())
                    {
                        writer.WriteLine($"{reader["Id"]},{reader["Amount"]},{reader["Category"]},{reader["Date"]},{reader["Type"]}");
                    }
                }
            }
            MessageBox.Show("Данные успешно экспортированы в CSV!");
        }

        private void importCsvButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.Title = "Выберите файл CSV для импорта";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportFromCSV(openFileDialog.FileName);
            }
        }

        private void ImportFromCSV(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                // Пропускаем заголовок
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length == 5) // Id, Amount, Category, Date, Type
                    {
                        double amount;
                        if (double.TryParse(values[1], out amount))
                        {
                            string category = values[2];
                            string date = values[3];
                            string type = values[4];

                            // Добавляем запись в базу данных
                            AddTransactionToDatabase(amount, category, date, type);
                        }
                    }
                }
            }

            LoadTransactions(); // Обновляем таблицу после импорта
            MessageBox.Show("Данные успешно импортированы из CSV!");
        }

        private void AddTransactionToDatabase(double amount, string category, string date, string type)
        {
            using (var connection = new SQLiteConnection("Data Source=finance.db"))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Transactions (Amount, Category, Date, Type) VALUES (@amount, @category, @date, @type)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@amount", amount);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@type", type);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}