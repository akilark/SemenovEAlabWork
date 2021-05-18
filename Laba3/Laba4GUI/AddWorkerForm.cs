using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba3.Logic;
using System.Windows.Forms;

namespace Laba4GUI
{
	public partial class AddWorkerForm : Form
	{
		int allowWorkHours = 8;
		Worker workerTmp;
		string filepath = @"C:\Users\akila\source\repos\akilark\SemenovEAlabWork\Laba3\data\202104.kek";
		WorkWithFiles files;

			public AddWorkerForm()
		{
			InitializeComponent();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AddWorkerForm_Load(object sender, EventArgs e)
		{
			visibleChange(false);
			workerTmp = new Worker(allowWorkHours);
			
		}

		private void visibleChange(bool bl)
		{
			workHoursLabel.Visible = bl;
			workHoursTextBox.Visible = bl;
			workMoneyLabel.Visible = bl;
			workMoneyTextBox.Visible = bl;
		}

		private void wageTypeInfoChange(string workHours, string workMoney)
		{
			workHoursLabel.Text = workMoney;
			workMoneyLabel.Text = workHours;
		}

		private void salaryRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange("Ставка за месяц:", "Дней отработано:");
			visibleChange(true);
			workerTmp.WageType(1);
		}

		private void wageRateRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange("Ставка за день:", "Дней отработано:");
			visibleChange(true);
			workerTmp.WageType(2);
		}

		private void horlyPaymentRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange("Ставка за час:", "Часов отработано:");
			visibleChange(true);
			workerTmp.WageType(3);
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			files = new WorkWithFiles(filepath);
			try
			{
				if (secondNameTextBox.Text == "" || firstNameTextBox.Text == "")
				{
					MessageBox.Show("Необходимо ввести данные", "Ошибка");
				}
				else
				{
					if (workHoursTextBox.Text == "" || workMoneyTextBox.Text == "")
					{
						DialogResult result = MessageBox.Show("Нельзя создать работника без данных о заработной плате", "Ошибка");
					}
					else
					{
						workerTmp.DesiredDate(files.extractDate());
						if (horlyPaymentRadioButton.Checked == true)
						{
							workerTmp.MoneyEarnedInMonth(Int32.Parse(workMoneyTextBox.Text), Int32.Parse(workHoursTextBox.Text));
						}
						else
						{
							workerTmp.MoneyEarnedInMonth(Int32.Parse(workMoneyTextBox.Text), Int32.Parse(workHoursTextBox.Text)* allowWorkHours);
						}
						files.WriteWorkerInfoToFile(workerTmp);
						erasePreviousData();
						MessageBox.Show("Работник успешно добавлен", "Успех");
					}
				}
			}
			catch(Exception exception)
			{
				MessageBox.Show(exception.Message, "Ошибка");
			}
		}

		private void secondNameTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				workerTmp.SecondName = secondNameTextBox.Text;
				secondNameTextBox.BackColor = Color.White;
			}
			catch (Exception)
			{
				secondNameTextBox.BackColor = Color.DeepPink;
			}
		}

		private void secondNameTextBox_Validating(object sender, CancelEventArgs e)
		{
			try
			{
				workerTmp.SecondName = secondNameTextBox.Text;
				
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Ошибка");
			}
		}

		private void firstNameTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				workerTmp.FirstName = firstNameTextBox.Text;
				firstNameTextBox.BackColor = Color.White;
			}
			catch (Exception)
			{
				firstNameTextBox.BackColor = Color.DeepPink;
			}
		}

		private void firstNameTextBox_Validating(object sender, CancelEventArgs e)
		{

		}

		private void erasePreviousData()
		{
			secondNameTextBox.Text = "";
			firstNameTextBox.Text = "";
			workMoneyTextBox.Text = "";
			workHoursTextBox.Text = "";
			secondNameTextBox.BackColor = Color.White;
			firstNameTextBox.BackColor = Color.White;
			wageRateRadioButton.Checked = false;
			salaryRadioButton.Checked = false;
			horlyPaymentRadioButton.Checked = false;
			visibleChange(false);
			
		}
	}
}
