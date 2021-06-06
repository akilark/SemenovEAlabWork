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
		 //TODO: RSDN(V)
        /// <summary>
		/// Поле класса содержащее путь к файлу
		/// </summary>
		private string filePath = @"C:\";

		 //TODO: RSDN(v)
		/// <summary>
		/// Поле класса содержащее объект класса WorkWithFiles
		/// </summary>
		private WorkWithFiles filesWork;

		//TODO: RSDN naming(v)
		/// <summary>
		/// Поле класса содержащее лист-источник для DataGridView 
		/// с работниками
		/// </summary>
		private BindingList<Worker> bindingWorkerList;

		private int bindingWorkerListCount = 0;

		/// <summary>
		/// Поле класса хранящее текст для текстбокса поиска
		/// </summary>
		private string searchTextBoxText = "Введите фамилию или имя:";

#if !DEBUG
		createRandomDataButton.Visible = false
#endif

		/// <summary>
		/// Конструктор класса без параметров
		/// </summary>
		public StartForm()
		{
			InitializeComponent();
			DataGridInitialization();
		}

		/// <summary>
		/// Метод который выполняется при загрузке данной формы
		/// </summary>
		private void StartForm_Load(object sender, EventArgs e)
		{
			resetButton.Visible = false;
		}

		/// <summary>
		/// Метод срабатывающий при закрытии формы
		/// </summary>
		private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (bindingWorkerList.Count == bindingWorkerListCount) return;				
			//TODO: RSDN (V)
			if (MessageBox.Show(this, "Сохранить список ?", "Предупреждение", 
				MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (filePath == @"C:\")
				{
					saveButton_Click(sender, e);
				}
			}
		}

		/// <summary>
		/// Метод обозначающий работу кнопки "Выход"
		/// </summary>
		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Сохранить"
		/// </summary>
		private void saveButton_Click(object sender, EventArgs e)
		{
			var createFileDialog = new SaveFileDialog
			{
				Filter = "txt files (*.kek)|*.kek",
				RestoreDirectory = true,
			};

			if (createFileDialog.ShowDialog() != DialogResult.OK) return;

			filePath = Path.GetFullPath(createFileDialog.FileName);
			filesWork = new WorkWithFiles(filePath);
			filesWork.RewriteFile(new List<Worker>(GetDataSource()));
			MessageBox.Show("Файл сохранен");
			fileNameLabel.Text = Path.GetFileName(filePath);
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
				foreach (Worker worker in bindingWorkerList)
				{
					if(SearchByName(worker.SecondName) || SearchByName(worker.FirstName))
					{
						collectionForSearch.Add(worker);
					}
					//TODO: Duplication(V)
				}
				SetDataSource(collectionForSearch);
				VisibleAfterSearch(true);
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
				bindingWorkerList.Add(addWorkerForm.WorkerTmp);
			}
			this.Show();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Сбросить"
		/// </summary>
		private void resetButton_Click(object sender, EventArgs e)
		{
			SetDataSource(bindingWorkerList);
			searchTextBox.Text = searchTextBoxText;
			VisibleAfterSearch(false);
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Удалить"
		/// </summary>
		private void deleteButton_Click(object sender, EventArgs e)
		{
			//BUG: (V)
			try
			{
				if (workerListDataGrid.CurrentRow == null)
				{
					throw new Exception("ОБъекты в списке закончились");
				}
				int indexDataGrid = workerListDataGrid.CurrentRow.Index;
				bindingWorkerList.Remove(
					workerListDataGrid.CurrentRow.DataBoundItem as Worker);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Ошибка");
			}

		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Загрузить"
		/// </summary>
		private void downloadButton_Click(object sender, EventArgs e)
		{

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = "txt files (*.kek)|*.kek";
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() != DialogResult.OK) return;

				filePath = openFileDialog.FileName;
				filesWork = new WorkWithFiles(filePath);
				FillingGridParamFromFile();
				fileNameLabel.Text = Path.GetFileName(filePath);
			}
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Заполнить"
		/// </summary>
		private void createRandomDataButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 10; i++)
			{
				bindingWorkerList.Add(RandomWorker.WorkerFullInformation(8));
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
		/// Метод реализующий поиск по имени в DataGridView
		/// </summary>
		/// <param name="Name">Имя или фамилия для поиска</param>
		/// <returns>true- если совпадения найдены,
		/// false- если совпадений нет</returns>
		private bool SearchByName(string Name)
		{
			int searchLenght = searchTextBox.Text.Length;
			if (Name.Length >= searchLenght)
			{
				if (Name.ToLower().Substring(0, searchLenght) ==
					searchTextBox.Text.ToLower())
				{
					return true;
				}
			}
			return false;
		}


		/// <summary>
		/// Создание оформления DataGridView
		/// </summary>
		private void DataGridInitialization()
		{
			bindingWorkerList = new BindingList<Worker>();
			var source = new BindingSource(bindingWorkerList, null);
			workerListDataGrid.DataSource = source;
			workerListDataGrid.Columns[0].HeaderText = "Фамилия";
			workerListDataGrid.Columns[1].HeaderText = "Имя";
			workerListDataGrid.Columns[2].HeaderText = "Зарплата за месяц";
			workerListDataGrid.Columns[3].HeaderText = "Месяц оплаты";
			workerListDataGrid.Columns[5].HeaderText = "тип ЗП";
			workerListDataGrid.Columns[5].Width = 110;
			workerListDataGrid.Columns[4].Visible = false;
		}

		/// <summary>
		/// Метод производящий заполнение dataGridView
		/// </summary>
		private void FillingGridParamFromFile()
		{
			bindingWorkerList = new BindingList<Worker>(filesWork.ReadFileInfo());
			SetDataSource(bindingWorkerList);
			bindingWorkerListCount = bindingWorkerList.Count;
		}

		/// <summary>
		/// Метод позволяющий задать источник данных для DataGridView
		/// </summary>
		/// <param name="workers">Лист с работниками, который должен стать 
		/// источником данных для DataGridView</param>
		private void SetDataSource(BindingList<Worker> workers)
		{
			var source = new BindingSource(workers, null);
			workerListDataGrid.DataSource = source;
		}

		/// <summary>
		/// Метод возврщающий лист работников из DataGridView
		/// </summary>
		/// <returns>Лист работников </returns>
		private BindingList<Worker> GetDataSource()
		{
			BindingSource source = (BindingSource)workerListDataGrid.DataSource;
			return (BindingList<Worker>)source.DataSource;
		}


		/// <summary>
		/// Метод позволяющий изменять видимость некоторых объектов,
		/// связанных с поиском 
		/// </summary>
		/// <param name="visible">false - скрывает объекты
		/// true - показывает объекты</param>
		private void VisibleAfterSearch(bool visible)
		{
			resetButton.Visible = visible;
			addButton.Visible = !visible;
			deleteButton.Visible = !visible;

		}
	}
}
