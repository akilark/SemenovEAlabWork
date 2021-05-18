
namespace Laba4GUI
{
	partial class StartForm
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
			this.addButton = new System.Windows.Forms.Button();
			this.searchButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.resetButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.workerListDataGrid = new System.Windows.Forms.DataGridView();
			this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.WageType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ammountMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.changeButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.workerListDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(576, 206);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 23);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(576, 22);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 23);
			this.searchButton.TabIndex = 2;
			this.searchButton.Text = "Поиск";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(576, 264);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(75, 23);
			this.deleteButton.TabIndex = 3;
			this.deleteButton.Text = "Удалить";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(583, 313);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 5;
			this.closeButton.Text = "Выход";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// resetButton
			// 
			this.resetButton.Location = new System.Drawing.Point(576, 48);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 23);
			this.resetButton.TabIndex = 6;
			this.resetButton.Text = "Сбросить";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.workerListDataGrid);
			this.groupBox1.Controls.Add(this.changeButton);
			this.groupBox1.Controls.Add(this.resetButton);
			this.groupBox1.Controls.Add(this.addButton);
			this.groupBox1.Controls.Add(this.searchButton);
			this.groupBox1.Controls.Add(this.deleteButton);
			this.groupBox1.Location = new System.Drawing.Point(6, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(660, 292);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Список работников:";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// workerListDataGrid
			// 
			this.workerListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.workerListDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SecondName,
            this.FirstName,
            this.WageType,
            this.ammountMoney});
			this.workerListDataGrid.Location = new System.Drawing.Point(6, 22);
			this.workerListDataGrid.Name = "workerListDataGrid";
			this.workerListDataGrid.Size = new System.Drawing.Size(543, 264);
			this.workerListDataGrid.TabIndex = 9;
			this.workerListDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.workerListDataGrid_CellContentClick);
			// 
			// SecondName
			// 
			this.SecondName.Frozen = true;
			this.SecondName.HeaderText = "Фамилия";
			this.SecondName.Name = "SecondName";
			this.SecondName.ReadOnly = true;
			this.SecondName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// FirstName
			// 
			this.FirstName.Frozen = true;
			this.FirstName.HeaderText = "Имя";
			this.FirstName.Name = "FirstName";
			this.FirstName.ReadOnly = true;
			this.FirstName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// WageType
			// 
			this.WageType.Frozen = true;
			this.WageType.HeaderText = "Тип ЗП";
			this.WageType.Name = "WageType";
			this.WageType.ReadOnly = true;
			this.WageType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.WageType.Width = 200;
			// 
			// ammountMoney
			// 
			this.ammountMoney.HeaderText = "Доход за месяц";
			this.ammountMoney.Name = "ammountMoney";
			this.ammountMoney.ReadOnly = true;
			this.ammountMoney.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// changeButton
			// 
			this.changeButton.Location = new System.Drawing.Point(577, 235);
			this.changeButton.Name = "changeButton";
			this.changeButton.Size = new System.Drawing.Size(75, 23);
			this.changeButton.TabIndex = 8;
			this.changeButton.Text = "Изменить";
			this.changeButton.UseVisualStyleBackColor = true;
			this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(670, 348);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.closeButton);
			this.Name = "StartForm";
			this.Text = "Данные о работниках";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.workerListDataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button changeButton;
		private System.Windows.Forms.DataGridView workerListDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn SecondName;
		private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
		private System.Windows.Forms.DataGridViewTextBoxColumn WageType;
		private System.Windows.Forms.DataGridViewTextBoxColumn ammountMoney;
	}
}

