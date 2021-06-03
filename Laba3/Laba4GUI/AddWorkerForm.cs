using System;
using System.ComponentModel;
using System.Drawing;
using Laba3.Logic;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Laba4GUI
{
	/// <summary>
	/// Класс определяющий поведение формы добавления работника
	/// </summary>
	public partial class AddWorkerForm : Form
	{
		/// <summary>
		/// Поле класса хранящее количество допустимых часов работы для работника
		/// </summary>
		private int _allowWorkHours = 8;

		/// <summary>
		/// Поле класса хранящее работника
		/// </summary>
		public Worker WorkerTmp;

		/// <summary>
		/// Поле класса необходимо для определения добавлена ли персона
		/// </summary>
		public bool AddFlag = false;

		/// <summary>
		/// Конструктор класса без параметров
		/// </summary>
		public AddWorkerForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Выход"
		/// </summary>
		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Метод который выполняется при загрузке данной формы
		/// </summary>
		private void AddWorkerForm_Load(object sender, EventArgs e)
		{
			visibleChange(false);
			WorkerTmp = new Worker(_allowWorkHours);
			AddFlag = false;
		}
		
		/// <summary>
		/// Метод позволяющий изменять видимость некоторых объектов,
		/// связанных с вводом информации для расчета ЗП
		/// </summary>
		/// <param name="visible">false - скрывает объекты
		/// true - показывает объекты</param>
		private void visibleChange(bool visible)
		{
			workHoursLabel.Visible = visible;
			workHoursTextBox.Visible = visible;
			workMoneyLabel.Visible = visible;
			workMoneyTextBox.Visible = visible;
		}

		/// <summary>
		/// Метод определяющий текст для workMoneyLabel и workHoursLabel 
		/// в зависимости от выбранного radioButton
		/// </summary>
		private void wageTypeInfoChange()
		{
			var labelsText = new Dictionary<WageType,string[]>
			{
				{WageType.HorlyPayment, 
					new string [] { "Ставка за час:", "Часов отработано:" } },
				{WageType.Salary, 
					new string [] { "Ставка за месяц:", "Дней отработано:" } },
				{WageType.WageRate, 
					new string [] { "Ставка за день:", "Дней отработано:"}}
			};
			var wageType = wageTypeFromRadioButton();
			workMoneyLabel.Text = labelsText[wageType][0];
			workHoursLabel.Text = labelsText[wageType][1];
			visibleChange(true);
		}

		/// <summary>
		/// Метод инициируемый при выборе salaryRadioButton
		/// </summary>
		private void salaryRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange();
		}

		/// <summary>
		/// Метод инициируемый при выборе wageRateRadioButton
		/// </summary>
		private void wageRateRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange();
		}

		/// <summary>
		/// Метод инициируемый при выборе horlyPaymentRadioButton
		/// </summary>
		private void horlyPaymentRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			wageTypeInfoChange();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Добавить"
		/// </summary>
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
					WorkerTmp.WageType(wageTypeFromRadioButton());
					WorkerTmp.dateTime = new DateTime(DateTime.Now.Year,DateTime.Now.Month-1,1);
					if (horlyPaymentRadioButton.Checked == true)
					{
						WorkerTmp.MoneyEarnedInMonth(Int32.Parse(workMoneyTextBox.Text), 
							Int32.Parse(workHoursTextBox.Text));
					}
					else
					{
						WorkerTmp.MoneyEarnedInMonth(Int32.Parse(workMoneyTextBox.Text), 
							Int32.Parse(workHoursTextBox.Text)* _allowWorkHours);
					}
					AddFlag = true;
					this.Hide();
				}
			}
			catch(Exception exception)
			{
				MessageBox.Show(exception.Message, "Ошибка");
			}
		}

		/// <summary>
		/// Метод инициируемый при изменении secondNameTextBox
		/// </summary>
		private void secondNameTextBox_TextChanged(object sender, EventArgs e)
		{
			nameTextBoxes("Фамилия");
		}

		/// <summary>
		/// Метод инициируемый при смене фокуса с secondNameTextBox
		/// </summary>
		private void secondNameTextBox_Validating(object sender, CancelEventArgs e)
		{
			try
			{
				WorkerTmp.SecondName = secondNameTextBox.Text;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Ошибка");
			}
		}

		/// <summary>
		/// Метод инициируемый при изменении firstNameTextBox
		/// </summary>
		private void firstNameTextBox_TextChanged(object sender, EventArgs e)
		{
			nameTextBoxes("Имя");
		}

		/// <summary>
		/// Метод определяющий какой RadioButton был выбран пользователем
		/// </summary>
		/// <returns>Тип заработной платы</returns>
		private WageType wageTypeFromRadioButton()
		{
			var radioButtonsChecked = new Tuple<bool,WageType>[] 
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
			throw new Exception("не выбран тип зарплаты");
		}

		/// <summary>
		/// Метод производящий валидацию вводимых данных для имени и фамилии
		/// </summary>
		/// <param name="name">"Фамилия" или "Имя"</param>
		private void nameTextBoxes(string name)
		{
			switch(name)
			{
				case "Фамилия":
				{
					try
					{
						WorkerTmp.SecondName = secondNameTextBox.Text;
						secondNameTextBox.BackColor = Color.White;
					}
					catch (Exception)
					{
						secondNameTextBox.BackColor = Color.DeepPink;
					}
					break;
				}
				case "Имя":
				{
					try
					{
						WorkerTmp.FirstName = firstNameTextBox.Text;
						firstNameTextBox.BackColor = Color.White;
					}
					catch (Exception)
					{
						firstNameTextBox.BackColor = Color.DeepPink;
					}
					break;
				}
			}
		}
	}
}
