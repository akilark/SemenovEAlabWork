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

		//TODO: поле в свойство(v)
		/// <summary>
		/// Свойство хранящее работника
		/// </summary>
		public Worker WorkerTmp { get; private set; }


		/// <summary>
		/// Конструктор класса без параметров
		/// </summary>
		public AddWorkerForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Метод который выполняется при загрузке данной формы
		/// </summary>
		private void AddWorkerForm_Load(object sender, EventArgs e)
		{
			VisibleChange(false);
			WorkerTmp = new Worker(_allowWorkHours);
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Выход"
		/// </summary>
		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Добавить"
		/// </summary>
		private void AddButton_Click(object sender, EventArgs e)
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
					WorkerTmp.WageType(WageTypeFromRadioButton());
					WorkerTmp.dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
					if (horlyPaymentRadioButton.Checked == true)
					{
						WorkerTmp.MoneyEarnedInMonth(Int32.Parse(workMoneyTextBox.Text),
							Int32.Parse(workHoursTextBox.Text));
					}
					else
					{
						WorkerTmp.MoneyEarnedInMonth(Int32.Parse(workMoneyTextBox.Text),
							Int32.Parse(workHoursTextBox.Text) * _allowWorkHours);
					}
					this.Hide();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Ошибка");
			}
		}

		/// <summary>
		/// Метод инициируемый при изменении firstNameTextBox
		/// </summary>
		private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
		{
			NameTextBoxes("Имя",  firstNameTextBox);
		}

		/// <summary>
		/// Метод инициируемый при изменении secondNameTextBox
		/// </summary>
		private void SecondNameTextBox_TextChanged(object sender, EventArgs e)
		{
			NameTextBoxes("Фамилия",secondNameTextBox);
		}

		/// <summary>
		/// Метод инициируемый при смене фокуса с secondNameTextBox
		/// </summary>
		private void SecondNameTextBox_Validating(object sender, CancelEventArgs e)
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
		/// Метод инициируемый при выборе salaryRadioButton
		/// </summary>
		private void RadioButtons_CheckedChanged(object sender, EventArgs e)
		{
			WageTypeInfoChange();
		}

		/// <summary>
		/// Метод позволяющий изменять видимость некоторых объектов,
		/// связанных с вводом информации для расчета ЗП
		/// </summary>
		/// <param name="visible">false - скрывает объекты
		/// true - показывает объекты</param>
		private void VisibleChange(bool visible)
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
		private void WageTypeInfoChange()
		{
			var labelsText = new Dictionary<WageType,string[]>
			{
				{
                    WageType.HorlyPayment, 
					new[]
                    {
                        "Ставка за час:", 
                        "Часов отработано:"
                    }
                },
				{
                    WageType.Salary, 
					new[]
                    {
                        "Ставка за месяц:", 
                        "Дней отработано:"
                    }
                },
				{
                    WageType.WageRate, 
					new[]
                    {
                        "Ставка за день:", 
                        "Дней отработано:"
                     }
                }
            };
			var wageType = WageTypeFromRadioButton();
			workMoneyLabel.Text = labelsText[wageType][0];
			workHoursLabel.Text = labelsText[wageType][1];
			workHoursTextBox.Text = "";
			workMoneyTextBox.Text = "";
			VisibleChange(true);
		}

		/// <summary>
		/// Метод определяющий какой RadioButton был выбран пользователем
		/// </summary>
		/// <returns>Тип заработной платы</returns>
		private WageType WageTypeFromRadioButton()
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
			foreach(var radioButtonWageType in radioButtonsChecked)
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
		/// <param name="nameTextBox">Текстбокс</param>
		private void NameTextBoxes(string name, TextBox nameTextBox)
		{
			try
			{
				switch(name)
				{
					case "Фамилия":
					{
						WorkerTmp.SecondName = nameTextBox.Text;
						break;
					}
					case "Имя":
					{
						WorkerTmp.FirstName = nameTextBox.Text;
						break;
					}
				} 
				nameTextBox.BackColor = Color.White;
			}
			catch (Exception)
			{
				nameTextBox.BackColor = Color.DeepPink;
			}
		}
	}
}
