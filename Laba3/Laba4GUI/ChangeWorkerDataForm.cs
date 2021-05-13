using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4GUI
{
	public partial class ChangeWorkerDataForm : Form
	{
		public ChangeWorkerDataForm()
		{
			InitializeComponent();
			/// при инициализации должены быть изначальный выбор
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ChangeWorkerDataForm_Load(object sender, EventArgs e)
		{
			visibleChange(false);
		}

		private void salaryRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange("Месячный оклад:", "Дней отработано:");
			visibleChange(true);
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



		private void horlyPaymentRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange("Ставка за час:", "Часов отработано:");
			visibleChange(true);
		}

		private void wageRateRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange("Ставка за день:", "Дней отработано:");
			visibleChange(true);
		}
	}
}
