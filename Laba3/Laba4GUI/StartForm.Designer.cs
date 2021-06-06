﻿
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
			this.fileNameLabel = new System.Windows.Forms.Label();
			this.workerListDataGrid = new System.Windows.Forms.DataGridView();
			this.downloadButton = new System.Windows.Forms.Button();
			this.createRandomDataButton = new System.Windows.Forms.Button();
			this.searchTextBox = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.workerListDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(576, 235);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 23);
			this.addButton.TabIndex = 6;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(234, 14);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 23);
			this.searchButton.TabIndex = 8;
			this.searchButton.Text = "Поиск";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(576, 264);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(75, 23);
			this.deleteButton.TabIndex = 7;
			this.deleteButton.Text = "Удалить";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(588, 337);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 3;
			this.closeButton.Text = "Выход";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// resetButton
			// 
			this.resetButton.Location = new System.Drawing.Point(327, 14);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 23);
			this.resetButton.TabIndex = 9;
			this.resetButton.Text = "Сбросить";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fileNameLabel);
			this.groupBox1.Controls.Add(this.workerListDataGrid);
			this.groupBox1.Controls.Add(this.addButton);
			this.groupBox1.Controls.Add(this.deleteButton);
			this.groupBox1.Location = new System.Drawing.Point(12, 39);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(660, 292);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Список работников:";
			// 
			// fileNameLabel
			// 
			this.fileNameLabel.AutoSize = true;
			this.fileNameLabel.Location = new System.Drawing.Point(119, 0);
			this.fileNameLabel.Name = "fileNameLabel";
			this.fileNameLabel.Size = new System.Drawing.Size(91, 13);
			this.fileNameLabel.TabIndex = 13;
			this.fileNameLabel.Text = "Новый файл.kek";
			// 
			// workerListDataGrid
			// 
			this.workerListDataGrid.AllowUserToAddRows = false;
			this.workerListDataGrid.AllowUserToDeleteRows = false;
			this.workerListDataGrid.AllowUserToResizeColumns = false;
			this.workerListDataGrid.AllowUserToResizeRows = false;
			this.workerListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.workerListDataGrid.Location = new System.Drawing.Point(6, 22);
			this.workerListDataGrid.Name = "workerListDataGrid";
			this.workerListDataGrid.ReadOnly = true;
			this.workerListDataGrid.Size = new System.Drawing.Size(553, 264);
			this.workerListDataGrid.TabIndex = 12;
			// 
			// downloadButton
			// 
			this.downloadButton.Location = new System.Drawing.Point(18, 337);
			this.downloadButton.Name = "downloadButton";
			this.downloadButton.Size = new System.Drawing.Size(75, 23);
			this.downloadButton.TabIndex = 1;
			this.downloadButton.Text = "Загрузить";
			this.downloadButton.UseCompatibleTextRendering = true;
			this.downloadButton.UseVisualStyleBackColor = true;
			this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
			// 
			// createRandomDataButton
			// 
			this.createRandomDataButton.Location = new System.Drawing.Point(496, 337);
			this.createRandomDataButton.Name = "createRandomDataButton";
			this.createRandomDataButton.Size = new System.Drawing.Size(75, 23);
			this.createRandomDataButton.TabIndex = 5;
			this.createRandomDataButton.Text = "Заполнить";
			this.createRandomDataButton.UseVisualStyleBackColor = true;
			this.createRandomDataButton.Click += new System.EventHandler(this.createRandomDataButton_Click);
			// 
			// searchTextBox
			// 
			this.searchTextBox.Location = new System.Drawing.Point(18, 16);
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(201, 20);
			this.searchTextBox.TabIndex = 10;
			this.searchTextBox.Text = "Введите фамилию или имя:";
			this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
			this.searchTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.searchTextBox_MouseDown);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(109, 337);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 4;
			this.saveButton.Text = "Сохранить";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(684, 371);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.searchTextBox);
			this.Controls.Add(this.createRandomDataButton);
			this.Controls.Add(this.downloadButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.searchButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "StartForm";
			this.Text = "Данные о работниках";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartForm_FormClosing);
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.workerListDataGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView workerListDataGrid;
		private System.Windows.Forms.Button downloadButton;
		private System.Windows.Forms.Button createRandomDataButton;
		private System.Windows.Forms.TextBox searchTextBox;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label fileNameLabel;
		private System.Windows.Forms.Button saveButton;
	}
}

