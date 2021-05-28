using System;
using System.Collections.Generic;
using System.ComponentModel;
using Laba3.Logic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4GUI
{
	public partial class StartForm : Form
	{
		private SearchForm searchForm = null;
		private AddWorkerForm addWorkerForm = null;
		private string filepath = @"C:\";
		private WorkWithFiles filesWork;

		#if !DEBUG
		CreateRandomData.Visible = false
		#endif

		public StartForm()
		{
			InitializeComponent();
			
			
		}

		private void StartForm_Load(object sender, EventArgs e)
		{
			searchForm = new SearchForm();
			resetButton.Visible = false;
			


		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void searchButton_Click(object sender, EventArgs e)
		{
			var collectionForSearch = new BindingList<Worker>();
			if (searchTextBox.Text == "Введите фамилию:")
			{
			}
			else
			{
				foreach (Worker worker in ListForDataGrid.BindingWorkerList)
				{
					if(worker.SecondName.ToLower() == searchTextBox.Text.ToLower())
					{
						collectionForSearch.Add(worker);
					}
				}
				var source = new BindingSource(collectionForSearch, null);
				workerListDataGrid.DataSource = source;
				resetButton.Visible = true;
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			addWorkerForm = new AddWorkerForm();
			this.Hide();
			addWorkerForm.ShowDialog();
			this.Show();

		}

		private void changeButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			
			this.Show();
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			resetButton.Visible = false;
			fillingGridParam();
			searchTextBox.Text = "Введите фамилию:";
		}

		private void workerListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		internal void fillingGridParam()
		{
			ListForDataGrid.BindingWorkerList = new BindingList<Worker>(filesWork.ReadFileInfo());
			var source = new BindingSource(ListForDataGrid.BindingWorkerList, null);
			workerListDataGrid.DataSource = source;
			workerListDataGrid.Columns[0].HeaderText = "Фамилия";
			workerListDataGrid.Columns[1].HeaderText = "Имя";
			workerListDataGrid.Columns[2].HeaderText = "Зарплата за месяц";
			workerListDataGrid.Columns[3].HeaderText = "Месяц оплаты";
			workerListDataGrid.Columns[5].HeaderText = "тип ЗП";
			workerListDataGrid.Columns[4].Visible = false;

		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			int indexDataGrid = workerListDataGrid.CurrentRow.Index;
			ListForDataGrid.BindingWorkerList.Remove(workerListDataGrid.CurrentRow.DataBoundItem as Worker);
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void DownloadButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog DirDialog = new FolderBrowserDialog();
			DirDialog.Description = "Выбор директории";
			DirDialog.SelectedPath = filepath;

			if (DirDialog.ShowDialog() == DialogResult.OK)
			{
				filepath = DirDialog.SelectedPath + @"\WorkersData.kek";
				filesWork = new WorkWithFiles(filepath);
				fillingGridParam();
				
			}
		}

		private void CreateRandomData_Click(object sender, EventArgs e)
		{
			var workerTmp = new List<Worker>();
			for(int i = 0; i<10; i++)
			{
				workerTmp.Add(RandomWorker.WorkerFullInformation(8));
			}
			filesWork.rewriteFile(workerTmp);
			fillingGridParam();
		}

		private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				filesWork.rewriteFile(new List<Worker>(ListForDataGrid.BindingWorkerList));
			}
			catch
			{

			}
		}

		private void searchTextBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (searchTextBox.Text == "Введите фамилию:")
			{
				searchTextBox.Clear();
			}
		}

		private void searchTextBox_Leave(object sender, EventArgs e)
		{
			if (searchTextBox.Text == "")
			{
				searchTextBox.Text = "Введите фамилию:";
			}
		}
	}
}
