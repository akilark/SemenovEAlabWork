using System;
using System.Collections.Generic;
using System.ComponentModel;
using Laba3.Logic;
using System.IO;
using System.Windows.Forms;

namespace Laba4GUI
{
	/// <summary>
	/// Класс определяющий поведение стартовой формы
	/// </summary>
	public partial class StartForm : Form
	{
		 //TODO: RSDN
        /// <summary>
		/// Поле класса содержащее путь к файлу
		/// </summary>
		private string filepath = @"C:\";

		 //TODO: RSDN
		/// <summary>
		/// Поле класса содержащее объект класса WorkWithFiles
		/// </summary>
		private WorkWithFiles filesWork;

		//TODO: RSDN naming
		/// <summary>
		/// Поле класса содержащее лист-источник для DataGridView с работниками
		/// </summary>
		private BindingList<Worker> BindingWorkerList;

		/// <summary>
		/// Поле класса хранящее текст для текстбокса поиска
		/// </summary>
		private string searchTextBoxText = "Введите фамилию или имя:";

		#if !DEBUG
		CreateRandomData.Visible = false
		#endif

		/// <summary>
		/// Конструктор класса без параметров
		/// </summary>
		public StartForm()
		{
			InitializeComponent();
			workWithDataButtonsVisible(false);
		}

		/// <summary>
		/// Метод который выполняется при загрузке данной формы
		/// </summary>
		private void StartForm_Load(object sender, EventArgs e)
		{
			resetButton.Visible = false;
		}

		/// <summary>
		/// Метод обозначающий работу кнопки "Выход"
		/// </summary>
		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Поиск"
		/// </summary>
		private void searchButton_Click(object sender, EventArgs e)
		{
			var collectionForSearch = new BindingList<Worker>();
			if (searchTextBox.Text == searchTextBoxText)
			{
			}
			else
			{
				foreach (Worker worker in BindingWorkerList)
				{
					int searchLenght = searchTextBox.Text.Length;
					//TODO: Duplication
					if (worker.SecondName.Length >= searchLenght)
					{
						 //TODO: RSDN
						if (worker.SecondName.ToLower().Substring(0, searchLenght) == searchTextBox.Text.ToLower())
						{
							collectionForSearch.Add(worker);
							continue;
						}
					}
					//TODO: Duplication
					if (worker.FirstName.Length >= searchLenght)
					{
						 //TODO: RSDN
						if (worker.FirstName.ToLower().Substring(0, searchLenght) == searchTextBox.Text.ToLower())
						{
							collectionForSearch.Add(worker);
							continue;
						}
					}
				}
				var source = new BindingSource(collectionForSearch, null);
				workerListDataGrid.DataSource = source;
				resetButton.Visible = true;
			}
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Добавить"
		/// </summary>
		private void addButton_Click(object sender, EventArgs e)
		{
			var addWorkerForm = new AddWorkerForm();
			this.Hide();
			addWorkerForm.ShowDialog();
			if (addWorkerForm.AddFlag)
			{
				BindingWorkerList.Add(addWorkerForm.WorkerTmp);
			}
			this.Show();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Сбросить"
		/// </summary>
		private void resetButton_Click(object sender, EventArgs e)
		{
			resetButton.Visible = false;
			fillingGridParam();
			searchTextBox.Text = searchTextBoxText;
		}

		/// <summary>
		/// Метод производящий заполнение dataGridView
		/// </summary>
		private void fillingGridParam()
		{
			BindingWorkerList = new BindingList<Worker>(filesWork.ReadFileInfo());
			var source = new BindingSource(BindingWorkerList, null);
			workerListDataGrid.DataSource = source;
			workerListDataGrid.Columns[0].HeaderText = "Фамилия";
			workerListDataGrid.Columns[1].HeaderText = "Имя";
			workerListDataGrid.Columns[2].HeaderText = "Зарплата за месяц";
			workerListDataGrid.Columns[3].HeaderText = "Месяц оплаты";
			workerListDataGrid.Columns[5].HeaderText = "тип ЗП";
			workerListDataGrid.Columns[5].Width = 110;
			workerListDataGrid.Columns[4].Visible = false;
			fileNameLabelChange();
			workWithDataButtonsVisible(true);
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Удалить"
		/// </summary>
		private void deleteButton_Click(object sender, EventArgs e)
		{
			//BUG:
			int indexDataGrid = workerListDataGrid.CurrentRow.Index;
			BindingWorkerList.Remove(workerListDataGrid.CurrentRow.DataBoundItem as Worker);
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Загрузить"
		/// </summary>
		private void DownloadButton_Click(object sender, EventArgs e)
		{

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = "txt files (*.kek)|*.kek";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                filepath = openFileDialog.FileName;
                filesWork = new WorkWithFiles(filepath);
                fillingGridParam();
                saveButton.Visible = true;
            }
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Заполнить"
		/// </summary>
		private void CreateRandomData_Click(object sender, EventArgs e)
		{
			if (filesWork == null)
			{
				createButton_Click(sender, e);
			}
			for (int i = 0; i<10; i++)
			{
				BindingWorkerList.Add(RandomWorker.WorkerFullInformation(8));
			}
		}

		/// <summary>
		/// Метод срабатывающий при закрытии формы
		/// </summary>
		private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BindingWorkerList == null) return;

            //TODO: RSDN
            if(MessageBox.Show(this, "Сохранить список ?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                filesWork.rewriteFile(new List<Worker>(BindingWorkerList));
            }
        }

		/// <summary>
		/// Метод инициируемый при нажатии на searchTextBox
		/// </summary>
		private void searchTextBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (searchTextBox.Text == searchTextBoxText)
			{
				searchTextBox.Clear();
			}
		}

		/// <summary>
		/// Метод инициируемый при смене фокуса с searchTextBox
		/// </summary>
		private void searchTextBox_Leave(object sender, EventArgs e)
		{
			if (searchTextBox.Text == "")
			{
				searchTextBox.Text = searchTextBoxText;
			}
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "создать"
		/// </summary>
		private void createButton_Click(object sender, EventArgs e)
		{
            var createFileDialog = new SaveFileDialog
            {
                Filter = "txt files (*.kek)|*.kek",
                FilterIndex = 2,
                RestoreDirectory = true,
                Title = "Создание нового файла"
            };

            if (createFileDialog.ShowDialog() != DialogResult.OK) return;

            filepath = Path.GetFullPath(createFileDialog.FileName);
            filesWork = new WorkWithFiles(filepath);
            filesWork.rewriteFile(new List<Worker>());
            fillingGridParam();
        }

		/// <summary>
		/// Метод изменяющий fileNameLabel на название файла
		/// </summary>
		private void fileNameLabelChange()
		{
			fileNameLabel.Visible = true;
			fileNameLabel.Text = Path.GetFileName(filepath);
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Сохранить"
		/// </summary>
		private void saveButton_Click(object sender, EventArgs e)
        {
            if (filesWork == null) return;

            filesWork.rewriteFile(new List<Worker>(BindingWorkerList));
            MessageBox.Show("Файл сохранен");
        }

		/// <summary>
		/// Метод позволяющий изменять видимость некоторых объектов, 
		/// для работы которых нужен выбранный файл
		/// </summary>
		/// <param name="visible">false - скрывает объекты
		/// true - показывает объекты</param>
		private void workWithDataButtonsVisible(bool visible)
		{
			fileNameLabel.Visible = visible;
			saveButton.Visible = visible;
			addButton.Visible = visible;
			deleteButton.Visible = visible;
			CreateRandomData.Visible = visible;
			searchButton.Visible = visible;
			searchTextBox.Visible = visible;
		}
	}
}
