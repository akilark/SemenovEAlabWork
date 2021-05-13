
namespace Laba4GUI
{
	partial class ChangeWorkerDataForm
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.sakaryRadioButton = new System.Windows.Forms.RadioButton();
			this.horlyPaymentRadioButton = new System.Windows.Forms.RadioButton();
			this.wageRateRadioButton = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.workMoneyTextBox = new System.Windows.Forms.TextBox();
			this.workMoneyLabel = new System.Windows.Forms.Label();
			this.workHoursTextBox = new System.Windows.Forms.TextBox();
			this.workHoursLabel = new System.Windows.Forms.Label();
			this.changeButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.secondNameTextBox = new System.Windows.Forms.TextBox();
			this.firastNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Controls.Add(this.workMoneyTextBox);
			this.groupBox2.Controls.Add(this.workMoneyLabel);
			this.groupBox2.Controls.Add(this.workHoursTextBox);
			this.groupBox2.Controls.Add(this.workHoursLabel);
			this.groupBox2.Location = new System.Drawing.Point(12, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(308, 135);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Заработная плата";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sakaryRadioButton);
			this.groupBox1.Controls.Add(this.horlyPaymentRadioButton);
			this.groupBox1.Controls.Add(this.wageRateRadioButton);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(6, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(143, 100);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Тип";
			// 
			// sakaryRadioButton
			// 
			this.sakaryRadioButton.AutoSize = true;
			this.sakaryRadioButton.Location = new System.Drawing.Point(7, 22);
			this.sakaryRadioButton.Name = "sakaryRadioButton";
			this.sakaryRadioButton.Size = new System.Drawing.Size(57, 17);
			this.sakaryRadioButton.TabIndex = 3;
			this.sakaryRadioButton.TabStop = true;
			this.sakaryRadioButton.Text = "Оклад";
			this.sakaryRadioButton.UseVisualStyleBackColor = true;
			this.sakaryRadioButton.CheckedChanged += new System.EventHandler(this.salaryRadioButton_CheckedChanged);
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
			this.horlyPaymentRadioButton.CheckedChanged += new System.EventHandler(this.horlyPaymentRadioButton_CheckedChanged);
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
			this.wageRateRadioButton.CheckedChanged += new System.EventHandler(this.wageRateRadioButton_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(7, 68);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(118, 17);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Почасовая оплата";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// workMoneyTextBox
			// 
			this.workMoneyTextBox.Location = new System.Drawing.Point(173, 38);
			this.workMoneyTextBox.Name = "workMoneyTextBox";
			this.workMoneyTextBox.Size = new System.Drawing.Size(100, 20);
			this.workMoneyTextBox.TabIndex = 7;
			// 
			// workMoneyLabel
			// 
			this.workMoneyLabel.AutoSize = true;
			this.workMoneyLabel.Location = new System.Drawing.Point(170, 18);
			this.workMoneyLabel.Name = "workMoneyLabel";
			this.workMoneyLabel.Size = new System.Drawing.Size(75, 13);
			this.workMoneyLabel.TabIndex = 5;
			this.workMoneyLabel.Text = "Ставка в час:";
			// 
			// workHoursTextBox
			// 
			this.workHoursTextBox.Location = new System.Drawing.Point(173, 87);
			this.workHoursTextBox.Name = "workHoursTextBox";
			this.workHoursTextBox.Size = new System.Drawing.Size(100, 20);
			this.workHoursTextBox.TabIndex = 8;
			// 
			// workHoursLabel
			// 
			this.workHoursLabel.AutoSize = true;
			this.workHoursLabel.Location = new System.Drawing.Point(170, 67);
			this.workHoursLabel.Name = "workHoursLabel";
			this.workHoursLabel.Size = new System.Drawing.Size(103, 13);
			this.workHoursLabel.TabIndex = 6;
			this.workHoursLabel.Text = "Часов отработано:";
			// 
			// changeButton
			// 
			this.changeButton.Location = new System.Drawing.Point(245, 191);
			this.changeButton.Name = "changeButton";
			this.changeButton.Size = new System.Drawing.Size(75, 23);
			this.changeButton.TabIndex = 17;
			this.changeButton.Text = "Изменить";
			this.changeButton.UseVisualStyleBackColor = true;
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(326, 191);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 16;
			this.closeButton.Text = "Назад";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Фамилия:";
			// 
			// secondNameTextBox
			// 
			this.secondNameTextBox.Location = new System.Drawing.Point(12, 22);
			this.secondNameTextBox.Name = "secondNameTextBox";
			this.secondNameTextBox.Size = new System.Drawing.Size(229, 20);
			this.secondNameTextBox.TabIndex = 14;
			// 
			// firastNameTextBox
			// 
			this.firastNameTextBox.Location = new System.Drawing.Point(261, 22);
			this.firastNameTextBox.Name = "firastNameTextBox";
			this.firastNameTextBox.Size = new System.Drawing.Size(143, 20);
			this.firastNameTextBox.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(258, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Имя:";
			// 
			// ChangeWorkerDataForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 221);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.changeButton);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.secondNameTextBox);
			this.Controls.Add(this.firastNameTextBox);
			this.Controls.Add(this.label1);
			this.Name = "ChangeWorkerDataForm";
			this.Text = "Изменение информации о работнике";
			this.Load += new System.EventHandler(this.ChangeWorkerDataForm_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton horlyPaymentRadioButton;
		private System.Windows.Forms.RadioButton wageRateRadioButton;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.TextBox workMoneyTextBox;
		private System.Windows.Forms.Label workMoneyLabel;
		private System.Windows.Forms.TextBox workHoursTextBox;
		private System.Windows.Forms.Label workHoursLabel;
		private System.Windows.Forms.Button changeButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox secondNameTextBox;
		private System.Windows.Forms.TextBox firastNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton sakaryRadioButton;
	}
}