
namespace Laba4GUI
{
	partial class SearchForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.closeButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.horlyPaymentRadioButton = new System.Windows.Forms.RadioButton();
			this.wageRateRadioButton = new System.Windows.Forms.RadioButton();
			this.salaryRadioButton = new System.Windows.Forms.RadioButton();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SecondNameTextBox = new System.Windows.Forms.TextBox();
			this.amountMoneyTextBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lessRadioButton = new System.Windows.Forms.RadioButton();
			this.moreRadioButton = new System.Windows.Forms.RadioButton();
			this.searchButton = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(335, 190);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 0;
			this.closeButton.Text = "Назад";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.horlyPaymentRadioButton);
			this.groupBox1.Controls.Add(this.wageRateRadioButton);
			this.groupBox1.Controls.Add(this.salaryRadioButton);
			this.groupBox1.Location = new System.Drawing.Point(6, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(143, 100);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Тип";
			// 
			// horlyPaymentRadioButton
			// 
			this.horlyPaymentRadioButton.AutoSize = true;
			this.horlyPaymentRadioButton.Location = new System.Drawing.Point(7, 68);
			this.horlyPaymentRadioButton.Name = "horlyPaymentRadioButton";
			this.horlyPaymentRadioButton.Size = new System.Drawing.Size(118, 17);
			this.horlyPaymentRadioButton.TabIndex = 2;
			this.horlyPaymentRadioButton.TabStop = true;
			this.horlyPaymentRadioButton.Text = "Почасовая оплата";
			this.horlyPaymentRadioButton.UseVisualStyleBackColor = true;
			// 
			// wageRateRadioButton
			// 
			this.wageRateRadioButton.AutoSize = true;
			this.wageRateRadioButton.Location = new System.Drawing.Point(7, 44);
			this.wageRateRadioButton.Name = "wageRateRadioButton";
			this.wageRateRadioButton.Size = new System.Drawing.Size(114, 17);
			this.wageRateRadioButton.TabIndex = 1;
			this.wageRateRadioButton.TabStop = true;
			this.wageRateRadioButton.Text = "Тарифная ставка";
			this.wageRateRadioButton.UseVisualStyleBackColor = true;
			// 
			// salaryRadioButton
			// 
			this.salaryRadioButton.AutoSize = true;
			this.salaryRadioButton.Location = new System.Drawing.Point(7, 20);
			this.salaryRadioButton.Name = "salaryRadioButton";
			this.salaryRadioButton.Size = new System.Drawing.Size(57, 17);
			this.salaryRadioButton.TabIndex = 0;
			this.salaryRadioButton.TabStop = true;
			this.salaryRadioButton.Text = "Оклад";
			this.salaryRadioButton.UseVisualStyleBackColor = true;
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Location = new System.Drawing.Point(267, 27);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size(143, 20);
			this.firstNameTextBox.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(264, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Имя:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Фамилия:";
			// 
			// SecondNameTextBox
			// 
			this.SecondNameTextBox.Location = new System.Drawing.Point(12, 27);
			this.SecondNameTextBox.Name = "SecondNameTextBox";
			this.SecondNameTextBox.Size = new System.Drawing.Size(229, 20);
			this.SecondNameTextBox.TabIndex = 8;
			// 
			// amountMoneyTextBox
			// 
			this.amountMoneyTextBox.Location = new System.Drawing.Point(6, 18);
			this.amountMoneyTextBox.Name = "amountMoneyTextBox";
			this.amountMoneyTextBox.Size = new System.Drawing.Size(100, 20);
			this.amountMoneyTextBox.TabIndex = 10;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lessRadioButton);
			this.groupBox2.Controls.Add(this.moreRadioButton);
			this.groupBox2.Controls.Add(this.amountMoneyTextBox);
			this.groupBox2.Location = new System.Drawing.Point(155, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(229, 65);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "За месяц";
			// 
			// lessRadioButton
			// 
			this.lessRadioButton.AutoSize = true;
			this.lessRadioButton.Location = new System.Drawing.Point(116, 42);
			this.lessRadioButton.Name = "lessRadioButton";
			this.lessRadioButton.Size = new System.Drawing.Size(66, 17);
			this.lessRadioButton.TabIndex = 1;
			this.lessRadioButton.TabStop = true;
			this.lessRadioButton.Text = "Меньше";
			this.lessRadioButton.UseVisualStyleBackColor = true;
			// 
			// moreRadioButton
			// 
			this.moreRadioButton.AutoSize = true;
			this.moreRadioButton.Location = new System.Drawing.Point(116, 19);
			this.moreRadioButton.Name = "moreRadioButton";
			this.moreRadioButton.Size = new System.Drawing.Size(64, 17);
			this.moreRadioButton.TabIndex = 0;
			this.moreRadioButton.TabStop = true;
			this.moreRadioButton.Text = "Больше";
			this.moreRadioButton.UseVisualStyleBackColor = true;
			// 
			// searchButton
			// 
			this.searchButton.Location = new System.Drawing.Point(254, 190);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 23);
			this.searchButton.TabIndex = 13;
			this.searchButton.Text = "Поиск";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.groupBox1);
			this.groupBox3.Controls.Add(this.groupBox2);
			this.groupBox3.Location = new System.Drawing.Point(12, 53);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(398, 131);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Заработная плата";
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(419, 221);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SecondNameTextBox);
			this.Controls.Add(this.firstNameTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.closeButton);
			this.Name = "SearchForm";
			this.Text = "Поиск работников";
			this.Load += new System.EventHandler(this.SearchForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton horlyPaymentRadioButton;
		private System.Windows.Forms.RadioButton wageRateRadioButton;
		private System.Windows.Forms.RadioButton salaryRadioButton;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox SecondNameTextBox;
		private System.Windows.Forms.TextBox amountMoneyTextBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton lessRadioButton;
		private System.Windows.Forms.RadioButton moreRadioButton;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.GroupBox groupBox3;
	}
}