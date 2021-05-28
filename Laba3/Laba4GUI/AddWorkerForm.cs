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
		
		private int allowWorkHours = 8;
		public Worker workerTmp;
		public bool addFlag = false;

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
			addFlag = false;
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
		}

		private void wageRateRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange("Ставка за день:", "Дней отработано:");
			visibleChange(true);
		}

		private void horlyPaymentRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange("Ставка за час:", "Часов отработано:");
			visibleChange(true);
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (secondNameTextBox.Text == "" || 
					firstNameTextBox.Text == "" ||
					workHoursTextBox.Text == "" ||
					workMoneyTextBox.Text == "")
				{
					MessageBox.Show("Для создания работника необходимо заполнить все поля",
						"Ошибка");
				}
				else
				{
					workerTmp.WageType(wageTypeFromRadioButton());
					workerTmp.dateTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month-1,1);
					if (horlyPaymentRadioButton.Checked == true)
					{
						workerTmp.MoneyEarnedInMonth(Int32.Parse(workMoneyTextBox.Text), 
							Int32.Parse(workHoursTextBox.Text));
					}
					else
					{
						workerTmp.MoneyEarnedInMonth(Int32.Parse(workMoneyTextBox.Text), 
							Int32.Parse(workHoursTextBox.Text)* allowWorkHours);
					}
					erasePreviousData();
					
					addFlag = true;
					this.Hide();
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

		private WageType wageTypeFromRadioButton()
		{
			Tuple<bool,WageType>[] radioButtonsChecked = new Tuple<bool,WageType>[] 
			{
				new Tuple<bool, WageType>
				(
				horlyPaymentRadioButton.Checked,
				WageType.HorlyPayment
				),
				new Tuple<bool, WageType>
				(
				wageRateRadioButton.Checked,
				WageType.WageRate
				),
				new Tuple<bool, WageType>
				(
				salaryRadioButton.Checked,
				WageType.Salary
				),
			};
			foreach(Tuple<bool,WageType> radioButtonWageType in radioButtonsChecked)
			{
				if(radioButtonWageType.Item1)
				{
					return radioButtonWageType.Item2;
				}
			}
			throw new Exception("Ничего не выбрано");
		}

		
	}
}
