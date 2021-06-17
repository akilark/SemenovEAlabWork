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
        /// <summary>
		/// Поле класса содержащее путь к файлу
		/// </summary>
		private string _filePath = @"C:\\";

		/// <summary>
		/// Поле класса содержащее объект класса WorkWithFiles
		/// </summary>
		private WorkWithFiles _filesWork;

		/// <summary>
		/// Поле класса содержащее лист-источник для DataGridView 
		/// с работниками
		/// </summary>
		private BindingList<Worker> _bindingWorkerList;

		/// <summary>
		/// Поле класса содержащее лист с работниками
		/// соответствует листу _bindingWorkerList при загрузке
		/// </summary>
		private BindingList<Worker> _bindingWorkerListBefore = 
			new BindingList<Worker>();

		/// <summary>
		/// Поле класса хранящее текст для текстбокса поиска
		/// </summary>
		private const string  _searchTextBoxText = "Введите фамилию или имя:";



		/// <summary>
		/// Конструктор класса без параметров
		/// </summary>
		public StartForm()
		{
			InitializeComponent();
			DataGridInitialization();
			#if !DEBUG
			createRandomDataButton.Visible = false;
			#endif
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
			if (DataMatching()) return;				

			if (MessageBox.Show(this, "Сохранить список ?", "Предупреждение", 
				MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				SaveButton_Click(sender, e);
			}
		}

		/// <summary>
		/// Метод обозначающий работу кнопки "Выход"
		/// </summary>
		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Сохранить"
		/// </summary>
		private void SaveButton_Click(object sender, EventArgs e)
		{
			var createFileDialog = new SaveFileDialog
			{
				InitialDirectory = _filePath,
				Filter = "txt files (*.kek)|*.kek",
				RestoreDirectory = true,
			};

			if (createFileDialog.ShowDialog() != DialogResult.OK) return;

			_filePath = Path.GetFullPath(createFileDialog.FileName);
			_filesWork = new WorkWithFiles(_filePath);
			_filesWork.RewriteFile(new List<Worker>(GetDataSource()));
			MessageBox.Show("Файл сохранен");
			fileNameLabel.Text = Path.GetFileName(_filePath);
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Поиск"
		/// </summary>
		private void SearchButton_Click(object sender, EventArgs e)
		{
			var collectionForSearch = new BindingList<Worker>();
			if (searchTextBox.Text == _searchTextBoxText)
			{
			}
			else
			{
				foreach (Worker worker in _bindingWorkerList)
				{
					if(SearchByName(worker.SecondName) || SearchByName(worker.FirstName))
					{
						collectionForSearch.Add(worker);
					}
				}
				SetDataSource(collectionForSearch);
				VisibleAfterSearch(true);
			}
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Добавить"
		/// </summary>
		private void AddButton_Click(object sender, EventArgs e)
		{
			var addWorkerForm = new AddWorkerForm();
			this.Hide();
			addWorkerForm.ShowDialog();
			if (addWorkerForm.AddFlag)
			{
				_bindingWorkerList.Add(addWorkerForm.WorkerTmp);
			}
			this.Show();
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Сбросить"
		/// </summary>
		private void ResetButton_Click(object sender, EventArgs e)
		{
			SetDataSource(_bindingWorkerList);
			searchTextBox.Text = _searchTextBoxText;
			VisibleAfterSearch(false);
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Удалить"
		/// </summary>
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (workerListDataGrid.CurrentRow == null)
				{
					throw new Exception("ОБъекты в списке закончились");
				}
				if (workerListDataGrid.SelectedRows.Count > 0)
				{
					foreach(DataGridViewRow row in workerListDataGrid.SelectedRows)
					{
						_bindingWorkerList.Remove(row.DataBoundItem as Worker);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Ошибка");
			}
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Загрузить"
		/// </summary>
		private void DownloadButton_Click(object sender, EventArgs e)
		{

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = _filePath;
				openFileDialog.Filter = "txt files (*.kek)|*.kek";
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() != DialogResult.OK) return;

				_filePath = openFileDialog.FileName;
				_filesWork = new WorkWithFiles(_filePath);
				FillingGridParamFromFile();
				fileNameLabel.Text = Path.GetFileName(_filePath);
			}
		}

		/// <summary>
		/// Метод производящий действия после нажатия кнопки "Заполнить"
		/// </summary>
		private void CreateRandomDataButton_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 10; i++)
			{
				_bindingWorkerList.Add(RandomWorker.WorkerFullInformation(8));
			}
		}

		/// <summary>
		/// Метод инициируемый при нажатии на searchTextBox
		/// </summary>
		private void SearchTextBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (searchTextBox.Text == _searchTextBoxText)
			{
				searchTextBox.Clear();
			}
		}

		/// <summary>
		/// Метод инициируемый при смене фокуса с searchTextBox
		/// </summary>
		private void SearchTextBox_Leave(object sender, EventArgs e)
		{
			if (searchTextBox.Text == "")
			{
				searchTextBox.Text = _searchTextBoxText;
			}
		}

		/// <summary>
		/// Метод реализующий поиск по имени в DataGridView
		/// </summary>
		/// <param name="name">Имя или фамилия для поиска</param>
		/// <returns>true- если совпадения найдены,
		/// false- если совпадений нет</returns>
		private bool SearchByName(string name)
		{
			int searchLenght = searchTextBox.Text.Length;
			if (name.Length >= searchLenght)
			{
				if (name.ToLower().Contains(searchTextBox.Text.ToLower()))
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
			_bindingWorkerList = new BindingList<Worker>();
			var source = new BindingSource(_bindingWorkerList, null);
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
			_bindingWorkerList = new BindingList<Worker>(_filesWork.ReadFileInfo());
			SetDataSource(_bindingWorkerList);
			DataTransfer();
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

		/// <summary>
		/// Метод для переноса данных из bindingWorkerList
		/// в bindingWorkerListBefore
		/// </summary>
		private void DataTransfer()
		{
			_bindingWorkerListBefore.Clear();
			foreach(Worker worker in _bindingWorkerList)
			{
				_bindingWorkerListBefore.Add(worker);
			}
		}

		/// <summary>
		/// метод сравнения данных из bindingWorkerList
		/// и bindingWorkerListBefore
		/// </summary>
		/// <returns>true если данные одинаковые, false- если разные</returns>
		private bool DataMatching()
		{
			
			foreach (Worker worker in _bindingWorkerList)
			{
				if (_bindingWorkerListBefore.Contains(worker)) continue;
				return false;
			}
			return true;
		}

	}
}
