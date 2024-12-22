namespace FinanceManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addIncomeButton = new System.Windows.Forms.Button();
            this.addExpenseButton = new System.Windows.Forms.Button();
            this.transactionsDataGridView = new System.Windows.Forms.DataGridView();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.budgetAmountTextBox = new System.Windows.Forms.TextBox();
            this.saveBudgetButton = new System.Windows.Forms.Button();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.clearExpensesButton = new System.Windows.Forms.Button();
            this.budgetCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.reminderDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.reminderDatePicker = new System.Windows.Forms.DateTimePicker();
            this.addReminderButton = new System.Windows.Forms.Button();
            this.checkRemindersButton = new System.Windows.Forms.Button();
            this.exportCsvButton = new System.Windows.Forms.Button();
            this.importCsvButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(111, 35);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(121, 22);
            this.amountTextBox.TabIndex = 0;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(111, 63);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(121, 24);
            this.categoryComboBox.TabIndex = 1;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(63, 93);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 2;
            // 
            // addIncomeButton
            // 
            this.addIncomeButton.Location = new System.Drawing.Point(170, 121);
            this.addIncomeButton.Name = "addIncomeButton";
            this.addIncomeButton.Size = new System.Drawing.Size(151, 23);
            this.addIncomeButton.TabIndex = 3;
            this.addIncomeButton.Text = "Добавить доход";
            this.addIncomeButton.UseVisualStyleBackColor = true;
            this.addIncomeButton.Click += new System.EventHandler(this.addIncomeButton_Click);
            // 
            // addExpenseButton
            // 
            this.addExpenseButton.Location = new System.Drawing.Point(12, 121);
            this.addExpenseButton.Name = "addExpenseButton";
            this.addExpenseButton.Size = new System.Drawing.Size(151, 23);
            this.addExpenseButton.TabIndex = 4;
            this.addExpenseButton.Text = "Добавить расход";
            this.addExpenseButton.UseVisualStyleBackColor = true;
            this.addExpenseButton.Click += new System.EventHandler(this.addExpenseButton_Click);
            // 
            // transactionsDataGridView
            // 
            this.transactionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactionsDataGridView.Location = new System.Drawing.Point(45, 150);
            this.transactionsDataGridView.Name = "transactionsDataGridView";
            this.transactionsDataGridView.RowHeadersWidth = 51;
            this.transactionsDataGridView.RowTemplate.Height = 24;
            this.transactionsDataGridView.Size = new System.Drawing.Size(483, 235);
            this.transactionsDataGridView.TabIndex = 5;
            // 
            // generateReportButton
            // 
            this.generateReportButton.Location = new System.Drawing.Point(170, 391);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(189, 23);
            this.generateReportButton.TabIndex = 6;
            this.generateReportButton.Text = "Сгенерировать отчет";
            this.generateReportButton.UseVisualStyleBackColor = true;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // budgetAmountTextBox
            // 
            this.budgetAmountTextBox.Location = new System.Drawing.Point(400, 35);
            this.budgetAmountTextBox.Name = "budgetAmountTextBox";
            this.budgetAmountTextBox.Size = new System.Drawing.Size(121, 22);
            this.budgetAmountTextBox.TabIndex = 7;
            // 
            // saveBudgetButton
            // 
            this.saveBudgetButton.Location = new System.Drawing.Point(400, 92);
            this.saveBudgetButton.Name = "saveBudgetButton";
            this.saveBudgetButton.Size = new System.Drawing.Size(164, 23);
            this.saveBudgetButton.TabIndex = 8;
            this.saveBudgetButton.Text = "Сохранить бюджет";
            this.saveBudgetButton.UseVisualStyleBackColor = true;
            this.saveBudgetButton.Click += new System.EventHandler(this.saveBudgetButton_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(708, 175);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(200, 100);
            this.cartesianChart1.TabIndex = 9;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // clearExpensesButton
            // 
            this.clearExpensesButton.Location = new System.Drawing.Point(400, 391);
            this.clearExpensesButton.Name = "clearExpensesButton";
            this.clearExpensesButton.Size = new System.Drawing.Size(143, 23);
            this.clearExpensesButton.TabIndex = 10;
            this.clearExpensesButton.Text = "Очистить все расходы";
            this.clearExpensesButton.UseVisualStyleBackColor = true;
            this.clearExpensesButton.Click += new System.EventHandler(this.clearExpensesButton_Click);
            // 
            // budgetCategoryComboBox
            // 
            this.budgetCategoryComboBox.FormattingEnabled = true;
            this.budgetCategoryComboBox.Location = new System.Drawing.Point(400, 63);
            this.budgetCategoryComboBox.Name = "budgetCategoryComboBox";
            this.budgetCategoryComboBox.Size = new System.Drawing.Size(121, 24);
            this.budgetCategoryComboBox.TabIndex = 11;
            // 
            // reminderDescriptionTextBox
            // 
            this.reminderDescriptionTextBox.Location = new System.Drawing.Point(688, 35);
            this.reminderDescriptionTextBox.Name = "reminderDescriptionTextBox";
            this.reminderDescriptionTextBox.Size = new System.Drawing.Size(111, 22);
            this.reminderDescriptionTextBox.TabIndex = 12;
            // 
            // reminderDatePicker
            // 
            this.reminderDatePicker.Location = new System.Drawing.Point(641, 77);
            this.reminderDatePicker.Name = "reminderDatePicker";
            this.reminderDatePicker.Size = new System.Drawing.Size(200, 22);
            this.reminderDatePicker.TabIndex = 13;
            // 
            // addReminderButton
            // 
            this.addReminderButton.Location = new System.Drawing.Point(641, 121);
            this.addReminderButton.Name = "addReminderButton";
            this.addReminderButton.Size = new System.Drawing.Size(174, 23);
            this.addReminderButton.TabIndex = 14;
            this.addReminderButton.Text = "Добавить напоминание";
            this.addReminderButton.UseVisualStyleBackColor = true;
            this.addReminderButton.Click += new System.EventHandler(this.addReminderButton_Click);
            // 
            // checkRemindersButton
            // 
            this.checkRemindersButton.Location = new System.Drawing.Point(821, 121);
            this.checkRemindersButton.Name = "checkRemindersButton";
            this.checkRemindersButton.Size = new System.Drawing.Size(185, 23);
            this.checkRemindersButton.TabIndex = 15;
            this.checkRemindersButton.Text = "Проверить напоминание";
            this.checkRemindersButton.UseVisualStyleBackColor = true;
            this.checkRemindersButton.Click += new System.EventHandler(this.checkRemindersButton_Click);
            // 
            // exportCsvButton
            // 
            this.exportCsvButton.Location = new System.Drawing.Point(741, 318);
            this.exportCsvButton.Name = "exportCsvButton";
            this.exportCsvButton.Size = new System.Drawing.Size(185, 23);
            this.exportCsvButton.TabIndex = 17;
            this.exportCsvButton.Text = "Экспорт в CSV";
            this.exportCsvButton.UseVisualStyleBackColor = true;
            this.exportCsvButton.Click += new System.EventHandler(this.exportCsvButton_Click);
            // 
            // importCsvButton
            // 
            this.importCsvButton.Location = new System.Drawing.Point(741, 347);
            this.importCsvButton.Name = "importCsvButton";
            this.importCsvButton.Size = new System.Drawing.Size(185, 23);
            this.importCsvButton.TabIndex = 19;
            this.importCsvButton.Text = "Импорт в CSV";
            this.importCsvButton.UseVisualStyleBackColor = true;
            this.importCsvButton.Click += new System.EventHandler(this.importCsvButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 574);
            this.Controls.Add(this.importCsvButton);
            this.Controls.Add(this.exportCsvButton);
            this.Controls.Add(this.checkRemindersButton);
            this.Controls.Add(this.addReminderButton);
            this.Controls.Add(this.reminderDatePicker);
            this.Controls.Add(this.reminderDescriptionTextBox);
            this.Controls.Add(this.budgetCategoryComboBox);
            this.Controls.Add(this.clearExpensesButton);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.saveBudgetButton);
            this.Controls.Add(this.budgetAmountTextBox);
            this.Controls.Add(this.generateReportButton);
            this.Controls.Add(this.transactionsDataGridView);
            this.Controls.Add(this.addExpenseButton);
            this.Controls.Add(this.addIncomeButton);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.amountTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button addIncomeButton;
        private System.Windows.Forms.Button addExpenseButton;
        private System.Windows.Forms.DataGridView transactionsDataGridView;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.TextBox budgetAmountTextBox;
        private System.Windows.Forms.Button saveBudgetButton;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button clearExpensesButton;
        private System.Windows.Forms.ComboBox budgetCategoryComboBox;
        private System.Windows.Forms.TextBox reminderDescriptionTextBox;
        private System.Windows.Forms.DateTimePicker reminderDatePicker;
        private System.Windows.Forms.Button addReminderButton;
        private System.Windows.Forms.Button checkRemindersButton;
        private System.Windows.Forms.Button exportCsvButton;
        private System.Windows.Forms.Button importCsvButton;
    }
}

